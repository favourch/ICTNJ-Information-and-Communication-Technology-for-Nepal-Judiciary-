using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMaagIssueDetail
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

        private int? _ItemsCategoryID;
        public int? ItemsCategoryID
        {
            get { return this._ItemsCategoryID; }
            set { this._ItemsCategoryID = value; }
        }

        private int? _ItemsSubCategoryID;
        public int? ItemsSubCategoryID
        {
            get { return this._ItemsSubCategoryID; }
            set { this._ItemsSubCategoryID = value; }
        }

        private double? _ItemsID;
        public double? ItemsID
        {
            get { return this._ItemsID; }
            set { this._ItemsID = value; }
        }

        private int _DeliveredQty;
        public int DeliveredQty
        {
            get { return this._DeliveredQty; }
            set { this._DeliveredQty = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTMaagIssueDetail()
        {
        }

        public ATTMaagIssueDetail(int? orgID, int? unitID, double? reqNo, int? issueSeq, int? itemsCategoryID, int? itemsSubCategoryID, int? itemsID, int deliveredQty)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.ReqNo = reqNo;
            this.IssueSeq = issueSeq;
            this.ItemsCategoryID = itemsCategoryID;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsID = itemsID;
            this.DeliveredQty = deliveredQty;
        }
    }
}
