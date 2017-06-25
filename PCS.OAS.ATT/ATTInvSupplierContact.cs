using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
 [Serializable]
 public   class ATTInvSupplierContact
    {
        private int _SupplierID;
        public int SupplierID
        {
            get { return this._SupplierID; }
            set { this._SupplierID = value; }
        }
        private int _SeqNo;
        public int SeqNo
        {
            get { return this._SeqNo; }
            set { this._SeqNo = value; }
        }
        private string _ContactPerson;
        public string ContactPerson
        {
            get { return this._ContactPerson.Trim(); }
            set { this._ContactPerson = value; }
        }
        private string _ContactPhone;
        public string ContactPhone
        {
            get { return this._ContactPhone.Trim(); }
            set { this._ContactPhone = value; }
        }
        private string _ContactEmail;
        public string ContactEmail
        {
            get { return this._ContactEmail.Trim(); }
            set { this._ContactEmail = value; }
        }
        private string _Action;

        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
	
        
        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }
     
        //private DateTime _EntryOn;
        //public DateTime EntryOn
        //{
        //    get { return this._EntryOn.Date; }
        //    set { this._EntryOn = value; }
        //}
     public ATTInvSupplierContact()
     {
 
     }
	
     public ATTInvSupplierContact(int supplierID, int seqNo, string contactPerson, string contactPhone, string contactEmail,string entryBy,string action)
     {
         this.SupplierID = supplierID;
         this.SeqNo = seqNo;
         this.ContactPerson = contactPerson;
         this.ContactPhone = contactPhone;
         this.ContactEmail = contactEmail;
         this.EntryBy = entryBy;
         this.Action = action;
     }

    }
}
