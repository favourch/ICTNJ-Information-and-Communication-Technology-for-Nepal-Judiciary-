using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseRegistration
    {
        private double _CaseID;
        public double CaseID
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
        private int? _CaseTypeID = null;
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
	
	
        private int? _RegDiaryID = null;
        public int? RegDiaryID
        {
            get { return _RegDiaryID; }
            set { _RegDiaryID = value; }
        }

        private string _RegDiaryName;
        public string RegDiaryName
        {
            get { return _RegDiaryName; }
            set { _RegDiaryName = value; }
        }


	
        private int? _RegSubjectID = null;
        public int? RegSubjectID
        {
            get { return _RegSubjectID; }
            set { _RegSubjectID = value; }
        }

        private string _RegSubjectName;
        public string RegSubjectName
        {
            get { return _RegSubjectName; }
            set { _RegSubjectName = value; }
        }
	
        private int? _RegDiaryNameID = null;
        public int? RegDiaryNameID
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
	

        private string _CaseRegistrationDate = "";
        public string CaseRegistrationDate
        {
            get { return _CaseRegistrationDate.Trim(); }
            set { _CaseRegistrationDate = value; }
        }

        private string _RegistrationNumber = "";
        public string RegistrationNumber
        {
            get { return _RegistrationNumber.Trim(); }
            set { _RegistrationNumber = value; }
        }
        private string _CaseNumber = "";
        public string CaseNumber
        {
            get { return _CaseNumber.Trim(); }
            set { _CaseNumber = value; }
        }
        private int? _WritSubjectID = null;
        public int? WritSubjectID
        {
            get { return _WritSubjectID; }
            set { _WritSubjectID = value; }
        }
        private int? _WritCatID = null;
        public int? WritCatID
        {
            get { return _WritCatID; }
            set { _WritCatID = value; }
        }
        private int? _WritCatTitleID = null;
        public int? WirtCatTitleID
        {
            get { return _WritCatTitleID; }
            set { _WritCatTitleID = value; }
        }
        private int? _WritCatSubTitleID = null;
        public int? WritCatSubTitleID
        {
            get { return _WritCatSubTitleID; }
            set { _WritCatSubTitleID = value; }
        }
        private string _AccountForwarded = "";
        public string AccountForwarded
        {
            get { return _AccountForwarded.Trim(); }
            set { _AccountForwarded = value; }
        }
        private double? _VerifiedBy = null;
        public double? VerifiedBy
        {
            get { return _VerifiedBy; }
            set { _VerifiedBy = value; }
        }
        private string _VerifiedYesNO = "";
        public string VerifiedYesNo
        {
            get { return _VerifiedYesNO.Trim(); }
            set { _VerifiedYesNO = value; }
        }
        private string _VerifiedDate = "";
        public string VerifiedDate
        {
            get { return _VerifiedDate.Trim(); }
            set { _VerifiedDate = value; }
        }
        private string _DarpithRemarks = "";
        public string DarpithRemarks
        {
            get { return _DarpithRemarks.Trim(); }
            set { _DarpithRemarks = value; }
        }
        private int? _ProceedingID = null;
        public int? ProceedingID
        {
            get { return _ProceedingID; }
            set { _ProceedingID = value; }
        }

        private string _ProceedingType;
        public string ProceedingType
        {
            get { return _ProceedingType; }
            set { _ProceedingType = value; }
        }
	


        private string _CaseSummary = "";
        public string CaseSummary
        {
            get { return _CaseSummary.Trim(); }
            set { _CaseSummary = value; }
        }
        private double? _RelatedCaseID = null;
        public double? RelatedCaseID
        {
            get { return _RelatedCaseID; }
            set { _RelatedCaseID = value; }
        }
        private string _FY = "";
        public string FY
        {
            get { return _FY.Trim(); }
            set { _FY = value; }
        }

        private string _Action = "";
        public string Action
        {
            get { return _Action.Trim(); }
            set { _Action = value; }
        }

        private List<ATTLitigants> _AppellantLST=new List<ATTLitigants>();
        public List<ATTLitigants> AppellantLST
        {
            get { return _AppellantLST; }
            set { _AppellantLST = value; }
        }

        private List<ATTLitigants> _RespondantLST = new List<ATTLitigants>();
        public List<ATTLitigants> RespondantLST
        {
            get { return _RespondantLST; }
            set { _RespondantLST = value; }
        }


        private List<ATTCaseCheckList> _CaseCheckListLST=new List<ATTCaseCheckList>();
        public List<ATTCaseCheckList> CaseCheckListLST
        {
            get { return _CaseCheckListLST; }
            set { _CaseCheckListLST = value; }
        }



        private List<ATTWitnessPerson> _WitnessPersonLST = new List<ATTWitnessPerson>();
        public List<ATTWitnessPerson> WitnessPersonLST
        {
            get { return _WitnessPersonLST; }
            set { _WitnessPersonLST = value; }
        }


        private List<ATTCaseLaywer> _CaseLawyerLST = new List<ATTCaseLaywer>();
        public List<ATTCaseLaywer> CaseLawyerLST
        {
            get { return _CaseLawyerLST; }
            set { _CaseLawyerLST = value; }
        }

	

	

        private List<ATTCaseDocuments> _CaseDocumentLST=new List<ATTCaseDocuments>();
        public List<ATTCaseDocuments> CaseDocumentLST
        {
            get { return _CaseDocumentLST; }
            set { _CaseDocumentLST = value; }
        }

        private List<ATTCaseDocumentsLit> _CaseDocumentLitLST = new List<ATTCaseDocumentsLit>();
        public List<ATTCaseDocumentsLit> CaseDocumentLitLST
        {
            get { return _CaseDocumentLitLST; }
            set { _CaseDocumentLitLST = value; }
        }


        private List<ATTCaseEvidence> _CaseEvidenceLST=new List<ATTCaseEvidence>();
        public List<ATTCaseEvidence> CaseEvidenceLST
        {
            get { return _CaseEvidenceLST; }
            set { _CaseEvidenceLST = value; }
        }


        private List<ATTCaseAccountForward> _CaseAccountForwardLST = new List<ATTCaseAccountForward>();
        public List<ATTCaseAccountForward> CaseAccountForwardLST
        {
            get { return _CaseAccountForwardLST; }
            set { _CaseAccountForwardLST = value; }
        }

	

	

	

	

	

        public ATTCaseRegistration()
        {

        }
    }
}
