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

public partial class MODULES_CMS_ReportForms_FYWiseCaseRegistration : System.Web.UI.Page
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
            DDLOrg.DataSource = lstOrg;
            DDLOrg.DataTextField = "OrgName";
            DDLOrg.DataValueField = "OrgID";
            DDLOrg.DataBind();

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
            List<ATTOrganizationCaseType> lstOrgCaseType = BLLOrganizationCaseType.GetOrgCaseType(int.Parse(DDLOrg.SelectedValue), null, "Y", 1, 0, 0, 0);
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

    void LoadRegistrationDiary()
    {
        try
        {
            List<ATTRegistrationDiary> lstRegDiary = BLLRegistrationDiary.GetRegistrationDiary(int.Parse(DDLOrg.SelectedValue), int.Parse(DDLCaseType.SelectedValue), null, "Y", 0, 0, 0);
            chkregDiry.DataSource = lstRegDiary;
            chkregDiry.DataTextField = "RegistrationDiaryName";
            chkregDiry.DataValueField = "RegistrationDiaryID";
            chkregDiry.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void DDLOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCaseType();
    }

    protected void DDLCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRegistrationDiary();
    }
    
    string SetCriteria()
    {
        string strFormula = "";

        if (rdblVeryfied.SelectedIndex == 1)
        {
            strFormula += "{VW_CASE_REG.VERIFIED_YES_NO}=" + "'Y'" + " AND ";
        }
        if (rdblVeryfied.SelectedIndex == 2)
        {
            strFormula += "{VW_CASE_REG.VERIFIED_YES_NO}=" + "'N'" + " AND ";
        }

        strFormula += "{VW_CASE_REG.COURT_ID}=" + int.Parse(DDLOrg.SelectedValue) + " AND ";

        if (DDLCaseType.SelectedIndex > 0)
        {
            strFormula += "{VW_CASE_REG.CASE_TYPE_ID}=" + int.Parse(DDLCaseType.SelectedValue) + " AND ";
        }
        string fyReq = txtFY_RQD.Text.Trim().Substring(0, 2);
        if (txtFY_RQD.Text != "__/__")
        {
            strFormula += "{VW_CASE_REG.FY}='" + fyReq + "' AND ";
        }

        foreach (ListItem lst in chkregDiry.Items)
        {
            if (lst.Selected == true)
            {
                strFormula += "{VW_CASE_REG.REG_DIARY_ID}=" + int.Parse(lst.Value) + "  OR ";
            }
        }
       
        if (strFormula != "")
        {
            strFormula = strFormula.Substring(0, strFormula.Length - 5);
        }
        return strFormula;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Session["CMS_REPORT"] = null;
        CrystalReport objReport = new CrystalReport();

        objReport.SelectionCriteria = SetCriteria();
        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/FYWiseCaseRegistration.rpt";
        
        objReport.FormulaList.Add(new ReportFormulaFields("FY", txtFY_RQD.Text.Trim()));
        objReport.FormulaList.Add(new ReportFormulaFields("Verified", rdblVeryfied.SelectedItem.Text));

        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | Fysical year wise Case Registration";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DDLOrg.SelectedIndex = 0;
        LoadCaseType();
        txtFY_RQD.Text = "__/__";
        chkregDiry.DataSource = "";
        chkregDiry.DataBind();
    }
}
