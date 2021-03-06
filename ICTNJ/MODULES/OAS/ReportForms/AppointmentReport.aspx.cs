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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.REPORT;

public partial class MODULES_OAS_ReportForms_AppointmentReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadOrganisation();
    }
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        try
        {

            CrystalReport report = new CrystalReport();
            report.SelectionCriteria = SelectionCriteria();
            //report.SelectionCriteria = "";

            report.UserID = "OAS_ADMIN";
            report.Password = "OAS_ADMIN";

            report.ReportName = Server.MapPath("~") + "\\MODULES\\OAS\\REPORTS\\Appointment.rpt";


            Session["OASReport"] = report;
            Session["OASReportTitle"] = null;
            Session["OASReportTitle"] = "OAS | Meeting Report";


            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public string SelectionCriteria()
    {
        try
        {
            int orgID = int.Parse(ddlOrg_rqd.SelectedValue.ToString());
            string strSelection = " 1=1 AND {VW_APPOINTMENT_EVENTS.ORG_ID} = " + orgID;

            if (txtDate_DT.Text != "")
                strSelection = " {VW_APPOINTMENT_EVENTS.APPOINTMENT_DATE} = '" + txtDate_DT.Text + "'";


            return strSelection;
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }

    public void LoadOrganisation()
    {
        try
        {
            Session["RptmeetingOrgList"] = BLLOrganization.GetOrganizationNameList();

            if (Session["RptmeetingOrgList"] != null)
            {
                this.ddlOrg_rqd.DataSource = (List<ATTOrganization>)Session["RptmeetingOrgList"];
                this.ddlOrg_rqd.DataTextField = "OrgName";
                this.ddlOrg_rqd.DataValueField = "OrgId";
                this.ddlOrg_rqd.DataBind();

                ListItem a = new ListItem();
                a.Selected = true;
                a.Text = "छान्नुहोस्";
                a.Value = "0";
                ddlOrg_rqd.Items.Insert(0, a);

            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ddlOrg_rqd.SelectedIndex = -1;
            txtDate_DT.Text = "";
        }
        catch (Exception ex)
        {

            throw (ex);
        }
    }
}
