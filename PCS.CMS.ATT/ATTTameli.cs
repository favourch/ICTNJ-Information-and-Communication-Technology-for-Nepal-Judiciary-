using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTTameli
    {
        private int _CaseID;
        public int CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _LitigantID;
        public int LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private string _IssuedDate;
        public string IssuedDate
        {
            get { return _IssuedDate; }
            set { _IssuedDate = value; }
        }

        private int _SeqNo;
        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }

        private int? _WitnessID;
        public int? WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }

        private int? _AttorneyID;
        public int? AttorneyID
        {
            get { return _AttorneyID; }
            set { _AttorneyID = value; }
        }
	

        private int? _IssuedBy;
        public int? IssuedBy
        {
            get { return _IssuedBy; }
            set { _IssuedBy = value; }
        }

        private string _ReceivedDate;
        public string ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        private int? _ReceivedBy;
        public int? ReceivedBy
        {
            get { return _ReceivedBy; }
            set { _ReceivedBy = value; }
        }

        private string _TameliDate;
        public string TameliDate
        {
            get { return _TameliDate; }
            set { _TameliDate = value; }
        }

        private string _TameliYesNo;
        public string TameliYesNo
        {
            get { return _TameliYesNo; }
            set { _TameliYesNo = value; }
        }
        	

        private string _SecClrkRcvdDate;
        public string SecClrkRcvdDate
        {
            get { return _SecClrkRcvdDate; }
            set { _SecClrkRcvdDate = value; }
        }

        private string _TamilDaarRemrks;
        public string TamilDaarRemrks
        {
            get { return _TamilDaarRemrks; }
            set { _TamilDaarRemrks = value; }
        }

        private string _VerifiedDate;
        public string VerifiedDate
        {
            get { return _VerifiedDate; }
            set { _VerifiedDate = value; }
        }

        private double? _VerifiedBy;
        public double? VerifiedBy
        {
            get { return _VerifiedBy; }
            set { _VerifiedBy = value; }
        }

        private string _VerifiedYesNo;
        public string VerifiedYesNo
        {
            get { return _VerifiedYesNo; }
            set { _VerifiedYesNo = value; }
        }
        
        private string _VerifiedRemarks;
        public string VerifiedRemarks
        {
            get { return _VerifiedRemarks; }
            set { _VerifiedRemarks = value; }
        }

        private int _AttendDays;
        public int AttendDays
        {
            get { return _AttendDays; }
            set { _AttendDays = value; }
        }
        	

        private int? _MyaadTypeID;
        public int? MyaadTypeID
        {
            get { return _MyaadTypeID; }
            set { _MyaadTypeID = value; }
        }

        private int? _TameliTypeID;
        public int? TameliTypeID
        {
            get { return _TameliTypeID; }
            set { _TameliTypeID = value; }
        }

        private int? _TameliStatusID;
        public int? TameliStatusID
        {
            get { return _TameliStatusID; }
            set { _TameliStatusID = value; }
        }

        private int? _TameliOrg;
        public int? TameliOrg
        {
            get { return _TameliOrg; }
            set { _TameliOrg = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _OldIssueDate;
        public string OldIssueDate
        {
            get { return _OldIssueDate; }
            set { _OldIssueDate = value; }
        }

        private List<ATTTameliWitnessPerson> _TameliWitnessPersonLIST = new List<ATTTameliWitnessPerson>();
        public List<ATTTameliWitnessPerson> TameliWitnessPersonLIST
        {
            get { return _TameliWitnessPersonLIST; }
            set { _TameliWitnessPersonLIST = value; }
        }

        private List<ATTTameliMedia> _TameliMediaLIST = new List<ATTTameliMedia>();
        public List<ATTTameliMedia> TameliMediaLIST
        {
            get { return _TameliMediaLIST; }
            set { _TameliMediaLIST = value; }
        }
	

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	
	
	
	
	
	
	
	


	
	
	
	
	
	
	
	
	
	
    }
}
