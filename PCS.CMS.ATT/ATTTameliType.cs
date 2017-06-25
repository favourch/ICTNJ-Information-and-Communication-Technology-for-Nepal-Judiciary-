using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public   class ATTTameliType
    {
        private int? _TameliTypeID;
        public int? TameliTypeID
        {
            get { return _TameliTypeID; }
            set { _TameliTypeID = value; }
        }

        private string _TameliTypeName;
        public string TameliTypeName
        {
            get { return _TameliTypeName; }
            set { _TameliTypeName = value; }
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

        private string _EntryDate;
        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public ATTTameliType()
        { }
        public ATTTameliType(int tameliTypeID, string tameliTypeName, string active)
        {
            this.TameliTypeID = tameliTypeID;
            this.TameliTypeName = tameliTypeName;
            this.Active = active;
        }
    }
}
