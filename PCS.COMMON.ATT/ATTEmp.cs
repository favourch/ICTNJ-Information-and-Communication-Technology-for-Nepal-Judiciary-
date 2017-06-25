using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTEmp
    {
        private int _EmpNo;
        public int EmpNo
        {
            get { return this._EmpNo; }
            set { this._EmpNo = value; }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return this._EmpName; }
            set { this._EmpName = value; }
        }

        public ATTEmp(int empNo, string empName)
        {
            this.EmpNo = empNo;
            this.EmpName = empName;
        }
    }
}
