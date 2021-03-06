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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.REPORT;

public partial class MODULES_CMS_Reports_CaseProceedingWise : System.Web.UI.Page
{
    int orgID = 9;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCourt();
        }
    }

    void LoadCourt()
    {
        try
        {
            List<ATTOrganization> lstCourt = BLLOrganization.GetOrgWithChilds(orgID);

            cbOrg.DataSource = lstCourt;
            cbOrg.DataTextField = "OrgName";
            cbOrg.DataValueField = "OrgID";
            cbOrg.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    //string SetCriteria()
    //{
    //    string strFormula = "";
    //    string strSelectedOffice = "";
    //    strSelectedOffice = GetSelectedString(this.cbOrg);
    //    if (strSelectedOffice != "")
    //        strFormula += "{SP_GET_CASE_PROCEEDING_WISE.COURT_ID} IN [" + strSelectedOffice + "]";
    //    //+"{SP_GET_CASE_PROCEEDING_WISE.CASE_REG_DATE}>='" + txtFromDate_RQD.Text.Trim() + "' AND "
    //    // + "{SP_GET_CASE_PROCEEDING_WISE.CASE_REG_DATE} <='" + txtToDate_RQD.Text.Trim() + "'";

    //    return strFormula;
    //}

    //string GetSelectedString(CheckBoxList lst)
    //{
    //    string strSelected = "";
    //    foreach (ListItem li in lst.Items)
    //    {
    //        if (li.Selected)
    //        {
    //            strSelected += li.Value + ",";
    //        }
    //    }
    //    if (strSelected != "")
    //        strSelected = strSelected.Remove(strSelected.LastIndexOf(','));
    //    return strSelected;
    //}

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Session["CMS_REPORT"] = null;
        int i = 0;
        foreach (ListItem lst in cbOrg.Items)
        {
            if (lst.Selected == true)
            {
                i++;  
            }
        }
        if (i == 0)
        {
            lblStatusMessage.Text = "Please Select at least one Court first ";
            programmaticModalPopup.Show();
            return;
        }
        if (txtFromDate_RQD.Text=="____/__/__")
        {
            lblStatusMessage.Text = "Please Enter From Date First";
            programmaticModalPopup.Show();
            return;
        }
        if (txtToDate_RQD.Text == "____/__/__")
        {
            lblStatusMessage.Text = "Please Enter To Date First";
            programmaticModalPopup.Show();
            return;
        }
        CrystalReport objReport = new CrystalReport();

        //objReport.SelectionCriteria = SetCriteria();

        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/CaseProceedingWise.rpt";

        //objReport.FormulaList.Add(new ReportFormulaFields("OrgName", DDLCourtID_RQD.SelectedItem.Text.Trim()));
        objReport.FormulaList.Add(new ReportFormulaFields("FromDate", txtFromDate_RQD.Text.Trim()));
        objReport.FormulaList.Add(new ReportFormulaFields("ToDate", txtToDate_RQD.Text.Trim()));

        foreach (ListItem lst in cbOrg.Items)
        {
            if (lst.Selected == true)
            {
                objReport.ParamList.Add(new ReportParameter("P_COURT_ID", int.Parse(lst.Value)));
                objReport.ParamList.Add(new ReportParameter("P_FROM_DATE", txtFromDate_RQD.Text.Trim()));
                objReport.ParamList.Add(new ReportParameter("P_TO_DATE", txtToDate_RQD.Text.Trim()));
            }
        }
        //objReport.ParamList.Add(new ReportParameter("P_COURT_ID", null));// int.Parse(DDLCourtID_RQD.SelectedValue)));
        //objReport.ParamList.Add(new ReportParameter("P_FROM_DATE", txtFromDate_RQD.Text.Trim()));
        //objReport.ParamList.Add(new ReportParameter("P_TO_DATE", txtToDate_RQD.Text.Trim()));

        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | Case Proceeding Wise Report";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (ListItem lst in cbOrg.Items)
        {
            lst.Selected =false;
        }
        txtFromDate_RQD.Text = "";
        txtToDate_RQD.Text = "";
    }
}
