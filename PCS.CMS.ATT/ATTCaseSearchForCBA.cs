using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseSearchForCBA
    {

        private int? _CaseID;
        public int? CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _CourtID;
        public int CourtID
        {
            get { return _CourtID; }
            set { _CourtID = value; }
        }

        private string _CaseRegDate;
        public string CaseRegDate
        {
            get { return _CaseRegDate; }
            set { _CaseRegDate = value; }
        }

        private string _CaseNo;
        public string CaseNo
        {
            get { return _CaseNo; }
            set { _CaseNo = value; }
        }

        private string _RegNo;
        public string RegNo
        {
            get { return _RegNo; }
            set { _RegNo = value; }
        }

        private int? _CaseTypeID;
        public int? CaseTypeID
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

        private int? _RegistrationDiaryID;
        public int? RegistrationDiaryID
        {
            get { return _RegistrationDiaryID; }
            set { _RegistrationDiaryID = value; }
        }

        private string _RegistrationDiary;
        public string RegistrationDiary
        {
            get { return _RegistrationDiary; }
            set { _RegistrationDiary = value; }
        }

        private string _RegistrationDiaryCode;
        public string RegistrationDiaryCode
        {
            get { return _RegistrationDiaryCode; }
            set { _RegistrationDiaryCode = value; }
        }

        private int? _RegistrationSubjectID;
        public int? RegistrationSubjectID
        {
            get { return _RegistrationSubjectID; }
            set { _RegistrationSubjectID = value; }
        }

        private string _SubjectName;
        public string SubjectName
        {
            get { return _SubjectName; }
            set { _SubjectName = value; }
        }

        private int? _RegistrationDiaryNameID;
        public int? RegistrationDiaryNameID
        {
            get { return _RegistrationDiaryNameID; }
            set { _RegistrationDiaryNameID = value; }
        }

        private string _RegDiaryNameDesc;
        public string RegDiaryNameDesc
        {
            get { return _RegDiaryNameDesc; }
            set { _RegDiaryNameDesc = value; }
        } 

        private int? _WritSubID;
        public int? WritSubID
        {
            get { return _WritSubID; }
            set { _WritSubID = value; }
        }

        private string _WritSubName;
        public string WritSubName
        {
            get { return _WritSubName; }
            set { _WritSubName = value; }
        }

        private int? _WritCatID;
        public int? WritCatID
        {
            get { return _WritCatID; }
            set { _WritCatID = value; }
        }

        private string _WritSubCatName;
        public string WritSubCatName
        {
            get { return _WritSubCatName; }
            set { _WritSubCatName = value; }
        }

        private int? _WritCatTitleID;
        public int? WritCatTitleID
        {
            get { return _WritCatTitleID; }
            set { _WritCatTitleID = value; }
        }

        private string _WritSubCatTitleName;
        public string WritSubCatTitleName
        {
            get { return _WritSubCatTitleName; }
            set { _WritSubCatTitleName = value; }
        }

        private int? _WritCatSubTitleID;
        public int? WritCatSubTitleID
        {
            get { return _WritCatSubTitleID; }
            set { _WritCatSubTitleID = value; }
        }

        private string _WritSubCatSubTitleName;
        public string WritSubCatSubTitleName
        {
            get { return _WritSubCatSubTitleName; }
            set { _WritSubCatSubTitleName = value; }
        }

        private string _AccountForwarded;
        public string AccountForwarded
        {
            get { return _AccountForwarded; }
            set { _AccountForwarded = value; }
        }

        private string _Verified;
        public string Verified
        {
            get { return _Verified; }
            set { _Verified = value; }
        }

        private string _DecisionYesNo;
        public string DecisionYesNo
        {
            get { return _DecisionYesNo; }
            set { _DecisionYesNo = value; }
        }

        private int _VerifiedBy;
        public int VerifiedBy
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

        private string _DarpithRemarks;
        public string DarpithRemarks
        {
            get { return _DarpithRemarks; }
            set { _DarpithRemarks = value; }
        }

        private int _ProceedingID;
        public int ProceedingID
        {
            get { return _ProceedingID; }
            set { _ProceedingID = value; }
        }

        private string _CaseSummary;
        public string CaseSummary
        {
            get { return _CaseSummary; }
            set { _CaseSummary = value; }
        }

        private int _RelatedCaseID;
        public int RelatedCaseID
        {
            get { return _RelatedCaseID; }
            set { _RelatedCaseID = value; }
        }

        private string _FY;
        public string FY
        {
            get { return _FY; }
            set { _FY = value; }
        }

        private string _Appelant;
        public string Appelant
        {
            get { return _Appelant; }
            set { _Appelant = value; }
        }

        private string _Respondant;
        public string Respondant
        {
            get { return _Respondant; }
            set { _Respondant = value; }
        }

        private string _RegDate;
        public string RegDate
        {
            get { return _RegDate; }
            set { _RegDate = value; }
        }

        private string _ClDate;
        public string ClDate
        {
            get { return _ClDate; }
            set { _ClDate = value; }
        }

        private string _ClEntryTypeName;
        public string ClEntryTypeName
        {
            get { return _ClEntryTypeName; }
            set { _ClEntryTypeName = value; }
        }



       /// <summary>
       ///  From CaseBenchAssignment
       /// </summary>

        private string _AssignmentDate;
        public string AssignmentDate
        {
            get { return _AssignmentDate; }
            set { _AssignmentDate = value; }
        }
       
        private int _BenchTypeID;
        public int BenchTypeID
        {
            get { return _BenchTypeID; }
            set { _BenchTypeID = value; }
        }
        
        private int _BenchNo;
        public int BenchNo
        {
            get { return _BenchNo; }
            set { _BenchNo = value; }
        }

        private String _FormDate;
        public String FormDate
        {
            get { return _FormDate; }
            set { _FormDate = value; }
        }
       
        private int _SeqNo;
        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }

        private int _BenStatusID;
        public int BenStatusID
        {
            get { return _BenStatusID; }
            set { _BenStatusID = value; }
        }

        private string _BenStatusName;
        public string BenStatusName
        {
            get { return _BenStatusName; }
            set { _BenStatusName = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        private int _Priority;

        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
	
        /// <summary>
        ///  From CaseBenchAssignment
        /// </summary>
	
	
	
	
                

        
	
	
	
	
	
    }
}
