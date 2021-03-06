using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMaagFaaramHead
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

        private string _ReqDate;
        public string ReqDate
        {
            get { return this._ReqDate; }
            set { this._ReqDate = value; }
        }


        private double? _ReqBy;
        public double? ReqBy
        {
            get { return this._ReqBy; }
            set { this._ReqBy = value; }
        }

        private string _ReqPurpose;
        public string ReqPurpose
        {
            get { return this._ReqPurpose; }
            set { this._ReqPurpose = value; }
        }

        private string _IssueType;
        public string IssueType
        {
            get { return this._IssueType; }
            set { this._IssueType = value; }
        }

        private double? _AppBy;
        public double? AppBy
        {
            get { return this._AppBy; }
            set { this._AppBy = value; }
        }

        private string _AppDate;
        public string AppDate
        {
            get { return this._AppDate; }
            set { this._AppDate = value; }
        }

        private string _AppYesNo;
        public string AppYesNo
        {
            get { return this._AppYesNo; }
            set { this._AppYesNo = value; }
        }

        private string _IssueFlag;
        public string IssueFlag
        {
            get { return this._IssueFlag; }
            set { this._IssueFlag = value; }
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

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName; }
            set { this._UnitName = value; }
        }

        private string _ReqPerson;
        public string ReqPerson
        {
            get { return this._ReqPerson; }
            set { this._ReqPerson = value; }
        }

        private string _AppPerson;
        public string AppPerson
        {
            get { return this._AppPerson; }
            set { this._AppPerson = value; }
        }
        
        public string AppYesNoDesc
        {
            get { return (this.AppYesNo == "" ? "" : (this.AppYesNo == "Y" ? "गर्ने" : "नगर्ने")); }
        }

        public string IssueFlagDesc
        {
            get { return (this.IssueFlag == "" ? "" : (this.IssueFlag == "Y" ? "भएको" : "नभएको")); }
        }

        private bool _SelectApproval;
        public bool SelectApproval
        {
            get { return this._SelectApproval; }
            set { this._SelectApproval = value; }
        }

        private bool _SelectIssue;
        public bool SelectIssue
        {
            get { return this._SelectIssue; }
            set { this._SelectIssue = value; }
        }
        

        private List<ATTMaagFaaramDetail> _LstMaagFaaramDetail = new List<ATTMaagFaaramDetail>();
        public List<ATTMaagFaaramDetail> LstMaagFaaramDetail
        {
            get { return this._LstMaagFaaramDetail; }
            set { this._LstMaagFaaramDetail = value; }
        }

        public ATTMaagFaaramHead()
        {
        }

        /// <summary>
        /// Call While Inserting Maag Head at First.
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="unitID"></param>
        /// <param name="reqNo"></param>
        /// <param name="reqDate"></param>
        /// <param name="reqBy"></param>
        /// <param name="issueType"></param>
        public ATTMaagFaaramHead(int? orgID, int? unitID, double? reqNo, string reqDate, double? reqBy, string issueType)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.ReqNo = reqNo;
            this.ReqDate = reqDate;
            this.ReqBy = reqBy;
            this.IssueType = issueType;
        }

        /// <summary>
        /// Call While Updating Approval or Issue Flag in the Maag Head
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="unitID"></param>
        /// <param name="reqNo"></param>
        /// <param name="appBy"></param>
        /// <param name="appDate"></param>
        /// <param name="appYesNo"></param>
        /// <param name="issueFlag"></param>

        public ATTMaagFaaramHead(int? orgID, int? unitID, double? reqNo, double? appBy, string appDate, string appYesNo,string issueFlag)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.ReqNo = reqNo;
            this.AppBy = appBy;
            this.AppDate = appDate;
            this.AppYesNo = appYesNo;
            this.IssueFlag = issueFlag;
        }
    }
}
