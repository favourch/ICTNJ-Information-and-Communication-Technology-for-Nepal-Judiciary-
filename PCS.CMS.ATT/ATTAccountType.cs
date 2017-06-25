using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTAccountType
    {
       
        private int _AccountTypeID;
        public int AccountTypeID
        {
            get { return _AccountTypeID; }
            set { _AccountTypeID = value; }
        }
        private string _AccountTypeName;
        public string AccountTypeName
        {
            get { return _AccountTypeName; }
            set { _AccountTypeName = value; }
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


        public ATTAccountType(int accountTypeID, string accountTypeName, string active)
        {
            this.AccountTypeID = accountTypeID;
            this.AccountTypeName = accountTypeName;
            this.Active = active;
        }

    }
}
