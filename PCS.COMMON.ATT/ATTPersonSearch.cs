using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonSearch
    {
        private double? _PersonID;
        public double? PersonID
        {
            get { return this._PersonID; }
            set { this._PersonID = value; }
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
                if (this.Gender == "M") return "पुरूष";
                else if (this.Gender == "F") return "माहिला";
                else if (this.Gender == "O") return "अन्य";
                else return "";
            }
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

        private string _DOB;
        public string DOB
        {
            get { return this._DOB; }
            set { this._DOB = value; }
        }

        private int? _BirthDistrict;
        public int? BirthDistrict
        {
            get { return this._BirthDistrict; }
            set { this._BirthDistrict = value; }
        }

        private int? _CountryID;
        public int? CountryID
        {
            get { return this._CountryID; }
            set { this._CountryID = value; }
        }

        private string _District;
        public string District
        {
            get { return this._District; }
            set { this._District = value; }
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

        private string _IniType;
        public string IniType
        {
            get { return this._IniType; }
            set { this._IniType = value; }
        }

        private int _ApplicationID;
        public int ApplicationID
        {
            get { return this._ApplicationID; }
            set { this._ApplicationID = value; }
        }

        private string _PostName;
        public string PostName
        {
            get { return this._PostName; }
            set { this._PostName = value; }
        }

        private string _EntityType;
        public string EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }

        private string _RegNo;
        public string RegNo
        {
            get { return _RegNo; }
            set { _RegNo = value; }
        }

        private string _PanNo;
        public string PanNo
        {
            get { return _PanNo; }
            set { _PanNo = value; }
        }

        private string _OrgType;
        public string OrgType
        {
            get { return _OrgType; }
            set { _OrgType = value; }
        }

        private int? _DocumentID;
        public int? DocumentID
        {
            get { return _DocumentID; }
            set { _DocumentID = value; }
        }

        private string _DocumentNo;
        public string DocumentNo
        {
            get { return _DocumentNo; }
            set { _DocumentNo = value; }
        }


        public ATTPersonSearch()
        {
        }

        public ATTPersonSearch(double personID, string firstName, string middleName, string surName, string gender, string dob,string district, string fatherName, string gFatherName)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.SurName = surName;
            this.Gender = gender;
            this.DOB = dob;
            this.District = district;
            this.FatherName = fatherName;
            this.GFatherName = gFatherName;
        }

        public ATTPersonSearch(double personID, string firstName, string middleName, string surName, string gender, string dob, string district, string fatherName, string gFatherName, string postName)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.SurName = surName;
            this.Gender = gender;
            this.DOB = dob;
            this.District = district;
            this.FatherName = fatherName;
            this.GFatherName = gFatherName;
            this.PostName = postName;
        }
    }
}
