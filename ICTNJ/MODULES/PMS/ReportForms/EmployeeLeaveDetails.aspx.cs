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
using PCS.REPORT;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;

public partial class MODULES_PMS_ReportForms_EmployeeLeaveDetails : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null) Response.Redirect("~/MODULES/Login.aspx", true);

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("3,41,1") == true)
        {
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }
    protected void btnEmpSearch_Click(object sender, EventArgs e)
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

    protected void btnEmpSearchCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    void ClearControls()
    {
        txtSymbolNo.Text = "";
        txtFName.Text = "";
        txtMName.Text = "";
        txtSurName.Text = "";
        ddlGender.SelectedIndex = -1;
        txtDOB.Text = "";
        grdEmployee.DataSource = null;
        grdEmployee.DataBind();
        this.lblSearch.Text = "";
    }
    void Print(int empid,int desid)
    {
        try
        {
            CrystalReport report = new CrystalReport();
            report.SelectionCriteria = SelectionCriteria();
            report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/EmployeeLeaveDetails.rpt";
            report.FormulaList.Add(new ReportFormulaFields("OrgName", ((ATTUserLogin)Session["Login_User_Detail"]).OrgName));
            report.FormulaList.Add(new ReportFormulaFields("OrgAddress", ((ATTUserLogin)Session["Login_User_Detail"]).OrgAddress));
            report.ParamList.Add(new ReportParameter("P_EMP_ID", null));
            //objReport.ParamList.Add(new ReportParameter("Report Name", "Employee Posting Information"));
            //report.FormulaList.Add(new ReportFormulaFields("Date", DateTime.Now.ToShortDateString()));
            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            Session["PMSReport"] = report;
            Session["PmsReportTitle"] = null;
            Session["PmsReportTitle"] = "PMS | Employee Leave Details Report";

            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
            //Response.Redirect("~/MODULES/PMS/ReportForms/CommonReportViewer.aspx");
        }
        catch(Exception)
        {
            this.lblStatusMessage.Text = "Report Cannot be loaded";
            this.programmaticModalPopup.Show();
        }
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        int  EmpID = int.Parse(grdEmployee.SelectedRow.Cells[0].Text.ToString());
        Session["EmpID"] = EmpID;

    }

    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if (this.grdEmployee.SelectedIndex > -1)
        {
            ATTEmployeePosting empPosting = BLLEmployeePosting.GetEmployeeCurrentPosting(int.Parse(Session["EmpID"].ToString()));
            int DesID = (int)empPosting.DesID;
            Session["DesID"] = DesID;
            Print(int.Parse(Session["EmpID"].ToString()), DesID);
        }
        else
        {
            this.lblStatusMessage.Text = "कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }
    }
    string SelectionCriteria()
    {
        string SelectionCriteria = "{vw_emp_posting.EMP_ID}=" + Session["EmpID"].ToString() + " AND  {vw_emp_posting.DES_ID}=" + Session["DesID"].ToString();

        if (ddlCriteria.SelectedIndex == 1)
        {
            SelectionCriteria += " AND isnull({SP_GET_EMP_LEAVE_APPL_DET.REC_YES_NO}) AND isnull({SP_GET_EMP_LEAVE_APPL_DET.REC_YES_NO})";
        }
        else if (ddlCriteria.SelectedIndex == 2)
        {
            SelectionCriteria += " AND {SP_GET_EMP_LEAVE_APPL_DET.REC_YES_NO}='N'";
        }
        else if (ddlCriteria.SelectedIndex == 3)
        {
            SelectionCriteria += " AND {SP_GET_EMP_LEAVE_APPL_DET.REC_YES_NO}='Y' AND isnull({SP_GET_EMP_LEAVE_APPL_DET.APP_YES_NO}) AND isnull({SP_GET_EMP_LEAVE_APPL_DET.APP_YES_NO})";

        }
        else if (ddlCriteria.SelectedIndex == 4)
        {
            SelectionCriteria += " AND {SP_GET_EMP_LEAVE_APPL_DET.REC_YES_NO}='Y' AND {SP_GET_EMP_LEAVE_APPL_DET.APP_YES_NO}='N'";
        }
        else if (ddlCriteria.SelectedIndex == 5)
        {
            SelectionCriteria += " AND {SP_GET_EMP_LEAVE_APPL_DET.REC_YES_NO}='Y'AND {SP_GET_EMP_LEAVE_APPL_DET.APP_YES_NO}='Y'";

        }
        return SelectionCriteria;

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.grdEmployee.DataSource = null;
        this.grdEmployee.DataBind();
        this.ddlCriteria.SelectedIndex = 0;
        this.lblSearch.Text = "";
        ClearControls();
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
    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible=false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }
}
