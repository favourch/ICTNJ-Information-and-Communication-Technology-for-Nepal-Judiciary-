using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTPratiuttarEvidence
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _PratiuttarID;
        public int PratiuttarID
        {
            get { return _PratiuttarID; }
            set { _PratiuttarID = value; }
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
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTPratiuttarEvidence()
        {
        }

        public ATTPratiuttarEvidence(double caseID,int pratiuttarID, int evidenceID, string evidence)
        {
            this.CaseID = caseID;
            this.PratiuttarID = pratiuttarID;
            this.EvidenceID = evidenceID;
            this.Evidence = evidence;
        }
    }
}
