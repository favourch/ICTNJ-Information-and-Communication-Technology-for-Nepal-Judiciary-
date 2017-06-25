using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTBenchType
    {
        private int _BenchTypeID;
        public int BenchTypeID
        {
            get { return _BenchTypeID; }
            set { _BenchTypeID = value; }
        }

        private string _BenchTypeName;
        public string BenchTypeName
        {
            get { return _BenchTypeName; }
            set { _BenchTypeName = value; }
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
        private List<ATTOrganisationBenchType> _OrganisationBenchTypeLIST = new List<ATTOrganisationBenchType>();

        public List<ATTOrganisationBenchType> OrganisationBenchTypeLIST
        {
            get { return _OrganisationBenchTypeLIST; }
            set { _OrganisationBenchTypeLIST = value; }
        }
	
	
	
	
    }
}
