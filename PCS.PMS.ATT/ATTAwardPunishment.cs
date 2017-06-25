using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTAwardPunishment
    {
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
	

        private int _SequenceNo;

        public int SequenceNo
        {
            get { return _SequenceNo; }
            set { _SequenceNo = value; }
        }

        private string _Award;

        public string Award
        {
            get { return _Award; }
            set { _Award = value; }
        }

        private string _AwardDate;

        public string AwardDate
        {
            get { return _AwardDate; }
            set { _AwardDate = value; }
        }

        private string _VerifiedBy;

        public string VerifiedBy
        {
            get { return _VerifiedBy; }
            set { _VerifiedBy = value; }
        }

        private string _VerifiedDate;

        public string VerifiedDate
        {
            get { return _VerifiedDate; }
            set { _VerifiedDate = value; }
        }

        private string _Remarks;

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private string _Punishment;

        public string Punishment
        {
            get { return _Punishment; }
            set { _Punishment = value; }
        }

        private string _PunishmentDate;

        public string PunishmentDate
        {
            get { return _PunishmentDate; }
            set { _PunishmentDate = value; }
        }

        private string _PunishmentRemarks;

        public string PunishmentRemarks
        {
            get { return _PunishmentRemarks; }
            set { _PunishmentRemarks = value; }
        }
	

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        public ATTAwardPunishment()
        {
        }
    }
}
