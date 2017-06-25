using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTTameliSearch
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
	
        private int _CaseID;
        public int CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _CaseTypeID;
        public int CaseTypeID
        {
            get { return _CaseTypeID; }
            set { _CaseTypeID = value; }
        }

        private string _CaseTypeName;
        public string CaseTypeName
        {
            get { return _CaseTypeName; }
            set { _CaseTypeName = value; }
        }

        private int _RegTypeID;
        public int RegTypeID
        {
            get { return _RegTypeID; }
            set { _RegTypeID = value; }
        }	

        private string _RegTypeName;
        public string RegTypeName
        {
            get { return _RegTypeName; }
            set { _RegTypeName = value; }
        }

        private int _RegDiaryID;
        public int RegDiaryID
        {
            get { return _RegDiaryID; }
            set { _RegDiaryID = value; }
        }

        private int _RegSubjectID;
        public int RegSubjectID
        {
            get { return _RegSubjectID; }
            set { _RegSubjectID = value; }
        }

        private string _SubjectName;
        public string SubjectName
        {
            get { return _SubjectName; }
            set { _SubjectName = value; }
        }

        private int _RegDiaryNameID;
        public int RegDiaryNameID
        {
            get { return _RegDiaryNameID; }
            set { _RegDiaryNameID = value; }
        }

        private string _RegDiarySubName;
        public string RegDiarySubName
        {
            get { return _RegDiarySubName; }
            set { _RegDiarySubName = value; }
        }

        private string _CaseRegDate;
        public string CaseRegDate
        {
            get { return _CaseRegDate; }
            set { _CaseRegDate = value; }
        }

        private string _RegNo;
        public string RegNo
        {
            get { return _RegNo; }
            set { _RegNo = value; }
        }

        private string _CaseNo;
        public string CaseNo
        {
            get { return _CaseNo; }
            set { _CaseNo = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }

        private int _LitigantID;
        public int LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private string _LitigantName;
        public string LitigantName
        {
            get { return _LitigantName; }
            set { _LitigantName = value; }
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

        private double _WitnessID;
        public double WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }

        private string _WitnessFullName;
        public string WitnessFullName
        {
            get { return _WitnessFullName; }
            set { _WitnessFullName = value; }
        }

        private double _AttorneyID;
        public double AttorneyID
        {
            get { return _AttorneyID; }
            set { _AttorneyID = value; }
        }

        private string _AttorneyFullName;
        public string AttorneyFullName
        {
            get { return _AttorneyFullName; }
            set { _AttorneyFullName = value; }
        }
             
        private int _IssuedBy;
        public int IssuedBy
        {
            get { return _IssuedBy; }
            set { _IssuedBy = value; }
        }

        private string _IssuedPerson;
        public string IssuedPerson
        {
            get { return _IssuedPerson; }
            set { _IssuedPerson = value; }
        }

        private string _ReceivedDate;
        public string ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        private int _ReceivedBy;
        public int ReceivedBy
        {
            get { return _ReceivedBy; }
            set { _ReceivedBy = value; }
        }

        private string _TamildaarName;
        public string TamildaarName
        {
            get { return _TamildaarName; }
            set { _TamildaarName = value; }
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

        private int _VerifiedBy;
        public int VerifiedBy
        {
            get { return _VerifiedBy; }
            set { _VerifiedBy = value; }
        }

        private string _SectionClerkName;
        public string SectionClerkName
        {
            get { return _SectionClerkName; }
            set { _SectionClerkName = value; }
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

        private int _MyaadTypeID;
        public int MyaadTypeID
        {
            get { return _MyaadTypeID; }
            set { _MyaadTypeID = value; }
        }

        private int _TameliTypeID;
        public int TameliTypeID
        {
            get { return _TameliTypeID; }
            set { _TameliTypeID = value; }
        }

        private int _TameliStatusID;
        public int TameliStatusID
        {
            get { return _TameliStatusID; }
            set { _TameliStatusID = value; }
        }

        private int _TameliOrg;
        public int TameliOrg
        {
            get { return _TameliOrg; }
            set { _TameliOrg = value; }
        }

        private string _RegDiaryName;
        public string RegDiaryName
        {
            get { return _RegDiaryName; }
            set { _RegDiaryName = value; }
        }

        private string _TameliTypeName;
        public string TameliTypeName
        {
            get { return _TameliTypeName; }
            set { _TameliTypeName = value; }
        }

        private string _TameliStatusName;
        public string TameliStatusName
        {
            get { return _TameliStatusName; }
            set { _TameliStatusName = value; }
        }

        private string _MyaadTypeName;
        public string MyaadTypeName
        {
            get { return _MyaadTypeName; }
            set { _MyaadTypeName = value; }
        }

        private string _MyaadType;
        public string MyaadType
        {
            get { return _MyaadType; }
            set { _MyaadType = value; }
        }	              

        

        

        //private string _WitnessGender;
        //public string WitnessGender
        //{
        //    get { return _WitnessGender; }
        //    set { _WitnessGender = value; }
        //}

        //private string _WitnessDOB;
        //public string WitnessDOB
        //{
        //    get { return _WitnessDOB; }
        //    set { _WitnessDOB = value; }
        //}        

        
    }
}
