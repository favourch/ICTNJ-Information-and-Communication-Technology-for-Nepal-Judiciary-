using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeePublication
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private int _PublicationID;
        public int PublicationID
        {
            get { return this._PublicationID; }
            set { this._PublicationID = value; }
        }

        private string _PublicationName;
        public string PublicationName
        {
            get { return this._PublicationName.Trim(); }
            set { this._PublicationName = value; }
        }

        private int _PubTypeID;

        public int PubTypeID
        {
            get { return _PubTypeID; }
            set { _PubTypeID = value; }
        }

        private string _PublicationTypeName;

        public string PublicationTypeName
        {
            get { return _PublicationTypeName; }
            set { _PublicationTypeName = value; }
        }
	
        private string _Publisher;
        public string Publisher
        {
            get { return this._Publisher.Trim(); }
            set { this._Publisher = value; }
        }

        private string _PublicationDate;
        public string PublicationDate
        {
            get { return this._PublicationDate.Trim(); }
            set { this._PublicationDate = value; }
        }
        private string _Remarks;

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
	
        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTEmployeePublication()
        {
        }
    }
}
