using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    [Serializable]
    public class ATTEmail
    {
        
        private string  _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private int _OrgId;
        public int OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }
        private string _EType;
        public string EType
        {
            get { return _EType; }
            set { _EType = value; }
        }
        private int _ESNo;
        public int ESNo
        {
            get { return _ESNo; }
            set { _ESNo = value; }
        }
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Action = "";

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
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

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
        private string  _EmailTypeId;

	public string  EmailTypeId
	{
        get { return _EmailTypeId; }
        set { _EmailTypeId = value; }
	}



        public ATTEmail(int OrgId,string emailTypeID, string EmailType, int SerialNo, string Email, string Active, string Remark, string EntryBy, DateTime EntryDate)
        {
            this.OrgId = OrgId;
            this.EmailTypeId = emailTypeID;
            this.EType = EmailType;
            this.ESNo = SerialNo;
            this.Email = Email;
            this.Active = Active;
            this.Remarks = Remark;
            this.EntryBy = EntryBy;
            this.EntryDate = EntryDate;
        }
        public ATTEmail(string EmailType, string EmailTypeId,int sno, string Email, string Active, string Entryby, string Action)
        {
            this._EType = EmailType;
            this._EmailTypeId = EmailTypeId;
            this.ESNo = sno;
            this._Email = Email;
            this._Active = Active;
            this.EntryBy = Entryby;
            this.Action = Action;
        }
        public ATTEmail(string EmailType, string EmailTypeId, string Email, string Active)
        {
            this._EType = EmailType;
            this._EmailTypeId = EmailTypeId;
            this._Email = Email;
            this._Active = Active;
        }
    }
}
