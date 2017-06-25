using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTPesiType
    {
        private int _PesiTypeID;
        public int PesiTypeID
        {
            get { return _PesiTypeID; }
            set { _PesiTypeID = value; }
        }

        private string _PesiTypeName;
        public string PesiTypeName
        {
            get { return _PesiTypeName; }
            set { _PesiTypeName = value; }
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
	
	
    }
}
