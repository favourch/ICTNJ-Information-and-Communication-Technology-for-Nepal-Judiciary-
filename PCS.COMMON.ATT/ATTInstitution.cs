using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
   public class ATTInstitution
    {
        private long _InstitutionID;

        public long InstitutionID
        {
            get { return _InstitutionID; }
            set { _InstitutionID = value; }
        }

        private string  _InstitutionName;

        public string  InstitutionName
        {
            get { return _InstitutionName; }
            set { _InstitutionName = value; }
        }
        private string _BoardName;

        public string BoardName
        {
            get { return _BoardName; }
            set { _BoardName = value; }
        }
        private string _Location;

        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
	
        private int _CountryID;

        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        private string _Active;

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _InstitutionType;

        public string InstitutionType
        {
            get { return _InstitutionType; }
            set { _InstitutionType = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

	
       private string _InstitutionNameBoardCountry;
       public string InstitutionNameBoardCountry
       {
           get { return this._InstitutionNameBoardCountry; }
           set { this._InstitutionNameBoardCountry = value; }
       }

       public ATTInstitution(long institutionID, string institutionName, string boardName, string location, int countryID, string active,string insType,string entryBy)
       {
           this.InstitutionID = institutionID;
           this.InstitutionName = institutionName;
           this.BoardName = boardName;
           this.Location = location;
           this.CountryID = countryID;
           this.Active = active;
           this.InstitutionType = insType;
           this.EntryBy = entryBy;
       }

       public ATTInstitution(long institutionID, string institutionName, string boardName, string location, int countryID, string active)
       {
           this.InstitutionID = institutionID;
           this.InstitutionName = institutionName;
           this.BoardName = boardName;
           this.Location = location;
           this.CountryID = countryID;
           this.Active = active;
       }
	
    }
}
