using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTLibraryMaterialKeyword
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _LibraryID;
        public int LibraryID
        {
            get { return this._LibraryID; }
            set { this._LibraryID = value; }
        }

        private long _LMaterialID;
        public long LMaterialID
        {
            get { return this._LMaterialID; }
            set { this._LMaterialID = value; }
        }

        //private int _KeywordID;
        //public int KeywordID
        //{
        //    get { return this._KeywordID; }
        //    set { this._KeywordID = value; }
        //}

        private ATTKeyword _Keyword = new ATTKeyword();
        public ATTKeyword Keyword
        {
            get { return this._Keyword; }
            set { this._Keyword = value; }
        }

        public int KeywordID
        {
            get { return this.Keyword.KeywordID; }
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

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private bool _HasChecked = false;
        public bool HasChecked
        {
            get { return this._HasChecked; }
            set { this._HasChecked = value; }
        }
    }
}
