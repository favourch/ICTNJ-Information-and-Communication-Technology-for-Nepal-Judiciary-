using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvOrgItemsPrice
    {

        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int? _ItemsCategoryID;
        public int? ItemsCategoryID
        {
            get { return _ItemsCategoryID; }
            set { _ItemsCategoryID = value; }
        }

        private string _ItemsCategoryName;
        public string ItemsCategoryName
        {
            get { return _ItemsCategoryName; }
            set { _ItemsCategoryName = value; }
        }
	

        private int? _ItemsSubCategoryID;
        public int? ItemsSubCategoryID
        {
            get { return _ItemsSubCategoryID; }
            set { _ItemsSubCategoryID = value; }
        }

        private string _ItemsSubCategoryName;
        public string ItemsSubCategoryName
        {
            get { return _ItemsSubCategoryName; }
            set { _ItemsSubCategoryName = value; }
        }
	

        private int _ItemsID;
        public int ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }

        private string _ItemCD;
        public string ItemCD
        {
            get { return _ItemCD; }
            set { _ItemCD = value; }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private string _ItemShortName;
        public string ItemShortName
        {
            get { return _ItemShortName; }
            set { _ItemShortName = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        
        private double _UnitPrice;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private int _ItemsTypeID;
        public int ItemsTypeID
        {
            get { return this._ItemsTypeID; }
            set { this._ItemsTypeID = value; }
        }

        private string _ItemsTypeName;
        public string ItemsTypeName
        {
            get { return this._ItemsTypeName; }
            set { this._ItemsTypeName = value; }
        }

        private int _ItemsUnitID;
        public int ItemsUnitID
        {
            get { return this._ItemsUnitID; }
            set { this._ItemsUnitID = value; }
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

        private string _IssuedTo;
        public string IssuedTo
        {
            get { return this._IssuedTo; }
            set { this._IssuedTo = value; }
        }

        private string _JiKhaPaNo;
        public string JiKhaPaNo
        {
            get { return this._JiKhaPaNo; }
            set { this._JiKhaPaNo = value; }
        }

        private int? _Quantity;
        public int? Quantity
        {
            get { return this._Quantity; }
            set { this._Quantity = value; }
        }
	

       public ATTInvOrgItemsPrice()
        { }

	
	
	
	
	
	
	
	
    }
}
