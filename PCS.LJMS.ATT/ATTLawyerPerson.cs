using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTLawyerPerson : PCS.COMMON.ATT.ATTPerson
    {
        private List<ATTLawyer> _LstLawyer = new List<ATTLawyer>();
        public List<ATTLawyer> LstLawyer
        {
            get { return this._LstLawyer; }
            set { this._LstLawyer = value; }
        }

        public ATTLawyerPerson(double pId, string firstName, string midName, string surName,
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

        public ATTLawyerPerson()
        {
        }
    }
}
