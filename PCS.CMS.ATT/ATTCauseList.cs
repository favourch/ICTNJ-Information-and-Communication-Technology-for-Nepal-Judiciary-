using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCauseList
    {
        private int _CauseListID;
        public int CauseListID
        {
            get { return _CauseListID; }
            set { _CauseListID = value; }
        }

        private string _CauseListName;
        public string CauseListName
        {
            get { return _CauseListName; }
            set { _CauseListName = value; }
        }
        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

       
        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTCauseList()
        {
        }

        public ATTCauseList(int CauseListId, string CauseListName, string active)
        {
            _CauseListID = CauseListId;
            _CauseListName = CauseListName;
            _Active = active;
        }
    }
}
