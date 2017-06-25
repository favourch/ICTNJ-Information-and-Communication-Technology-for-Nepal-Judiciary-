using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseAccount
    {
        private string _InVoiceNumber;
        public string InVoiceNumber
        {
            get { return _InVoiceNumber.Trim(); }
            set { _InVoiceNumber = value; }
        }
	
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
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
	
        private string _TransactionDate;
        public string TransactionDate
        {
            get { return _TransactionDate.Trim(); }
            set { _TransactionDate = value; }
        }
        private double _TransactionAmount;
        public double TransactionAmount
        {
            get { return _TransactionAmount; }
            set { _TransactionAmount = value; }
        }

        private string  _Remarks;
        public string  Remarks
        {
            get { return _Remarks.Trim(); }
            set { _Remarks = value; }
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
	

        public ATTCaseAccount()
        {
        }

        public ATTCaseAccount(double caseID, int accountTypeID, string tranDate, double tranAmount, string remarks)
        {
            this.CaseID = caseID;
            this.AccountTypeID = accountTypeID;
            this.TransactionDate = tranDate;
            this.TransactionAmount = tranAmount;
            this.Remarks = remarks;
        }
	
    }
}
