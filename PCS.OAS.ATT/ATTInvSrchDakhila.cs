using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvSrchDakhila
    {
        private int? _OrgID = null;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int? _ItemsCategoryID =null;
        public int? ItemsCategoryID
        {
            get { return _ItemsCategoryID; }
            set { _ItemsCategoryID = value; }
        }

        
        private int? _ItemsSubCategoryID = null;
        public int? ItemsSubCategoryID
        {
            get { return _ItemsSubCategoryID; }
            set { _ItemsSubCategoryID = value; }
        }

        private int? _ItemsID = null;
        public int? ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }

        private string _DirectEntryDate = "";
        public string DirectEntryDate
        {
            get { return _DirectEntryDate; }
            set { _DirectEntryDate = value; }
        }

        public ATTInvSrchDakhila()
        {
        }

    }
}
