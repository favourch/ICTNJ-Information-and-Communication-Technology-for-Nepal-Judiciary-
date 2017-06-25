using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTSectionClerkCase
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
        private int _CaseTypeID;
        public int CaseTypeID
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
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }
        private double _SectionClerkID;
        public double SectionClerkID
        {
            get { return _SectionClerkID; }
            set { _SectionClerkID = value; }
        }
        private string _SectionClerkFromDate;
        public string SectionClerkFromDate
        {
            get { return _SectionClerkFromDate; }
            set { _SectionClerkFromDate = value; }
        }
        private string _SectionClerkToDate;
        public string SectionClerkToDate
        {
            get { return _SectionClerkToDate; }
            set { _SectionClerkToDate = value; }
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
	
        public ATTSectionClerkCase()
        {
        }
	
    }
}
