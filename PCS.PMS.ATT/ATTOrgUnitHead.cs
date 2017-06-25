using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTOrgUnitHead
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _UnitID;
        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        private string _UnitName;
        public string UnitName
        {
            get { return _UnitName; }
            set { _UnitName = value; }
        }

        private double _EmpID;
        public double EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        private string _UnitHead;
        public string UnitHead
        {
            get { return _UnitHead; }
            set { _UnitHead = value; }
        }
        private string _OfficeHead;
        public string OfficeHead
        {
            get { return _OfficeHead; }
            set { _OfficeHead = value; }
        }
        private string _EntryBY;
        public string EntryBY
        {
            get { return _EntryBY; }
            set { _EntryBY = value; }
        }
        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        public ATTOrgUnitHead()
        {
        }
    }
}
