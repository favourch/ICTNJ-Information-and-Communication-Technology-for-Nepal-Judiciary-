using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTOrgDecisionType
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _DecisionTypeID;
        public int DecisionTypeID
        {
            get { return _DecisionTypeID; }
            set { _DecisionTypeID = value; }
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

        private string  _Action;
        public string  Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	
        public ATTOrgDecisionType()
        { 
        }

        public ATTOrgDecisionType(int orgID, int decTypeID, string active)
        {
            this.OrgID = orgID;
            this.DecisionTypeID = decTypeID;
            this.Active = active;
        }
	
    }
}
