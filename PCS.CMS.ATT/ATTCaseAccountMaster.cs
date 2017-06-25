using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseAccountMaster
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
        private double? _LitigantID;
        public double? LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }
        private double? _AttorneyID;
        public double? AttorneyID
        {
            get { return _AttorneyID; }
            set { _AttorneyID = value; }
        }
        private string __Remarks;
        public string Remarks
        {
            get { return __Remarks; }
            set { __Remarks = value; }
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
        private List<ATTCaseAccountDetails>  _LstAccountDetails=new List<ATTCaseAccountDetails>();
        public List<ATTCaseAccountDetails>  LstAccountDetails
        {
            get { return _LstAccountDetails; }
            set { _LstAccountDetails = value; }
        }
        private List<ATTCaseAccountForward> _LstAccountForward = new List<ATTCaseAccountForward>();
        public List<ATTCaseAccountForward> LstAccountForward
        {
            get { return _LstAccountForward; }
            set { _LstAccountForward = value; }
        }

        public ATTCaseAccountMaster()
        {
        }

        public ATTCaseAccountMaster(double caseID, string transactionDate, int tranSeaquence,double? litigantID,double? attorneyID,string remarks)
        {
            this.CaseID = caseID;
            this.TransactionDate = transactionDate;
            this.TransactionSequence =tranSeaquence;
            this.LitigantID = litigantID;
            this.AttorneyID = attorneyID;
            this.Remarks = remarks;
        }
    }
}
