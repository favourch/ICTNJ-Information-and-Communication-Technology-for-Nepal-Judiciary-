using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTPratiuttarLitigants
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

        private double _LitigantID;
        public double LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
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

        public ATTPratiuttarLitigants()
        {
        }

        public ATTPratiuttarLitigants(double caseID,int pratiuttarID, double litigantID)
        {
            this.CaseID = caseID;
            this.PratiuttarID = pratiuttarID;
            this.LitigantID = litigantID;
        }
    }
}
