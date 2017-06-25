using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonDocuments
    {
        private double _PId;
        public double PId
        {
            get { return this._PId; }
            set { this._PId = value; }
        }

        private int _DocTypeID;
        public int DocTypeID
        {
            get { return this._DocTypeID; }
            set { this._DocTypeID = value; }
        }

        private string _DocTypeName;
        public string DocTypeName
        {
            get { return this._DocTypeName; }
            set { this._DocTypeName = value; }
        }

        private string _DocNumber;
        public string DocNumber
        {
            get { return this._DocNumber; }
            set { this._DocNumber = value; }
        }

        private int? _IssuedFrom;
        public int? IssuedFrom
        {
            get { return this._IssuedFrom; }
            set { this._IssuedFrom = value; }
        }

        private string _NepDistName;
        public string NepDistName
        {
            get { return this._NepDistName; }
            set { this._NepDistName = value; }
        }

        private string _DistUcodeName;

        public string DistUcodeName
        {
            get { return _DistUcodeName; }
            set { _DistUcodeName = value; }
        }
	

        private string _IssuedOn;
        public string IssuedOn
        {
            get { return this._IssuedOn; }
            set { this._IssuedOn = value; }
        }

        private string _IssuedBy;
        public string IssuedBy
        {
            get { return this._IssuedBy; }
            set { this._IssuedBy = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
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

        public ATTPersonDocuments()
        {
        }

        public ATTPersonDocuments(double personID, int docTypeID, string docNumber, int? issuedFrom, string issuedOn, string issuedBy, string active, string entryBy)
        {
            this.PId = personID;
            this.DocTypeID = docTypeID;
            this.DocNumber = docNumber;
            this.IssuedFrom = issuedFrom;
            this.IssuedOn = issuedOn;
            this.IssuedBy = issuedBy;
            this.Active = active;
            this.EntryBy = entryBy;
        }
    }
}
