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
using PCS.PMS.DLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.COMMON.DLL;
using PCS.SECURITY.ATT;


public partial class MODULES_PMS_Forms_EmployeeDeputation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         //this.SrchGrid.Height = Unit.Pixel(0);
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
            Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("3,3,1") == true)
        {
            Session["Orgid"] = user.OrgID;
            Session["UserName"] = user.UserName;
            ddlDeputaionOrgEdit.Enabled = false;
            //pnlEmployee.Height = 0;
            int org_id = int.Parse(Session["Orgid"].ToString());
            if (!IsPostBack)
            {
                LoadOrganization(org_id);
                LoadUnit();
                LoadDesignations();
                LoadEmpDeputation();               
            }

        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }
    private void LoadEmpDeputation()
    {
        List<ATTEmployeeDeputaion> LSTEmpDeputation = BLLEmployeeDeputation.GetEmpForDeputation(GetEmployeeFilterDep(),"wld");
        Session["EmpDepNoLeave"]=LSTEmpDeputation;
        this.grdEmpDepRamana.DataSource = LSTEmpDeputation;
        this.grdEmpDepRamana.DataBind();
    }
    void LoadOrganization(int orgID)
    {
        List<ATTOrganization> LSTOrgSubType = GetOrganizationWithChild(orgID);
        Session["Organization"] = LSTOrgSubType;
        LSTOrgSubType.Insert(0, new ATTOrganization(0, "छान्नुहोस्"));
        ddlOrganization.DataSource = LSTOrgSubType;
        ddlOrganization.DataTextField = "OrgName";
        ddlOrganization.DataValueField = "OrgID";
        ddlOrganization.DataBind();
    }
    void LoadOrganizationDeputation(int orgID)
    {
        List<ATTOrganization> LSTOrgSubType = GetOrganizationWithChild(orgID);
        Session["Organization"] = LSTOrgSubType;
        LSTOrgSubType.RemoveAll(delegate(ATTOrganization obj)
                                    {
                                        return obj.OrgID == int.Parse(ddlOrganization.SelectedValue);
                                    }
                               );
        LSTOrgSubType.Insert(0, new ATTOrganization(0, "छान्नुहोस्"));
        ddlDeputationOrganization.DataSource = LSTOrgSubType;
        ddlDeputationOrganization.DataTextField = "OrgName";
        ddlDeputationOrganization.DataValueField = "OrgID";
        ddlDeputationOrganization.DataBind();
    }
    private void LoadOrganizationDeputationEdit(int p)
    {
        List<ATTOrganization> LSTOrgSubType = GetOrganizationWithChild(p);
        Session["OrganizationEdit"] = LSTOrgSubType;
        LSTOrgSubType.RemoveAll(delegate(ATTOrganization obj)
                                    {
                                        return obj.OrgID == int.Parse(Server.HtmlDecode(grdEmpDepRamana.Rows[grdEmpDepRamana.SelectedIndex].Cells[3].Text).ToString());
                                    }
                               );
        LSTOrgSubType.Insert(0, new ATTOrganization(0, "छान्नुहोस्"));
        ddlDeputaionOrgEdit.DataSource = LSTOrgSubType;
        ddlDeputaionOrgEdit.DataTextField = "OrgName";
        ddlDeputaionOrgEdit.DataValueField = "OrgID";
        ddlDeputaionOrgEdit.DataBind();
    }
    private static List<ATTOrganization> GetOrganizationWithChild(int orgID)
    {
        List<ATTOrganization> LSTOrgSubType = BLLOrganization.GetOrgWithChilds(orgID);
        return LSTOrgSubType;
    }
    void LoadUnit()
    {
        int orgid = int.Parse(Session["Orgid"].ToString());
        List<ATTOrganizationUnit> LSTOrgUnit = BLLOrganizationUnit.GetOrganizationUnits(orgid, null);
        ddlUnit.DataSource = LSTOrgUnit;
        Session["OrgUnit"] = LSTOrgUnit;
        LSTOrgUnit.Insert(0, new ATTOrganizationUnit(0, 0, "छान्नुहोस्"));
        ddlUnit.DataTextField = "UnitName";
        ddlUnit.DataValueField = "UnitID";
        ddlUnit.DataBind();
    }
    void LoadDesignations()
    {
        string desType = "O";
        try
        {
            List<ATTDesignation> LstDesignation = BLLDesignation.GetDesignation(null, desType);
            LstDesignation.Insert(0, new ATTDesignation(0, "छान्नुहोस", "",0,0));
            this.ddlPost.DataSource = LstDesignation;
            this.ddlPost.DataTextField = "DesignationName";
            this.ddlPost.DataValueField = "DesignationID";
            this.ddlPost.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    //protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlUnit.SelectedIndex < 1)
    //    {
    //        ddlSection.DataSource = null;
    //        ddlSection.DataBind();
    //    }
    //    else
    //    {
    //        int org_id = int.Parse(this.ddlOrganization.SelectedValue.ToString());
    //        int unit_id = int.Parse(this.ddlUnit.SelectedValue.ToString());
    //        List<ATTOrganizationSection> LSTOrgSec = BLLOrganizationSection.GetOrgSection(org_id, unit_id);
    //        LSTOrgSec.Insert(0, new ATTOrganizationSection(0, 0, 0, "छान्नुहोस्", "", ""));
    //        ddlSection.DataSource = LSTOrgSec;
    //        ddlSection.DataValueField = "SectionID";
    //        ddlSection.DataTextField = "SectionName";
    //        ddlSection.DataBind();
    //    }
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeDeputaion> LSTEmp = new List<ATTEmployeeDeputaion>();
        if (this.ddlOrganization.SelectedIndex < 1)
        {
            this.lblStatusMessage.Text = "Select An Organization";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                LSTEmp = BLLEmployeeDeputation.GetEmpForDeputation(GetEmployeeFilter(),"wod");
                if (LSTEmp.Count == 0)
                {
                    lblSearch.Text = "No records found";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        grdEmployee.DataSource = LSTEmp;
        this.grdEmployee.DataBind();
        this.grdEmployee.SelectedIndex = -1;
        Session["EmpDeputation"] = LSTEmp;
    }
    private ATTEmployeeDeputaion GetEmployeeFilterDep()
    {
        ATTEmployeeDeputaion EmployeeSearch = new ATTEmployeeDeputaion();
        EmployeeSearch.OrgID = int.Parse(Session["Orgid"].ToString());
        EmployeeSearch.Active = "Y";
        //if (this.ddlPost.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlPost.SelectedValue);
        //if (this.ddlUnit.SelectedIndex > 0) EmployeeSearch.UnitID = int.Parse(this.ddlBranch.SelectedValue);
        //if (this.ddlSection.SelectedIndex > 0) EmployeeSearch.SectionID = int.Parse(this.ddlFant.SelectedValue);
        //EmployeeSearch.DesType = "O";
        //EmployeeSearch.ToDate = null;
        return EmployeeSearch;
    }
    private ATTEmployeeDeputaion GetEmployeeFilter()
    {
        ATTEmployeeDeputaion EmployeeSearch = new ATTEmployeeDeputaion();
        if (this.ddlOrganization.SelectedIndex > 0) EmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        EmployeeSearch.Active = "Y";
        //if (this.ddlPost.SelectedIndex > 0) EmployeeSearch.DesID = int.Parse(this.ddlPost.SelectedValue);
        //if (this.ddlUnit.SelectedIndex > 0) EmployeeSearch.UnitID = int.Parse(this.ddlBranch.SelectedValue);
        //if (this.ddlSection.SelectedIndex > 0) EmployeeSearch.SectionID = int.Parse(this.ddlFant.SelectedValue);
        //EmployeeSearch.DesType = "O";
        //EmployeeSearch.ToDate = null;
        return EmployeeSearch;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtDecisionDate.Text == "")
        {
            this.lblStatusMessage.Text = "र्कपया काज निर्णय मिति बर्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        double empId = double.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[0].Text).ToString());
        foreach (GridViewRow row in this.grdEmpDepRamana.Rows)
        {
            if (int.Parse(row.Cells[0].Text) == empId)
            {
                this.lblStatusMessage.Text = "**कर्मचारी काजको लागि सिफारिस भैसकेको छ";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        int orgId = int.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[3].Text).ToString());
        int desId = int.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[5].Text).ToString());
        string createdDate = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[7].Text).ToString();
        int postId = int.Parse(Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[8].Text).ToString());
        string fromDate = Server.HtmlDecode(grdEmployee.Rows[grdEmployee.SelectedIndex].Cells[9].Text).ToString();
        string decisionDate = this.txtDecisionDate.Text;
        int dep_org_id = int.Parse(this.ddlDeputationOrganization.SelectedValue);
        int dicision_ver_by = 0;
        string responsibility = this.txtResponsibility.Text;
        string active = "Y";
        string entry_by = Session["UserName"].ToString();
        List<ATTEmployeeDeputaion> LSTAddDep;
        if (Session["EmpDepNoLeave"] != null)
        {
            LSTAddDep = (List<ATTEmployeeDeputaion>)Session["EmpDepNoLeave"];
        }
        else
        {
            LSTAddDep = new List<ATTEmployeeDeputaion>();
        }
        if (this.ddlDeputationOrganization.SelectedIndex < -1)
        {
            this.lblStatusMessage.Text = "काज कार्यालय छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }
        else if (this.ddlDeputationOrganization.SelectedIndex > 0)
        {
            ATTEmployeeDeputaion objAddDep = new ATTEmployeeDeputaion();
            objAddDep.EmpID = empId;
            objAddDep.OrgID = orgId;
            objAddDep.DesID = desId;
            objAddDep.CreatedDate = createdDate;
            objAddDep.PostID = postId;
            objAddDep.FromDate = fromDate;
            objAddDep.DecisionDate = decisionDate;
            objAddDep.DepOrgID = dep_org_id;
            objAddDep.DecisionVerifiedBy = dicision_ver_by;
            objAddDep.Responsibilities = responsibility;
            objAddDep.Active = active;
            objAddDep.EntryBy = entry_by;
            objAddDep.Action = "A";
            objAddDep.LeaveDate = "";
            objAddDep.LeaveVerifiedBy = 0;
            LSTAddDep.Add(objAddDep);

            //Session["DeputaionWOLeave"] = LSTAddDep;
            if (BLLEmployeeDeputation.SaveEmpForDeputation(LSTAddDep))
            {
                this.lblStatusMessage.Text = "Employee Deputation Saved Successfully";
                this.programmaticModalPopup.Show();

                Session["EmpDepNoLeave"] = BLLEmployeeDeputation.GetEmpForDeputation(GetEmployeeFilterDep(), "wld");
                grdEmpDepRamana.DataSource = Session["EmpDepNoLeave"];
                grdEmpDepRamana.DataBind();
                //grdEmployee.DataSource = BLLEmployeeDeputation.GetEmpForDeputation(GetEmployeeFilter(), "wod");
                //this.grdEmployee.DataBind();
                this.ddlDeputationOrganization.SelectedIndex = -1;
                this.txtDecisionDate.Text = "";
                this.txtResponsibility.Text = "";
                this.txtVerifiedBy.Text = "";
                return;
            }
        }
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        int orgid = int.Parse(Session["Orgid"].ToString());
        LoadOrganizationDeputation(orgid);
    }
    protected void grdEmpDepRamana_SelectedIndexChanged(object sender, EventArgs e)
    {
        int orgid = int.Parse(Session["Orgid"].ToString());
        ddlDeputaionOrgEdit.Enabled = true;
        LoadOrganizationDeputationEdit(orgid);
        txtDecisionDateEdit.Text = Server.HtmlDecode(grdEmpDepRamana.Rows[grdEmpDepRamana.SelectedIndex].Cells[10].Text).ToString();
        txtResponsibilityEdit.Text=Server.HtmlDecode(grdEmpDepRamana.Rows[grdEmpDepRamana.SelectedIndex].Cells[11].Text).ToString();
    }
    protected void btnAddEdited_Click(object sender, EventArgs e)
    {
        if (this.txtDecisionDateEdit.Text == "")
        {
            this.lblStatusMessage.Text = "र्कपया रमाना निर्णय मिति बर्नुहोस्";
            this.programmaticModalPopup.Show();
            return;
        }
        if (grdEmpDepRamana.SelectedIndex > -1)
        {
            List<ATTEmployeeDeputaion> LSTEmpDepNoLeave = (List<ATTEmployeeDeputaion>)Session["EmpDepNoLeave"];
            LSTEmpDepNoLeave[grdEmpDepRamana.SelectedIndex].OrgID = int.Parse(this.ddlDeputaionOrgEdit.SelectedValue);
            LSTEmpDepNoLeave[grdEmpDepRamana.SelectedIndex].OrgName = this.ddlDeputaionOrgEdit.SelectedItem.ToString();
            LSTEmpDepNoLeave[grdEmpDepRamana.SelectedIndex].DecisionDate = this.txtDecisionDateEdit.Text;
            LSTEmpDepNoLeave[grdEmpDepRamana.SelectedIndex].Responsibilities = this.txtResponsibilityEdit.Text;
            LSTEmpDepNoLeave[grdEmpDepRamana.SelectedIndex].Action = "E";

            //objEmpDepNoLeave.OrgID = int.Parse(this.ddlDeputaionOrgEdit.SelectedValue);
            //objEmpDepNoLeave.OrgName = this.ddlDeputaionOrgEdit.SelectedItem.ToString();
            //objEmpDepNoLeave.DecisionDate = this.txtDecisionDateEdit.Text;
            //objEmpDepNoLeave.Responsibilities = this.txtResponsibilityEdit.Text;
            //objEmpDepNoLeave.Action = "E";
            //LSTEmpDepNoLeave.Add(objEmpDepNoLeave);
            this.grdEmpDepRamana.DataSource = LSTEmpDepNoLeave;
            this.grdEmpDepRamana.DataBind();
            Session["EmpDepLeave"] = LSTEmpDepNoLeave;
        }
    }
    protected void btnRawanaSave_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeDeputaion> LSTEmpDepLeave = (List<ATTEmployeeDeputaion>)Session["EmpDepNoLeave"];
        if (LSTEmpDepLeave.Count == 0)
        {
            this.lblStatusMessage.Text = "**Sorry! There Is No Data To Save";
            this.programmaticModalPopup.Show();
            return;
        }
        //List<ATTEmployeeDeputaion> LSTEmpDepOther = new List<ATTEmployeeDeputaion>();
        try
        {
            for (int j = 0; j <= this.grdEmpDepRamana.Rows.Count-1; j++)
            {
                LSTEmpDepLeave[j].LeaveDate = ((TextBox)grdEmpDepRamana.Rows[j].FindControl("TextBox1")).Text;
                bool check = ((CheckBox)grdEmpDepRamana.Rows[j].Cells[14].FindControl("chkBox")).Checked;
                if (check)
                {
                    LSTEmpDepLeave[j].Active = "Y";
                    LSTEmpDepLeave[j].Action = "E";
                }
                else
                {
                    LSTEmpDepLeave[j].Active = "N";
                    LSTEmpDepLeave[j].Action = "E";
                }
                
            }

            if (BLLEmployeeDeputation.SaveEmpForDeputation(LSTEmpDepLeave))
            {
                this.lblStatusMessage.Text = "**Employee Deputation Leave Successfully Save";
                this.programmaticModalPopup.Show();
                this.ddlDeputaionOrgEdit.SelectedIndex = -1;
                this.txtDecisionDateEdit.Text = "";
                this.txtResponsibilityEdit.Text = "";
                this.txtDecision.Text = "";


                Session["EmpDepNoLeave"] = BLLEmployeeDeputation.GetEmpForDeputation(GetEmployeeFilterDep(), "wld");
                grdEmpDepRamana.DataSource = Session["EmpDepNoLeave"];
                grdEmpDepRamana.DataBind();
                grdEmployee.DataSource = BLLEmployeeDeputation.GetEmpForDeputation(GetEmployeeFilter(), "wod");
                //grdEmpDepRamana.DataSource = Session["EmpDepNoLeave"];
                //grdEmpDepRamana.DataBind();
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdEmpDepRamana_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        List<ATTEmployeeDeputaion> lst = (List<ATTEmployeeDeputaion>)Session["EmpDepNoLeave"];
        int index = e.RowIndex;

        if (((LinkButton)grdEmpDepRamana.Rows[index].FindControl("btnDeleteRamana")).Text == "Delete")
        {
            ((LinkButton)(grdEmpDepRamana.Rows[index].FindControl("btnSelect"))).Enabled = true;
            if (grdEmpDepRamana.Rows[index].Cells[16].Text == "" || grdEmpDepRamana.Rows[index].Cells[16].Text == "&nbsp;")
            {
                lst[index].Action = "D";
                //lst[index].Active = "N";
            }
            else if (grdEmpDepRamana.Rows[index].Cells[16].Text == "E")
            {
                lst.RemoveAt(index);
                //lst[index].Active = "N";
            }
        }
        else if (((LinkButton)grdEmpDepRamana.Rows[index].FindControl("btnDeleteRamana")).Text == "Undo")
        {
            lst[e.RowIndex].Action = "";
            ((LinkButton)(grdEmpDepRamana.Rows[index].FindControl("btnSelect"))).Enabled = false;
        }

        grdEmpDepRamana.DataSource = lst;
        grdEmpDepRamana.DataBind(); 
    }
    protected void grdEmpDepRamana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[16].Text == "D")
            {
                ((LinkButton)e.Row.FindControl("btnDeleteRamana")).Text = "Undo";
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (e.Row.Cells[16].Text == "")
            {
                ((LinkButton)e.Row.FindControl("btnDeleteRamana")).Text = "Delete";
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    protected void grdEmpDepRamana_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
        e.Row.Cells[12].Visible = false;
        e.Row.Cells[16].Visible = false;
    }
    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[7].Visible = false;
        e.Row.Cells[8].Visible = false;
        e.Row.Cells[9].Visible = false;
    }
    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        this.ddlOrganization.SelectedIndex = -1;
        this.ddlPost.SelectedIndex = -1;
        this.ddlUnit.SelectedIndex = -1;
        this.ddlSection.SelectedIndex = -1;
        this.grdEmployee.DataSource = null;
        this.grdEmployee.DataBind();
    }
    protected void btnSaveCancel_Click(object sender, EventArgs e)
    {
        this.ddlDeputaionOrgEdit.SelectedIndex = -1;
        this.txtDecisionDateEdit.Text = "";
        this.txtResponsibilityEdit.Text = "";
        //this.grdEmpDepRamana.DataSource = null;
        //this.grdEmpDepRamana.DataBind();
        this.ddlOrganization.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ddlDeputationOrganization.SelectedIndex = -1;
        this.txtDecisionDate.Text = "";
        this.txtResponsibility.Text = "";
    }
}
