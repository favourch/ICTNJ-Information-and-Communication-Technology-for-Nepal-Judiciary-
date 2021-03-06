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
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using PCS.REPORT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;


public partial class MODULES_PMS_ReportForms_EmployeeMedicalExpenses : System.Web.UI.Page
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
        Session["OrgID"] = user.OrgID;

        if (this.grdEmployee.Rows.Count == 0)
        {
            this.Panel1.Height = Unit.Pixel(0);
        }
        if (user.MenuList.ContainsKey("3,42,1") == true)
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
                if (this.grdEmployee.Rows.Count == 0)
                {
                    this.Panel1.Height = Unit.Pixel(0);
                }
                else if (this.grdEmployee.Rows.Count > 0)
                {
                    this.Panel1.Height = Unit.Pixel(306);
                }

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }
    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
    }
    protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        int EmpID = int.Parse(this.grdEmployee.SelectedRow.Cells[0].Text.ToString());
        Session["EmpID"] = EmpID;
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
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (grdEmployee.SelectedIndex > -1)
        {
            try
            {
                CrystalReport report = new CrystalReport();
                report.SelectionCriteria = SelectionCriteria();

                report.UserID = "PMS_ADMIN";
                report.Password = "PMS_ADMIN";

                report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/EmployeeMedicalExpenses.rpt";

                report.FormulaList.Add(new ReportFormulaFields("OrgName", ((ATTUserLogin)Session["Login_User_Detail"]).OrgName));
                report.FormulaList.Add(new ReportFormulaFields("OrgAddress", ((ATTUserLogin)Session["Login_User_Detail"]).OrgAddress));

                Session["PMSReport"] = report;
                Session["PmsReportTitle"] = null;
                Session["PmsReportTitle"] = "PMS | Employee Medical Expenses Report";

                string script = "";
                script += "<script language='javascript' type='text/javascript'>";
                script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
                script += "</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = "Error Loading Report";
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
                return;
            }
        }
        else
        {
            this.lblStatusMessage.Text = "कर्मचारी छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    void ClearControls()
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
        this.grdEmployee.SelectedIndex = -1;
    }

    string SelectionCriteria()
    {
        string SelectCmd = "";
        if (Session["EmpID"] != null)
        {
            SelectCmd = "{VW_EMPLOYEE_MED_EXPENSES.EMP_ID}=" + Session["EmpID"].ToString();
        }
        //else
        //{
        //    SelectCmd = "isnull{SP_GET_EMP_MEDICAL_EXP.EMP_ID}=";
        //}
        return SelectCmd;
    }
}
