using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseStatus
    {
         private int _CaseStatusID;
        public int CaseStatusID
        {
            get { return _CaseStatusID; }
            set { _CaseStatusID = value; }
        }

        private string _CaseStatusName;
        public string CaseStatusName
        {
            get { return _CaseStatusName; }
            set { _CaseStatusName = value; }
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

        public ATTCaseStatus()
        {
        }

        public ATTCaseStatus(int caseStatusID, string caseStatusName, string active)
        {
            this.CaseStatusID = caseStatusID;
            this.CaseStatusName = caseStatusName;
            this.Active = active;
        }
    }
}
