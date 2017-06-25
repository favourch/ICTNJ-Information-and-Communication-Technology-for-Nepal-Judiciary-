using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPropertyCategoryColumns
    {
        private int _PCategoryID;
        public int PCategoryID
        {
            get { return this._PCategoryID; }
            set { this._PCategoryID = value; }
        }

        private int _ColNo;
        public int ColNo
        {
            get { return this._ColNo; }
            set { this._ColNo = value; }
        }

        private string _ColName;
        public string ColName
        {
            get { return this._ColName.Trim(); }
            set { this._ColName = value; }
        }

        private string _ColDataType;
        public string ColDataType
        {
            get { return this._ColDataType.Trim(); }
            set { this._ColDataType = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private List<ATTPropertyCategoryColumns> _LstPCatCols = new List<ATTPropertyCategoryColumns>();
        public List<ATTPropertyCategoryColumns> LstPCatCols
        {
            get { return _LstPCatCols; }
            set { _LstPCatCols = value; }
        }

        public ATTPropertyCategoryColumns()
        {
        }

        public ATTPropertyCategoryColumns(int pCategoryID,int colNo,string colName,string colDataType,string active)
        {
            this.PCategoryID = pCategoryID;
            this.ColNo = colNo;
            this.ColName = colName;
            this.ColDataType = colDataType;
            this.Active = active;
        }
    }
}


