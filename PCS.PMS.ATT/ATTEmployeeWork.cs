using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeWork
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _EvalFromDate;
        public string EvalFromDate
        {
            get { return this._EvalFromDate; }
            set { this._EvalFromDate = value; }
        }

        private int _WorkID;
        public int WorkID
        {
            get { return this._WorkID; }
            set { this._WorkID = value; }
        }

        private string _WorkDescription;
        public string WorkDescription
        {
            get { return this._WorkDescription.Trim(); }
            set { this._WorkDescription = value; }
        }

        private string _Unit;
        public string Unit
        {
            get { return this._Unit.Trim(); }
            set { this._Unit = value; }
        }

        private string _HalfYearTarget;
        public string HalfYearTarget
        {
            get { return this._HalfYearTarget.Trim(); }
            set { this._HalfYearTarget = value; }
        }

        private string _FullYearTarget;
        public string FullYearTarget
        {
            get { return this._FullYearTarget.Trim(); }
            set { this._FullYearTarget = value; }
        }

        private string _WorkProgress;
        public string WorkProgress
        {
            get { return this._WorkProgress.Trim(); }
            set { this._WorkProgress = value; }
        }

        private string _Remark;
        public string Remark
        {
            get { return this._Remark.Trim(); }
            set { this._Remark = value; }
        }

        private string _AssignByOffice;
        public string AssignByOffice
        {
            get { return this._AssignByOffice.Trim(); }
            set { this._AssignByOffice = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn; }
            set { this._EntryOn = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTEmployeeWork()
        {
        }
    }
}
