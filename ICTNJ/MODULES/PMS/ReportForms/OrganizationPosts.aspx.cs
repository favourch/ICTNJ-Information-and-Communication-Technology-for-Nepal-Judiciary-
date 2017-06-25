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

public partial class MODULES_PMS_ReportForms_OrganizationPosts : System.Web.UI.Page
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
        if (user.MenuList.ContainsKey("3,28,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                LoadOffice();
                LoadDesignation();
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
    void LoadDesignation()
    {
        List<ATTDesignation> LSTDesg = BLLDesignation.GetDesignation(null, "O");
        chkBoxListPost.DataSource = LSTDesg;
        chkBoxListPost.DataTextField = "DesignationName";
        chkBoxListPost.DataValueField = "DesignationID";
        chkBoxListPost.DataBind();
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
                report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/OrganizationPosts.rpt";
            else if (ddlReportType.SelectedIndex == 2)
                report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/OrganizationPosts.rpt";
            else if (ddlReportType.SelectedIndex == 3)
                report.ReportName = Server.MapPath("~") + "/MODULES/PMS/Reports/EmployeeVisitCountry.rpt";

            report.FormulaList.Add(new ReportFormulaFields("OrgName", ((ATTUserLogin)Session["Login_User_Detail"]).OrgName));
            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            Session["PMSReport"] = report;
            Session["PmsReportTitle"] = null;
            Session["PmsReportTitle"] = "PMS | Employee Current Post Report";

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

        if (rdoGender.SelectedIndex != 0)
        {
            strFormula+="AND {VW_EMP_POSTING.GENDER} ='"+rdoGender.SelectedValue.ToString()+"'";
        }

        if (txtDOB.Text != "")
        {
            strFormula += "AND {VW_EMP_POSTING.DOB} ='" + txtDOB.Text.ToString()+"'";
        }

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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (ListItem lstCheckBoxOffice in chkBoxListOffice.Items)
        {
            lstCheckBoxOffice.Selected = false;
        }
        foreach (ListItem lstCheckBoxPost in chkBoxListPost.Items)
        {
            lstCheckBoxPost.Selected = false;
        }
        rdoGender.SelectedIndex = 0;
        txtDOB.Text = "";                                                                            
        ddlReportType.SelectedIndex = 0;
    }

}
