using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvReturnOrderDetail
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

        private int? _DeliverySeq;
        public int? DeliverySeq
        {
            get { return this._DeliverySeq; }
            set { this._DeliverySeq = value; }
        }

        private int? _ReturnSeq;
        public int? ReturnSeq
        {
            get { return this._ReturnSeq; }
            set { this._ReturnSeq = value; }
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

        private int? _SeqNo = null;
        public int? SeqNo
        {
            get { return this._SeqNo; }
            set { this._SeqNo = value; }
        }



        private int? _ReturnQty;
        public int? ReturnQty
        {
            get { return this._ReturnQty; }
            set { this._ReturnQty = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTInvReturnOrderDetail()
        {
        }

    }
}
