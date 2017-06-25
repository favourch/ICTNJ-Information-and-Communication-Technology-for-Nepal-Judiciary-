using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseProceeding
    {
        private int _CaseProceedingID;
        public int CaseProceedingID
        {
            get { return _CaseProceedingID; }
            set { _CaseProceedingID = value; }
        }
        private string _CaseProceedingName;
        public string CaseProceedingName
        {
            get { return _CaseProceedingName; }
            set { _CaseProceedingName = value; }
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


        public ATTCaseProceeding(int caseProceedingID, string caseProceedingName, string active)
        {
            this.CaseProceedingID = caseProceedingID;
            this.CaseProceedingName = caseProceedingName;
            this.Active = active;
        }

    }
}