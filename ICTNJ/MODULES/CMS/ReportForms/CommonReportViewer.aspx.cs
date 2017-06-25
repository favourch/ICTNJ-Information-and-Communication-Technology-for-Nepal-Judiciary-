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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PCS.REPORT;

public partial class MODULES_DLPDS_ReportForms_CommonReportViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) 
            this.Page.Title = Session["CMS_REPORT_TITLE"].ToString();
        BindReport();
    }

    void BindReport()
    {
        CrystalReport report = (CrystalReport)Session["CMS_REPORT"];

        ReportDocument mainDoc = new ReportDocument();
        mainDoc.Load(report.ReportName);
        mainDoc.RecordSelectionFormula = report.SelectionCriteria;
        mainDoc.Refresh();

        foreach (ReportParameter param in report.ParamList)
        {
            mainDoc.SetParameterValue(param.ParamName, param.ParamValue);
        }

        foreach (ReportFormulaFields formula in report.FormulaList)
        {
            mainDoc.DataDefinition.FormulaFields[formula.FormulaName].Text = "'" + formula.FormulaValue.ToString() + "'";
        }

        foreach (SubReport sr in report.SubReportList)
        {
            foreach (ReportParameter param in sr.ParamList)
            {
                mainDoc.SetParameterValue(param.ParamName, param.ParamValue, sr.SubReportName + ".rpt");
            }
        }

        mainDoc.SetDatabaseLogon(report.UserID, report.Password, "ICTNJDB", "");

        this.rptComViewer.ReportSource = mainDoc;

    }
}
