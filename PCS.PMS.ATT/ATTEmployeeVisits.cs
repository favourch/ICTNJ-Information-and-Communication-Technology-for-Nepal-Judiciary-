using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeVisits
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

        private string _Location;
        public string Location
        {
            get { return this._Location; }
            set { this._Location = value; }
        }

        private int? _Country;
        public int? Country
        {
            get { return this._Country; }
            set { this._Country = value; }
        }

        private string _CountryNepName;
        public string CountryNepName
        {
            get { return this._CountryNepName; }
            set { this._CountryNepName = value; }
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

        private string _Purpose;
        public string Purpose
        {
            get { return this._Purpose; }
            set { this._Purpose = value; }
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

        private string _Vehicle;

        public string Vehicle
        {
            get { return _Vehicle; }
            set { _Vehicle = value; }
        }
	

        public ATTEmployeeVisits()
        {
        }

        public ATTEmployeeVisits(double empID, int seqNo, string purpose, string location, int? country, string fromDate, string toDate,string vehicle, string remarks, string entryBy)
        {
            this.EmpID = empID;
            this.SeqNo = seqNo;
            this.Purpose = purpose;
            this.Location = location;
            this.Country = country;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Vehicle = vehicle;
            this.Remarks = remarks;
            this.EntryBy = entryBy;
        }

        public ATTEmployeeVisits(double empID, int seqNo, string purpose, string location, int? country, string fromDate, string toDate, string remarks, string entryBy)
        {
            this.EmpID = empID;
            this.SeqNo = seqNo;
            this.Purpose = purpose;
            this.Location = location;
            this.Country = country;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Remarks = remarks;
            this.EntryBy = entryBy;
        }

    }
}
