using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPropertyIncome
    {
        private int _EmpID;
        public int EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private int _PCatID;
        public int PCatID
        {
            get { return this._PCatID; }
            set { this._PCatID = value; }
        }

        private string _SubDate;
        public string SubDate
        {
            get { return this._SubDate; }
            set { this._SubDate = value; }
        }

        private double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private string _Year;
        public string Year
        {
            get { return this._Year; }
            set { this._Year = value; }
        }

    }
}
