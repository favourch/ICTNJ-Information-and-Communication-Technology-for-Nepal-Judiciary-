using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTCommitteeByTippani
    {
        private int _CommitteeOrgID;
        public int CommitteeOrgID
        {
            get { return this._CommitteeOrgID; }
            set { this._CommitteeOrgID = value; }
        }

        private string _CommitteeOrgName;
        public string CommitteeOrgName
        {
            get { return this._CommitteeOrgName.Trim(); }
            set { this._CommitteeOrgName = value; }
        }

        private int _CommitteeID;
        public int CommitteeID
        {
            get { return this._CommitteeID; }
            set { this._CommitteeID = value; }
        }

        private string _CommitteeName;
        public string CommitteeName
        {
            get { return this._CommitteeName.Trim(); }
            set { this._CommitteeName = value; }
        }

        private string _Description;
        public string Description
        {
            get { return this._Description.Trim(); }
            set { this._Description = value; }
        }

        private string _Type;
        public string Type
        {
            get { return this._Type.Trim(); }
            set { this._Type = value; }
        }

        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _TippaniID;
        public int TippaniID
        {
            get { return this._TippaniID; }
            set { this._TippaniID = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTCommitteeByTippani()
        {

        }
    }
}
