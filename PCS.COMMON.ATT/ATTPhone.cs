using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    [Serializable]
    public class ATTPhone
    {
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private int _OrgId;
        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }

        private string  _PType;
        public string  Phone_Type
        {
            get { return _PType; }
            set { _PType = value; }
        }
        private int _PSno;
        public int PSno
        {
            get { return _PSno; }
            set { _PSno = value; }
        }
        private string  _Active;
        public string  Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private string  _EntryBy;
        public string  EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
        private DateTime  _EntryDate;
        public DateTime  EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
        private string  _PhoneTypeId;

        public string  PhoneTypeId
        {
            get { return _PhoneTypeId; }
            set { _PhoneTypeId = value; }
        }

        private string _Action="";

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        public ATTPhone()
        {
        }


        public ATTPhone(int OrgID,string PhoneTypeId, string PhoneType, int SerialNo, string OrgPhone, string Active,string Remarks, string EntryBy,DateTime EntryDate)
        {
            this._OrgId = OrgID;
            this.PhoneTypeId = PhoneTypeId;
            this.Phone_Type= PhoneType;
            this.PSno = SerialNo;
            this.Phone = OrgPhone;
            this.Active = Active;
            this.Remarks = Remarks;
            this.EntryBy = EntryBy;
            this.EntryDate = EntryDate;
        }

        public ATTPhone(string PhoneType,string PhoneTypeID,int sno, string OrgPhone, string Active,string Entryby,string Action)
        {
            this.Phone_Type = PhoneType;
            this.PhoneTypeId = PhoneTypeID;
            this.PSno = sno;
            this.Phone = OrgPhone;
            this.Active = Active;
            this.EntryBy = Entryby;
            this.Action = Action;
        }

        public ATTPhone(string PhoneType, string PhoneTypeID, string OrgPhone, string Active)
        {
            this.Phone_Type = PhoneType;
            this.PhoneTypeId = PhoneTypeID;
            this.Phone = OrgPhone;
            this.Active = Active;
        }
    }
}
