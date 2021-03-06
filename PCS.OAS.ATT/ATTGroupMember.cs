using System;
using System.Collections.Generic;
using System.Text;
using PCS.PMS.ATT;

namespace PCS.OAS.ATT
{
    public class ATTGroupMember
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _GroupID;
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return this._EmpName.Trim(); }
            set { this._EmpName = value; }
        }

        private string _FromDate="";
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }

        private string _ToDate="";
        public string ToDate
        {
            get { return this._ToDate.Trim(); }
            set { this._ToDate = value; }
        }

        private string _OFromDate = "";
        public string OFromDate
        {
            get { return this._OFromDate.Trim(); }
            set { this._OFromDate = value; }
        }

        private string _OToDate = "";
        public string OToDate
        {
            get { return this._OToDate.Trim(); }
            set { this._OToDate = value; }
        }

        private ATTMemberPosition _MemberPostion = new ATTMemberPosition();
        public ATTMemberPosition MemberPostion
        {
            get { return this._MemberPostion; }
            set { this._MemberPostion = value; }
        }

        private int ? _OPositionID;
        public int ? OPositionID
        {
            get { return this._OPositionID; }
            set { this._OPositionID = value; }
        }

        public int ?  PositionID
        {
            get { return this.MemberPostion.PositionID; }
        }

        public string PositionName
        {
            get { return this.MemberPostion.PositionName; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public bool DateControlEnabled
        {
            get
            {
                if (this.Action == "E" || this.Action == "N" || this.Action == "D")
                    return true;
                else
                    return false;
            }
        }

        public System.Drawing.Color DateColor
        {
            get
            {
                if (this.Action == "A")
                    return System.Drawing.Color.White;
                else
                    return System.Drawing.Color.FromName("#E7E2E2");
            }
        }

        public ATTGroupMember()
        {
        }

        public ATTGroupMember(int orgID, int groupID, int empID, string fromDate, string toDate, int positionID, string empName)
        {
            OrgID = orgID;
            GroupID = groupID;
            EmpID = empID;
            FromDate = fromDate;
            ToDate = toDate;
            this.MemberPostion.PositionID = positionID;
            EmpName = empName;
        }
      
       
    }
}
