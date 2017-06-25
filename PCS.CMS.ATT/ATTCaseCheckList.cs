using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseCheckList
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

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



        private string _FulFilled;
        public string FulFilled
        {
            get { return _FulFilled; }
            set { _FulFilled = value; }
        }

        public bool CheckedYN
        {
            get { return _FulFilled == "Y" ? true : false; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
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


        public ATTCaseCheckList()
        {
        }

    }
}
