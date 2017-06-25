using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseAccountDetails
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }
        private string _TrasactionDate;
        public string TransactionDate
        {
            get { return _TrasactionDate; }
            set { _TrasactionDate = value; }
        }
        private int _TransactionSequence;
        public int TransactionSequence
        {
            get { return _TransactionSequence; }
            set { _TransactionSequence = value; }
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
	

        public ATTCaseAccountDetails()
        {
        }

        public ATTCaseAccountDetails(double caseID, string transactionDate, int tranSeaquence, int accountTypeID,double totalAmount)
        {
            this.CaseID = caseID;
            this.TransactionDate = transactionDate;
            this.TransactionSequence =tranSeaquence;
            this.AccountTypeID = accountTypeID;
            this.TotalAmount = totalAmount;
        }
    }
}
