using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    [Serializable]
    public class ATTOrganizationSection
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

        private int _SectionID;

        public int SectionID
        {
            get { return _SectionID; }
            set { _SectionID = value; }
        }

        private string _SectionName;

        public string SectionName
        {
            get { return _SectionName; }
            set { _SectionName = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string  _Action;

        public string  Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        public ATTOrganizationSection()
        {
        }

        public ATTOrganizationSection(int orgid, int unitid, int sectionid, string sectionname, string entryby,string action)
        {
            this.OrgID = orgid;
            this.UnitID = unitid;
            this.SectionID = sectionid;
            this.SectionName = sectionname;
            this.EntryBy = entryby;
            this.Action = action;
        }
	
	
	
    }
}
