using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCheckList
    {
        private int _CheckListID;
        public int CheckListID
        {
            get { return this._CheckListID; }
            set { this._CheckListID = value; }
        }

        private string _CheckListName;
        public string CheckListName
        {
            get { return this._CheckListName; }
            set { this._CheckListName = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _CheckListType;
        public string CheckListType
        {
            get { return _CheckListType; }
            set { _CheckListType = value; }
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

        public ATTCheckList()
        {
        }

        public ATTCheckList(int checkListID, string checkListName, string active)
        {
            this.CheckListID = checkListID;
            this.CheckListName = checkListName;
            this.Active = active;
        }
    }
}
