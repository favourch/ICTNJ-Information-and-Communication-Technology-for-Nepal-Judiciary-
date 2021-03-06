using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTVwEmpRelativeBeneficiary
    {
        private double _PId;
        public double PId
        {
            get { return this._PId; }
            set { this._PId = value; }
        }

        private double _RelativeId;
        public double RelativeId
        {
            get { return this._RelativeId; }
            set { this._RelativeId = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        private string _MidName;
        public string MidName
        {
            get { return this._MidName; }
            set { this._MidName = value; }
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
                strFullName += (this.MidName == "" ? "" : " " + this.MidName);
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

        private int? _BirthDistrict;
        public int? BirthDistrict
        {
            get { return this._BirthDistrict; }
            set { this._BirthDistrict = value; }
        }

        private string _NepDistName;
        public string NepDistName
        {
            get { return this._NepDistName; }
            set { this._NepDistName = value; }
        }

        private int _RelationTypeId;
        public int RelationTypeId
        {
            get { return this._RelationTypeId; }
            set { this._RelationTypeId = value; }
        }

        private string _RelationTypeName;
        public string RelationTypeName
        {
            get { return this._RelationTypeName; }
            set { this._RelationTypeName = value; }
        }

        private string _Occupation;
        public string Occupation
        {
            get { return this._Occupation; }
            set { this._Occupation = value; }
        }

        public bool IsBeneficiary
        {
            get
            {
                return (this.Active == "Y" ? (this.BeneficiarySince != "" ? true : false) : false);
            }
        }

        public bool IsActive
        {
            get
            {
                return (this.Active == "Y" ? true : false);
            }
        }


        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
        
        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _BeneficiarySince;
        public string BeneficiarySince
        {
            get { return this._BeneficiarySince; }
            set { this._BeneficiarySince = value; }
        }

        public ATTVwEmpRelativeBeneficiary
            (
            double pId,
            double relativeId,
            string firstName,
            string midName,
            string surName,
            string dOB,
            string gender,
            string maritalStatus,
            int? birthDistrict,
            string nepDistName,
            int relationTypeID,
            string relationTypeName,
            string occupation,
            string active,
            string beneficiarySince
            )
        {
            this.PId = pId;
            this.RelativeId = relativeId;
            this.FirstName = firstName;
            this.MidName = midName;
            this.SurName = surName;
            this.DOB = dOB;
            this.Gender = gender;
            this.MaritalStatus = maritalStatus;
            this.BirthDistrict = birthDistrict;
            this.NepDistName = nepDistName;
            this.RelationTypeId = relationTypeID;
            this.RelationTypeName = relationTypeName;
            this.Occupation = occupation;
            this.Active = active;
            this.BeneficiarySince = beneficiarySince;
        }
    }
}
