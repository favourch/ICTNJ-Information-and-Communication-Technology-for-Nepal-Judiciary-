
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

using System.IO;
using PCS.COMMON.ATT;
using PCS.COMMON.BLL;
using PCS.PMS.ATT;
using PCS.PMS.BLL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using System.Reflection;
using PCS.LJMS.ATT;
using PCS.LJMS.BLL;
using PCS.REPORT;

public partial class MODULES_LJMS_Forms_LawyerRenewalComparision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        //block if without login
        if (Session["Login_User_Detail"] == null)
        {
            Response.Redirect("~/MODULES/Login.aspx", true);
        }

        //block if from URL
        ATTUserLogin user = ((ATTUserLogin)Session["Login_User_Detail"]);
        if (user.MenuList.ContainsKey("2,41,1") == true)
        {
            if (this.IsPostBack == false)
            {
                this.LoadLawyerType();
                this.LoadUnit();
            }
        }
        else
            Response.Redirect("~/MODULES/Login.aspx", true);
    }

    void LoadLawyerType()
    {
        try
        {
            this.ddlLawyerType.DataSource = BLLLawyerType.GetLawyerTypeList(null, true);
            this.ddlLawyerType.DataTextField = "LawyerTypeDescription";
            this.ddlLawyerType.DataValueField = "LawyerTypeID";
            this.ddlLawyerType.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    void LoadUnit()
    {
        try
        {
            this.ddlUnit.DataSource = BLLUnit.GetUnitList(null, true);
            this.ddlUnit.DataTextField = "UnitName";
            this.ddlUnit.DataValueField = "UnitID";
            this.ddlUnit.DataBind();
        }
        catch (Exception ex)
        {
            this.lblStatus.Text = ex.Message;
        }
    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        if (this.txtStartYear.Text.Trim() == "")
        {
            this.lblStatus.Text = "Error:: Please enter start year for renew data comparision.";
            return;
        }

        if (this.txtEndYear.Text.Trim() == "")
        {
            this.lblStatus.Text = "Error:: Please enter end year for renew data comparision.";
            return;
        }

        CrystalReport report = new CrystalReport(Server.MapPath("~/MODULES/LJMS/REPORTS/RenewalComparision_New.rpt"), "LJMS_ADMIN", "LJMS_ADMIN");
        //report.SelectionCriteria = " 1 = 1 ";

        //if (this.txtLisenceNo.Text.Trim() != "")
        //{
        //    report.SelectionCriteria += "and {VW_PL_RENEW_DATE_COMPARE.LICENSE_NO} = '" + this.txtLisenceNo.Text.Trim() + "'";
        //    //report.SelectionCriteria += "and ({VW_PL_RENEW_DATE_COMPARE.LICENSE_NO} = '" + this.txtLisenceNo.Text.Trim() + "' or isnull({VW_PL_RENEW_DATE_COMPARE.LICENSE_NO}) = true)";
        //}

        //if (this.ddlLawyerType.SelectedIndex > 0)
        //{
        //    report.SelectionCriteria += "and {VW_PL_RENEW_DATE_COMPARE.LAWYER_TYPE_ID} = " + this.ddlLawyerType.SelectedValue;
        //    //report.SelectionCriteria += "and ({VW_PL_RENEW_DATE_COMPARE.LAWYER_TYPE_ID} = " + this.ddlLawyerType.SelectedValue + " or isnull({VW_PL_RENEW_DATE_COMPARE.LAWYER_TYPE_ID}) = true)";
        //}

        //if (this.ddlUnit.SelectedIndex > 0)
        //{
        //    report.SelectionCriteria += "and {VW_PL_RENEW_DATE_COMPARE.UNIT_ID} = " + this.ddlUnit.SelectedValue;
        //    //report.SelectionCriteria += "and ({VW_PL_RENEW_DATE_COMPARE.UNIT_ID} = " + this.ddlUnit.SelectedValue + " or isnull({VW_PL_RENEW_DATE_COMPARE.UNIT_ID}) = true)";
        //}

        ReportParameter stYear = new ReportParameter("st_numb", this.txtStartYear.Text.Trim());
        ReportParameter endYear = new ReportParameter("end_numb", this.txtEndYear.Text.Trim());
        report.ParamList.Add(stYear);
        report.ParamList.Add(endYear);

        if (this.txtLisenceNo.Text.Trim() != "")
            report.ParamList.Add(new ReportParameter("P_LICENSE_NO", this.txtLisenceNo.Text.Trim()));
        else
            report.ParamList.Add(new ReportParameter("P_LICENSE_NO", null));

        if (this.ddlLawyerType.SelectedIndex > 0)
            report.ParamList.Add(new ReportParameter("P_LAWYER_TYPE_ID", int.Parse(this.ddlLawyerType.SelectedValue)));
        else
            report.ParamList.Add(new ReportParameter("P_LAWYER_TYPE_ID", null));

        if (this.ddlUnit.SelectedIndex > 0)
            report.ParamList.Add(new ReportParameter("P_UNIT_ID", int.Parse(this.ddlUnit.SelectedValue)));
        else
            report.ParamList.Add(new ReportParameter("P_UNIT_ID", null));

        Session["LJMSReport"] = report;

        this.lblStatus.Text = "";

        string script = "";
        script += "<script language='javascript' type='text/javascript'>";
        script += "var win=window.open('../ReportForms/CommonReportViewer.aspx', 'popup','width=780,height=500,directories=no,location=no,menubar=no,resizable=1,scrollbars=1,status=yes,toolbar=no');";
        script += "</script>";
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "PCS", script);
    }
}
