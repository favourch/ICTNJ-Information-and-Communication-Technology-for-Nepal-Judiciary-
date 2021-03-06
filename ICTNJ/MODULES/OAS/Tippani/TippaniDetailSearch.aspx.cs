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
using PCS.COMMON.ATT;
using System.Collections.Generic;
using PCS.COMMON.BLL;
using PCS.OAS.ATT;
using PCS.OAS.BLL;
using PCS.REPORT;

public partial class MODULES_OAS_Tippani_TippaniDetailSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadOrganization();
            GetTippaniStatusList();
            this.gridDiv.Visible = false;

        }

    }
    protected void hideModalPopupViaServer_Click(object sender, EventArgs e)
    {
        this.programmaticModalPopup.Hide();
    }
    void LoadOrganization()
    {
        try
        {
            List<ATTOrganization> lst = new List<ATTOrganization>();
            lst = BLLOrganization.GetOrganizationNameList();
            lst.Insert(0, new ATTOrganization(-1, "---- कार्यालय छन्नुहोस ----"));
            this.ddlOrg_Rqd.DataSource = lst;
            this.ddlOrg_Rqd.DataTextField = "OrgName";
            this.ddlOrg_Rqd.DataValueField = "OrgID";
            this.ddlOrg_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    void LoadTippaniSubject()
    {
        try
        {
            int orgID = int.Parse(ddlOrg_Rqd.SelectedValue);
            List<ATTTippaniSubject> lst = BLLTippaniSubject.GetTippaniSubjectList(orgID, true);
            this.ddlTipaniSubject_Rqd.DataSource = lst;
            this.ddlTipaniSubject_Rqd.DataTextField = "TippaniSubjectName";
            this.ddlTipaniSubject_Rqd.DataValueField = "TippaniSubjectID";
            this.ddlTipaniSubject_Rqd.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void GetTippaniStatusList()
    {
        try
        {
            List<ATTTippaniStatus> statusLst = BLLTippaniStatus.GetTippaniStatusList(true);
            ddlTippaniStatus.DataSource = statusLst;
            ddlTippaniStatus.DataTextField = "TippaniStatusName";
            ddlTippaniStatus.DataValueField = "TippaniStatusID";
            ddlTippaniStatus.DataBind();
        }
        catch (Exception ex)
        {

            this.lblStatusMessage.Text = ex.Message;
            this.programmaticModalPopup.Show();
        }
    }

    protected void ddlOrg_Rqd_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTippaniSubject();
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        ATTGeneralTippaniSearch obj = new ATTGeneralTippaniSearch();
        if (ddlOrg_Rqd.SelectedIndex < 1)
        {
            this.lblStatusMessage.Text = "Please select organisation";
            this.programmaticModalPopup.Show();
            return;
        }
        if (ddlTipaniSubject_Rqd.SelectedIndex < 1)
        {
            this.lblStatusMessage.Text = "Please select Tippani Subject";
            this.programmaticModalPopup.Show();
            return;
        }

        obj.OrgID = int.Parse(this.ddlOrg_Rqd.SelectedValue);
        obj.TippaniSubjectID = int.Parse(this.ddlTipaniSubject_Rqd.SelectedValue);
        if (fileNoTxt.Text == "")
        {
            obj.FileNo = 0;

        }
        else
        {
            obj.FileNo = int.Parse(this.fileNoTxt.Text);
        }
        obj.FromDate = this.fromDateTxt.Text;
        obj.ToDate = this.toDateTxt.Text;
        obj.FinalStatus = int.Parse(this.ddlTippaniStatus.SelectedValue);
        List<ATTGeneralTippaniSearch> lst = BLLGeneralTippaniSearch.GetTippaniDetails(obj);
        this.tippaniDetailGrid.DataSource = lst;
        this.tippaniDetailGrid.DataBind();
        this.gridDiv.Visible = true;
    }
    protected void tippaniDetailGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }
    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        ClearControls();

    }
    void ClearControls()
    {
        this.ddlOrg_Rqd.SelectedIndex = 0;
        this.ddlTipaniSubject_Rqd.SelectedIndex = 0;
        this.fileNoTxt.Text = "";
        this.fromDateTxt.Text = "";
        this.toDateTxt.Text = "";
        this.ddlTippaniStatus.SelectedIndex = -1;
        this.tippaniDetailGrid.DataSource = null;
        this.tippaniDetailGrid.DataBind();
        this.gridDiv.Visible = false;
    }

    string GetFormName(int tippaniTypeID)
    {
        //Leave = 1,
        //Visit = 2, //COMPLETE
        //Posting = 3, //COMPLETE
        //General = 4, // NOT REQUIRED
        //Training = 5, // COMPLETED
        //Deputation = 6, //COMPLETED
        //Punishment = 7, //COMPLETED
        //Award = 8 //COMPLETED

        string path = "";
        switch (tippaniTypeID)
        {
            case 1:
                path = "~/modules/oas/tippani/leavetippani.aspx";
                break;
            case 2:
                path = "~/modules/oas/tippani/visittippani.aspx";
                break;
            case 3:
                path = "~/modules/oas/tippani/postingtippani.aspx";
                break;
            case 4:
                path = "~/modules/oas/tippani/generaltippani.aspx";
                break;
            case 5:
                path = "~/modules/oas/tippani/trainingtippani.aspx";
                break;
            case 6:
                path = "~/modules/oas/tippani/deputationtippani.aspx";
                break;
            case 7:
                path = "~/modules/oas/tippani/punishmenttippani.aspx";
                break;
            case 8:
                path = "~/modules/oas/tippani/awardtippani.aspx";
                break;
            case 9:
                path = "~/modules/oas/tippani/committeetippani.aspx";
                break;
            default:
                break;
        }
        return path;
    }

    protected void tippaniDetailGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.EditMode == true)
        {
            int orgID = int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[0].Text);
            int tippaniID = int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[1].Text);
            int tipPrcID = int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[2].Text);

            Session["tippani_mode"] = orgID.ToString() + "/" + tippaniID.ToString() + "/" + tipPrcID.ToString();

            Response.Redirect(this.GetFormName(tipPrcID), true);
            return;
        }

        this.LoadReport();
    }

    void LoadReport()
    {
        CrystalReport objReport = new CrystalReport();
        objReport.UserID = "oas_admin";
        objReport.Password = "oas_admin";

        if (1 == 2)
        {
            #region absoluted code
            objReport.SelectionCriteria = GetSelectionFormula(tippaniDetailGrid.SelectedRow);

            char[] delimiter = { '/' };
            string Data = GetReportName(int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[2].Text));
            string[] reportData = Data.Split(delimiter);
            string tippani_id_param = reportData[1].ToString();

            objReport.ReportName = Server.MapPath("~/MODULES/OAS/TIPPANI/REPORTS/") + reportData[0].ToString();
            objReport.ParamList.Add(new ReportParameter("OrgName", "Supreme Court"));
            objReport.ParamList.Add(new ReportParameter("OrgAddress", "Kantipath Kathmandu"));

            SubReport detail = new SubReport();
            detail.SubReportName = "TippaniDetail";
            detail.ParamList.Add(new ReportParameter("P_ORG_ID", int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[0].Text)));
            detail.ParamList.Add(new ReportParameter(tippani_id_param, int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[1].Text)));
            if (int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[2].Text) == 2 || int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[2].Text) == 3)
                detail.ParamList.Add(new ReportParameter("P_TIPPANI_PRC_ID", -1));
            if (int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[2].Text) == 3)
                detail.ParamList.Add(new ReportParameter("P_SUBJETC_ID", -1));


            SubReport process = new SubReport();
            process.SubReportName = "TippaniProcess";
            //process.ParamList.Add(new ReportParameter("P_ORG_ID", int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[0].Text)));
            //process.ParamList.Add(new ReportParameter("P_TIPANI_ID", int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[1].Text)));

            objReport.SubReportList.Add(detail);
            objReport.SubReportList.Add(process);
            #endregion
        }
        else if (this.PrintableReport == true)
        {
            objReport.ReportName = Server.MapPath("~/MODULES/OAS/TIPPANI/REPORTS/PrintableVisit.rpt");
            objReport.ParamList.Add(new ReportParameter("p_org_id", int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[0].Text)));
            objReport.ParamList.Add(new ReportParameter("p_tipani_id", int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[1].Text)));
            objReport.ParamList.Add(new ReportParameter("p_tippani_prc_id", int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[2].Text)));
        }
        else if (this.ProcessReport == true)
        {
            objReport.ReportName = Server.MapPath("~/MODULES/OAS/TIPPANI/REPORTS/TippaniText.rpt");
            int orgID = int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[0].Text);
            int tippaniID = int.Parse(this.tippaniDetailGrid.SelectedRow.Cells[1].Text);
            objReport.SelectionCriteria = "{VW_TIPPANI_INFO.ORG_ID}=" + orgID + " AND {VW_TIPPANI_INFO.TIPPANI_ID}=" + tippaniID;
        }

        Session["OASReport"] = objReport;
        Session["OASReportTitle"] = "OAS || Tippani Report";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('./ReportForms/CommonReportViewer.aspx', 'popup','width=802,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=no,toolbar=no');";
        script += "</script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }

    protected string GetSelectionFormula(GridViewRow row)
    {
        int org_id = int.Parse(row.Cells[0].Text);
        int tippani_id = int.Parse(row.Cells[1].Text);
        string selection = "{VW_TIPPANI_INFO.ORG_ID}=" + org_id + " AND {VW_TIPPANI_INFO.TIPPANI_ID}=" + tippani_id;
        return selection;

    }

    protected string GetReportName(int tippaniSubjectID)
    {
        string reportName = "";
        string tippaniParam = "";

        switch (tippaniSubjectID)
        {
            case 1:
                reportName = "LeaveTippani.rpt";
                tippaniParam = "P_TIPPANI_ID";
                break;
            case 2:
                reportName = "VisitTippani.rpt";
                tippaniParam = "P_TIPANI_ID";
                break;
            case 3:
                reportName = "PostingTippani.rpt";
                tippaniParam = "P_TIPANI_ID";
                break;
            case 4:
                reportName = "GeneralTippani.rpt";
                tippaniParam = "P_TIPPANI_ID";
                break;
            case 5:
                reportName = "TrainingTippani.rpt";
                tippaniParam = "P_TIPPANI_ID";
                break;
            case 6:
                reportName = "DeputationTippani.rpt";
                tippaniParam = "P_TIPPANI_ID";
                break;
            case 7:
                reportName = "PunishmentTippani.rpt";
                tippaniParam = "P_TIPPANI_ID";
                break;
            case 8:
                reportName = "RewardTippani.rpt";
                tippaniParam = "P_TIPPANI_ID";
                break;
            default:
                break;

        }
        return reportName + "/" + tippaniParam;
    }

    bool PrintableReport = false;
    protected void lnkPrintableReport_Click(object sender, EventArgs e)
    {
        this.PrintableReport = true;
    }

    bool EditMode = false;
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        this.EditMode = true;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["tippani_from_message"] = "9/1";
        Response.Redirect("~/modules/oas/tippani/visittippani.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["tippani_from_dartaa_chalaani"] = "9_2067/06/06_2";
        Response.Redirect("~/modules/oas/tippani/visittippani.aspx");
    }

    bool ProcessReport = false;
    protected void lnkTippaniText_Click(object sender, EventArgs e)
    {
        this.ProcessReport = true;
    }
}