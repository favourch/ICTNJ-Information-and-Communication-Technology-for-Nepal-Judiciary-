using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvDakhila
    {
        private int? _OrgID;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
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
            get { return this._ItemsCategoryName; }
            set { this._ItemsCategoryName = value; }
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
            get { return this._ItemsSubCategoryName; }
            set { this._ItemsSubCategoryName = value; }
        }

        private int _ItemsID;
        public int ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }

        private string _ItemsName;
        public string ItemsName
        {
            get { return _ItemsName; }
            set { _ItemsName = value; }
        }

        private int? _DirectEntrySeq = null;
        public int? DirectEntrySeq
        {
            get { return this._DirectEntrySeq; }
            set { this._DirectEntrySeq = value; }
        }

        private string _DirectEntryDate;
        public string DirectEntryDate
        {
            get { return _DirectEntryDate; }
            set { _DirectEntryDate = value; }
        }

        private string _DirectEntryType;
        public string DirectEntryType
        {
            get { return _DirectEntryType; }
            set { _DirectEntryType = value; }
        }

        private string _DonationOrg;
        public string DonationOrg
        {
            get { return _DonationOrg; }
            set { _DonationOrg = value; }
        }


        private double _UnitPrice;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        private int _Quantity;
        public int Quantity
        {
            get { return this._Quantity; }
            set { this._Quantity = value; }
        }



        private string _JelaaKhataNo ="";
        public string JelaaKhataNo
        {
            get { return _JelaaKhataNo; }
            set { _JelaaKhataNo = value; }
        }

        private int _AppBy ;
        public int AppBy
        {
            get { return _AppBy; }
            set { _AppBy = value; }
        }

        private string _AppDate = "";
        public string AppDate
        {
            get { return _AppDate; }
            set { _AppDate = value; }
        }

        private string _AppYesNo = "";
        public string AppYesNo
        {
            get { return _AppYesNo; }
            set { _AppYesNo = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private int? _ItemsTypeID = null;
        public int? ItemsTypeID
        {
            get { return _ItemsTypeID; }
            set { _ItemsTypeID = value; }
        }

        private List<ATTInvOrgItemsKNJ> _LstKNJ = new List<ATTInvOrgItemsKNJ>();
        public List<ATTInvOrgItemsKNJ> LstKNJ
        {
            get { return _LstKNJ; }
            set { _LstKNJ = value; }
        }

        public ATTInvDakhila()
        {
        }


    }
}
