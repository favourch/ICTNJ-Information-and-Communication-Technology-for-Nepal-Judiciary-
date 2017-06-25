using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{

    public class ATTBenchOrder
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _BenchTypeID;
        public int BenchTypeID
        {
            get { return _BenchTypeID; }
            set { _BenchTypeID = value; }
        }
        private int _BenchNo;
        public int BenchNo
        {
            get { return _BenchNo; }
            set { _BenchNo = value; }
        }
        private int _CaseID;
        public int CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        private string _AssignmentDate;
        public string AssignmentDate
        {
            get { return _AssignmentDate; }
            set { _AssignmentDate = value; }
        }
        private int _OrderID;
        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }
        private int _SeqNo;
        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }
        private string _OrderName;
        public string OrderName
        {
            get { return _OrderName; }
            set { _OrderName = value; }
        }
        private string _Action;
        public string Action
        {
            get{return _Action;}
            set{_Action=value;}
        }
        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
        private string _EntryDate;
        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _Appelant;
        public string Appelant
        {
            get { return _Appelant; }
            set { _Appelant = value; }
        }
        private string _Respondent;
        public string Respondent
        {
            get { return _Respondent; }
            set { _Respondent = value; }
        }

        private string _CaseNumber;
        public string CaseNumber
        {
            get{return _CaseNumber;}
            set{_CaseNumber=value;}
        }
        private string _CaseReg;
        public string CaseReg
        {
            get{return _CaseReg;}
            set{_CaseReg=value;}
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private int _BoSeqNo;
        public int BoSeqNo
        {
            get { return _BoSeqNo; }
            set { _BoSeqNo = value; }
        }

       
        public ATTBenchOrder() { }
        public ATTBenchOrder(int orgid, int benchtypeid, int benchno, int caseid, string assignmentdate, int orderid, string entryby, string entrydate)
        {
            this.OrgID = orgid;
            this.BenchTypeID = benchtypeid;
            this.BenchNo = benchno;
            this.CaseID = caseid;
            this.AssignmentDate = assignmentdate;
            this.OrderID = orderid;
            this.EntryBy = entryby;
            this.EntryDate = entrydate;
        }
        public ATTBenchOrder(string casenum, string casereg, string appelant, string respondent, int orgid, int benchtypeid, string assignmentdate)
        {
            this.CaseNumber = casenum;
            this.CaseReg = casereg;
            this.Appelant = appelant;
            this.Respondent = respondent;
            this.OrgID = orgid;
            this.BenchTypeID = benchtypeid;
            this.AssignmentDate = assignmentdate;
        }
        public ATTBenchOrder(int orgid, int benchtypeid,int benchno,string fromdate,int seqno,int caseid, string assignmentdate, int orderid,int boseqno, string remarks, string entryby, string entrydate,string action)
        {
            this.OrgID = orgid;
            this.BenchTypeID = benchtypeid;
            this.BenchNo = benchno;
            this.FromDate = fromdate;
            this.SeqNo = seqno;
            this.CaseID = caseid;
            this.AssignmentDate = assignmentdate;
            this.OrderID = orderid;
            this.BoSeqNo = boseqno;
            this.Remarks = remarks;
            this.EntryBy = entryby;
            this.EntryDate = entrydate;
            this.Action = action;
        }

        

    }
}
