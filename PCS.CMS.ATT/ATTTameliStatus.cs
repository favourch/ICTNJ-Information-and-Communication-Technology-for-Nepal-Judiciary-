using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTTameliStatus
    {
       
        private int? _TameliStatusID;
        public int? TameliStatusID
        {
            get { return _TameliStatusID; }
            set { _TameliStatusID = value; }
        }

        private string _TameliStatusName;
        public string TameliStatusName
        {
            get { return _TameliStatusName; }
            set { _TameliStatusName = value; }
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

        private string _EntryDate;
        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public ATTTameliStatus()
        { }
        public ATTTameliStatus(int tameliStatusID, string tameliStatusName, string active)
        {
            this.TameliStatusID = tameliStatusID;
            this.TameliStatusName = tameliStatusName;
            this.Active = active;
        }
    }
}
