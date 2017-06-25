using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTLeaveType
    {
        private int _LeaveTypeID;
        public int LeaveTypeID
        {
            get { return _LeaveTypeID; }
            set { _LeaveTypeID = value; }
        }

        private string _LeaveTypeName;
        public string LeaveTypeName
        {
            get { return _LeaveTypeName; }
            set { _LeaveTypeName = value; }
        }


        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }


        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public ATTLeaveType(int leaveTypeID, string leaveTypeName, string gender, string active)
        {
            this.LeaveTypeID = leaveTypeID;
            this.LeaveTypeName = leaveTypeName;
            this.Gender = gender;
            this.Active = active;
        }

        public ATTLeaveType(int leaveTypeID, string leaveTypeName, string active)
        {
            this.LeaveTypeID = leaveTypeID;
            this.LeaveTypeName = leaveTypeName;
            //this.Gender = gender;
            this.Active = active;
        }

    }
}
