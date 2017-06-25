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
using PCS.REPORT;
using PCS.SECURITY.ATT;
using PCS.SECURITY.BLL;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

public partial class MODULES_LJMS_ReportForms_JudgeVisit : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("2,31,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                LoadOffice();
                LoadPost();
                LoadCountry();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);

    }

    void LoadOffice()
    {
        List<ATTOrganization> LSTOrganization = BLLOrganization.GetOrganization();
        chkBoxListOffice.DataSource = LSTOrganization;
        chkBoxListOffice.DataTextField = "OrgName";
        chkBoxListOffice.DataValueField = "OrgID";
        chkBoxListOffice.DataBind();

    }

    void LoadPost()
    {
        string desType = "J";
        List<ATTDesignation> LSTDesignation = BLLDesignation.GetDesignation(null, desType);
        chkBoxListPost.DataSource = LSTDesignation;
        chkBoxListPost.DataTextField = "DesignationName";
        chkBoxListPost.DataValueField = "DesignationID";
        chkBoxListPost.DataBind();
    }

    void LoadCountry()
    {
        List<ATTCountry> LSTCountry = BLLCountry.GetCountries(null, 2);
        chkBoxListCountry.DataSource = LSTCountry;
        chkBoxListCountry.DataTextField = "CountryNepName";
        chkBoxListCountry.DataValueField = "CountryId";
        chkBoxListCountry.DataBind();
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            CrystalReport report = new CrystalReport();
            report.SelectionCriteria = SetCriteria();
            if (ddlReportType.SelectedIndex <= 0)
            {
                this.lblStatus.Text = "Please Select The Report Type";
                this.lblStatusMessage.Text = "Report Type Must Be Selected";
                this.programmaticModalPopup.Show();
                return;
            }

            if (ddlReportType.SelectedIndex == 1)
                report.ReportName = Server.MapPath("~") + "/MODULES/LJMS/Reports/JudgeVisitOffice.rpt";
            else if (ddlReportType.SelectedIndex == 2)
                report.ReportName = Server.MapPath("~") + "/MODULES/LJMS/Reports/JudgeVisitPost.rpt";
            else if (ddlReportType.SelectedIndex == 3)
                report.ReportName = Server.MapPath("~") + "/MODULES/LJMS/Reports/JudgeVisitCountry.rpt";

            //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

            //report.ParamList.Add(new ReportParameter("OrgName", "Supreme Court"));
            report.FormulaList.Add(new ReportFormulaFields("OrgName", "Supreme Court"));
            report.ParamList.Add(new ReportParameter("P_EMP_ID", null));
            //objReport.ParamList.Add(new ReportParameter("OrgAddress", "PCS"));
            //objReport.ParamList.Add(new ReportParameter("ReportName", "Employee Visit Information"));
            //objReport.ParamList.Add(new ReportParameter("Date", DateTime.Now.ToString()));
            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            Session["LJMSReport"] = report;
            Session["LJMSReportTitle"] = null;
            Session["LJMSReportTitle"] = "LJMS | Employee Visit Report";

            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

        }

        catch (Exception ex)
        {
            this.lblStatus.Text = "Error Loading Report";
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
            return;
        }
    }

    string SetCriteria()
    {
        string strFormula = "1=1 ";
        string strSelectedOffice = "";

        strSelectedOffice = GetSelectedString(this.chkBoxListOffice);
        if (strSelectedOffice != "")
            strFormula += "AND {VW_EMP_POSTING.ORG_ID} IN [" + strSelectedOffice + "]";

        string strSelectedPost = "";
        strSelectedPost = GetSelectedString(this.chkBoxListPost);
        if (strSelectedPost != "")
            strFormula += "AND {VW_EMP_POSTING.DES_ID} IN [" + strSelectedPost + "]";

        string strSelectedCountry = "";
        strSelectedCountry = GetSelectedString(this.chkBoxListCountry);
        if (strSelectedCountry != "")
            strFormula += "AND {SP_GET_EMP_VISITS.COUNTRY} IN [" + strSelectedCountry + "]";

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
    void Cancel()
    {
        foreach (ListItem lstCheckBoxOffice in chkBoxListOffice.Items)
        {
            lstCheckBoxOffice.Selected = false;
        }
        foreach (ListItem lstCheckBoxPost in chkBoxListPost.Items)
        {
            lstCheckBoxPost.Selected = false;
        }
        foreach (ListItem lstCheckBoxCountry in chkBoxListCountry.Items)
        {
            lstCheckBoxCountry.Selected = false;
        }
        ddlReportType.SelectedIndex = 0;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Cancel();
    }
}
