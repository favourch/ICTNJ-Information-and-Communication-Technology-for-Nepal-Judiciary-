using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPropertyCategory
    {
        private int _PCategoryID;
        public int PCategoryID
        {
            get { return this._PCategoryID; }
            set { this._PCategoryID = value; }
        }

        private int _NoOfCols;
        public int NoOfCols
        {
            get { return this._NoOfCols; }
            set { this._NoOfCols = value; }
        }

        private string _PCategoryName;
        public string PCategoryName
        {
            get { return this._PCategoryName.Trim(); }
            set { this._PCategoryName = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Income;
        public string Income
        {
            get { return _Income; }
            set { _Income = value; }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //private int _MasterType;
        //public int MasterType
        //{
        //    get { return this._MasterType; }
        //    set { this._MasterType = value; }
        //}

        private string _MasterType;
        public string MasterType
        {
            get { return this._MasterType; }
            set { this._MasterType = value; }
        }


        public ATTPropertyCategory()
        {
        }

        //public ATTPropertyCategory(int pCategoryID, string pCategoryName, int noOfCols, string income,string type)
        //{
        //    this.PCategoryID = pCategoryID;
        //    this.PCategoryName = pCategoryName;
        //    this.NoOfCols = noOfCols;
        //    this.Income = income;
        //    this.Type = type;
        //}

        public ATTPropertyCategory(int pCategoryID, string pCategoryName, int noOfCols, string income, string type, string masterType)
        {
            this.PCategoryID = pCategoryID;
            this.PCategoryName = pCategoryName;
            this.NoOfCols = noOfCols;
            this.Income = income;
            this.Type = type;
            this.MasterType = masterType;
        }

        //public ATTPropertyCategory(string pCategoryName, int noOfCols,string active, string income)
        public ATTPropertyCategory(string pCategoryName, int noOfCols, string active, string income,string type,string masterType)

        {
            this.PCategoryName = pCategoryName;
            this.NoOfCols = noOfCols;
            this.Active = active;
            this.Income = income;
            this.Type = type;
            this.MasterType = masterType;
        }
    }
}
