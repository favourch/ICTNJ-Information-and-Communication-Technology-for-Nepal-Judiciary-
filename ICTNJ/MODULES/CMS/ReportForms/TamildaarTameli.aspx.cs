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

public partial class MODULES_CMS_ReportForms_TamildaarTameli : System.Web.UI.Page
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

    void LoadRegistrationDiary()
    {
        try
        {
            List<ATTRegistrationDiary> lstRegDiary = BLLRegistrationDiary.GetRegistrationDiary(int.Parse(DDLOrgWithChilds.SelectedValue), int.Parse(DDLCaseType.SelectedValue), null, "Y", 0, 0, 0);
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

    void LoadTamildaar()
    {
        try
        {
            List<ATTEmployeeWorkDivision> lstEWD = BLLEmployeeWorkDivision.SearchEmployee(GetFilter());
            chkTamildaar.DataSource = lstEWD;
            chkTamildaar.DataTextField = "FullName";
            chkTamildaar.DataValueField = "EmpID";
            chkTamildaar.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    ATTEmployeeWorkDivision GetFilter()
    {
        ATTEmployeeWorkDivision empWorkDiv = new ATTEmployeeWorkDivision();
        empWorkDiv.UnitType = "MY";
        return empWorkDiv;
    }

    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        programmaticModalPopup.Hide();
    }

    protected void DDLOrgWithChilds_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCaseType();
        LoadTamildaar();
    }
   
    protected void DDLCaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRegistrationDiary();
    }
   
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Session["CMS_REPORT"] = null;
        CrystalReport objReport = new CrystalReport();

        objReport.SelectionCriteria = SetCriteria();
        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/TamildaarTameli.rpt";

        objReport.FormulaList.Add(new ReportFormulaFields("Tameli", rdblTameli.SelectedItem.Text));
        
        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | Tamildaar Tameli Info Report";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    string SetCriteria()
    {
        string strFormula = "";

        strFormula += "{SP_GET_TAMILDAAR_TAMELI.COURT_ID}=" + int.Parse(DDLOrgWithChilds.SelectedValue) + " AND ";

        
        if (rdblTameli.SelectedIndex == 0)
            strFormula += " not isnull({SP_GET_TAMILDAAR_TAMELI.RECEIVED_DATE})" + " AND " + "not isnull({SP_GET_TAMILDAAR_TAMELI.TAMELI_DATE})"+ " AND " + "{SP_GET_TAMILDAAR_TAMELI.VERIFIED_YES_NO}=" + "'Y'" + " AND ";
        else if (rdblTameli.SelectedIndex == 1)
            strFormula += "not isnull({SP_GET_TAMILDAAR_TAMELI.RECEIVED_DATE})" + " AND " + "not isnull({SP_GET_TAMILDAAR_TAMELI.TAMELI_DATE})"+ " AND " + "{SP_GET_TAMILDAAR_TAMELI.VERIFIED_YES_NO}=" + "'N'" + " AND ";
        else if (rdblTameli.SelectedIndex == 2)
            strFormula += "not isnull({SP_GET_TAMILDAAR_TAMELI.RECEIVED_DATE})" + " AND " + "isnull({SP_GET_TAMILDAAR_TAMELI.TAMELI_DATE})"+ " AND ";
            
        if (DDLCaseType.SelectedIndex > 0)
        {
            strFormula += "{SP_GET_TAMILDAAR_TAMELI.CASE_TYPE_ID}=" + int.Parse(DDLCaseType.SelectedValue) + " AND ";
        }

        foreach (ListItem lst in chkregDiry.Items)
        {
            if (lst.Selected == true)
            {
                strFormula += "{SP_GET_TAMILDAAR_TAMELI.REG_DIARY_ID}=" + int.Parse(lst.Value) + "  OR ";
            }
        }

        foreach (ListItem lst in chkTamildaar.Items)
        {
            if (lst.Selected == true)
            {
                strFormula += "{SP_GET_TAMILDAAR_TAMELI.RECEIVED_BY}=" + int.Parse(lst.Value) + "  OR ";
            }
        }

        if (strFormula != "")
        {
            strFormula = strFormula.Substring(0, strFormula.Length - 5);
        }
        return strFormula;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DDLOrgWithChilds.SelectedIndex = 0;
        DDLOrgWithChilds.SelectedIndex = -1;
        chkTamildaar.DataSource = "";
        chkTamildaar.DataBind();
        chkregDiry.DataSource = "";
        chkregDiry.DataBind();
    }
}
