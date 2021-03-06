using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonPhone
    {
        private double _PId;
        public double PId
        {
            get {return this._PId;}
            set {this._PId=value;}
        }

        private string _PType;
        public string PType
        {
            get {return this._PType;}
            set {this._PType=value;}
        }

        private string _PhoneType;
        public string PhoneType
        {
            get
            {
                if (PType == "M")
                    return "मोबाईल";
                else if (PType == "O")
                    return "अफिस";
                else if (PType == "R")
                    return "घर";
                else if (PType == "OT")
                    return "अन्य";
                else
                    return "";
            }
            set {this._PhoneType=value;}
        }

        private int _PSNo;
        public int PSNo
        {
            get {return this._PSNo;}
            set {this._PSNo=value;}
        }

        private string _Phone;
        public string Phone
        {
            get {return this._Phone;}
            set {this._Phone=value;}
        }

        private string _Active;
        public string Active
        {
            get{return this._Active;}
            set {this._Active=value;}
        }

        private string _Remarks;
        public string Remarks
        {
            get {return this._Remarks;}
            set {this._Remarks=value;}
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value.Trim(); }
        }

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return this._EntryDate; }
            set { this._EntryDate = value; }
        }

        public ATTPersonPhone()
        {
        }

        public ATTPersonPhone(double pId, string pType, int pSNo, string phone, string active, string remarks, string entryBy, DateTime entryDate)
        {
            this.PId = pId;
            this.PType = pType;
            this.PSNo = pSNo;
            this.Phone = phone;
            this.Active = active;
            this.Remarks = remarks;
            this.EntryBy = entryBy;
            this.EntryDate = entryDate;
        }

    }
}
