using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
     public class ATTLitigantSearch
    {
        private double? _CaseID;
        public double? CaseID
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

        private string _RegistrationDiaryName;
        public string RegistrationDiaryName
        {
            get { return _RegistrationDiaryName; }
            set { _RegistrationDiaryName = value; }
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

        private double? _LitigantID;
        public double? LitigantID
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

        private string _DOB;
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }	

        private String _DisplayName;    
        public String DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        private String _LitigantType;
        public String LitigantType
        {
            get { return _LitigantType; }
            set { _LitigantType = value; }
        }

         public string LitigantTypeName
         {
             get
             {
                 return (this.LitigantType == "A" ? "वादी" : "प्रतिवादी");
             }
         }	

        private int? _LitigantSubTypeID;
        public int? LitigantSubTypeID
        {
            get { return _LitigantSubTypeID; }
            set { _LitigantSubTypeID = value; }
        }

        private string  _LitigantSubTypeName;
        public string  LitigantSubTypeName
        {
            get { return _LitigantSubTypeName; }
            set { _LitigantSubTypeName = value; }
        }

        private int? _SNo;
        public int? SNo
        {
            get { return _SNo; }
            set { _SNo = value; }
        }

        private string _IsPrisoned;
        public string IsPrisoned
        {
            get { return _IsPrisoned; }
            set { _IsPrisoned = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
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

        
	
	
	


        public ATTLitigantSearch()
        {}
        public ATTLitigantSearch(double? caseID,string caseRegDate,string caseNo,string regNo,int? caseTypeID,string caseTypeName,int? regDiaryID,string regDiary,string regDiaryCode,int? regSubjectID,string subjectName,int? regDiaryNameID,string regDiaryName,int? writSubID,string writSubName,int? writCatID,string writSubCatName,int? writCatTitleID,string writSubCatTitleName,int?writCatSubTitleID,string writSubCatSubtitleName , double? litigantID,string litigantName,string dob,string gender, String litigantType, int? litigantSubTypeID,string litigantSubTypeName ,String displayName, int sNo, string isPrisioned)
        {
            this.CaseID = caseID;
            this.CaseRegDate = caseRegDate;
            this.CaseNo = caseNo;
            this.RegNo = regNo;
            this.CaseTypeID = caseTypeID;
            this.CaseTypeName = caseTypeName;
            this.RegistrationDiaryID = regDiaryID;
            this.RegistrationDiary = regDiary;
            this.RegistrationDiaryCode = regDiaryCode;
            this.RegistrationSubjectID = regSubjectID;
            this.SubjectName = subjectName;
            this.RegistrationDiaryNameID = regDiaryNameID;
            this.RegistrationDiaryName = regDiaryName;
            this.WritSubID = writSubID;
            this.WritSubName = writSubName;
            this.WritCatID = writCatID;
            this.WritSubCatName = writSubCatName;
            this.WritCatTitleID = writCatTitleID;
            this.WritSubCatTitleName = writSubCatTitleName;
            this.WritCatSubTitleID = writCatSubTitleID;
            this.WritSubCatSubTitleName = writSubCatSubtitleName;
            this.LitigantID = litigantID;
            this.LitigantName = litigantName;
            this.DOB = dob;
            this.Gender = gender;
            this.DisplayName = displayName;
            this.LitigantType = litigantType;
            this.LitigantSubTypeID = litigantSubTypeID;
            this.LitigantSubTypeName = litigantSubTypeName;
            this.SNo = sNo;
            this.IsPrisoned = isPrisioned;
        }
    }
}
