using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTDocumentCategory
    {
        private int _FileCatID;
        public int FileCatID
        {
            get { return this._FileCatID; }
            set { this._FileCatID = value; }
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

        public ATTDocumentCategory()
        {

        }

        public ATTDocumentCategory(int fileCatID,string categoryName)
        {
            this.FileCatID = fileCatID;
            this.CategoryName = categoryName;
        }
   
    }
}
