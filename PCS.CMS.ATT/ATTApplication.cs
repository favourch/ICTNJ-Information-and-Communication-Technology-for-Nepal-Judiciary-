using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTApplication
    {
        private int _ApplicationID;
        public int ApplicationID
        {
            get { return _ApplicationID; }
            set { _ApplicationID = value; }
        }

        private string _ApplicationName;
        public string ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        private String _ApplicationType;
        public String ApplicationType
        {
            get { return _ApplicationType; }
            set { _ApplicationType = value; }
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


        private List<ATTOrgApplication> _OrgApplicationLST = new List<ATTOrgApplication>();
        public List<ATTOrgApplication> OrgApplicationLST
        {
            get { return this._OrgApplicationLST; }
            set { this._OrgApplicationLST = value; }
        }
	
	
	
	
	
    }
}
