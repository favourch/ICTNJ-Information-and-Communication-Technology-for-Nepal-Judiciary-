using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvOrgItemsKNJ
    {
        private int? _OrgID;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _OrgName;

        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
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


        private int? _KNJSeq = null;
        public int? KNJSeq
        {
            get { return this._KNJSeq; }
            set { this._KNJSeq = value; }
        }

        private string _ItemsAttrib;
        public string ItemsAttrib
        {
            get { return _ItemsAttrib; }
            set { _ItemsAttrib = value; }
        }

        private string _VehRegNo;
        public string VehRegNo
        {
            get { return _VehRegNo; }
            set { _VehRegNo = value; }
        } 
        
        
        private string _ItemsStatus;
        public string ItemsStatus
        {
            get { return _ItemsStatus; }
            set { _ItemsStatus = value; }
        }

        private int _ItemsTypeID;

        public int ItemsTypeID
        {
            get { return _ItemsTypeID; }
            set { _ItemsTypeID = value; }
        }

        private string _ItemsTypeName;

        public string ItemsTypeName
        {
            get { return _ItemsTypeName; }
            set { _ItemsTypeName = value; }
        }

        private string _ItemsDescription;
        public string ItemsDescription
        {
            get
            {
                return this.ItemsName + "(" + this.KNJSeq.ToString() + ")";
            }
            set
            {
                _ItemsDescription = value;
            }
        }

        private int _ItemsUnitID;

        public int ItemsUnitID
        {
            get { return _ItemsUnitID; }
            set { _ItemsUnitID = value; }
        }

        private string _ItemsUnitName;

        public string ItemsUnitName
        {
            get { return _ItemsUnitName; }
            set { _ItemsUnitName = value; }
        }


        private string _JI_KHA_PA_NO;

        public string JI_KHA_PA_NO
        {
            get { return _JI_KHA_PA_NO; }
            set { _JI_KHA_PA_NO = value; }
        }


        private string _PK;

        public string PK
        {
            get { return OrgID.ToString() + ItemsCategoryID.ToString() + ItemsSubCategoryID.ToString() + ItemsID.ToString() + KNJSeq.ToString(); }
            set { _PK = value; }
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

        public ATTInvOrgItemsKNJ()
        {
        }

        public ATTInvOrgItemsKNJ(int itemID, string itemdescription)
        {
            this.ItemsID = itemID;
            this.ItemsDescription = itemdescription;
        }
    }
}
