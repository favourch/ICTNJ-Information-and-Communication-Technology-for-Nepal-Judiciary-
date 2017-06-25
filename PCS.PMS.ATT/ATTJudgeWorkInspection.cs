using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTJudgeWorkInspection
    {


        private int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

       
	
        private string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }	

        private int _InspEmpID;
        public int InspEmpID
        {
            get { return _InspEmpID; }
            set { _InspEmpID = value; }
        }
        private string _InspEmpName;

        public string InspEmpName
        {
            get { return _InspEmpName; }
            set { _InspEmpName = value; }
        }
	

        private string _FiscalYear;
        public string FiscalYear
        {
            get { return _FiscalYear; }
            set { _FiscalYear = value; }
        }	

        private DateTime _InspectionDate;
        public DateTime InspectionDate
        {
            get { return _InspectionDate; }
            set { _InspectionDate = value; }
        }
	
        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return _EntryOn; }
            set { _EntryOn = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        private List<ATTJudgeWorkInspectionDetails> _Details;

        public List<ATTJudgeWorkInspectionDetails> Details
        {
            get { return _Details; }
            set { _Details = value; }
        }
	

        public ATTJudgeWorkInspection()
        { }

        public ATTJudgeWorkInspection(int empID,int inspEmpID,string fiscalYear,DateTime inspDate,string entryBy)
        {
            this.EmployeeID = empID;
            this.InspEmpID = inspEmpID;
            this.FiscalYear = fiscalYear;
            this.InspectionDate = inspDate;
            this.EntryBy = entryBy;
        }
    }
}
