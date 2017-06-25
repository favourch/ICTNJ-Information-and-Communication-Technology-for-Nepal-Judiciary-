using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
   public class ATTOrgCaseRegistrationType
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

        private int _RegTypeID;
        public int RegTypeID
        {
            get { return _RegTypeID; }
            set { _RegTypeID = value; }
        }

        private string _RegTypeName;
        public string RegTypeName
        {
            get { return _RegTypeName; }
            set { _RegTypeName = value; }
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
       public ATTOrgCaseRegistrationType()
       {
       }

       private List<ATTOrgCaseRegTypeCheckList> _OrgCaseRegTypeCheckListLST=new List<ATTOrgCaseRegTypeCheckList>();
       public List<ATTOrgCaseRegTypeCheckList> OrgCaseRegTypeCheckListLST
       {
           get { return _OrgCaseRegTypeCheckListLST; }
           set { _OrgCaseRegTypeCheckListLST = value; }
       }
	


       public ATTOrgCaseRegistrationType(int orgID, int caseTypeID, int regTypeID,string regTypeName, string active,string action)
       {
           this.OrgID = orgID;
           this.CaseTypeID = caseTypeID;
           this.RegTypeID = regTypeID;
           this.RegTypeName = regTypeName;
           this.Active = active;
           this.Action = action;
       }
	
    }
}
