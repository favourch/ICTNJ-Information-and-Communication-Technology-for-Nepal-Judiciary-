using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMaagIssueHead
    {
        private int? _OrgID;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int? _UnitID;
        public int? UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private double? _ReqNo;
        public double? ReqNo
        {
            get { return this._ReqNo; }
            set { this._ReqNo = value; }
        }

        private int? _IssueSeq;
        public int? IssueSeq
        {
            get { return this._IssueSeq; }
            set { this._IssueSeq = value; }
        }

        private string _IssueDate;
        public string IssueDate
        {
            get { return this._IssueDate; }
            set { this._IssueDate = value; }
        }

        private double? _IssueBy;
        public double? IssueBy
        {
            get { return this._IssueBy; }
            set { this._IssueBy = value; }
        }

        private double? _RcvdBy;
        public double? RcvdBy
        {
            get { return this._RcvdBy; }
            set { this._RcvdBy = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return this._Remarks; }
            set { this._Remarks = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }


        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTMaagIssueDetail> _LstMaagIssueDetail = new List<ATTMaagIssueDetail>();
        public List<ATTMaagIssueDetail> LstMaagIssueDetail
        {
            get { return this._LstMaagIssueDetail; }
            set { this._LstMaagIssueDetail = value; }
        }

        public ATTMaagIssueHead()
        {
        }

        public ATTMaagIssueHead(int? orgID, int? unitID, double? reqNo, int? issueSeq, string issueDate, double? issueBy, double? rcvdBy)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.ReqNo = reqNo;
            this.IssueSeq = issueSeq;
            this.IssueDate = issueDate;
            this.IssueBy = issueBy;
            this.RcvdBy = rcvdBy;
        }
    }
}
