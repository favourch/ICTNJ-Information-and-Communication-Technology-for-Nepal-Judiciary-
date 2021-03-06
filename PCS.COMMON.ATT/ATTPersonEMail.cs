using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonEMail
    {
        private double _PId;
        public double PId
        {
            get { return this._PId; }
            set { this._PId = value; }
        }

        private string _EType;
        public string EType
        {
            get { return this._EType; }
            set { this._EType = value; }
        }

        private string _EMailType;
        public string EMailType
        {
            get 
            {
                if (EType == "O")
                    return "अफिस";
                if (EType == "P")
                    return "ब्यक्तिगत";
                if (EType == "OT")
                    return "अन्य";
                    return "";
            }
            set { this._EMailType = value; }
        }

        private int _ESNo;
        public int ESNo
        {
            get { return this._ESNo; }
            set { this._ESNo = value; }
        }

        private string _EMail;
        public string EMail
        {
            get { return this._EMail; }
            set { this._EMail = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return this._Remarks; }
            set { this._Remarks = value; }
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

        public ATTPersonEMail()
        {
        }

        public ATTPersonEMail(double pId, string eType, int eSNo, string email, string active, string remarks, string entryBy, DateTime entryDate)
        {
            this.PId = pId;
            this.EType = eType;
            this.ESNo = eSNo;
            this.EMail = email;
            this.Active = active;
            this.Remarks = remarks;
            this.EntryBy = entryBy;
            this.EntryDate = entryDate;
        }
    }
}
