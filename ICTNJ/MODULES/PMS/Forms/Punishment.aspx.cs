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

public partial class MODULES_PMS_Forms_Punishment : System.Web.UI.Page
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
        Session["OrgID"] = user.OrgID;
        Session["User"] = user.UserName;
        if (user.MenuList.ContainsKey("3,8,1") == true)
        {
            Session["UserName"] = user.UserName;
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
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
    protected void btnPunishmentAdd_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex == -1)
        {
            this.lblStatusMessage.Text = "**कर्मचारी खोज्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (this.txtPunishment.Text == "")
        {
            this.lblStatusMessage.Text = "**सजाय बारे भर्नुहोस्";
            this.programmaticModalPopup.Show();
        }
        if (this.txtpunishmentDate.Text == "")
        {
            this.lblStatusMessage.Text = "**सजायको मिति भर्नुहोस्";
            this.programmaticModalPopup.Show();
        }
        if (this.txtPunishmentRemarks.Text=="")
        {
            this.lblStatusMessage.Text = "**सजायको कैफियत भर्नुहोस्";
            this.programmaticModalPopup.Show();
        }
        string punishment_date = this.txtpunishmentDate.Text;
        double empidSelected = double.Parse(Session["SelectedEmp"].ToString());

        //List<ATTAwardPunishment> LSTAwards = BLLAwardPunishment.GetAwards(empidSelected);
        //if (LSTAwards.Count > 0)
        //{
        //    foreach (ATTAwardPunishment itm in LSTAwards)
        //    {
        //        if (itm.EmpID == empidSelected && itm.AwardDate == this.txtpunishmentDate.Text)
        //        {
        //            this.lblStatusMessage.Text = "**कर्मचारीको लागी विभुषण दर्ता सोहि मितिमा भैसकेको छ.";
        //            this.programmaticModalPopup.Show();
        //            return;
        //        }
        //    }
        //}
        //if (this.grdpunishment.Rows.Count > 0)
        //{
        //    foreach (GridViewRow row in this.grdpunishment.Rows)
        //    {
        //        if (this.txtpunishmentDate.Text == row.Cells[3].Text && empidSelected.ToString() == row.Cells[0].Text && this.txtPunishment.Text==row.Cells[2].Text)
        //        {
        //            this.lblStatusMessage.Text = "**कर्मचारीको लागी सोहि मितिमा सजाय दर्ता भैसकेको छ.\n**सजाय मिति सच्याउनुहोस्.";
        //            this.programmaticModalPopup.Show();
        //            return;
        //        }
        //    }
        //}

        if (grdpunishment.SelectedIndex < 0)
        {
            if (this.grdEmployee.SelectedIndex == -1)
            {
                this.lblStatusMessage.Text = "कर्मचारी छान्नुहोस्";
                this.programmaticModalPopup.Show();
                return;
            }   
            int empid = int.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text).ToString());
            string empname = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString();
            string punishment = this.txtPunishment.Text;
            //string punishment_date = this.txtpunishmentDate.Text;
            string punishment_rem = this.txtPunishmentRemarks.Text;
            List<ATTAwardPunishment> LSTAP = (List<ATTAwardPunishment>)Session["PrevPunishments"];
            if (LSTAP.Count == 0)
            {
                LSTAP = new List<ATTAwardPunishment>();
            }
            ATTAwardPunishment objAP = new ATTAwardPunishment();
            objAP.EmpID = empid;
            objAP.EmpName = empname;
            objAP.Punishment = punishment;
            objAP.PunishmentDate = punishment_date;
            objAP.PunishmentRemarks = punishment_rem;
            objAP.EntryBy = Session["User"].ToString();
            objAP.Action = "A";
            LSTAP.Add(objAP);
            Session["PrevPunishments"] = LSTAP;
            this.grdpunishment.DataSource = LSTAP;
            this.grdpunishment.DataBind();
        }
        if (this.grdpunishment.SelectedIndex > -1)
        {
            bool valid = true;
            int i = 0;
            foreach (GridViewRow grow in grdpunishment.Rows)
            {
                if (i != grdpunishment.SelectedIndex)
                {
                    if (grow.Cells[3].Text.Trim() == punishment_date)
                    {
                        valid = false;
                        break;
                    }
                }
                i++;
            }
            if (valid)
            {
                int empid = int.Parse(Server.HtmlDecode(grdpunishment.Rows[grdpunishment.SelectedIndex].Cells[0].Text).ToString());
                //string empname = Server.HtmlDecode(grdAward.Rows[grdAward.SelectedIndex].Cells[5].Text).ToString();
                int seqno = int.Parse(Server.HtmlDecode(grdpunishment.Rows[grdpunishment.SelectedIndex].Cells[1].Text).ToString());
                string punishment = this.txtPunishment.Text;
                string punishment_rem = this.txtPunishmentRemarks.Text;
                List<ATTAwardPunishment> LSTAP = (List<ATTAwardPunishment>)Session["PrevPunishments"];
                LSTAP[grdpunishment.SelectedIndex].EmpID = empid;
                LSTAP[grdpunishment.SelectedIndex].SequenceNo = seqno;
                //LSTAP[grdAward.SelectedIndex].EmpName = empname;
                LSTAP[grdpunishment.SelectedIndex].Punishment = punishment;
                LSTAP[grdpunishment.SelectedIndex].PunishmentDate = punishment_date;
                LSTAP[grdpunishment.SelectedIndex].PunishmentRemarks = punishment_rem;
                LSTAP[grdpunishment.SelectedIndex].EntryBy = Session["User"].ToString();
                string action = grdpunishment.Rows[grdpunishment.SelectedIndex].Cells[6].Text;
                LSTAP[grdpunishment.SelectedIndex].Action = "E";
                Session["Punishment"] = LSTAP;
                this.grdpunishment.DataSource = LSTAP;
                this.grdpunishment.DataBind();
            }
            else
            {
                this.lblStatusMessage.Text = "**कर्मचारीको लागी त्यही मितिमा सजाय दर्ता भैसकेको छ .";
                this.programmaticModalPopup.Show();
                return;
            }     
        }
        ClearControls("Add");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<ATTAwardPunishment> LSTPunishment = (List<ATTAwardPunishment>)Session["Punishment"];
        if (this.grdpunishment.SelectedIndex > -1 || LSTPunishment == null)
        {
            LSTPunishment = (List<ATTAwardPunishment>)Session["PrevPunishments"];
        }
        try
        {
            if (BLLAwardPunishment.SavePunishment(LSTPunishment))
            {
                this.lblStatusMessage.Text = "**Punishment for Employee Saved Successfully";
                this.programmaticModalPopup.Show();
                //double empid = LSTPunishment[0].EmpID;
                //grdpunishment.DataSource = BLLAwardPunishment.GetPunishments(empid);
                //grdpunishment.DataBind();
            }
            ClearControls("punishment");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        int empid = int.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text).ToString());
        Session["SelectedEmp"] = empid;
        this.lblEmpName.Text = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString();
        List<ATTAwardPunishment> LSTPunishments = BLLAwardPunishment.GetPunishments(empid);
        Session["PrevPunishments"] = LSTPunishments;
        grdpunishment.DataSource = LSTPunishments;
        grdpunishment.DataBind();
    }
    protected void grdpunishment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTAwardPunishment> lst = (List<ATTAwardPunishment>)Session["PrevPunishments"];
        int index = e.RowIndex;
        if (((LinkButton)grdpunishment.Rows[index].FindControl("btnDeletePunishment")).Text == "Delete")
        {
            ((LinkButton)(grdpunishment.Rows[index].FindControl("btnSelect"))).Enabled = true;
            if (grdpunishment.Rows[index].Cells[5].Text == "" || grdpunishment.Rows[index].Cells[5].Text == "&nbsp;")
            {
                lst[index].Action = "D";
                //lst[index].Active = "N";
            }
            else if (grdpunishment.Rows[index].Cells[5].Text == "A")
            {
                lst.RemoveAt(index);
                //lst[index].Active = "N";
            }
        }
        else if (((LinkButton)grdpunishment.Rows[index].FindControl("btnDeletePunishment")).Text == "Undo")
        {
            ((LinkButton)(grdpunishment.Rows[index].FindControl("btnSelect"))).Enabled = false;
            lst[e.RowIndex].Action = "";
        }
        grdpunishment.DataSource = lst;
        grdpunishment.DataBind(); 
    }
    protected void grdpunishment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text == "D")
            {
                ((LinkButton)e.Row.FindControl("btnDeletePunishment")).Text = "Undo";
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[5].Text == "")
            {
                ((LinkButton)e.Row.FindControl("btnDeletePunishment")).Text = "Delete";
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    protected void grdpunishment_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtPunishment.Text = Server.HtmlDecode(grdpunishment.Rows[grdpunishment.SelectedIndex].Cells[2].Text);
        this.txtpunishmentDate.Text = Server.HtmlDecode(grdpunishment.Rows[grdpunishment.SelectedIndex].Cells[3].Text);
        this.txtPunishmentRemarks.Text = Server.HtmlDecode(grdpunishment.Rows[grdpunishment.SelectedIndex].Cells[4].Text);
    }
    protected void btnCancelPunishment_Click(object sender, EventArgs e)
    {
        ClearControls("punishment");
    }
    private void ClearControls(string opt)
    {
        if (opt == "main")
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
        if (opt == "punishment")
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
            this.lblSearch.Text = "";
            this.lblEmpName.Text = "";
            this.txtPunishment.Text = "";
            this.txtpunishmentDate.Text = "";
            this.txtPunishmentRemarks.Text = "";
            this.grdpunishment.DataSource = null;
            this.grdpunishment.DataBind();
        }
        if (opt == "Add")
        {
            this.txtPunishment.Text = "";
            this.txtpunishmentDate.Text = "";
            this.txtPunishmentRemarks.Text = "";
            this.grdEmployee.SelectedIndex = -1;
            this.grdEmployee.DataSource = null;
            this.grdEmployee.DataBind();
        }
    }
    protected void grdpunishment_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
    }
    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        e.Row.Cells[10].Visible = false;
    }
}
