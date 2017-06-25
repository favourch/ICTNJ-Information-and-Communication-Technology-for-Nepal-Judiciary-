using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
   public class ATTRegistrationType
    {
        private int _RegTypeID;
        public int RegTypeID
        {
            get { return _RegTypeID; }
            set { _RegTypeID = value; }
        }

        private string _RegTypeName;
        public string RegTypeName
        {
            get { return _RegTypeName; }
            set { _RegTypeName = value; }
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

       public ATTRegistrationType(int regTypeID, string regTypeName, string active)
       {
           this.RegTypeID = regTypeID;
           this.RegTypeName = regTypeName;
           this.Active = active;
       }
    }
}
