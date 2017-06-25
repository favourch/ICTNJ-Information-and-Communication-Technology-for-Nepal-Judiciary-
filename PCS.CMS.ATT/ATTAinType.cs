using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTAinType
    {
        private int _AinTypeID;
        public int AinTypeID
        {
            get { return _AinTypeID; }
            set { _AinTypeID = value; }
        }

        private string _AinTypeName;
        public string AinTypeName
        {
            get { return _AinTypeName; }
            set { _AinTypeName = value; }
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
	

        public ATTAinType(int ainTypeID, string ainTypeName, string active)
        {
            this.AinTypeID = ainTypeID;
            this.AinTypeName = ainTypeName;
            this.Active = active;
        }
    }
}
