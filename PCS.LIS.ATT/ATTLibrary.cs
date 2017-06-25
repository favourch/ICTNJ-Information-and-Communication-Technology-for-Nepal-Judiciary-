using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTLibrary
    {
        private int _LibraryID;
        public int LibraryID
        {
            get { return this._LibraryID; }
            set { this._LibraryID = value; }
        }

        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _LibraryName;
        public string LibraryName
        {
            get { return this._LibraryName.Trim(); }
            set { this._LibraryName = value; }
        }

        private string _Location;
        public string Location
        {
            get { return this._Location.Trim(); }
            set { this._Location = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        private List<ATTLibrary> _LstLibraryName;
        public List<ATTLibrary> LstLibraryName
        {
            get { return _LstLibraryName; }
            set { _LstLibraryName = value; }
        }

        public ATTLibrary()
        {
        }

        public ATTLibrary(int orgID, int libraryID, string libraryName)
        {
            this.OrgID = orgID;
            this.LibraryID = libraryID;
            this.LibraryName = libraryName;
        }

        public ATTLibrary(int libraryID, int orgID, string libraryName, string location, string entryBy, DateTime entryOn)
        {
            this.LibraryID = libraryID;
            this.OrgID = orgID;
            this.LibraryName = libraryName;
            this.Location = location;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
        }
    }
}
