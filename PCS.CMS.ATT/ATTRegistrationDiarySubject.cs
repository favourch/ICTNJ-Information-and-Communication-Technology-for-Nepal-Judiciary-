using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTRegistrationDiarySubject:ICloneable
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

        private int? _SubjectID;
	    public int? SubjectID
	{
		get { return _SubjectID;}
		set { _SubjectID = value;}
	}
	
        private string _SubjectName;
    	public string SubjectName
	    {
		    get { return _SubjectName;}
		    set { _SubjectName = value;}
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

        private List<ATTRegistrationDiaryName> _RegistrationDiaryNameLIST = new List<ATTRegistrationDiaryName>();

        public List<ATTRegistrationDiaryName> RegistrationDiaryNameLIST
        {
            get { return _RegistrationDiaryNameLIST; }
            set { _RegistrationDiaryNameLIST = value; }
        }
	
	
	    public ATTRegistrationDiarySubject()
        { }

        public ATTRegistrationDiarySubject(int caseTypeID, int registrationDiaryID, int subjectID,string subjectName, string active)
        {
            CaseTypeID = caseTypeID;
            RegistrationDiaryID = registrationDiaryID;
            SubjectID = subjectID;
            SubjectName = subjectName;
            Active = active;
            
        }

        public object Clone()
        {
            ATTRegistrationDiarySubject RegistrationDiarySubject = (ATTRegistrationDiarySubject)this.MemberwiseClone();
            List<ATTRegistrationDiaryName> tmpRegDiaryNameLst = new List<ATTRegistrationDiaryName>();
            foreach (ATTRegistrationDiaryName obj in this.RegistrationDiaryNameLIST)
            {
                tmpRegDiaryNameLst.Add((ATTRegistrationDiaryName)obj.Clone());
            }
            RegistrationDiarySubject.RegistrationDiaryNameLIST = tmpRegDiaryNameLst;
            return RegistrationDiarySubject;
        }
    }
}
