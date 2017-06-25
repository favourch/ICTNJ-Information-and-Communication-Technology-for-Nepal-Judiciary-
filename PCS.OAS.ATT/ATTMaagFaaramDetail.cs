using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMaagFaaramDetail
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

        private int? _ReqQty;
        public int? ReqQty
        {
            get { return this._ReqQty; }
            set { this._ReqQty = value; }
        }

        private int? _AppQty;
        public int? AppQty
        {
            get { return this._AppQty; }
            set { this._AppQty = value; }
        }

        private int? _DeliveredQty;
        public int? DeliveredQty
        {
            get { return this._DeliveredQty; }
            set { this._DeliveredQty = value; }
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

        private string _ItemsName;
        public string ItemsName
        {
            get { return _ItemsName; }
            set { _ItemsName = value; }
        }

        private string _ItemsCategoryName;
        public string ItemsCategoryName
        {
            get { return _ItemsCategoryName; }
            set { _ItemsCategoryName = value; }
        }

        private string _ItemsSubCategoryName;
        public string ItemsSubCategoryName
        {
            get { return _ItemsSubCategoryName; }
            set { _ItemsSubCategoryName = value; }
        }
        private string _ItemsUnitName;
        public string ItemsUnitName
        {
            get { return this._ItemsUnitName; }
            set { this._ItemsUnitName = value; }
        }

        private string _Specifications;
        public string Specifications
        {
            get { return this._Specifications; }
            set { this._Specifications = value; }
        }

        private string _JiKhaPaNo;
        public string JiKhaPaNo
        {
            get { return this._JiKhaPaNo; }
            set { this._JiKhaPaNo = value; }
        }

        public ATTMaagFaaramDetail()
        {
        }

        public ATTMaagFaaramDetail(int? orgID, int? unitID, double? reqNo, int? itemsCategoryID, int? itemsSubCategoryID, int? itemsID, int? reqQty)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.ReqNo = reqNo;
            this.ItemsCategoryID = itemsCategoryID;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsID = itemsID;
            this.ReqQty = reqQty;
        }

        public ATTMaagFaaramDetail(int? orgID, int? unitID, double? reqNo, int? itemsCategoryID, int? itemsSubCategoryID, int? itemsID)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.ReqNo = reqNo;
            this.ItemsCategoryID = itemsCategoryID;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsID = itemsID;
        }

    }
}
