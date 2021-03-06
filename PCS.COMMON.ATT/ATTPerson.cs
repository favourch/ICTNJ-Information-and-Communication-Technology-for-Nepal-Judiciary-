using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPerson
    {

        private double _PId;
        public double PId
        {
            get { return this._PId; }
            set { this._PId = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return this._FirstName.Trim(); }
            set { this._FirstName = value.Trim(); }
        }

        private string _MidName;
        public string MidName
        {
            get { return this._MidName.Trim(); }
            set { this._MidName = value.Trim(); }
        }

        private string _SurName;
        public string SurName
        {
            get { return this._SurName.Trim(); }
            set { this._SurName = value.Trim(); }
        }

        private string _FullName;
        public string FullName
        {
            get { return this._FullName.Trim(); }
            set { this._FullName = value.Trim(); }
        }

        private string _DOB;
        public string DOB
        {
            get { return this._DOB.Trim(); }
            set { this._DOB = value.Trim(); }
        }

        private string _Gender;
        public string Gender
        {
            get { return this._Gender.Trim(); }
            set { this._Gender = value.Trim(); }
        }

        public string RDGender
        {
            get
            {
                if (this.Gender == "M") return "पुरूष";
                else if (this.Gender == "F") return "महिला";
                else if (this.Gender == "O") return "अन्य";
                else return "";
            }
        }

        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return this._MaritalStatus.Trim(); }
            set { this._MaritalStatus = value.Trim(); }
        }
        public string RDMaritalStatus
        {
            get
            {
                if (this.MaritalStatus == "S") return "अविवाहित";
                else if (this.MaritalStatus == "M") return "विवाहित";
                else if (this.MaritalStatus == "W") return "विधवा/विदुर";
                else if (this.MaritalStatus == "D") return "छोडपत्र";
                else if (this.MaritalStatus == "O") return "अन्य";
                else return "";
            }
        }


        private string _FatherName;
        public string FatherName
        {
            get { return this._FatherName.Trim(); }
            set { this._FatherName = value.Trim(); }
        }

        private string _GFatherName;
        public string GFatherName
        {
            get { return this._GFatherName.Trim(); }
            set { this._GFatherName = value.Trim(); }
        }

        private int? _CountryId;
        public int? CountryId
        {
            get { return this._CountryId; }
            set { this._CountryId = value; }
        }

        private int? _BirthDistrict;
        public int? BirthDistrict
        {
            get { return this._BirthDistrict; }
            set { this._BirthDistrict = value; }
        }

        private int? _ReligionId;
        public int? ReligionId
        {
            get { return this._ReligionId; }
            set { this._ReligionId = value; }
        }

        private int _IniUnit;
        public int IniUnit
        {
            get { return this._IniUnit; }
            set { this._IniUnit = value; }
        }

        private int _IniType;
        public int IniType
        {
            get { return this._IniType; }
            set { this._IniType = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value.Trim(); }
        }

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return this._EntryDate; }
            set { this._EntryDate = value; }
        }

        private byte[] _Photo;
        public byte[] Photo
        {
            get { return this._Photo; }
            set { this._Photo = value; }
        }

        private string _EntityType;

        public string EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }


        public string EntityTypeName
        {
            get
            {
                if (EntityType == "O")
                    return "संस्था";
                else if (EntityType == "P")
                    return "व्यक्ति";
                else
                    return "";
            }

        }

        private string _RegdNo;
        public string RegdNO
        {
            get { return _RegdNo; }
            set { _RegdNo = value; }
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

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTPersonAddress> _LstPersonAddress = new List<ATTPersonAddress>();
        public List<ATTPersonAddress> LstPersonAddress
        {
            get { return this._LstPersonAddress; }
            set { this._LstPersonAddress = value; }
        }

        private List<ATTPersonPhone> _LstPersonPhone = new List<ATTPersonPhone>();
        public List<ATTPersonPhone> LstPersonPhone
        {
            get { return this._LstPersonPhone; }
            set { this._LstPersonPhone = value; }
        }

        private List<ATTPersonEMail> _LstPersonEMail = new List<ATTPersonEMail>();
        public List<ATTPersonEMail> LstPersonEMail
        {
            get { return this._LstPersonEMail; }
            set { this._LstPersonEMail = value; }
        }

        private List<ATTPersonDocuments> _LstPersonDocuments = new List<ATTPersonDocuments>();
        public List<ATTPersonDocuments> LstPersonDocuments
        {
            get { return this._LstPersonDocuments; }
            set { this._LstPersonDocuments = value; }
        }

        private List<ATTPersonQualification> _LstPersonQualification = new List<ATTPersonQualification>();
        public List<ATTPersonQualification> LstPersonQualification
        {
            get { return this._LstPersonQualification; }
            set { this._LstPersonQualification = value; }
        }

        private List<ATTPersonTraining> _LstPersonTraining = new List<ATTPersonTraining>();
        public List<ATTPersonTraining> LstPersonTraining
        {
            get { return this._LstPersonTraining; }
            set { this._LstPersonTraining = value; }
        }

        private List<ATTRelatives> _LstRelatives = new List<ATTRelatives>();
        public List<ATTRelatives> LstRelatives
        {
            get { return this._LstRelatives; }
            set { this._LstRelatives = value; }
        }



        public ATTPerson()
        {
        }

        public ATTPerson(double pId, string firstName, string midName, string surName,
            string dOB, string gender, string maritalStatus, string fatherName, string gFatherName,
            int? countryId, int? birthDistrict, int? religionId, int iniUnit, int iniType,
            string entryBy, DateTime entryDate, byte[] photo,string entityType)
        {
            this.PId = pId;
            this.FirstName = firstName;
            this.MidName = midName;
            this.SurName = surName;
            this.DOB = dOB;
            this.Gender = gender;
            this.MaritalStatus = maritalStatus;
            this.FatherName = fatherName;
            this.GFatherName = gFatherName;
            this.CountryId = countryId;
            this.BirthDistrict = birthDistrict;
            this.ReligionId = religionId;
            this.IniUnit = iniUnit;
            this.IniType = iniType;
            this.EntryBy = entryBy;
            this.EntryDate = entryDate;
            this.Photo = photo;
            this.EntityType = entityType;
        }

        public ATTPerson(double pId, string firstName, string midName, string surName,
            string dOB, string gender, string maritalStatus, string fatherName, string gFatherName,
            int? countryId, int? birthDistrict, int? religionId, int iniUnit, int iniType,
            string entryBy, DateTime entryDate, byte[] photo)
        {
            this.PId = pId;
            this.FirstName = firstName;
            this.MidName = midName;
            this.SurName = surName;
            this.DOB = dOB;
            this.Gender = gender;
            this.MaritalStatus = maritalStatus;
            this.FatherName = fatherName;
            this.GFatherName = gFatherName;
            this.CountryId = countryId;
            this.BirthDistrict = birthDistrict;
            this.ReligionId = religionId;
            this.IniUnit = iniUnit;
            this.IniType = iniType;
            this.EntryBy = entryBy;
            this.EntryDate = entryDate;
            this.Photo = photo;
        }
    }
}
