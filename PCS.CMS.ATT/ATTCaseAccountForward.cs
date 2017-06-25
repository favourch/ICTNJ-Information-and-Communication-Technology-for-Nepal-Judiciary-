using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
   public class ATTCaseAccountForward
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }
        private string _CaseName;
        public string CaseName
        {
            get { return _CaseName; }
            set { _CaseName = value; }
        }
	
        private int _AccountTypeID;
        public int AccountTypeID
        {
            get { return _AccountTypeID; }
            set { _AccountTypeID = value; }
        }
        private string _AccountTypeName;
        public string AccountTypeName
        {
            get { return _AccountTypeName; }
            set { _AccountTypeName = value; }
        }

        private double _TotalAmount;
        public double TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        private string _Paid;
        public string Paid
        {
            get { return _Paid.Trim(); }
            set { _Paid = value; }
        }

       private string _Appellants;
       public string Appellants
       {
           get { return this._Appellants; }
           set { this._Appellants = value; }
       }

       private string _Respondents;
       public string Respondents
       {
           get { return this._Respondents; }
           set { this._Respondents = value; }
       }
	
        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy.Trim(); }
            set { _EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action.Trim(); }
            set { _Action = value; }
        }
	

        public ATTCaseAccountForward()
        {
        }

        public ATTCaseAccountForward(double caseID, int accountTypeID,double totalAmount,string paid)
        {
            this.CaseID = caseID;
            this.AccountTypeID = accountTypeID;
            this.TotalAmount = totalAmount;
            this.Paid = paid;
        }
    }
}
