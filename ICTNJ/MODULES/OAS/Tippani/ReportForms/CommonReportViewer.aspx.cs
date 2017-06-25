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
using PCS.FRAMEWORK;
using PCS.REPORT;

public partial class MODULES_PMS_ReportForms_CommonReportViewer : System.Web.UI.Page
{
    string GetReportSessionName()
    {
        return "OASReport";
    }
    string GetDocumentSessionName()
    {
        return "OAS-rpt";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            //this.Page.Title = Session["PmsReportTitle"].ToString();
            ReportDocument doc = (ReportDocument)Session[this.GetDocumentSessionName()];
            
            if (doc != null)
            {
                doc.Close();
                doc.Dispose();
            }
            Session[this.GetDocumentSessionName()] = null;
            Session.Remove(this.GetDocumentSessionName());
        }

        if (Session[this.GetReportSessionName()] != null && Session[this.GetDocumentSessionName()] == null)
        {
            this.BindReport();
            Session[this.GetReportSessionName()] = null;
            Session.Remove(this.GetReportSessionName());
        }
        else
        {
            this.rptComViewer.ReportSource = (ReportDocument)Session[this.GetDocumentSessionName()];
        }
    }

    void BindReport()
    {
        DateTime t1 = DateTime.Now;

        CrystalReport report = (CrystalReport)Session[this.GetReportSessionName()];

        ReportDocument mainDoc = new ReportDocument();
        mainDoc.Load(report.ReportName, OpenReportMethod.OpenReportByDefault);
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
                mainDoc.SetParameterValue(param.ParamName, param.ParamValue, sr.SubReportName);
            }
        }

        mainDoc.SetDatabaseLogon("oas_admin", "oasadm1npa$$", "ICTNJDB", "");
        //mainDoc.SetDatabaseLogon("oas_admin", "oas_admin", "ICTNJDB", "");
        this.rptComViewer.ReportSource = mainDoc;

        Session[this.GetDocumentSessionName()] = mainDoc;

        DateTime t2 = DateTime.Now;
        TimeSpan s = t2.Subtract(t1);
        this.lblEllapsedTime.Text = "Ellapsed time: " + s.TotalMilliseconds.ToString() + " Millisecond(s)";
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
    }
}



