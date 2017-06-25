using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTAuthor
    {
        private int _AuhtorID;
        public int AuthorID
        {
            get { return this._AuhtorID; }
            set { this._AuhtorID = value; }
        }

        private string _AuthorName;
        public string AuthorName
        {
            get { return this._AuthorName.Trim(); }
            set { this._AuthorName = value; }
        }

        private string _EntryBy = "";
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

        public ATTAuthor()
        {
        }

        public ATTAuthor(int authorID, string authorName)
        {
            this.AuthorID = authorID;
            this.AuthorName = authorName;
        }

        public ATTAuthor(int authorID, string authorName, string entryBy, DateTime entryOn)
        {
            this.AuthorID = authorID;
            this.AuthorName = authorName;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
        }

        public override string ToString()
        {
            return this.AuthorName;
        }
    }
}
