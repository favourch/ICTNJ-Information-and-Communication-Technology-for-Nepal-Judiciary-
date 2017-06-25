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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
            this.Page.Title = Session["OASReportTitle"].ToString();
      
            BindReport();

    }

    void BindReport()
    {
        try
        {
            if (Session["OASReport"] != null)
            {
                CrystalReport report = (CrystalReport)Session["OASReport"];

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
                        mainDoc.SetParameterValue(param.ParamName, param.ParamValue, sr.SubReportName);
                    }
                }

                mainDoc.SetDatabaseLogon("oas_admin", "oasadm1npa$$", "ICTNJDB", "");

                this.rptComViewer.ReportSource = mainDoc;
            }
        }
        catch (Exception ex)
        {
            
            throw(ex);
        }

      

    }
}



