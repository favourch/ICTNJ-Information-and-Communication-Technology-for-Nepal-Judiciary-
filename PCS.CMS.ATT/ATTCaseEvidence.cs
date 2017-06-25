using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseEvidence
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _EvidenceID;
        public int EvidenceID
        {
            get { return _EvidenceID; }
            set { _EvidenceID = value; }
        }

        private string _Evidence;
        public string Evidence
        {
            get { return _Evidence; }
            set { _Evidence = value; }
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
