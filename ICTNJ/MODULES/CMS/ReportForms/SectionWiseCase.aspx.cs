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

public partial class MODULES_CMS_ReportForms_SectionWiseCase : System.Web.UI.Page
{
    int orgID = 9;
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrgWithChilds();
            LoadOrgSections();
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

    void LoadOrgSections()
    {
        try
        {
            List<ATTOrganizationUnit> lstOrgSections = BLLOrganizationUnit.GetOrganizationUnits(int.Parse(DDLOrg.SelectedValue), null);
            
            List<ATTOrganizationUnit> listOrgSec = lstOrgSections.FindAll(delegate(ATTOrganizationUnit att)
           {
               return att.UnitType == "C";
           });
            listOrgSec.Insert(0, new ATTOrganizationUnit(0, 0, "शाखा छान्नुस्"));
            DDLSection.DataSource = listOrgSec;
            DDLSection.DataTextField = "UnitName";
            DDLSection.DataValueField = "UnitID";
            DDLSection.DataBind();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = ex.Message;
            programmaticModalPopup.Show();
        }
    }

    void LoadOrgSectionsClrk()
    {
        try
        {
            ATTEmployeeWorkDivision attEWD = new ATTEmployeeWorkDivision();
            attEWD.OrgID = orgID;
            attEWD.OrgUnitID = int.Parse(DDLSection.SelectedValue);
            attEWD.DesType = "O";
            List<ATTEmployeeWorkDivision> lstEWD = BLLEmployeeWorkDivision.SearchEmployee(attEWD);

            //lstEWD.Insert(0, new ATTEmployeeWorkDivision("शाखा क्लर्क छान्नुस्"));
            cbSectionClerk.DataSource = lstEWD;

            cbSectionClerk.DataTextField = "FullName";
            cbSectionClerk.DataValueField = "EmpID";
            cbSectionClerk.DataBind();
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

    protected void DDLSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadOrgSectionsClrk();
    }

    string SetCriteria()
    {
        string strFormula = "";
             
            strFormula += "{SP_GET_SECTION_CLERK_CASES.ORG_ID}=" + int.Parse(DDLOrg.SelectedValue)+ " AND ";
       
        if (DDLCaseType.SelectedIndex > 0)
        {
            strFormula += "{SP_GET_SECTION_CLERK_CASES.CASE_TYPE_ID}=" + int.Parse(DDLCaseType.SelectedValue) + " AND ";
        }
        if (DDLSection.SelectedIndex > 0)
        {
            strFormula += "{SP_GET_SECTION_CLERK_CASES.UNIT_ID}=" + int.Parse(DDLSection.SelectedValue) + " AND ";
        }
        foreach (ListItem lst in chkregDiry.Items)
        {
            if (lst.Selected == true)
            {
                strFormula += "{SP_GET_SECTION_CLERK_CASES.REG_DIARY_ID}=" + int.Parse(lst.Value) + "  OR ";
            }
        }
        foreach (ListItem lst in cbSectionClerk.Items)
        {
            if (lst.Selected == true)
            {
                strFormula += "{SP_GET_SECTION_CLERK_CASES.SECTION_CLRK_ID}=" + int.Parse(lst.Value) + "  OR ";
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
        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/SectionWiseCase.rpt";

       // objReport.FormulaList.Add(new ReportFormulaFields("OrgName", DDLOrg.SelectedItem.Text.Trim()));
        //objReport.FormulaList.Add(new ReportFormulaFields("OrgAddress", "Ram Sah Path"));
        
        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | Section Clerk Case Report";

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
        DDLSection.SelectedIndex = -1;
        cbSectionClerk.DataSource = "";
        cbSectionClerk.DataBind();
        chkregDiry.DataSource = "";
        chkregDiry.DataBind();
    }
}
