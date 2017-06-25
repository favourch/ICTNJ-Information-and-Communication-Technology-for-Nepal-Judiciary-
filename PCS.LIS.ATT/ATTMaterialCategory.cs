using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTMaterialCategory
    {

        private int _CategoryID;
        public int CategoryID
        {
            get { return this._CategoryID; }
            set { this._CategoryID = value; }
        }

        private string _CategoyName;
        public string CategoryName
        {
            get { return this._CategoyName.Trim(); }
            set { this._CategoyName = value; }
        }

        private string _CategoryEntryBy;
        public string CategoryEntryBy
        {
            get { return this._CategoryEntryBy.Trim(); }
            set { this._CategoryEntryBy = value; }
        }

        private string _CategoryDescription;
        public String CategoryDescription
        {
            get { return this._CategoryDescription.Trim(); }
            set { this._CategoryDescription = value; }
        }

        public ATTMaterialCategory(int categoryID,string categoryName,string categoryEntryBy,string categoryDescription)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.CategoryEntryBy = categoryEntryBy;
            this.CategoryDescription = categoryDescription;
        }

    }
}
