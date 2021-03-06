using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeLeave
    {
        private int _EmpID;
        public int EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private string _EmpFullName;

        public string EmpFullName
        {
            get { return _EmpFullName; }
            set { _EmpFullName = value; }
        }
	
        private string _LeaveType;
        public string LeaveType
        {
            get { return _LeaveType; }
            set { _LeaveType = value; }
        }

        private string _ApplDate;
        public string ApplDate
        {
            get { return _ApplDate; }
            set { _ApplDate = value; }
        }

        private int _LeaveTypeID;
        public int LeaveTypeID
        {
            get { return _LeaveTypeID; }
            set { _LeaveTypeID = value; }
        }
	
        private string _ReqdFrom;
        public string ReqdFrom
        {
            get { return _ReqdFrom; }
            set { _ReqdFrom = value; }
        }
	
        private string _ReqdTo;
        public string ReqdTo
        {
            get { return _ReqdTo; }
            set { _ReqdTo = value; }
        }

        private int _EmpDays;
        public int EmpDays
        {
            get { return _EmpDays; }
            set { _EmpDays = value; }
        }

        private string _EmpReason;
        public string EmpReason
        {
            get { return _EmpReason; }
            set { _EmpReason = value; }
        }
	
        private int? _RecByID;
        public int? RecByID
        {
            get { return _RecByID; }
            set { _RecByID = value; }
        }

        private string _RecByName;

        public string RecByName
        {
            get { return _RecByName; }
            set { _RecByName = value; }
        }
	

        private string _RecDate;
        public string RecDate
        {
            get { return _RecDate; }
            set { _RecDate = value; }
        }
	
        private string _RecFrom;
        public string RecFrom
        {
            get { return _RecFrom; }
            set { _RecFrom = value; }
        }
	
        private string _RecTo;
        public string RecTo
        {
            get { return _RecTo; }
            set { _RecTo = value; }
        }

        private int? _RecDays;
        public int? RecDays
        {
            get { return _RecDays; }
            set { _RecDays = value; }
        }
	
        private string _Recommended;
        public string Recommended
        {
            get { return _Recommended; }
            set { _Recommended = value; }
        }

        private string _RecYesNo;

        public string RecYesNo
        {
            get
            {
                return (this.Recommended == "Y" ? "भएको" : "नभएको");
            }
        }

        private string _RecReason;
        public string RecReason
        {
            get { return _RecReason; }
            set { _RecReason = value; }
        }
	
        private int? _AppByID;
        public int? AppByID
        {
            get { return _AppByID; }
            set { _AppByID = value; }
        }

        private string _AppByName;

        public string AppByName
        {
            get { return _AppByName; }
            set { _AppByName = value; }
        }
	
	
        private string _AppDate;
        public string AppDate
        {
            get { return _AppDate; }
            set { _AppDate = value; }
        }
	
        private string _AppFrom;
        public string AppFrom
        {
            get { return _AppFrom; }
            set { _AppFrom = value; }
        }
	
        private string _AppTo;
        public string AppTo
        {
            get { return _AppTo; }
            set { _AppTo = value; }
        }

        private int? _AppDays;
        public int? AppDays
        {
            get { return _AppDays; }
            set { _AppDays = value; }
        }

        private string _Approved;

        public string Approved
        {
            get { return _Approved; }
            set { _Approved = value; }
        }
	
	
        private string _ApprYesNo;

        public string ApprYesNo
        {
            get { return this.Approved=="Y"?"भएको" : "नभएको"; }
        }
	
	
        private string _AppReason;
        public string AppReason
        {
            get { return _AppReason; }
            set { _AppReason = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _EntryDate;
        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private int _NoOfDays;
        public int NoOfDays
        {
            get { return _NoOfDays; }
            set { _NoOfDays = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private string _OutMessage;

        public string OutMessage
        {
            get { return _OutMessage; }
            set { _OutMessage = value; }
        }

        private int _PeriodCount;

        public int PeriodCount
        {
            get { return _PeriodCount; }
            set { _PeriodCount = value; }
        }

        private string _PFY;

        public string PFY
        {
            get { return _PFY; }
            set { _PFY = value; }
        }
        private string _PeriodType;

        public string PeriodType
        {
            get { return _PeriodType; }
            set { _PeriodType = value; }
        }

        private string _ApprovedLeaves;

        public string ApprovedLeaves
        {
            get { return _ApprovedLeaves; }
            set { _ApprovedLeaves = value; }
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
	
        
	
	
	
        public ATTEmployeeLeave(int empId, string applDate, int leaveTypeId, string reqdFrom, string reqdTo, int empDays, string empReason, int recById, string recDate, string recFrom, string recTo, int recDays, string recommended, string recReason, int appById, string appDate, string appFrom, string appTo, int appDays, string approved, string appReason, string entryBy)
        {
            this.EmpID = empId;
            this.ApplDate = applDate;
            this.LeaveTypeID = leaveTypeId;
            this.ReqdFrom = reqdFrom;
            this.ReqdTo = reqdTo;
            this.EmpDays = empDays;
            this.EmpReason = empReason;
            this.RecByID = recById;
            this.RecDate = recDate;
            this.RecFrom = recFrom;
            this.RecTo = recTo;
            this.RecDays = recDays;
            this.Recommended = recommended;
            this.RecReason = recReason;
            this.AppByID = appById;
            this.AppDate = appFrom;
            this.AppFrom = appFrom;
            this.AppTo = appTo;
            this.AppDays = appDays;
            this.Approved = approved;
            this.AppReason = appReason;
            this.EntryBy = entryBy;
        }
        public ATTEmployeeLeave(int leaveTypeId, int no_of_days, string leaveType)
        {
            this.LeaveTypeID = leaveTypeId;
            this.LeaveType = leaveType;
            this.NoOfDays = no_of_days;
        }
        public ATTEmployeeLeave()
        {
           
        }
        public ATTEmployeeLeave(int empid, string fromdate, string todate, int days, int leavetypeid, string outmessage, int periodcount, string pfy,string periodtype)
        {
            this.EmpID = empid;
            this.AppFrom = fromdate;
            this.AppTo = todate;
            this.AppDays = days;
            this.LeaveTypeID = leavetypeid;
            this.OutMessage = outmessage;
            this.PeriodCount = periodcount;
            this.PFY = pfy;
            this.PeriodType = periodtype;
        }
    }
}
