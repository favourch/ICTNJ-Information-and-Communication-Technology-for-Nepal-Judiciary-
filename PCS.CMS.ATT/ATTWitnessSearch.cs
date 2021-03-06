using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.CMS.ATT
{
   public class ATTWitnessSearch
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private string _CaseRegistrationDate;
        public string CaseRegistrationDate
        {
            get { return _CaseRegistrationDate; }
            set { _CaseRegistrationDate = value; }
        }

        private string _CaseNumber;
        public string CaseNumber
        {
            get { return _CaseNumber; }
            set { _CaseNumber = value; }
        }

        private string _RegNumber;
        public string RegNumber
        {
            get { return _RegNumber; }
            set { _RegNumber = value; }
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
        private double _LItigantID;
        public double LItigantID
        {
            get { return _LItigantID; }
            set { _LItigantID = value; }
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

        private string _DisplayName;
        public string DispalyName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        private int _WitnessID;
        public int WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }
        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

        private string _WitnessName;
        public string WitnessName
        {
            get { return _WitnessName; }
            set { _WitnessName = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
	
        private string _WitnessDOB;
        public string WitnessDOB
        {
            get { return _WitnessDOB; }
            set { _WitnessDOB = value; }
        }
        private string _WitnessGender;
        public string WitnessGender
        {
            get { return _WitnessGender; }
            set { _WitnessGender = value; }
        }
       public string RDGender
       {
           get
           {
               if (this.WitnessGender == "M") return "पुरूष";
               else if (this.WitnessGender == "F") return "माहिला";
               else if (this.WitnessGender == "O") return "अन्य";
               else return "";
           }
       }
      
        private string _LitigantType;
        public string LitigantType
        {
            get { return _LitigantType; }
            set { _LitigantType = value; }
        }
        private int _LitigantSubTypeID;
        public int LitigantSubTypeID
        {
            get { return _LitigantSubTypeID; }
            set { _LitigantSubTypeID = value; }
        }
        private string _LitigantSubTypeName;
        public string LitigantSubtypeName
        {
            get { return _LitigantSubTypeName; }
            set { _LitigantSubTypeName = value; }
        }

        private int _SNO;
        public int SNO
        {
            get { return _SNO; }
            set { _SNO = value; }
        }
        private string _IsPrisioned;
        public string IsPrisioned
        {
            get { return _IsPrisioned; }
            set { _IsPrisioned = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	
        private ATTPerson _ObjPerson = new ATTPerson();
        public ATTPerson ObjPerson
        {
            get { return _ObjPerson; }
            set { _ObjPerson = value; }
        }
      

       public ATTWitnessSearch()
       {
       }
       public ATTWitnessSearch(double caseID,string caseRegDate,string caseNumber,string regNumber,int caseTypeID,
           string caseTypeName,double litigantID,string litigantName,string dob,string gender,string displayName,
           int witnessID,int personID,string witnessName,string witnessDOB,string witnessGender,string litigantType,
           int litigantSubTypeID,string litigantSubTypeName,int sNO,string isPrisioned)
       {
           this.CaseID = caseID;
           this.CaseRegistrationDate = caseRegDate;
           this.CaseNumber = caseNumber;
           this.RegNumber = regNumber;
           this.CaseTypeID = caseTypeID;
           this.CaseTypeName = caseTypeName;
           this.LItigantID = litigantID;
           this.LitigantName = litigantName;
           this.DOB = dob;
           this.Gender = gender;
           this.DispalyName = displayName;
           this.WitnessID = witnessID;
           this.PersonID = personID;
           this.WitnessName = witnessName;
           this.WitnessDOB = witnessDOB;
           this.WitnessGender = witnessGender;
           this.LitigantType = litigantType;
           this.LitigantSubTypeID = litigantSubTypeID;
           this.LitigantSubtypeName = litigantSubTypeName;
           this.SNO = sNO;
           this.IsPrisioned = isPrisioned;
       }
    }
}
