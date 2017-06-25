using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTLawyerRenewal
    {
        private double _PID;

        public double PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        private int _LawyerTypeID;

        public int LawyerTypeID
        {
            get { return _LawyerTypeID; }
            set { _LawyerTypeID = value; }
        }

        private string _LawyerTypeName;

        public string LawyerTypeName
        {
            get { return _LawyerTypeName; }
            set { _LawyerTypeName = value; }
        }

        private string _LicenseNo;

        public string LicenseNo
        {
            get { return _LicenseNo; }
            set { _LicenseNo = value; }
        }

        private string _RenewalDate;

        public string RenewalDate
        {
            get { return _RenewalDate; }
            set { _RenewalDate = value; }
        }

        private string _RenewalUpto;
        public string RenewalUpto
        {
            get { return _RenewalUpto; }
            set { _RenewalUpto = value; }
        }
        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private DateTime _EntryOn;

        public DateTime EntryOn
        {
            get { return _EntryOn; }
            set { _EntryOn = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public ATTLawyerRenewal()
        {
        }
    }
}
