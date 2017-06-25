using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPropertyDetails
    {

        private int _EmpID;
        public int EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        //private DateTime _SubDate;
        //public DateTime SubDate
        //{
        //    get { return this._SubDate; }
        //    set { this._SubDate = value; }
        //}
        private string _SubDate;
        public string SubDate
        {
            get { return this._SubDate; }
            set { this._SubDate = value; }
        }

        private int _PCatID;
        public int PCatID
        {
            get { return _PCatID; }
            set { _PCatID = value; }
        }

        private int _ColNo;
        public int ColNo
        {
            get { return _ColNo; }
            set { _ColNo = value; }
        }


        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }


        private int _RowNo;
        public int RowNo
        {
            get { return _RowNo; }
            set { _RowNo = value; }
        }

        private List<ATTPropertyDetails> _LstPropertyDetails = new List<ATTPropertyDetails>();
        public List<ATTPropertyDetails> LstPropertyDetails
        {
            get { return _LstPropertyDetails; }
            set { _LstPropertyDetails = value; }
        }

        private List<ATTPropertyIncome> _LstPropertyIncome = new List<ATTPropertyIncome>();
        public List<ATTPropertyIncome> LstPropertyIncome
        {
            get { return _LstPropertyIncome; }
            set { _LstPropertyIncome = value; }
        }
	

        public ATTPropertyDetails()
        {

        }

       public ATTPropertyDetails(int empID, int pCatID, int colNo, string value, int rowNo)
       {
           this.EmpID = empID;
           this.PCatID = pCatID;
           this.ColNo = colNo;
           this.Value = value;
           this.RowNo = rowNo;
          
       }
    }
}
