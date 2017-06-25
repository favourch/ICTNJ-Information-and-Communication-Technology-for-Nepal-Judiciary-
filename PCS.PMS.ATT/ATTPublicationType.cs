using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPublicationType
    {
        private int? _PubTypeID;

        public int? PubTypeID
        {
            get { return _PubTypeID; }
            set { _PubTypeID = value; }
        }

        private string _PubTypeName;

        public string PubTypeName
        {
            get { return _PubTypeName; }
            set { _PubTypeName = value; }
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

        public ATTPublicationType()
        {
        }

        public ATTPublicationType(int? pubtypeid, string pubtypename, string active, string entryby, string action)
        {
            this.PubTypeID = pubtypeid;
            this.PubTypeName = pubtypename;
            this.Active = active;
            this.EntryBy = entryby;
            this.Action = action;
        }

        public ATTPublicationType(int? pubtypeid, string pubtypename, string active,string action)
        {
            this.PubTypeID = pubtypeid;
            this.PubTypeName = pubtypename;
            this.Active = active;
            this.Action = action;
        }
    }
}
