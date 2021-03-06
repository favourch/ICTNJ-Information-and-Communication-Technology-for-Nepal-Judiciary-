using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeDetailSearch
    {
        private double? _EmpID = null;
        public double? EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private int? _OrgID = null;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _OrgName = "";
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }


        private string _SymbolNo = null;
        public string SymbolNo
        {
            get { return this._SymbolNo; }
            set { this._SymbolNo = value; }
        }

        private string _FirstName = "";
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        private string _MiddleName = "";
        public string MiddleName
        {
            get { return this._MiddleName; }
            set { this._MiddleName = value; }
        }

        private string _SurName = "";
        public string SurName
        {
            get { return this._SurName; }
            set { this._SurName = value; }
        }

        public string RDFullName
        {
            get
            {
                string strFullName;
                strFullName = this.FirstName;
                strFullName += (this.MiddleName == "" ? "" : " " + this.MiddleName);
                strFullName += (this.SurName == "" ? "" : " " + this.SurName);
                return strFullName;
            }
        }

        private int? _SewaID = null;
        public int? SewaID
        {
            get { return this._SewaID; }
            set { this._SewaID = value; }
        }

        private string _SewaName = "";
        public string SewaName
        {
            get { return this._SewaName; }
            set { this._SewaName = value; }
        }

        private int? _SamuhaID = null;
        public int? SamuhaID
        {
            get { return this._SamuhaID; }
            set { this._SamuhaID = value; }
        }

        private string _SamuhaName = "";
        public string SamuhaName
        {
            get { return this._SamuhaName; }
            set { this._SamuhaName = value; }
        }

        private int? _UpaSamuhaID = null;
        public int? UpaSamuhaID
        {
            get { return this._UpaSamuhaID; }
            set { this._UpaSamuhaID = value; }
        }

        private string _UpaSamuhaName = "";
        public string UpaSamuhaName
        {
            get { return this._UpaSamuhaName; }
            set { this._UpaSamuhaName = value; }
        }

        private int? _PostID = null;
        public int? PostID
        {
            get { return this._PostID; }
            set { this._PostID = value; }
        }

        private string _PostName = "";
        public string PostName
        {
            get { return this._PostName; }
            set { this._PostName = value; }
        }

        private int? _LevelID = null;
        public int? LevelID
        {
            get { return this._LevelID; }
            set { this._LevelID = value; }
        }

        private string _LevelName = "";
        public string LevelName
        {
            get { return this._LevelName; }
            set { this._LevelName = value; }
        }

        private int? _PostingTypeID = null;
        public int? PostingTypeID
        {
            get { return this._PostingTypeID; }
            set { this._PostingTypeID = value; }
        }

        private string _PostingTypeName = "";
        public string PostingTypeName
        {
            get { return this._PostingTypeName; }
            set { this._PostingTypeName = value; }
        }

        private string _Gender = "";
        public string Gender
        {
            get { return this._Gender; }
            set { this._Gender = value; }
        }

        public string RDGender
        {
            get
            {
                if (this.Gender == "M") return "पुरुष";
                else if (this.Gender == "F") return "महिला";
                else if (this.Gender == "O") return "अन्य";
                else return "";
            }
        }

        private int? _DistrictID = null;
        public int? DistrictID
        {
            get { return this._DistrictID; }
            set { this._DistrictID = value; }
        }

        private string _DistrictName = "";
        public string DistrictName
        {
            get { return this._DistrictName.Trim(); }
            set { this._DistrictName = value; }
        }

        private int _SubjectID;
        public int SubjectID
        {
            get { return this._SubjectID; }
            set { this._SubjectID = value; }
        }

        private string _Training = "";
        public string Training
        {
            get { return this._Training.Trim(); }
            set { this._Training = value; }
        }

        private string _JoiningDate = "";
        public string JoiningDate
        {
            get { return this._JoiningDate.Trim(); }
            set { this._JoiningDate = value; }
        }

        private string _RetirementDate = "";
        public string RetirementDate
        {
            get { return this._RetirementDate.Trim(); }
            set { this._RetirementDate = value; }
        }

        private string _RetirementDateOperator = "";
        public string RetirementDateOperator
        {
            get { return this._RetirementDateOperator.Trim(); }
            set { this._RetirementDateOperator = value; }
        }

        private int _RetirementYear;
        public int RetirementYear
        {
            get { return this._RetirementYear; }
            set { this._RetirementYear = value; }
        }

        private List<int> _QualificationList;
        public List<int> QualificationList
        {
            get { return this._QualificationList; }
            set { this._QualificationList = value; }
        }

        private int _DegreeID;
        public int DegreeID
        {
            get { return this._DegreeID; }
            set { this._DegreeID = value; }
        }

        private string _QualificationName = "";
        public string QualificationName
        {
            get { return this._QualificationName.Trim(); }
            set { this._QualificationName = value; }
        }

        private List<int> _VisitList;
        public List<int> VisitList
        {
            get { return this._VisitList; }
            set { this._VisitList = value; }
        }

        private int _VisitCountryID;
        public int VisitCountryID
        {
            get { return this._VisitCountryID; }
            set { this._VisitCountryID = value; }
        }

        private string _VisitCountryName = "";
        public string VisitCountryName
        {
            get { return this._VisitCountryName.Trim(); }
            set { this._VisitCountryName = value; }
        }

        private string _VisitPurpose = "";
        public string VisitPurpose
        {
            get { return this._VisitPurpose.Trim(); }
            set { this._VisitPurpose = value; }
        }

        private string _VisitFromDate = "";
        public string VisitFromDate
        {
            get { return this._VisitFromDate.Trim(); }
            set { this._VisitFromDate = value; }
        }

        private string _VisitToDate = "";
        public string VisitToDate
        {
            get { return this._VisitToDate.Trim(); }
            set { this._VisitToDate = value; }
        }

        private int _IsTrainingMerged;
        public int IsTrainingMerged
        {
            get { return this._IsTrainingMerged; }
            set { this._IsTrainingMerged = value; }
        }

        private int _IsDegreeMerged;
        public int IsDegreeMerged
        {
            get { return this._IsDegreeMerged; }
            set { this._IsDegreeMerged = value; }
        }

        private int _IsVisitMerged;
        public int IsVisitMerged
        {
            get { return this._IsVisitMerged; }
            set { this._IsVisitMerged = value; }
        }

        public ATTEmployeeDetailSearch()
        {
            this.RetirementYear = 20;
        }
    }
}
