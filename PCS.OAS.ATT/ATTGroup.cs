using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTGroup
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _GroupID;
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private string _GroupName;
        public string GroupName
        {
            get { return this._GroupName; }
            set { this._GroupName = value; }
        }

        private string _Description;
        public string Description
        {
            get { return this._Description; }
            set { this._Description = value; }
        }

        private char _Type;

        public char Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTGroupMember> _LstGroupMember = new List<ATTGroupMember>();
        public List<ATTGroupMember> LstGroupMember
        {
            get { return this._LstGroupMember; }
            set { this._LstGroupMember = value; }
        }

        public ATTGroup()
        {
        }


        public ATTGroup(int orgID, int groupID, string groupName, string description, string active)
        {
            OrgID = orgID;
            GroupID = groupID;
            GroupName = groupName;
            Description = description;
            Active = active;
        }
    }
}
