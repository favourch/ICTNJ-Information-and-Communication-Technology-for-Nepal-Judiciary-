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

public partial class MODULES_CMS_ReportForms_CauseList : System.Web.UI.Page
{
    int orgID = 9;
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrgWithChilds();
            LoadCaseType();
            txtToDate_RQD.Visible = false;
            lblToDate.Visible = false;
            //DateTime d1; 
            //d1 = DateTime.Now.Date;
            //txtFromDate_RQD.Text = d1.ToString();
        }
    }
    void LoadOrgWithChilds()
    {
        try
        {

            List<ATTOrganization> lstOrg = BLLOrganization.GetOrgWithChilds(orgID);
            i = lstOrg.FindIndex(delegate(ATTOrganization att)
           {
               return att.OrgID == orgID;
           });
            DDLOrg.DataSource = lstOrg;
            DDLOrg.DataTextField = "OrgName";
            DDLOrg.DataValueField = "OrgID";
            DDLOrg.DataBind();
            DDLOrg.SelectedIndex = i;

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

    string SetCriteria()
    {
        string strFormula = "";
        strFormula += "{VW_CAUSE_LIST.COURT_ID}= " + int.Parse(DDLOrg.SelectedValue) + " AND ";

        if (DDLCaseType.SelectedIndex > 0)
        {
            strFormula += "{VW_CAUSE_LIST.CASE_TYPE_ID}= " + int.Parse(DDLCaseType.SelectedValue) + " AND ";
        }

        if (RDLTime.SelectedIndex == 0)
        {
            strFormula += "{VW_CAUSE_LIST.CL_DATE}= '" +  txtFromDate_RQD.Text.Trim() +"' AND ";
        }

        if (RDLTime.SelectedIndex == 1)
        {
            strFormula += "{VW_CAUSE_LIST.CL_DATE} = '" + txtFromDate_RQD.Text.Trim() + "' TO '" + txtToDate_RQD.Text.Trim() + "' AND ";
        }

        if (strFormula != "")
        {
            strFormula = strFormula.Substring(0, strFormula.Length - 4);
        }

        return strFormula;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {

        if (RDLTime.SelectedIndex==1 && txtFromDate_RQD.Text == "____/__/__" && txtToDate_RQD.Text=="____/__/__")
        {
            lblStatusMessage.Text = "Please Enter From date and To Date First";
            programmaticModalPopup.Show();
            return;
        }
        if (RDLTime.SelectedIndex == 0 && txtFromDate_RQD.Text == "____/__/__")
        {
            lblStatusMessage.Text = "Please Enter From date First";
            programmaticModalPopup.Show();
            return;
        }

        if (RDLTime.SelectedIndex == 1)
        {
            if ((txtFromDate_RQD.Text.Trim().CompareTo(txtToDate_RQD.Text.Trim())) > 0)
            {
                lblStatusMessage.Text = "From Date must be smaller then To Date";
                programmaticModalPopup.Show();
                return;
            }

            DateTime dt1 = DateTime.Parse(txtFromDate_RQD.Text.Trim());
            DateTime dt2 = DateTime.Parse(txtToDate_RQD.Text.Trim());

            TimeSpan t1 = dt2.Subtract(dt1) + new TimeSpan(1, 0, 0, 0);
            if (t1 >= new TimeSpan(7, 0, 0, 0))
            {
                lblStatusMessage.Text = "Enter Date shouldn't be greater then one week";
                programmaticModalPopup.Show();
                return;
            }
        }

        Session["CMS_REPORT"] = null;
        CrystalReport objReport = new CrystalReport();

        objReport.SelectionCriteria = SetCriteria();
        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/CauseList.rpt";

        objReport.FormulaList.Add(new ReportFormulaFields("OrgName", DDLOrg.SelectedItem.Text.Trim()));
        objReport.FormulaList.Add(new ReportFormulaFields("OrgAddress", "Ram Sah Path"));

        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | Cause List";

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

    protected void DDLOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
       LoadCaseType();
    }

    protected void RDLTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RDLTime.SelectedIndex == 1)
        {
            txtToDate_RQD.Visible = true;
            lblToDate.Visible = true;
        }
        else
        {
            txtToDate_RQD.Visible = false;
            lblToDate.Visible = false;
        }
    }
}
