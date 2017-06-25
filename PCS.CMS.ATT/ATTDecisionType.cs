using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTDecisionType
    {
        private int _DecisionTypeID;
        public int DecisionTypeID
        {
            get { return _DecisionTypeID; }
            set { _DecisionTypeID = value; }
        }

        private string _DecisionTypeName;
        public string DecisionTypeName
        {
            get { return _DecisionTypeName; }
            set { _DecisionTypeName = value; }
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


        private List<ATTOrgDecisionType> _LstOrgDecisionType = new List<ATTOrgDecisionType>();
        public List<ATTOrgDecisionType> LstOrgDecisionType
        {
            get { return _LstOrgDecisionType; }
            set { _LstOrgDecisionType = value; }
        }

        public ATTDecisionType()
        {
        }

        public ATTDecisionType(int decisionTypeID, string  decisionTypeName, string active)
        {
            this.DecisionTypeID = decisionTypeID;
            this.DecisionTypeName = decisionTypeName;
            this.Active = active;
        }
	
	
    }
}
