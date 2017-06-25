using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTLeaveTypeDesignation
    {
        private int _LeaveTypeID;
        public int LeaveTypeID
        {
            get { return _LeaveTypeID; }
            set { _LeaveTypeID = value; }
        }

        private string _LeaveType;
        public string LeaveType
        {
            get { return _LeaveType; }
            set { _LeaveType = value; }
        }


        private int _DesignationID;
        public int DesignationID
        {
            get { return _DesignationID; }
            set { _DesignationID = value; }
        }

        private int _Days;
        public int Days
        {
            get { return _Days; }
            set { _Days = value; }
        }

        private string _PeriodType;
        public string PeriodType
        {
            get { return _PeriodType; }
            set { _PeriodType = value; }
        }

        private int _PeriodTimes;
        public int PeriodTimes
        {
            get { return _PeriodTimes; }
            set { _PeriodTimes = value; }
        }

        private bool _IsAccural;
        public bool IsAccural
        {
            get { return _IsAccural; }
            set { _IsAccural = value; }
        }

        private int? _AccuralDays;
        public int? AccuralDays
        {
            get { return _AccuralDays; }
            set { _AccuralDays = value; }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _EffectiveFromDate;
        public string EffectiveFromDate
        {
            get { return _EffectiveFromDate; }
            set { _EffectiveFromDate = value; }
        }

        private string _EffectiveTillDate;
        public string EffectiveTillDate
        {
            get { return _EffectiveTillDate; }
            set { _EffectiveTillDate = value; }
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

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }


        public ATTLeaveTypeDesignation()
        { }
        public ATTLeaveTypeDesignation(int leaveTypeId, string leaveType, int designationID, int days, string periodType, int periodTimes, bool isAccural, int accuralDays, bool active, string effectiveFromDate, string entryBy, string entryDate)
        {
            this.LeaveTypeID = leaveTypeId;
            this.LeaveType = leaveType;
            this.DesignationID = designationID;
            this.Days = days;
            this.PeriodType = periodType;
            this.PeriodTimes = periodTimes;
            this.IsAccural = isAccural;
            this.AccuralDays = accuralDays;
            this.Active = active;
            this.EffectiveFromDate = effectiveFromDate;
            //this.EffectiveTillDate = effectiveTillDate;
            this.EntryBy = entryBy;
            this.EntryDate = entryDate;
        }











    }
}
