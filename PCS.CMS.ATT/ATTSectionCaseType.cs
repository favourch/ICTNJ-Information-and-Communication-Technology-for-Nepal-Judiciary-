using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTSectionCaseType
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _UnitID;
        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        private string _UnitName;
        public string UnitName
        {
            get { return _UnitName; }
            set { _UnitName = value; }
        }
	
        private int? _CaseTypeID;
        public int? CaseTypeID
        {
            get { return _CaseTypeID; }
            set { _CaseTypeID = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
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
	
        public ATTSectionCaseType()
        {
        }
    }
}
