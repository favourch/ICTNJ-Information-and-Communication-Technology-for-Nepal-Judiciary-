using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTDocumentsType
    {
        private int _DocTypeID;
        public int DocTypeID
        {
            get { return this._DocTypeID; }
            set { this._DocTypeID = value; }
        }

        private string _DocTypeName;
        public string DocTypeName
        {
            get { return this._DocTypeName; }
            set { this._DocTypeName = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTDocumentsType()
        {
        }

        public ATTDocumentsType(int docTypeID, string docTypeName)
        {
            this.DocTypeID = docTypeID;
            this.DocTypeName = docTypeName;
        }

    }
}
