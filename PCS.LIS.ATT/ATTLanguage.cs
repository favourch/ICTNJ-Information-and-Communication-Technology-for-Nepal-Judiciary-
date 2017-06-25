using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTLanguage
    {
        private int _LanguageID;
        public int LanguageID
        {
            get { return this._LanguageID; }
            set { this._LanguageID = value; }
        }

        private string _LanguageName;
        public string LanguageName
        {
            get { return this._LanguageName.Trim(); }
            set { this._LanguageName = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        public ATTLanguage(int languageID, string languageName)
        {
            this.LanguageID = languageID;
            this.LanguageName = languageName;
           
        }

        public ATTLanguage(int languageID, string languageName, string entryBy, DateTime entryOn)
        {
            this.LanguageID = languageID;
            this.LanguageName = languageName;
            this.EntryBy = entryBy;
        }
    }
}
