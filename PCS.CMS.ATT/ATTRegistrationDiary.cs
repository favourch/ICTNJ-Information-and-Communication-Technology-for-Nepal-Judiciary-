using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTRegistrationDiary:ICloneable
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

        private int? _RegistrationDiaryID;
        public int? RegistrationDiaryID
        {
            get { return _RegistrationDiaryID; }
            set { _RegistrationDiaryID = value; }
        }

        private string _RegistrationDiaryName;
        public string RegistrationDiaryName
        {
            get { return _RegistrationDiaryName; }
            set { _RegistrationDiaryName = value; }
        }

        private string _RegistrationDiaryCode;
        public string RegistrationDiaryCode
        {
            get { return _RegistrationDiaryCode; }
            set { _RegistrationDiaryCode = value; }
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

        private List<ATTRegistrationDiarySubject> _RegistrationDiarySubjectLIST = new List<ATTRegistrationDiarySubject>();
        public List<ATTRegistrationDiarySubject> RegistrationDiarySubjectLIST
        {
            get { return _RegistrationDiarySubjectLIST; }
            set { _RegistrationDiarySubjectLIST = value; }
        }
	
	
	    public ATTRegistrationDiary()
        { }

        public ATTRegistrationDiary(int caseTypeID,int registrationDiaryID, string registrationDiaryName,string registrationDiaryCode, string active)
        {
            CaseTypeID = caseTypeID;
            RegistrationDiaryID = registrationDiaryID;
            RegistrationDiaryName = registrationDiaryName;
            RegistrationDiaryCode = registrationDiaryCode;
            Active = active;

        }

        public object Clone()
        {
            ATTRegistrationDiary RegistrationDiary = (ATTRegistrationDiary)this.MemberwiseClone();
            List<ATTRegistrationDiarySubject> tmpRegDiarySubjectLst = new List<ATTRegistrationDiarySubject>();
            foreach (ATTRegistrationDiarySubject obj in this.RegistrationDiarySubjectLIST)
            {
                tmpRegDiarySubjectLst.Add((ATTRegistrationDiarySubject)obj.Clone());
            }
            RegistrationDiary.RegistrationDiarySubjectLIST = tmpRegDiarySubjectLst;
            return RegistrationDiary;
        }

    }
}
