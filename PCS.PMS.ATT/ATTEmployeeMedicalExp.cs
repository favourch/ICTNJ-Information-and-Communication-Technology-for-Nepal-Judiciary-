using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeMedicalExp
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private int _SeqNo;
        public int SeqNo
        {
            get { return this._SeqNo; }
            set { this._SeqNo = value; }
        }

        private string _Particulars;
        public string Particulars
        {
            get { return this._Particulars; }
            set { this._Particulars = value; }
        }

        private string _DateTaken;
        public string DateTaken
        {
            get { return this._DateTaken; }
            set { this._DateTaken = value; }
        }

        private double? _AmountTaken;
        public double? AmountTaken
        {
            get { return this._AmountTaken; }
            set { this._AmountTaken = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTEmployeeMedicalExp()
        {
        }

        public ATTEmployeeMedicalExp(double empID, int seqNo, string particulars, string dateTaken, double? amountTaken)
        {
            this.EmpID = empID;
            this.SeqNo = seqNo;
            this.Particulars = particulars;
            this.DateTaken = dateTaken;
            this.AmountTaken = amountTaken;
        }
    }
}
