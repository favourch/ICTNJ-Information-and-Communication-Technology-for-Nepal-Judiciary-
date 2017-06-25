using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTLibraryMaterialAuthor
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

        private string _CategoryName;
        public string CategoryName
        {
            get { return this._CategoryName; }
            set { this._CategoryName = value; }
        }

        private string _CategoryDescription;
        public string CategoryDescription
        {
            get { return this._CategoryDescription; }
            set { this._CategoryDescription = value; }
        }

        private string _CallNo;
        public string CallNo
        {
            get { return this._CallNo; }
            set { this._CallNo = value; }
        }

        private string _PublisherName;
        public string PublisherName
        {
            get { return this._PublisherName; }
            set { this._PublisherName = value; }
        }

        private string _CorporateBody;
        public string CorporateBody
        {
            get { return this._CorporateBody; }
            set { this._CorporateBody = value; }
        }

        private double _Price;
        public double Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }

        private string _Edition;
        public string Edition
        {
            get { return this._Edition; }
            set { this._Edition = value; }
        }

        private string _Language;
        public string Language
        {
            get { return this._Language; }
            set { this._Language = value; }
        }

        private string _AuthorName;
        public string AuthorName
        {
            get { return this._AuthorName; }
            set { this._AuthorName = value; }
        }

        private string _CurrencyName;
        public string CurrencyName
        {
            get { return this._CurrencyName; }
            set { this._CurrencyName = value; }
        }

        //private int _AuthorID;
        //public int AuthorID
        //{
        //    get { return this._AuthorID; }
        //    set { this._AuthorID = value; }
        //}

        private ATTAuthor _Author = new ATTAuthor();
        public ATTAuthor Author
        {
            get { return this._Author; }
            set { this._Author = value; }
        }

        public int AuthorID
        {
            get { return this.Author.AuthorID; }
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

        public ATTLibraryMaterialAuthor()
        {
        }

        //public ATTLibraryMaterialAuthor(int orgID, int libraryID, int lMaterialID, string categoryName, string categoryDescription, double price, string edition, string language, string currencyName)
        //{
        //    this.OrgID = orgID;
        //    this.LibraryID = libraryID;
        //    this.LMaterialID = lMaterialID;
        //    this.CategoryName = categoryName;
        //    this.CategoryDescription = categoryDescription;
        //    this.Price = price;
        //    this.Edition = edition;
        //    this.Language = language;
        //    this.CurrencyName = currencyName;
        //}

        //public ATTLibraryMaterialAuthor(int orgID, int libraryID, int lMaterialID, string categoryName, string categoryDescription, double price, string edition, string language, string currencyName)
        public ATTLibraryMaterialAuthor(int orgID, int libraryID, int lMaterialID, string categoryName, string categoryDescription, string language, string callno, string corporateBody, string publisherName)
        {
            this.OrgID = orgID;
            this.LibraryID = libraryID;
            this.LMaterialID = lMaterialID;
            this.CategoryName = categoryName;
            this.CategoryDescription = categoryDescription;

            //this.Price = price;
            //this.Edition = edition;

            this.Language = language;
            this.CallNo = callno;
            this.CorporateBody = corporateBody;
            this.PublisherName = publisherName;

            //this.CurrencyName = currencyName;
        }
    }
}
