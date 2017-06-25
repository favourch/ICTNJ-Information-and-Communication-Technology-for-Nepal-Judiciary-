using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.REPORT
{
    public class ReportParameter
    {
        private string _ParamName;
        public string ParamName
        {
            get { return this._ParamName; }
            set { this._ParamName = value; }
        }

        private object _ParamValue;
        public object ParamValue
        {
            get { return _ParamValue; }
            set { _ParamValue = value; }
        }

        public ReportParameter(string name, object value)
        {
            this.ParamName = name;
            this.ParamValue = value;
        }
    }

    public class ReportFormulaFields
    {
        private string _FormulaName;
        public string FormulaName
        {
            get { return this._FormulaName; ; }
            set { this._FormulaName= value; }
        }

        private object _FormulaValue;
        public object FormulaValue
        {
            get { return _FormulaValue; }
            set { _FormulaValue = value; }
        }

        public ReportFormulaFields(string name, object value)
        {
            this.FormulaName = name;
            this.FormulaValue = value;
        }
    }

    public class SubReport
    {
        private string _SubReportName;
        public string SubReportName
        {
            get { return this._SubReportName.Trim(); }
            set { this._SubReportName = value; }
        }

        private List<ReportParameter> _ParamList = new List<ReportParameter>();
        public List<ReportParameter> ParamList
        {
            get { return _ParamList; }
            set { _ParamList = value; }
        }

        private List<ReportFormulaFields> _FormulaList = new List<ReportFormulaFields>();
        public List<ReportFormulaFields> FormulaList
        {
            get { return _FormulaList; }
            set { _FormulaList = value; }
        }
    }

    public class CrystalReport
    {
        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set { _ReportName = value; }
        }

        private List<ReportParameter> _ParamList = new List<ReportParameter>();
        public List<ReportParameter> ParamList
        {
            get { return _ParamList; }
            set { _ParamList = value; }
        }

        private List<ReportFormulaFields> _FormulaList = new List<ReportFormulaFields>();
        public List<ReportFormulaFields> FormulaList
        {
            get { return _FormulaList; }
            set { _FormulaList = value; }
        }

        private List<SubReport> _SubReportList = new List<SubReport>();
        public List<SubReport> SubReportList
        {
            get { return _SubReportList; }
            set { _SubReportList = value; }
        }

        private string _SelectionCriteria;
        public string SelectionCriteria
        {
            get { return _SelectionCriteria; }
            set { _SelectionCriteria = value; }
        }

        private string _UserID;
        public string UserID
        {
            get { return this._UserID; }
            set { _UserID = value; }
        }

        private string _Password;
        public string Password
        {
            get { return this._Password; }
            set { _Password = value; }
        }

        public CrystalReport()
        {
            
        }

        public CrystalReport(string reportName, string userID, string password)
        {
            this.ReportName = reportName;
            this.UserID = userID;
            this.Password = password;
        }
    }
}
