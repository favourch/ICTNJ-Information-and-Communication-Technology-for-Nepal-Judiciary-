using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseType
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
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

        private string _Appellant;
        public string Appellant
        {
            get { return _Appellant; }
            set { _Appellant = value; }
        }

        private string _Respondant;
        public string Respondant
        {
            get { return _Respondant; }
            set { _Respondant = value; }
        }
	
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private List<ATTOrganizationCaseType> _OrganisationCaseTypeLIST=new List<ATTOrganizationCaseType>();

        public List<ATTOrganizationCaseType> OrganisationCaseTypesLIST
        {
            get { return _OrganisationCaseTypeLIST; }
            set { _OrganisationCaseTypeLIST=value; }
        }
	

        //private List<ATTRegistrationDiary> _RegistrationDiaryLIST = new List<ATTRegistrationDiary>();
        //public List<ATTRegistrationDiary> RegistrationDiaryLIST
        //{
        //    get { return _RegistrationDiaryLIST; }
        //    set { _RegistrationDiaryLIST = value; }
        //}


        public ATTCaseType()
        { }

        public ATTCaseType(int caseTypeID, string caseTypeName,string appellant,string  respondant, string active)
        {
            CaseTypeID = caseTypeID;
            CaseTypeName = caseTypeName;
            Appellant = appellant;
            Respondant = respondant;
            Active = active;           
        }

       
	
    }
}
