using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeSearch
    {
        private double? _EmpID;
        public double? EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _SymbolNo;
        public string SymbolNo
        {
            get { return this._SymbolNo; }
            set { this._SymbolNo = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return this._MiddleName; }
            set { this._MiddleName = value; }
        }

        private string _SurName;
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

        private string _Gender;
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

        private string _DOB;
        public string DOB
        {
            get { return this._DOB; }
            set { this._DOB = value; }
        }

        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return this._MaritalStatus; }
            set { this._MaritalStatus = value; }
        }

        public string RDMaritalStatus
        {
            get
            {
                if (this.MaritalStatus == "S") return "अबिबाहित";
                else if (this.MaritalStatus == "M") return "बिबाहित";
                else if (this.MaritalStatus == "W") return "बिधवा/बिदुर";
                else if (this.MaritalStatus == "D") return "छोडपत्र";
                else if (this.MaritalStatus == "O") return "अन्य";
                else return "";
            }
        }

        private string _FatherName;
        public string FatherName
        {
            get { return this._FatherName; }
            set { this._FatherName = value; }
        }

        private string _GFatherName;
        public string GFatherName
        {
            get { return this._GFatherName; }
            set { this._GFatherName = value; }
        }

        private int? _CountryID;
        public int? CountryID
        {
            get { return this._CountryID; }
            set { this._CountryID = value; }
        }

        private int? _BirthDistrict;
        public int? BirthDistrict
        {
            get { return this._BirthDistrict; }
            set { this._BirthDistrict = value; }
        }

        private int? _RelgionID;
        public int? ReligionID
        {
            get { return this._RelgionID; }
            set { this._RelgionID = value; }
        }

        private string _IdentityMark;
        public string IdentityMark
        {
            get { return this._IdentityMark; }
            set { this._IdentityMark = value; }
        }

        private int? _DesID;
        public int? DesID
        {
            get { return this._DesID; }
            set { this._DesID = value; }
        }

        private int? _OrgID;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _DesName;
        public string DesName
        {
            get { return this._DesName; }
            set { this._DesName = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }

        private string _LevelName;
        public string LevelName
        {
            get { return this._LevelName; }
            set { this._LevelName = value; }
        }

        private string _DesType;
        public string DesType
        {
            get { return this._DesType; }
            set { this._DesType = value; }
        }

        private int? _IniType;
        public int? IniType
        {
            get { return this._IniType; }
            set { this._IniType = value; }
        }

        private int? _IniUnit;
        public int? IniUnit
        {
            get { return this._IniUnit; }
            set { this._IniUnit = value; }
        }

        private string _CitznNo;

        public string CitznNo
        {
            get { return _CitznNo; }
            set { _CitznNo = value; }
        }

        private string _PFNo;

        public string PFNo
        {
            get { return _PFNo; }
            set { _PFNo = value; }
        }

        private int _OfficeNo;

        public int OfficeNo
        {
            get { return _OfficeNo; }
            set { _OfficeNo = value; }
        }

        private string _UnitHead;
        public string UnitHead
        {
            get { return _UnitHead; }
            set { _UnitHead = value; }
        }
        private string _OfficeHead;
        public string OfficeHead
        {
            get { return _OfficeHead; }
            set { _OfficeHead = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return _UnitName; }
            set { _UnitName = value; }
        }
        private int _UnitID;
        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
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

        private bool _IsPosting;
        public bool IsPosting
        {
            get { return _IsPosting; }
            set { _IsPosting = value; }
        }

        public ATTEmployeeSearch()
        {
        }

        public ATTEmployeeSearch(
            double empID, string symbolNo,string firstName,string middleName,string surName,
            string gender,string dob,string maritalStatus)
        {
            this.EmpID = empID;
            this.SymbolNo = symbolNo;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.SurName = surName;
            this.Gender = gender;
            this.DOB = dob;
            this.MaritalStatus = maritalStatus;
        }

    }
}
