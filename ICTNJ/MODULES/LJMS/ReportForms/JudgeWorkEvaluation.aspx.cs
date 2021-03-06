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
using PCS.REPORT;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;

public partial class MODULES_LJMS_ReportForms_JudgeWorkEvaluation : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("2,3,1") == true)
        {
            if (!this.IsPostBack)
            {
                ClearControls();
                LoadOrganizations();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void ClearControls()
    {
        this.chklstJudges.DataSource = "";
        this.chklstJudges.DataBind();
    }

    void LoadOrganizations()
    {
        try
        {
            List<ATTOrganization> OrganizationList = BLLOrganization.GetOrganization();
            OrganizationList.Insert(0,new ATTOrganization(0, "--छान्नुहोस--"));
            this.ddlOrganization.DataSource = OrganizationList;
            this.ddlOrganization.DataTextField = "ORGNAME";
            this.ddlOrganization.DataValueField = "ORGID";
            this.ddlOrganization.DataBind();

        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.chklstJudges.DataSource = BLLJudgeWorkList.GetCurrentJudgesList(int.Parse(this.ddlOrganization.SelectedValue));
            this.chklstJudges.DataTextField = "JUDGENAME";
            this.chklstJudges.DataValueField = "JUDGEID";
            this.chklstJudges.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        if (this.txtFiscalYear.Text == "__/__")
        {
            this.lblStatusMessage.Text = "कृपया आ.व. राख्नुहोस.\n उदाहरणको लागी 65/66.";
            this.programmaticModalPopup.Show();
            this.txtFiscalYear.Focus();
            return;
        }
        else
        {
            string strFiscalYear = this.txtFiscalYear.Text.Trim();
            try
            {
                int intStartYear = int.Parse(strFiscalYear.Substring(0, strFiscalYear.IndexOf('/')));
                int intEndYear = int.Parse(strFiscalYear.Substring(strFiscalYear.IndexOf('/') + 1));
                if ((intStartYear+1) != intEndYear)
                {
                    this.lblStatusMessage.Text = "अघिको साल(" + intStartYear.ToString() + ") पछिको साल(" + intEndYear.ToString() + ") भन्दा एक साल सानो राख्नुहोस.";
                    this.programmaticModalPopup.Show();
                    return;
                }

            }
            catch (Exception)
            {
                this.lblStatusMessage.Text = "कृपया सहि आ.व. राख्नुहोस.";
                this.programmaticModalPopup.Show();
                return;
            }
        }
        
        int intJudgeCount = 0;
        foreach (ListItem lst in chklstJudges.Items)
        {
            if (lst.Selected)
                intJudgeCount += 1;
            if (intJudgeCount > 0)
                break;
        }
        if (intJudgeCount == 0)
        {
            this.lblStatusMessage.Text = "कृपया एउटा अथवा एउटाभन्दा धेरै न्यायाधिश छान्नुहोस.";
            this.programmaticModalPopup.Show();
            return;
        }
        else
        {
            try
            {
                CrystalReport report = new CrystalReport();
                report.SelectionCriteria = SetCriteria();
                    report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/JudgeWorkEvaluation.rpt";

                //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

                //report.FormulaList.Add(new ReportFormulaFields("OrgName", "Supreme Court"));

                report.ParamList.Add(new ReportParameter("P_EMP_ID", null));
                report.ParamList.Add(new ReportParameter("P_FISCAL_YEAR", this.txtFiscalYear.Text.Trim()));

                report.UserID = "PMS_ADMIN";
                report.Password = "PMS_ADMIN";

                Session["PMSReport"] = report;
                Session["PmsReportTitle"] = null;

                Session["PmsReportTitle"] = "PMS | Judge Evaluation Report";
                string script = "";
                script += "<script language='javascript' type='text/javascript'>";
                script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
                script += "</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

            }
            catch (Exception ex)
            {
                this.lblStatusMessage.Text = ex.Message;
                this.programmaticModalPopup.Show();
                return;
            }
        }

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

    string SetCriteria()
    {
        string strFormula = "1=1 ";
        string strSelectedJudges = "";

        strSelectedJudges = GetSelectedString(this.chklstJudges);
        if (strSelectedJudges != "")
            strFormula += "AND {SP_GET_JUDGE_WORK_INSPECTION.EMP_ID} IN [" + strSelectedJudges + "]";
        return strFormula;
    }
}
