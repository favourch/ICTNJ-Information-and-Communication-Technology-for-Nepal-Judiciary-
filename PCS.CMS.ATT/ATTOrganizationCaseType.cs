using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
   public class ATTOrganizationCaseType: ICloneable
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private string _OrgName;
        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }
	
        private int _CaseTypeID;
        public int CaseTypeID
        {
            get { return _CaseTypeID; }
            set { _CaseTypeID = value; }
        }

        private string  _CaseTypeName;
        public string  CaseTypeName
        {
            get { return _CaseTypeName; }
            set { _CaseTypeName = value; }
        }

        
	
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

       public bool RDActive
       {
           get { return (this.Active == "Y" ? true : false); }
       }

        private string  _EntryBy;
        public string  EntryBy
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

        private List<ATTRegistrationDiary> _LstRegistrationDiary=new List<ATTRegistrationDiary>();
        public List<ATTRegistrationDiary> LstRegistrationDiary
        {
            get { return _LstRegistrationDiary; }
            set { _LstRegistrationDiary= value; }
        }
        
        private List<ATTCaseType> _LstCaseType=new List<ATTCaseType>();
        public List<ATTCaseType> LstCaseType
        {
            get { return _LstCaseType; }
            set { _LstCaseType = value; }
        }


        private List<ATTOrgCaseRegistrationType> _OrgCaseRegistrationTypeLST;
        public List<ATTOrgCaseRegistrationType> OrgCaseRegistrationTypeLST
        {
            get { return _OrgCaseRegistrationTypeLST; }
            set { _OrgCaseRegistrationTypeLST = value; }
        }
	


       public ATTOrganizationCaseType()
       {
       }
	
       public ATTOrganizationCaseType(int orgID,int caseTypeID, string active)
       {
           this.OrgID = orgID;
           this.CaseTypeID = caseTypeID;
           this.Active = active;
       }

       public object Clone()
       {
           ATTOrganizationCaseType orgCaseType = (ATTOrganizationCaseType)this.MemberwiseClone();
           List<ATTRegistrationDiary> tmpRegDiaryLst = new List<ATTRegistrationDiary>();

           foreach (ATTRegistrationDiary obj in this.LstRegistrationDiary)
           {
               tmpRegDiaryLst.Add((ATTRegistrationDiary)obj.Clone());
           }
           orgCaseType.LstRegistrationDiary = tmpRegDiaryLst;
           return orgCaseType;
       }
	
    }
}
