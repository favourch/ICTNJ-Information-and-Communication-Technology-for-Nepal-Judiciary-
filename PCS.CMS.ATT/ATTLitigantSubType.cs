using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTLitigantSubType
    {
        private int? _LitigantSubTypeID;
        public int? LitigantSubTypeID
        {
            get { return _LitigantSubTypeID; }
            set { _LitigantSubTypeID = value; }
        }

        private string _LitigantSubTypeName;
        public string LitigantSubTypeName
        {
            get { return _LitigantSubTypeName; }
            set { _LitigantSubTypeName = value; }
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

        public ATTLitigantSubType()
        { }
        public ATTLitigantSubType(int litigantSubTypeID, string litigantSubTypeName, string active)
        {
            this.LitigantSubTypeID = litigantSubTypeID;
            this.LitigantSubTypeName = litigantSubTypeName;
            this.Active = active;
        }
    }
}
