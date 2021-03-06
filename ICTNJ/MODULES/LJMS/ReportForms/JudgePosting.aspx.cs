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
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;

public partial class MODULES_LJMS_Report_Forms_JudgePosting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }
        ////block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        Session["OrgID"] = user.OrgID;
        if (user.MenuList.ContainsKey("2,29,1") == true)
        {
            if (Page.IsPostBack == false)
            {
                LoadOffice();
                LoadPost();
                LoadSewa();
                LoadLevel();
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
    void LoadSewa()
    {
        List<ATTSewa> LSTSewa = BLLSewa.GetSewaList(null);
        LSTSewa.Insert(0,new ATTSewa(0, "----सेवा छान्नुहोस्----","",DateTime.MinValue,""));
        Session["Sewa"] = LSTSewa;
        ddlSewa.DataSource = LSTSewa;
        ddlSewa.DataTextField = "SewaName";
        ddlSewa.DataValueField = "SewaID";
        ddlSewa.DataBind();
    }
    void LoadLevel()
    {
        List<ATTDesignationLevel> LSTDesignationLevel = BLLDesignationLevel.GetDesignationLevelList();
        chkBoxListLevel.DataSource = LSTDesignationLevel;
        chkBoxListLevel.DataTextField = "LevelName";
        chkBoxListLevel.DataValueField = "LevelID";
        chkBoxListLevel.DataBind();
        
    }


    protected void Button1_Click(object sender, EventArgs e)
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
            {
                report.ReportName = Server.MapPath("~")+"/MODULES/LJMS/Reports/JudgePostingOrganization.rpt";
            }
            else if (ddlReportType.SelectedIndex == 2)
            {
                report.ReportName = Server.MapPath("~") + "/MODULES/LJMS/Reports/JudgePostingSewa.rpt";
            }
            else if (ddlReportType.SelectedIndex == 3)
            {
                report.ReportName = Server.MapPath("~") + "/MODULES/LJMS/Reports/JudgePostingDesignation.rpt";
            }


            //ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);

            report.UserID = "PMS_ADMIN";
            report.Password = "PMS_ADMIN";

            report.FormulaList.Add(new ReportFormulaFields("OrgName", "Supreme Court"));
            report.FormulaList.Add(new ReportFormulaFields("OrgAddress", "Kathmandu"));
            //objReport.ParamList.Add(new ReportParameter("Report Name", "Employee Posting Information"));
            report.FormulaList.Add(new ReportFormulaFields("Date", DateTime.Now.ToShortDateString()));

            Session["LJMSReport"] = report;
            Session["LJMSReportTitle"] = null;
            Session["LJMSReportTitle"] = "LJMS | Employee Posting Report";

            string script = "";
            script += "<script language='javascript' type='text/javascript'>";
            script += "var win=window.open('./CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
            script += "</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);

            //Response.Redirect("~/MODULES/PMS/ReportForms/CommonReportViewer.aspx");
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

        string strSelectedLevel = "";
        strSelectedLevel = GetSelectedString(this.chkBoxListLevel);
        if (strSelectedLevel != "")
            strFormula += "AND {VW_EMP_POSTING.LEVEL_ID} IN [" + strSelectedLevel + "]";

        if (ddlSewa.SelectedIndex != 0)
        {
            strFormula += "AND {VW_EMP_POSTING.SEWA_ID} =" + ddlSewa.SelectedValue.ToString();

            if (ddlSamuha.SelectedIndex != 0)
            {
                strFormula += "AND {VW_EMP_POSTING.SAMUHA_ID} =" + ddlSamuha.SelectedValue.ToString();

                if (ddlUpaSamuha.SelectedIndex != 0)
                {
                    strFormula += "AND {VW_EMP_POSTING.UPA_SAMUHA_ID} =" + ddlUpaSamuha.SelectedValue.ToString();
                }
            }
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
    
    protected void ddlSewa_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSewa.SelectedIndex == 0)
        {
            ddlSamuha.SelectedIndex = 0;
            ddlUpaSamuha.SelectedIndex=0;
        }
        List<ATTSewa> LSTSewa = (List<ATTSewa>)Session["Sewa"];
        List<ATTSamuha> LstSamuha = LSTSewa[ddlSewa.SelectedIndex].LstSamuha;
        LstSamuha.Insert(0, new ATTSamuha(0, 0, "---समुह छान्नुहोस्---", "", DateTime.MinValue, ""));
        Session["Samuha"] = LstSamuha;
        ddlSamuha.DataSource = LSTSewa[ddlSewa.SelectedIndex].LstSamuha;
        ddlSamuha.DataTextField = "SamuhaName";
        ddlSamuha.DataValueField = "SamuhaID";
        ddlSamuha.DataBind();
    }

    protected void ddlSamuha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSamuha.SelectedIndex == 0)
        {
            ddlUpaSamuha.SelectedIndex=0;
        }
        List<ATTSamuha> LSTSamuha = (List<ATTSamuha>)Session["Samuha"];
        List<ATTUpaSamuha> LSTUpaSamuha = LSTSamuha[ddlSamuha.SelectedIndex].LstUpaSamuha;
        LSTUpaSamuha.Insert(0, new ATTUpaSamuha(0, 0, 0, "--उप समुह छान्नुहोस्--", "", DateTime.MinValue, ""));
        Session["UpaSamuha"] = LSTUpaSamuha;
        ddlUpaSamuha.DataSource = LSTSamuha[ddlSamuha.SelectedIndex].LstUpaSamuha;
        ddlUpaSamuha.DataTextField = "UpaSamuhaName";
        ddlUpaSamuha.DataValueField = "UpaSamuhaID";
        ddlUpaSamuha.DataBind();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        foreach (ListItem lstCheckBoxOffice in chkBoxListOffice.Items)
        {
            lstCheckBoxOffice.Selected = false;
        }
        foreach (ListItem lstCheckBoxPost in chkBoxListPost.Items)
        {
            lstCheckBoxPost.Selected = false;
        }
        ddlSewa.SelectedIndex = 0;
        ddlSamuha.SelectedIndex = 0;
        ddlUpaSamuha.SelectedIndex = 0;
        foreach (ListItem lstCheckBoxLevel in chkBoxListLevel.Items)
        {
            lstCheckBoxLevel.Selected = false;
        }
        ddlReportType.SelectedIndex = 0;
    }
}
