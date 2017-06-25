using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTDocument
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private int _DocID;
        public int DocID
        {
            get { return this._DocID; }
            set { this._DocID = value; }
        }

        private string _DocumentName;
        public string DocumentName
        {
            get { return this._DocumentName.Trim(); }
            set { this._DocumentName = value; } 
        }

        private string _DocDescription;
        public string DocDescription
        {
            get { return this._DocDescription.Trim(); }
            set { this._DocDescription = value; }
        }

        private int _DocFlowType;
        public int DocFlowType
        {
            get { return this._DocFlowType; }
            set { this._DocFlowType = value; }
        }

        private string _DocFlowTypeName;
        public string DocFlowTypeName
        {
            get { return this._DocFlowTypeName; }
            set { this._DocFlowTypeName = value; }
        }

        private int _DocCategory;
        public int DocCategory
        {
            get { return this._DocCategory; }
            set { this._DocCategory = value; }
        }

        private string _DocCategoryName;
        public string DocCategoryName
        {
            get { return this._DocCategoryName; }
            set { this._DocCategoryName = value; }
        }

        private List<ATTDocument> _LstDocName;
        public List<ATTDocument> LstDocName
        {
            get { return _LstDocName; }
            set { _LstDocName = value; }
        }

        private List<ATTDocumentAttachment> _LstDocAttachment = new List<ATTDocumentAttachment>();
        public List<ATTDocumentAttachment> LstDocAttachment
        {
            get { return _LstDocAttachment; }
            set { _LstDocAttachment = value; }
        }

        private List<ATTDocumentProcess> _LstDocProcess = new List<ATTDocumentProcess>();
        public List<ATTDocumentProcess> LstDocProcess
        {
            get { return _LstDocProcess; }
            set { _LstDocProcess = value; }
        }

        public ATTDocument()
        {
        }

        public ATTDocument(int unitID,int docID,string documentName)
        {
            this.UnitID = unitID;
            this.DocID = docID;
            this.DocumentName = documentName;
        }

        public ATTDocument(int orgID,int unitID, int docID, string documentName,string docDescription,int flowID,string docFlowTypeName,int catID,string docCategoryName)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.DocID = docID;
            this.DocumentName = documentName;
            this.DocDescription = docDescription;
            this.DocFlowType = flowID;
            this.DocFlowTypeName =  docFlowTypeName;
            this.DocCategory = catID;
            this.DocCategoryName = docCategoryName;

        }

       
    }
}
