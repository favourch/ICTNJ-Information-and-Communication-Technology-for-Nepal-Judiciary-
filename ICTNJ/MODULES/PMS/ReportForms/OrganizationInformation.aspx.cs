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
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.REPORT;
using CrystalDecisions.Reporting;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Enterprise;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using PCS.SECURITY.ATT;

public partial class MODULES_PMS_ReportForms_OrganizationInformation : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,48,1") == true)
        {

            if (!Page.IsPostBack)
            {
                LoadOrganization();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    public void LoadOrganization()
    {
        try
        {
            Session["PmsRptOrgList"] = BLLOrganization.GetOrganizationNameList();
            this.chkLstOrganization.DataSource = (List<ATTOrganization>)Session["PmsRptOrgList"];//session list data source
            this.chkLstOrganization.DataTextField = "OrgName";
            this.chkLstOrganization.DataValueField = "OrgId";
            this.chkLstOrganization.DataBind();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    private string SetCriteria()//select checked values  only  
    {
        string strFormula = "";
        string strSelectedOrgName = "";

        strSelectedOrgName = GetSelectedString(this.chkLstOrganization);
        if (strSelectedOrgName != "")
        {
            strFormula += "{vw_orgnization_units.org_id} IN [" + strSelectedOrgName + "]";
        }
        else
        {
            this.lblStatusMessage.Text = "**कार्यालय छान्नुहोस्";
            this.programmaticModalPopup.Show();
        }
        return strFormula;

    }
    string GetSelectedString(CheckBoxList lst)
    {
        string strSelected = "";
        foreach (ListItem item in chkLstOrganization.Items)
        {
            if (item.Selected)
            {
                strSelected += item.Value + ","; // for comma seperated selected values like (1,2,3)
            }
        }
        if (strSelected != "")
            strSelected = strSelected.Remove(strSelected.LastIndexOf(','));

        return strSelected;
    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            CrystalReport report = new CrystalReport();
            report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/OrganizationInformation.rpt";
            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            report.SelectionCriteria = SetCriteria();

            if (report.SelectionCriteria != "")
            {
                Session["PMSReport"] = report;
                Session["PmsReportTitle"] = null;
                Session["PmsReportTitle"] = "PMS | Organization Information";

                string script = "";
                script += "<script language='javascript' type='text/javascript'>";
                script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
                script += "</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

            }
            else
            {
                this.lblStatusMessage.Text = "All Fields Cannot Be Empty.";
                this.programmaticModalPopup.Show();
            }
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        chkLstOrganization.ClearSelection();
    }
}
