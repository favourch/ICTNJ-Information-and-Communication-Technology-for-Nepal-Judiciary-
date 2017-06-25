using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTRegistrationDiaryName:ICloneable
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
	
        private int _CaseTypeID;
        public int CaseTypeID
        {
            get { return _CaseTypeID; }
            set { _CaseTypeID = value; }
        }

        private int _RegistrationDiaryID;
        public int RegistrationDiaryID
        {
            get { return _RegistrationDiaryID; }
            set { _RegistrationDiaryID = value; }
        }

        private int _RegistrationSubjectID;
        public int RegistrationSubjectID
	{
        get { return _RegistrationSubjectID; }
        set { _RegistrationSubjectID = value; }
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

        private string _RegistrationDiaryNameDescription;
        public string RegistrationDiaryNameDescription
    {
        get { return _RegistrationDiaryNameDescription; }
        set { _RegistrationDiaryNameDescription = value; }
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

        private string _EntryDate;
        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	
	    public ATTRegistrationDiaryName()
        { }
        public ATTRegistrationDiaryName(int caseTypeID, int registrationDiaryID, int registrationSubjectID, int registrationDiaryNameID, string registrationDiaryName, string registrationDiaryNameDescription, string active)
        {
            CaseTypeID = caseTypeID;
            RegistrationDiaryID = registrationDiaryID;
            RegistrationSubjectID = registrationSubjectID;
            RegistrationDiaryNameID = registrationDiaryNameID;
            RegistrationDiaryName = registrationDiaryName;
            RegistrationDiaryNameDescription = registrationDiaryNameDescription;            
            Active = active;
            
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
