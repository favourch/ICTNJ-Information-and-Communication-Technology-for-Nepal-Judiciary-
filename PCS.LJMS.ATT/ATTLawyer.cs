using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.LJMS.ATT
{
    public class ATTLawyer
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

        private ATTPerson _ObjPerson;
        public ATTPerson ObjPerson
        {
            get { return this._ObjPerson; }
            set { this._ObjPerson = value; }
        }

        private List<ATTLawyerRenewal> _LstLawyerRenewal = new List<ATTLawyerRenewal>();
        public List<ATTLawyerRenewal> LstLawyerRenewal
        {
            get { return this._LstLawyerRenewal; }
            set { this._LstLawyerRenewal = value; }
        }

        private List<ATTPrivateLawyer> _LstPrivateLawyer = new List<ATTPrivateLawyer>();
        public List<ATTPrivateLawyer> LstPrivateLawyer
        {
            get { return this._LstPrivateLawyer; }
            set { this._LstPrivateLawyer = value; }
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

        public ATTLawyer()
        {
        }

    }
}
