using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTAttendance
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private string _OrgName;

        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }
	
        private int _DesID;

        public int DesID
        {
            get { return _DesID; }
            set { _DesID = value; }
        }

        private string _DesName;

        public string DesName
        {
            get { return _DesName; }
            set { _DesName = value; }
        }

        private string _YearMonth;

        public string YearMonth
        {
            get { return _YearMonth; }
            set { _YearMonth = value; }
        }

        private string _EmpFullName;

        public string EmpFullName
        {
            get { return _EmpFullName; }
            set { _EmpFullName = value; }
        }

        private double _EmpID;

        public double EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private string _LogDate;

        public string LogDate
        {
            get { return _LogDate; }
            set { _LogDate = value; }
        }
	
        private string _PresentDate;

        public string PresentDate
        {
            get { return _PresentDate; }
            set { _PresentDate = value; }
        }

        public ATTAttendance()
        {
        }

        public ATTAttendance(int orgId, string orgName, int desId, string desName, string yearMonth, string empFullName, int empId, string logDate, string presentDate)
        {
            this.OrgID = orgId;
            this.OrgName = OrgName;
            this.DesID = desId;
            this.DesName = desName;
            this.YearMonth = yearMonth;
            this.EmpFullName = empFullName;
            this.EmpID = EmpID;
            this.LogDate = LogDate;
            this.PresentDate = presentDate;
        }
        

    }
}
