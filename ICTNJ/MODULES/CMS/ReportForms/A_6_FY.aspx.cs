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
using PCS.CMS.ATT;
using PCS.CMS.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.REPORT;

public partial class MODULES_CMS_ReportForms_A_6_FY : System.Web.UI.Page
{
    int orgID = 9;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrgWithChilds();
        }
    }

    void LoadOrgWithChilds()
    {
        try
        {
            List<ATTOrganization> lstOrg = BLLOrganization.GetOrgWithChilds(orgID);
            DDLOrgWithChilds.DataSource = lstOrg;
            DDLOrgWithChilds.DataTextField = "OrgName";
            DDLOrgWithChilds.DataValueField = "OrgID";
            DDLOrgWithChilds.DataBind();

            LoadCaseType();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadCaseType()
    {
        try
        {
            List<ATTOrganizationCaseType> lstOrgCaseType = BLLOrganizationCaseType.GetOrgCaseType(int.Parse(DDLOrgWithChilds.SelectedValue), null, "Y", 1, 0, 0, 0);
            DDLCaseType.DataSource = lstOrgCaseType;
            DDLCaseType.DataTextField = "CaseTypeName";
            DDLCaseType.DataValueField = "CaseTypeID";
            DDLCaseType.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadOrgRegType()
    {
        try
        {
            List<ATTOrgCaseRegistrationType> LstOrgRegType = BLLOrgCaseRegistrationType.GetOrgCaseRegType(orgID, int.Parse(DDLCaseType.SelectedValue), null, "Y", 0);

            chkRegType.DataSource = LstOrgRegType;
            chkRegType.DataTextField = "RegTypeName";
            chkRegType.DataValueField = "RegTypeID";
            chkRegType.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["CMS_REPORT"] = null;
        CrystalReport objReport = new CrystalReport();

        objReport.SelectionCriteria = SetCriteria();
        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/A_6_FY.rpt";
        
        string txtFY = this.txtFY_RQD.Text.Trim();
        string strFYFrom = txtFY.Substring(0, 2);
       
        objReport.ParamList.Add(new ReportParameter("P_FY", strFYFrom));
        objReport.FormulaList.Add(new ReportFormulaFields("FY", txtFY));

        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | Registration Type Wise Case Report";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

    }

    string SetCriteria()
    {
        string strFormula = "";
            strFormula += "{RPT_SP_GET_A_6_FY.COURT_ID}=" + int.Parse(DDLOrgWithChilds.SelectedValue) + " AND ";

        foreach (ListItem lst in chkRegType.Items)
        {
            if (lst.Selected == true)
            {
                strFormula += "{RPT_SP_GET_A_6_FY.REG_TYPE_ID}=" + int.Parse(lst.Value) + "  OR ";
            }
        }

        if (strFormula != "")
        {
            strFormula = strFormula.Substring(0, strFormula.Length - 5);
        }
        return strFormula;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void DDLOrgWithChilds_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCaseType();
    }

    protected void DDLCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadOrgRegType();
    }
}
