using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTKeyword
    {
        private int _KeywordID;
        public int KeywordID
        {
            get { return this._KeywordID; }
            set { this._KeywordID = value; }
        }

        private string _KeywordName;
        public string KeywordName
        {
            get { return this._KeywordName.Trim(); }
            set { this._KeywordName = value; }
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

        public ATTKeyword()
        {
        }

        public ATTKeyword(int keywordID, string keywordName)
        {
            this.KeywordID = keywordID;
            this.KeywordName = keywordName;
        }

        public ATTKeyword(int keywordID, string keywordName, string entryBy, DateTime entryOn)
        {
            this.KeywordID = keywordID;
            this.KeywordName = keywordName;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
        }

        public override string ToString()
        {
            return this.KeywordName;
        }
    }
}
