using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvItemType
    {
        private int _ItemsTypeID;
        public int ItemsTypeID
        {
            get { return _ItemsTypeID; }
            set { this._ItemsTypeID = value; }
        }

        private string _ItemsTypeName;
        public string ItemsTypeName
        {
            get { return _ItemsTypeName; }
            set { this._ItemsTypeName = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        public ATTInvItemType(int itemsTypeID, string itemsTypeName, string active)
        {
            this.ItemsTypeID = itemsTypeID;
            this.ItemsTypeName = itemsTypeName;    
            this.Active = active;                      
        }

        public ATTInvItemType()
        {
        }
    }
}
