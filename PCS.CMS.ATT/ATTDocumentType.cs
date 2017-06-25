using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTDocumentType
    {
         private int _DocumentTypeID;
        public int DocumentTypeID
        {
            get { return _DocumentTypeID; }
            set { _DocumentTypeID = value; }
        }

        private string _DocumentTypeName;
        public string DocumentTypeName
        {
            get { return _DocumentTypeName; }
            set { _DocumentTypeName = value; }
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
	

        public ATTDocumentType(int DocumentTypeID, string DocumentTypeName, string active)
        {
            this.DocumentTypeID = DocumentTypeID;
            this.DocumentTypeName = DocumentTypeName;
            this.Active = active;
        }
    }
}
