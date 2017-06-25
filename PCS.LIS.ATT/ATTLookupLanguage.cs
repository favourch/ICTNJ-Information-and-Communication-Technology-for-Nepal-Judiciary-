using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    
    public class ATTLookupLanguage
    {
        private int _LookupLanguageID;
        public int LookupLanguageID
        {
            get {return this._LookupLanguageID;}
            set {this._LookupLanguageID = value;}
        }

        private string  _LookupLanguageName;
        public string LookupLanguageName
        {
            get {return this._LookupLanguageName;}
            set {this._LookupLanguageName = value;}
        }
        private string _LookupLanguageEntryBy;
        public string LookupLanguageEntryBy
        {
            get { return this._LookupLanguageEntryBy; }
            set { this._LookupLanguageEntryBy = value; }
        }

        private string _EntryOn;
        public string EntryOn
        {
            get {return this._EntryOn;}
            set { this._EntryOn = value; }

        }

        public ATTLookupLanguage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public ATTLookupLanguage(int languageID,string lookupLanguageName, string lookupLanguageEntryBy, string entryOn)
        {
            this.LookupLanguageID = languageID;
            this.LookupLanguageName = lookupLanguageName;
            this.LookupLanguageEntryBy = lookupLanguageEntryBy;
            this.EntryOn = entryOn;
        }
        public ATTLookupLanguage(int languageID, string lookupLanguageName)
        {
            this.LookupLanguageID = languageID;
            this.LookupLanguageName = lookupLanguageName;
        }
        public ATTLookupLanguage(string lookupLanguageName, string lookupLanguageEntryBy)
        {
            
            this.LookupLanguageName = lookupLanguageName;
            this.LookupLanguageEntryBy = lookupLanguageEntryBy;
        }
        public ATTLookupLanguage(int id)
        {
            this.LookupLanguageID = id;
        }
    }
}
