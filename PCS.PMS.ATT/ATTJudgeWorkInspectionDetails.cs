using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTJudgeWorkInspectionDetails
    {
        private int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        private string _FiscalYear;
        public string FiscalYear
        {
            get { return _FiscalYear; }
            set { _FiscalYear = value; }
        }

        private int _JwcID;
        public int JwcID
        {
            get { return _JwcID; }
            set { _JwcID = value; }
        }

        private string _JwcName;
        public string JwcName
        {
            get { return _JwcName; }
            set { _JwcName = value; }
        }

        private bool _WorkDone;
        public bool WorkDone
        {
            get { return _WorkDone; }
            set { _WorkDone = value; }
        }

        private int? _NoOfCase;
        public int? NoOfCase
        {
            get { return _NoOfCase; }
            set { _NoOfCase = value; }
        }

        private string _NoDoneReason;
        public string NoDoneReason
        {
            get { return _NoDoneReason; }
            set { _NoDoneReason = value; }
        }

        private bool? _IsReasonValid;
        public bool? IsReasonValid
        {
            get { return _IsReasonValid; }
            set { _IsReasonValid = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private int? _InspectionCaseNo;
        public int? InspectionCaseNo
        {
            get { return _InspectionCaseNo; }
            set { _InspectionCaseNo = value; }
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

        public ATTJudgeWorkInspectionDetails()
        { }
        public ATTJudgeWorkInspectionDetails(int empID, string fiscalYear, int jwcID,
                                             bool workDone, int noOfCase, string noDoneReason,
                                             bool isReasonValid, string remarks, int inspectionCaseNo, string entryBy)
        {
            this.EmployeeID = empID;
            this.FiscalYear = fiscalYear;
            this.JwcID = jwcID;
            this.WorkDone = workDone;
            this.NoOfCase = noOfCase;
            this.NoDoneReason = noDoneReason;
            this.IsReasonValid = isReasonValid;
            this.Remarks = remarks;
            this.InspectionCaseNo = inspectionCaseNo;
            this.EntryBy = entryBy;

        }

    }
}
