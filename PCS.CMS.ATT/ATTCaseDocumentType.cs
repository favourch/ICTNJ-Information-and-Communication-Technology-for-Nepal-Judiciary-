using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseDocumentType
    {
         private int _CaseDocumentTypeID;
        public int CaseDocumentTypeID
        {
            get { return _CaseDocumentTypeID; }
            set { _CaseDocumentTypeID = value; }
        }

        private string _CaseDocumentTypeName;
        public string CaseDocumentTypeName
        {
            get { return _CaseDocumentTypeName; }
            set { _CaseDocumentTypeName = value; }
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
	

        public ATTCaseDocumentType(int CaseDocumentTypeID, string CaseDocumentTypeName, string active)
        {
            this.CaseDocumentTypeID = CaseDocumentTypeID;
            this.CaseDocumentTypeName = CaseDocumentTypeName;
            this.Active = active;
        }
    }
}
