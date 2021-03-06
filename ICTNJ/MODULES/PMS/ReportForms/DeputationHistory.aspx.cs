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
using System.Collections.Generic;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.REPORT;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_ReportForms_DeputationHistory : System.Web.UI.Page
{
    //protected string OrgName = "Supreme Court", OrgAddress = "Kathmandu";
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
                if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("3,46,1") == true)
        {
            if (!IsPostBack)
            {
                LoadOrganizationWithChilds(((ATTUserLogin)Session["Login_User_Detail"]).OrgID);

                LoadDeputationOrganisation();
                Session["EmpID"] = null;
                Session.Remove("EmpID");
                Session["EmpFullName"] = null;
                Session.Remove("EmpFullName");
                Session["PropDetailsEmpID"] = null;
                Session.Remove("PropDetailsEmpID");
                grdDiv.Visible = false;
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
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
    void LoadDeputationOrganisation()
    {
        try
        {
            List<ATTOrganization> depOrgList = BLLOrganization.GetOrganization();
            depOrgList.Insert(0, new ATTOrganization(0, "छान्नुहोस"));
         
            this.ddlDeputedOrgs.DataSource = depOrgList;
            this.ddlDeputedOrgs.DataTextField = "ORGNAME";
            this.ddlDeputedOrgs.DataValueField = "ORGID";
            this.ddlDeputedOrgs.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

   
    protected string GetSearchType()
    {
        string status = "";
       
        return "All";
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<ATTEmployeeDeputaion> lst;
        this.lblSearch.Text = "";
        if (this.txtSymbolNo.Text.Trim() == "" && this.txtFName.Text.Trim() == "" && this.txtMName.Text.Trim() == "" && this.txtSurName.Text.Trim() == ""
            && this.ddlGender.SelectedIndex == 0 && this.txtDOB.Text.Trim() == "" && this.ddlOrganization.SelectedIndex == 0)
        {
            this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
            this.programmaticModalPopup.Show();
        }
        else
        {
            try
            {
                //lst = BLLEmployeeSearch.SearchEmployee(GetFilter());
                Session["EmpSearchResult"] = BLLEmployeeDeputation.SearchEmployeeDeputation(GetFilter(), GetSearchType());
                lst = (List<ATTEmployeeDeputaion>)Session["EmpSearchResult"];
                this.lblSearch.Text = lst.Count.ToString() + " records found.";
                this.grdEmployee.DataSource = lst;
                this.grdEmployee.DataBind();
                grdDiv.Visible = true;

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
            }
        }
    }
    private ATTEmployeeDeputaion GetFilter()
    {
        
        ATTEmployeeDeputaion DeputedEmployeeSearch=new ATTEmployeeDeputaion();
        if (this.txtSymbolNo.Text.Trim() != "")DeputedEmployeeSearch.SymbolNo = this.txtSymbolNo.Text.Trim();
        if (this.txtFName.Text.Trim() != "") DeputedEmployeeSearch.FirstName= this.txtFName.Text.Trim();
        if (this.txtMName.Text.Trim() != "") DeputedEmployeeSearch.MiddleName = this.txtMName.Text.Trim();
        if (this.txtSurName.Text.Trim() != "") DeputedEmployeeSearch.LastName = this.txtSurName.Text.Trim();
        if (this.ddlGender.SelectedIndex > 0) DeputedEmployeeSearch.Gender= this.ddlGender.SelectedValue;
        if (this.txtDOB.Text.Trim() != "") DeputedEmployeeSearch.DOB= this.txtDOB.Text.Trim();
        if (this.ddlOrganization.SelectedIndex > 0) DeputedEmployeeSearch.OrgID = int.Parse(this.ddlOrganization.SelectedValue);
        if (this.ddlDeputedOrgs.SelectedIndex > 0) DeputedEmployeeSearch.DepOrgID = int.Parse(this.ddlDeputedOrgs.SelectedValue);


        return DeputedEmployeeSearch;
    }
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //Find the checkbox control in header and add an attribute
            ((CheckBox)e.Row.FindControl("selectAllCb")).Attributes.Add("onclick", "javascript:SelectAll('" +
                    ((CheckBox)e.Row.FindControl("selectAllCb")).ClientID + "')");

        }
        e.Row.Cells[1].Visible = false; 
      
    }
    protected void viewDeputationRpt_Btn_Click(object sender, EventArgs e)
    {
        
      
        CrystalReport report = new CrystalReport();

        report.ReportName = Server.MapPath("~") + "/MODULES/PMS/REPORTS/EmployeeDeputationHistory.rpt";
        report.SelectionCriteria = GetSelectionFormula();

        if (count == 0)
        {
            this.lblStatusMessage.Text = "No data selected";
            this.programmaticModalPopup.Show();
            return;
        }

        report.UserID = "PMS_ADMIN";
        report.Password = "PMS_ADMIN";


        Session["PMSReport"] = report;
        Session["PmsReportTitle"] = null;
        Session["PmsReportTitle"] = "PMS | Employee Deputation History Report";

        
        report.ParamList.Add(new ReportParameter("OrgName",((ATTUserLogin)Session["Login_User_Detail"]).OrgName));
        report.ParamList.Add(new ReportParameter("OrgAddress", ((ATTUserLogin)Session["Login_User_Detail"]).OrgAddress));
        //report.ParamList.Add(new ReportParameter("Date", Session["NepDate"].ToString()));

      

        Session["PMSReport"] = report;

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    
    }
    protected string GetSelectionFormula()
    {
        string selection = "";
        
        foreach (GridViewRow row in grdEmployee.Rows)
        {
            if (((CheckBox)row.FindControl("selectCb")).Checked && count==0)
            {
                selection = "{VW_EMP_DEPUTATION.EMP_ID}=" + Convert.ToInt32(row.Cells[1].Text);
                count++;
            }
            if (((CheckBox)row.FindControl("selectCb")).Checked && count > 0)
            {
                selection += " OR {VW_EMP_DEPUTATION.EMP_ID}=" + Convert.ToInt32(row.Cells[1].Text);
            }
        }
        return selection;

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
        
        this.ddlOrganization.SelectedIndex = 0;
       
        this.grdEmployee.DataSource = null;
        this.grdEmployee.DataBind();
        this.grdDiv.Visible = false;
        lblSearch.Text = "";
    }

    protected void grdEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible=false;
        e.Row.Cells[2].Visible=false;
        e.Row.Cells[3].Visible = false;
    }
}
