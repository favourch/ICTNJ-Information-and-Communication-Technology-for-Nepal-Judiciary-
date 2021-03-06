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
using PCS.SECURITY;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.SECURITY.ATT;
using PCS.COREDL;

public partial class MODULES_PMS_ReportForms_LeaveApplicableForEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        //Session["OrgID"] = user.OrgID;
        Session["OrgID"] =user.OrgID;
        if (user.MenuList.ContainsKey("3,40,1") == true)
        {
            if (!IsPostBack)
            {
                LoadDesignations();
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
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
    protected void grdEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Print")
            {
                //GetConnection Conn = new GetConnection();
                //OracleConnection DBConn;
                //DBConn = Conn.GetDbConn(Module.PMS);
                //object obj = DBConn;
                int empID = int.Parse(e.CommandArgument.ToString());
                ATTEmployeePosting empPosting = BLLEmployeePosting.GetEmployeeCurrentPosting(empID);

                int desID = (int)empPosting.DesID;
                Print(empID, desID);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

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
    }

    void Print(int EmpID,int DesID)
    {
        CrystalReport report = new CrystalReport();
        //report.SelectionCriteria = "{vw_emp_posting.EMP_ID}=1";
        report.SelectionCriteria = "{vw_emp_posting.EMP_ID}=" + EmpID.ToString() + " AND  {vw_emp_posting.DES_ID}=" + DesID.ToString();

        report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/EmployeeWiseApplicableLeave.rpt";
        report.UserID = "PMS_ADMIN";
        report.Password = "PMS_ADMIN";

        SubReport sub1 = new SubReport();
        sub1.SubReportName = "By Designation";
        sub1.ParamList.Add(new ReportParameter("p_des_id", System.DBNull.Value));
        sub1.ParamList.Add(new ReportParameter("p_leave_type_id", System.DBNull.Value));

        SubReport sub2 = new SubReport();
        sub2.SubReportName = "By Employee";
        sub2.ParamList.Add(new ReportParameter("p_emp_id", System.DBNull.Value));
        sub2.ParamList.Add(new ReportParameter("p_leave_type_id", System.DBNull.Value));

        report.SubReportList.Add(sub1);
        report.SubReportList.Add(sub2);

        Session["PMSReport"] = report;
        Session["PmsReportTitle"] = null;

        Session["PmsReportTitle"] = "PMS |Leave For Employee Report";
        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
       
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
            this.ddlOrganization.DataTextField = "OrgName";
            this.ddlOrganization.DataValueField = "OrgID";
            this.ddlOrganization.DataBind();
            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "OrgName";
            this.ddlOrganization.DataValueField = "OrgID";
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

        e.Row.Cells[0].Visible = false;
        //e.Row.Cells[1].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
        //e.Row.Cells[4].Visible = false;
    }
}
