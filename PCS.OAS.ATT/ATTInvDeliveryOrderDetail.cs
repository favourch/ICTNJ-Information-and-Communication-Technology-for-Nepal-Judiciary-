using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvDeliveryOrderDetail
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

        private string _OrderNo;
        public string OrderNo
        {
            get { return this._OrderNo; }
            set { this._OrderNo = value; }
        }


        private string _ApproveDate;
        public string ApproveDate
        {
            get { return this._ApproveDate; }
            set { this._ApproveDate = value; }
        }


        private int? _ItemsCategoryID;
        public int? ItemsCategoryID
        {
            get { return this._ItemsCategoryID; }
            set { this._ItemsCategoryID = value; }
        }

        private string _ItemsCategoryName;
        public string ItemsCategoryName
        {
            get { return this._ItemsCategoryName; }
            set { this._ItemsCategoryName = value; }
        }


        private int? _ItemsSubCategoryID;
        public int? ItemsSubCategoryID
        {
            get { return this._ItemsSubCategoryID; }
            set { this._ItemsSubCategoryID = value; }
        }

        private string _ItemsSubCategoryName;
        public string ItemsSubCategoryName
        {
            get { return this._ItemsSubCategoryName; }
            set { this._ItemsSubCategoryName = value; }
        }


        private int? _ItemsID;
        public int? ItemsID
        {
            get { return this._ItemsID; }
            set { this._ItemsID = value; }
        }

        private string _ItemsName;
        public string ItemsName
        {
            get { return this._ItemsName; }
            set { this._ItemsName = value; }
        }


        private int? _DeliverySeq = null;
        public int? DeliverySeq
        {
            get { return this._DeliverySeq; }
            set { this._DeliverySeq = value; }
        }


        private int? _RequiredQty;
        public int? RequiredQty
        {
            get { return this._RequiredQty; }
            set { this._RequiredQty = value; }
        }

        private int? _DeliveredQty;
        public int? DeliveredQty
        {
            get { return this._DeliveredQty; }
            set { this._DeliveredQty = value; }
        }

        private int? _ReturnedQty;
        public int? ReturnedQty
        {
            get { return this._ReturnedQty; }
            set { this._ReturnedQty = value; }
        }

        private int? _TotalDeliveryQty;
        public int? TotalDeliveryQty
        {
            get { return this._TotalDeliveryQty; }
            set { this._TotalDeliveryQty = value; }
        }

        private int? _SeqNo = null;
        public int? SeqNo
        {
            get { return this._SeqNo; }
            set { this._SeqNo = value; }
        }


        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }


        public ATTInvDeliveryOrderDetail()
        {
        }
    }
}
