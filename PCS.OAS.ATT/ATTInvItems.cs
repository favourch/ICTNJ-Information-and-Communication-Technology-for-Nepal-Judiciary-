using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvItems
    {
        private int? _ItemsCategoryID;
        public int? ItemsCategoryID
        {
            get { return _ItemsCategoryID; }
            set { _ItemsCategoryID = value; }
        }

        private int? _ItemsSubCategoryID;
        public int? ItemsSubCategoryID
        {
            get { return _ItemsSubCategoryID; }
            set { _ItemsSubCategoryID = value; }
        }

        private int _ItemsID;
        public int ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }

        private string _ItemsCD;
        public string ItemsCD
        {
            get { return _ItemsCD; }
            set { _ItemsCD = value; }
        }

        private string _ItemsName;
        public string ItemsName
        {
            get { return _ItemsName; }
            set { _ItemsName = value; }
        }

        private string _ItemsShortName;
        public string ItemsShortName
        {
            get { return _ItemsShortName; }
            set { _ItemsShortName = value; }
        }

        private int _ItemsTypeID;
        public int ItemsTypeID
        {
            get { return _ItemsTypeID; }
            set { _ItemsTypeID = value; }
        }

        //private string _GKPNo;
        //public string GKPNo
        //{
        //    get { return _GKPNo; }
        //    set { _GKPNo = value; }
        //}

        private string _ItemsSpecification;
        public string ItemsSpecification
        {
            get { return _ItemsSpecification; }
            set { _ItemsSpecification = value; }
        }

        private int _ItemsUnitID;
        public int ItemsUnitID
        {
            get { return _ItemsUnitID; }
            set { _ItemsUnitID = value; }
        }

        private string _IssuedTo;
        public string IssuedTo
        {
            get { return _IssuedTo; }
            set { _IssuedTo = value; }
        }


        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
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

        private string _ItemsTypeName;
        public string ItemsTypeName
        {
            get { return _ItemsTypeName; }
            set { _ItemsTypeName = value; }
        }

        private string _ItemsUnitName;
        public string ItemsUnitName
        {
            get { return _ItemsUnitName; }
            set { _ItemsUnitName = value; }
        }

        public ATTInvItems()
        {
        }

        public ATTInvItems(int itemscatgoryID, int itemsID, string itemsName, string itemsShortName, int itemsTypeID, int itemsUnitID, string issuedTo, string active)
        {
            this.ItemsCategoryID = itemscatgoryID;
            this.ItemsID = itemsID;
            this.ItemsName = itemsName;
            this.ItemsShortName = itemsShortName;
            this.ItemsTypeID = itemsTypeID;
            this.ItemsUnitID = itemsUnitID;
            this.IssuedTo = issuedTo;
            this.Active = active;
        }

        public ATTInvItems(int itemscatgoryID, int itemsSubCategoryID, int itemsID, string itemsCD, string itemsName, string itemsShortName, int itemsTypeID, string specification, int itemsUnitID, string issuedTo, string active)
        {
            this.ItemsCategoryID = itemscatgoryID;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsID = itemsID;
            this.ItemsCD = itemsCD;
            this.ItemsName = itemsName;
            this.ItemsShortName = itemsShortName;
            this.ItemsTypeID = itemsTypeID;
            //this.GKPNo = gkpno;
            this.ItemsSpecification = specification;
            this.ItemsUnitID = itemsUnitID;
            this.IssuedTo = issuedTo;
            this.Active = active;            
        }

        public ATTInvItems(int itemscatgoryID, int itemsSubCategoryID, int itemsID, string itemsCD, string itemsName, string itemsShortName, int itemsTypeID, string specification, int itemsUnitID, string issuedTo, string active, string entryby)
        {
            this.ItemsCategoryID = itemscatgoryID;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsID = itemsID;
            this.ItemsCD = itemsCD;
            this.ItemsName = itemsName;
            this.ItemsShortName = itemsShortName;
            this.ItemsTypeID = itemsTypeID;
            //this.GKPNo = gkpno;
            this.ItemsSpecification = specification;
            this.ItemsUnitID = itemsUnitID;
            this.IssuedTo = issuedTo;
            this.Active = active;
            this.EntryBy = entryby;
        }

        public ATTInvItems(int itemscatgoryID, int itemsSubCategoryID, int itemsID, string itemsCD, string itemsName, string itemsShortName, int itemsTypeID, int itemsUnitID, string active, string entryby)
        {
            this.ItemsCategoryID = itemscatgoryID;
            this.ItemsSubCategoryID = itemsSubCategoryID;
            this.ItemsID = itemsID;
            this.ItemsCD = itemsCD;
            this.ItemsName = itemsName;
            this.ItemsShortName = itemsShortName;
            this.ItemsTypeID = itemsTypeID;
            this.ItemsUnitID = itemsUnitID;
            this.Active = active;
            this.EntryBy = entryby;
        }
    }
}
