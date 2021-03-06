using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.SECURITY.ATT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

public partial class MODULES_PMS_Forms_AwardPunishment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = ((ATTUserLogin)Session["Login_User_Detail"]).OrgID;
        Session["User"] = user.UserName;
        if (user.MenuList.ContainsKey("3,7,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(9);
                LoadDesignations();
            }
        }

        else
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
    }
    void LoadOrganizationWithChilds(int OrgID)
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrgWithChilds(OrgID);
            OrganizationList.Insert(0, new ATTOrganization(0, "छान्नुहोस", "", "", 0));

            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    void LoadDesignations()
    {
        string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", "",0,0));
            this.ddlDesignation.DataSource = LstDesignation;
            this.ddlDesignation.DataTextField = "DesignationName";
            this.ddlDesignation.DataValueField = "DesignationID";
            this.ddlDesignation.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeSearch> lst;
        this.lblSearch.Text = "";
        if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
            && this.ddlGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "" && this.ddlMarStatus.SelectedIndex == 0
            && this.ddlOrganization.SelectedIndex == 0 && this.ddlDesignation.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                //lst = BLLEmployeeSearch.SearchEmployee(GetFilter());
                Session["EmpSearchResult"] = BLLEmployeeSearch.SearchEmployee(GetFilter());
                lst = (List<ATTEmployeeSearch>)Session["EmpSearchResult"];
                this.lblSearch.Text = lst.Count.ToString() + " records found.";
                this.grdEmployee.DataSource = lst;
                this.grdEmployee.DataBind();
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }
    private ATTEmployeeSearch GetFilter()
    {
        ATTEmployeeSearch EmployeeSearch = new ATTEmployeeSearch();
        if (this.txtSymbolNo.Text.Trim() != "") EmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
        if (this.txtFName.Text.Trim() != "") EmployeeSearch.FirstName = this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") EmployeeSearch.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") EmployeeSearch.SurName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) EmployeeSearch.Gender = this.ddlGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") EmployeeSearch.DOB = this.txtDOB.Text.Trim();
        if (this.ddlMarStatus.SelectedIndex > 0) EmployeeSearch.MaritalStatus = this.ddlMarStatus.SelectedValue;
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDesignation.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlDesignation.SelectedValue);
        EmployeeSearch.DesType = "O";
        EmployeeSearch.IniType = 3;
        return EmployeeSearch;
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls("main");
    }
    protected void btnAwardAdd_Click(object sender, EventArgs e)
    {
        string msg = "";
        int count = 0;
        if (this.grdEmployee.SelectedIndex == -1)
        {
            msg+= "**कर्मचारी छान्नुहोस्</br>";
            count++;
        }
        
        if (this.txtAwardDesc.Text == "")
        {
            msg += "**विभुषणको बारे बर्नुहोस्</br>";
            count++;
        }
        if (this.txtAwardDate.Text == "")
        {
            msg += "**मिति बर्नुहोस्</br>";
            count++;
        }
        if (this.txtAwardRemarks.Text == "")
        {
            msg += "**विभुषणको कैफिएत बर्नुहोस्</br>";
            count++;
        }
        if (count > 0)
        {
            this.lblStatusMessage.Text = msg;
            this.programmaticModalPopup.Show();
            return;
        }
        double empidSelected = double.Parse(Session["SelectedEmp"].ToString());
        List<ATTAwardPunishment> LSTAP = (List<ATTAwardPunishment>)Session["PrevAwards"];
        if (LSTAP==null)
        {
            LSTAP = new List<ATTAwardPunishment>();
        }
        string award_date = this.txtAwardDate.Text;

        if (this.grdAward.SelectedIndex < 0)
        {
            if (this.grdEmployee.SelectedIndex == -1)
            {
                this.lblStatusMessage.Text = "कर्मचारी छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }            

            bool exists = LSTAP.Exists(
                                            delegate(ATTAwardPunishment obj)
                                            {
                                                return award_date == obj.AwardDate;
                                            }
                                        );

            if (exists)
            {
                this.lblStatusMessage.Text = "**विभुषण र मिति जाँच्नुहोस् ";
                this.programmaticModalPopup.Show();
                return;
            }
            else
            {
                double empid = double.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].                                  Cells[0].Text).ToString());
                string empname = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text)                               .ToString();
                string award = this.txtAwardDesc.Text;
                string award_rem = this.txtAwardRemarks.Text;
                ATTAwardPunishment objAP = new ATTAwardPunishment();
                objAP.EmpID = empid;
                objAP.EmpName = empname;
                objAP.Award = award;
                objAP.AwardDate = award_date;
                objAP.Remarks = award_rem;
                objAP.EntryBy = Session["User"].ToString();
                objAP.Action = "A";
                LSTAP.Add(objAP);
                this.grdAward.DataSource = LSTAP;
                this.grdAward.DataBind();
            }
        }
        if (this.grdAward.SelectedIndex >-1)
        {
            bool valid = true;
            int i = 0;
            foreach (GridViewRow grow in grdAward.Rows)
            {
                if (i!=grdAward.SelectedIndex)
	            {
                    if (grow.Cells[4].Text.Trim() == award_date)
                    {
                        valid = false;
                        break;
                    }
	            }
                i++;   
            }

            if (valid)
            {
                int seqno = int.Parse(Server.HtmlDecode(grdAward.Rows[grdAward.SelectedIndex].Cells[1].Text).                                ToString());

                string award = this.txtAwardDesc.Text;
                string award_rem = this.txtAwardRemarks.Text;
                LSTAP[grdAward.SelectedIndex].SequenceNo = seqno;                
                LSTAP[grdAward.SelectedIndex].Award = award;
                LSTAP[grdAward.SelectedIndex].AwardDate = award_date;
                LSTAP[grdAward.SelectedIndex].Remarks = award_rem;
                LSTAP[grdAward.SelectedIndex].EntryBy = Session["User"].ToString();

                string action = grdAward.Rows[grdAward.SelectedIndex].Cells[6].Text;
                if (action == "A")
                {
                    LSTAP[grdAward.SelectedIndex].Action = "A";
                }
                if (action == "" || action == "&nbsp;")
                {
                    LSTAP[grdAward.SelectedIndex].Action = "E";
                }

                Session["PrevAwards"] = LSTAP;
                this.grdAward.DataSource = LSTAP;
                this.grdAward.DataBind();
            }
            else
            {
                this.lblStatusMessage.Text = "**कर्मचारीको लागी त्यही मितिमा विभुषण दर्ता भैसकेको छ .";
                this.programmaticModalPopup.Show();
                return;
            }           
        }
        ClearControls("Add");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTAwardPunishment> LSTAward = (List<ATTAwardPunishment>)Session["Award"];
        
        if (this.grdAward.SelectedIndex > -1 || LSTAward == null)
        {
            LSTAward = (List<ATTAwardPunishment>)Session["PrevAwards"];
        }
        if (Session["Award"] == null && Session["PrevAwards"]==null)
        {
            this.lblStatusMessage.Text = "**Sorry ! No Data To Save";
            this.programmaticModalPopup.Show();
            return;
        }
        try
        {
            if (BLLAwardPunishment.SaveAward(LSTAward))
            {
                this.lblStatusMessage.Text = "**Award for Employee Saved Successfully";
                this.programmaticModalPopup.Show();
                double empid = LSTAward[0].EmpID;
                grdAward.DataSource = BLLAwardPunishment.GetAwards(empid);
                grdAward.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        double empid = double.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text).ToString());
        Session["SelectedEmp"] = empid;
        List<ATTAwardPunishment> LSTAwards  = BLLAwardPunishment.GetAwards(empid);
        this.lblEmpName.Text = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString();
        Session["PrevAwards"]=LSTAwards;
        grdAward.DataSource = LSTAwards;
        grdAward.DataBind();
    }
    protected void grdAward_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTAwardPunishment> lst = (List<ATTAwardPunishment>)Session["PrevAwards"];
        if (lst[e.RowIndex].Action == "A")
        {
            lst.RemoveAt(e.RowIndex);
        }
        else
        {
            int index = e.RowIndex;

            if (((LinkButton)grdAward.Rows[index].FindControl("btnDeleteAward")).Text == "Delete")
            {
                ((LinkButton)(grdAward.Rows[index].FindControl("btnSelect"))).Enabled = true;
                lst[index].Action = "D";
                //((LinkButton)grdAward.Rows[index].FindControl("btnDeleteAward")).Text = "Undo";
            }
            else
            {
                ((LinkButton)(grdAward.Rows[index].FindControl("btnSelect"))).Enabled = true;
                lst[index].Action = "E";
                //((LinkButton)grdAward.Rows[index].FindControl("btnDeleteAward")).Text = "Delete";
            }
        }

        grdAward.DataSource = lst;
        grdAward.DataBind();
    }
    protected void grdAward_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text == "D")
            {
                ((LinkButton)e.Row.FindControl("btnDeleteAward")).Text = "Undo";
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[6].Text == "" || e.Row.Cells[6].Text == "E")
            {
                ((LinkButton)e.Row.FindControl("btnDeleteAward")).Text = "Delete";
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    protected void grdAward_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtAwardDesc.Text = Server.HtmlDecode(grdAward.Rows[grdAward.SelectedIndex].Cells[3].Text);
        this.txtAwardDate.Text = Server.HtmlDecode(grdAward.Rows[grdAward.SelectedIndex].Cells[4].Text);
        this.txtAwardRemarks.Text=Server.HtmlDecode(grdAward.Rows[grdAward.SelectedIndex].Cells[5].Text);
    }
    protected void grdAward_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[6].Visible = false;
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        ClearControls("award");
    }
    private void ClearControls(string p)
    {
        if (p == "main")
        {

            this.txtSymbolNo.Text = "";
            this.txtFName.Text = "";
            this.txtMName.Text = "";
            this.txtSurName.Text = "";
            this.txtDOB.Text = "";
            this.ddlGender.SelectedIndex = 0;
            this.ddlMarStatus.SelectedIndex = 0;
            this.ddlOrganization.SelectedIndex = 0;
            this.ddlDesignation.SelectedIndex = 0;
            this.grdEmployee.DataSource = null;
            this.grdEmployee.DataBind();
            this.lblSearch.Text = "";
        }
        else if (p == "award")
        {
            this.txtSymbolNo.Text = "";
            this.txtFName.Text = "";
            this.txtMName.Text = "";
            this.txtSurName.Text = "";
            this.txtDOB.Text = "";
            this.ddlGender.SelectedIndex = 0;
            this.ddlMarStatus.SelectedIndex = 0;
            this.ddlOrganization.SelectedIndex = 0;
            this.ddlDesignation.SelectedIndex = 0;
            this.grdEmployee.SelectedIndex = -1;
            this.grdEmployee.DataSource = null;
            this.grdEmployee.DataBind();
            this.grdAward.DataSource = null;
            this.grdAward.DataBind();
            this.lblSearch.Text = "";
            this.lblEmpName.Text = "";
            this.txtAwardDesc.Text = "";
            this.txtAwardDate.Text = "";
            this.txtAwardRemarks.Text = "";
        }
        else if (p == "Add")
        {
            this.txtAwardDesc.Text = "";
            this.txtAwardDate.Text = "";
            this.txtAwardRemarks.Text = "";
            this.grdEmployee.SelectedIndex = -1;
            this.grdEmployee.DataSource = null;
            this.grdEmployee.DataBind();
        }
    }
    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[10].Visible = false;
    }
}
