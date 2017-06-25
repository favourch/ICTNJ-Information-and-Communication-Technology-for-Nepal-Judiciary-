using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvPurchaseOrderDetail
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

        private int? _SectionID;
        public int? SectionID
        {
            get { return this._SectionID; }
            set { this._SectionID = value; }
        }

        private string _OrderNo;
        public string OrderNo
        {
            get { return this._OrderNo; }
            set { this._OrderNo = value; }
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

        private double? _UnitPrice;
        public double? UnitPrice
        {
            get { return this._UnitPrice; }
            set { this._UnitPrice = value; }
        }

        private int? _TotalQty;
        public int? TotalQty
        {
            get { return this._TotalQty; }
            set { this._TotalQty = value; }
        }

        

        private double? _TotalPrice;
        public double? TotalPrice
        {
            get { return this._TotalPrice; }
            set { this._TotalPrice = value; }
        }

        private string _ManuCompany;
        public string ManuCompany
        {
            get { return this._ManuCompany; }
            set { this._ManuCompany = value; }
        }

        private string _ManuDate;
        public string ManuDate
        {
            get { return this._ManuDate; }
            set { this._ManuDate = value; }
        }

        private string _Brand;
        public string Brand
        {
            get { return this._Brand; }
            set { this._Brand = value; }
        }


        private string _Specification;
        public string Specification
        {
            get { return this._Specification; }
            set { this._Specification = value; }
        }

        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }
        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        private string _Action = "";
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTInvPurchaseOrderDetail()
        {
        }

        public ATTInvPurchaseOrderDetail(int? itemsCategoryID, string itemsCategoryName, int? itemsSubCategoryID,string  itemsSubCategoryName,
                                         int? itemsID, string itemName, double? unitPrice, int? totalQty,string action)
        {
            this.ItemsCategoryID = itemsCategoryID;
            this.ItemsCategoryName = itemsCategoryName;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsSubCategoryName = itemsSubCategoryName;
            this.ItemsID = itemsID;
            this.ItemsName = itemName;
            this.UnitPrice = unitPrice;
            this.TotalQty = totalQty;
            this.Action = action;
        }

        public ATTInvPurchaseOrderDetail(int? itemsCategoryID, string itemsCategoryName, int? itemsSubCategoryID, string itemsSubCategoryName,
                                       int? itemsID, string itemName, double? unitPrice, int? totalQty,
                                       string manuCompany,string manuDate,string brand,string specification, string action)
        {
            this.ItemsCategoryID = itemsCategoryID;
            this.ItemsCategoryName = itemsCategoryName;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsSubCategoryName = itemsSubCategoryName;
            this.ItemsID = itemsID;
            this.ItemsName = itemName;
            this.UnitPrice = unitPrice;
            this.TotalQty = totalQty;
            this.ManuCompany = manuCompany;
            this.ManuDate = manuDate;
            this.Brand = brand;
            this.Specification = specification;
            this.Action = action;
        }

        public ATTInvPurchaseOrderDetail(int? itemsCategoryID, string itemsCategoryName, int? itemsSubCategoryID, string itemsSubCategoryName,
                                       int? itemsID, string itemName, double? unitPrice, int? totalQty,
                                       string manuCompany, string manuDate, string brand,string action)
        {
            this.ItemsCategoryID = itemsCategoryID;
            this.ItemsCategoryName = itemsCategoryName;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsSubCategoryName = itemsSubCategoryName;
            this.ItemsID = itemsID;
            this.ItemsName = itemName;
            this.UnitPrice = unitPrice;
            this.TotalQty = totalQty;
            this.ManuCompany = manuCompany;
            this.ManuDate = manuDate;
            this.Brand = brand;
            this.Action = action;
        }

    }
}
