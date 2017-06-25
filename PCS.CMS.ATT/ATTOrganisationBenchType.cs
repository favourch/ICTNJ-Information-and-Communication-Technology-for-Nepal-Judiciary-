using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTOrganisationBenchType
    {
        private int _OrganisationID;
        public int OrganisationID
        {
            get { return _OrganisationID; }
            set { _OrganisationID = value; }
        }
	    
        private int _BenchTypeID;
        public int BenchTypeID
        {
            get { return _BenchTypeID; }
            set { _BenchTypeID = value; }
        }

        private string _OrganisationName;
        public string OrganisationName
        {
            get { return _OrganisationName; }
            set { _OrganisationName = value; }
        }
        private string _BenchTypeName;
        public string BenchTypeName
        {
            get { return _BenchTypeName; }
            set { _BenchTypeName = value; }
        }

        private int _Cardinality;
        public int Cardinality
        {
            get { return _Cardinality; }
            set { _Cardinality = value; }
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

    }
}
