using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeExperience
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

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private string _PostingLocation;
        public string PostingLocation
        {
            get { return this._PostingLocation; }
            set { this._PostingLocation = value; }
        }

        private string _JobLocation;
        public string JobLocation
        {
            get { return this._JobLocation; }
            set { this._JobLocation = value; }
        }

        private string _Classification;
        public string Classification
        {
            get { return this._Classification; }
            set { this._Classification = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return this._Remarks; }
            set { this._Remarks = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return this._EntryDate; }
            set { this._EntryDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTEmployeeExperience()
        {
        }

        public ATTEmployeeExperience(double empID, int seqNo, string fromDate, string toDate, string postingLocation, string jobLocation, string classification, string remarks, string entryBy)
        {
            this.EmpID = empID;
            this.SeqNo = seqNo;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.PostingLocation = postingLocation;
            this.JobLocation = jobLocation;
            this.Classification = classification;
            this.Remarks = remarks;
            this.EntryBy = entryBy;
        }

    }
}
