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

public partial class MODULES_CMS_ReportForms_F_6_FY : System.Web.UI.Page
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
            cbOrgWithChilds.DataSource = lstCourt;
            cbOrgWithChilds.DataTextField = "OrgName";
            cbOrgWithChilds.DataValueField = "OrgID";
            cbOrgWithChilds.DataBind();
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

    string SetCriteria()
    {
        string strFormula = "";
        string strSelectedOffice = "";
        strSelectedOffice = GetSelectedString(this.cbOrgWithChilds);
        if (strSelectedOffice != "")
            strFormula += "{RPT_SP_GET_F_6_FY.COURT_ID} IN [" + strSelectedOffice + "]";
        return strFormula;
    }

    string GetSelectedString(CheckBoxList lst)
    {
        string strSelected = "";
        foreach (ListItem li in lst.Items)
        {
            if (li.Selected)
            {
                strSelected += li.Value + ",";
            }
        }
        if (strSelected != "")
            strSelected = strSelected.Remove(strSelected.LastIndexOf(','));
        return strSelected;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Session["CMS_REPORT"] = null;

        if (txtFY_RQD.Text=="__/__")
        {
            lblStatusMessage.Text = "Please Enter Fysical Year First";
            programmaticModalPopup.Show();
            return;
        }
       
        CrystalReport objReport = new CrystalReport();
        objReport.ReportName = Server.MapPath("~") + "/MODULES/CMS/Reports/F_6_FY.rpt";
        objReport.SelectionCriteria = SetCriteria();
        
        string txtFY = this.txtFY_RQD.Text.Trim();
        string strFYFrom = txtFY.Substring(0, 2);
        string strFyTo = txtFY.Substring(3, 2);
        string FromDate = "20" + strFYFrom + "/" + "04" + "/" + "01";
        string ToDate = "20" + strFyTo + "/" + "04" + "/" + "01";

        objReport.ParamList.Add(new ReportParameter("P_REG_FROM_DATE", FromDate));
        objReport.ParamList.Add(new ReportParameter("P_REG_TO_DATE", ToDate));
        objReport.ParamList.Add(new ReportParameter("P_FY", strFYFrom));

        objReport.FormulaList.Add(new ReportFormulaFields("FY", txtFY_RQD.Text.Trim()));
       
        objReport.UserID = "CMS_ADMIN";
        objReport.Password = "CMS_ADMIN";

        Session["CMS_REPORT"] = objReport;
        Session["CMS_REPORT_TITLE"] = "CMS | FY Wise Case Summary Report";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (ListItem lst in cbOrgWithChilds.Items)
        {
            lst.Selected = false;
        }

        txtFY_RQD.Text = "__/__";
    }

}
