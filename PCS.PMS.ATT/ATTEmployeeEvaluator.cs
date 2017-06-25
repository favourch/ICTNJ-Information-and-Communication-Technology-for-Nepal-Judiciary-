using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeEvaluator
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

        private int _GroupID;
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private string _GroupName;
        public string GroupName
        {
            get { return this._GroupName; }
            set { this._GroupName = value; }
        }

        private double _PersonID;
        public double PersonID
        {
            get { return this._PersonID; }
            set { this._PersonID = value; }
        }

        private string _PersonName;
        public string PersonName
        {
            get { return this._PersonName; }
            set { this._PersonName = value; }
        }

        private string _Designation;
        public string Designation
        {
            get { return this._Designation.Trim(); }
            set { this._Designation = value; }
        }

        private double _SymbolNo;
        public double SymbolNo
        {
            get { return this._SymbolNo; }
            set { this._SymbolNo = value; }
        }

        private string _Date;
        public string Date
        {
            get { return this._Date; }
            set { this._Date = value; }
        }

        private string _Remark;
        public string Remark
        {
            get { return this._Remark.Trim(); }
            set { this._Remark = value; }
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

        public ATTEmployeeEvaluator()
        {
        }
    }
}
