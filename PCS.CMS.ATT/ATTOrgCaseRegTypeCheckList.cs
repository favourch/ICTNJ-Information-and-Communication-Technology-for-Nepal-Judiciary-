using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTOrgCaseRegTypeCheckList
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _CaseTypeID;
        public int CaseTypeID
        {
            get { return _CaseTypeID; }
            set { _CaseTypeID = value; }
        }

        private int _RegTypeID;
        public int RegTypeID
        {
            get { return _RegTypeID; }
            set { _RegTypeID = value; }
        }
	
        private int _CheckListID;
        public int CheckListID
        {
            get { return _CheckListID; }
            set { _CheckListID = value; }
        }

        private string _CheckListName;
        public string CheckListName
        {
            get { return _CheckListName; }
            set { _CheckListName = value; }
        }

        private string _CheckListType;
        public string CheckListType
        {
            get { return _CheckListType; }
            set { _CheckListType = value; }
        }
	
        private string _EntryBY;
        public string EntryBY
        {
            get { return _EntryBY; }
            set { _EntryBY = value; }
        }
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public ATTOrgCaseRegTypeCheckList()
        {
        }

        public ATTOrgCaseRegTypeCheckList(int orgID, int caseTypeID, int regTypeID, int checkListID, string checkListName, string entryBY,string active, string action)
        {
            this.OrgID = orgID;
            this.CaseTypeID = caseTypeID;
            this.RegTypeID = regTypeID;
            this.CheckListID = checkListID;
            this.CheckListName = checkListName;
            this.EntryBY = entryBY;
            this.Active = active;
            this.Action = action;
        }
	
    }
}
