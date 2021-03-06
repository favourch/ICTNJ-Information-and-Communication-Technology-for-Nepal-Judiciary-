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

using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Collections.Generic;
using PCS.REPORT;

public partial class MODULES_PMS_ReportForms_EmployeeEvaluationReport : System.Web.UI.Page
{
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;

        if (user.MenuList.ContainsKey("3,44,1") == true)
        {
            if (this.IsPostBack == false)
            {
                LoadOrganizationWithChilds(int.Parse(Session["OrgID"].ToString()));
                LoadDesignations();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.grdEmployee.SelectedIndex = -1;
        //this.lblPersonName.Text = "";
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
                    this.pnlSearch.Height = Unit.Pixel(0);
                }
                else if (this.grdEmployee.Rows.Count > 0)
                {
                    this.pnlSearch.Height = Unit.Pixel(306);
                }

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
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
        this.lblEmpID.Text = this.grdEmployee.SelectedRow.Cells[0].Text;
        this.lblComma.Text = ", ";
        this.lblEmpName.Text = "कर्मचारीको पुरा नाम::: " + this.grdEmployee.SelectedRow.Cells[5].Text;
        this.grdEmployee.SelectedRow.Focus();

        this.LoadEmployeeEvaluationList();
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
    void LoadEmployeeEvaluationList()
    {
        try
        {
            List<ATTEmployeeEvaluation> lst = BLLEmployeeEvaluation.GetEmployeeEvaluationList(double.Parse(this.lblEmpID.Text), "");
            if (lst.Count > 0)
            {
                this.pnlEvaluationList.GroupingText = "हाल सम्मको मुल्यांकनहरु";
                this.dlstEvaluation.DataSource = lst;
                this.dlstEvaluation.DataBind();
            }
            else
            {
                this.pnlEvaluationList.GroupingText = "यस कर्मचारीको हाल सम्म कुनै पनि मुल्यांकन गरिएको छैन! क्रिपया नया मुल्यांकन गर्नुहोस!";
                this.dlstEvaluation.DataSource = "";
                this.dlstEvaluation.DataBind();
            }

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void lnkSelectEvaluation_Click(object sender, EventArgs e)
    {
        double empID = double.Parse(((LinkButton)sender).CommandArgument);
        char[] Token ={ ':' };
        string fromDate = ((LinkButton)sender).CommandName.Split(Token)[0];
        string ToDate = ((LinkButton)sender).CommandName.Split(Token)[1];
        
        CrystalReport report = new CrystalReport();

        report.ReportName = Server.MapPath("~") + "/MODULES/PMS/REPORTS/EmployeeEvaluation.rpt";
        report.SelectionCriteria = "{EMPLOYEE_EVALUATION.EMP_ID}=" + empID.ToString() + " and {EMPLOYEE_EVALUATION.EVAL_FROM_DATE}='" + fromDate + "'";

        report.UserID = "PMS_ADMIN";
        report.Password = "PMS_ADMIN";


        Session["PMSReport"] = report;
        Session["PmsReportTitle"] = null;
        Session["PmsReportTitle"] = "PMS | Employee Medical Expenses Report";

        
        report.ParamList.Add(new ReportParameter("OrgList", BLLEmployeeEvaluation.GetEmployeeTransferedOrg(empID, fromDate, ToDate)));

        SubReport EmpEvalDetail1 = new SubReport();
        EmpEvalDetail1.SubReportName = "EmpEvalDetail1.rpt";
        EmpEvalDetail1.ParamList.Add(new ReportParameter("P_EMP_ID", empID));
        EmpEvalDetail1.ParamList.Add(new ReportParameter("P_EVAL_FROM_DATE", fromDate));
        EmpEvalDetail1.ParamList.Add(new ReportParameter("p_CONTAIN_SAMITI", "N"));

        SubReport EmpEvalDetail2 = new SubReport();
        EmpEvalDetail2.SubReportName = "EmpEvalDetail2.rpt";
        EmpEvalDetail2.ParamList.Add(new ReportParameter("P_EMP_ID", empID));
        EmpEvalDetail2.ParamList.Add(new ReportParameter("P_EVAL_FROM_DATE", fromDate));
        EmpEvalDetail2.ParamList.Add(new ReportParameter("p_CONTAIN_SAMITI", "Y"));

        SubReport EvaluatorSamiti = new SubReport();
        EvaluatorSamiti.SubReportName = "EvaluatorSamiti.rpt";
        EvaluatorSamiti.ParamList.Add(new ReportParameter("P_EMP_ID", empID));
        EvaluatorSamiti.ParamList.Add(new ReportParameter("P_EVAL_FROM_DATE", fromDate));

        SubReport EvaluatorInspector = new SubReport();
        EvaluatorInspector.SubReportName = "EvaluatorInspector.rpt";
        EvaluatorInspector.ParamList.Add(new ReportParameter("P_EMP_ID", empID));
        EvaluatorInspector.ParamList.Add(new ReportParameter("P_EVAL_FROM_DATE", fromDate));

        SubReport EvaluatorPunarawolokan = new SubReport();
        EvaluatorPunarawolokan.SubReportName = "EvaluatorPunarawolokan.rpt";
        EvaluatorPunarawolokan.ParamList.Add(new ReportParameter("P_EMP_ID", empID));
        EvaluatorPunarawolokan.ParamList.Add(new ReportParameter("P_EVAL_FROM_DATE", fromDate));

        report.SubReportList.Add(EmpEvalDetail1);
        report.SubReportList.Add(EmpEvalDetail2);
        report.SubReportList.Add(EvaluatorSamiti);
        report.SubReportList.Add(EvaluatorInspector);
        report.SubReportList.Add(EvaluatorPunarawolokan);

        Session["PMSReport"] = report;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }
}
