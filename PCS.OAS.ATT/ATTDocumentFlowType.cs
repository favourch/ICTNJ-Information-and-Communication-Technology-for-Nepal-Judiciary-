using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTDocumentFlowType
    {
        private int __DocFlowID;
        public int DocFlowID
        {
            get { return this.__DocFlowID; }
            set { this.__DocFlowID = value; }
        }

        private string _DocFlowName;
        public string DocFlowName
        {
            get { return this._DocFlowName; }
            set { this._DocFlowName = value; }
        }

        private string _DocFlowDescription;
        public string DocFlowDescription
        {
            get { return this._DocFlowDescription; }
            set { this._DocFlowDescription = value; }
        }

        public ATTDocumentFlowType()
        {
        }


        public ATTDocumentFlowType(int docFlowID,string docFlowName,string docFlowDescription)
        {
            this.DocFlowID = docFlowID;
            this.DocFlowName = docFlowName;
            this.DocFlowDescription = docFlowDescription;
        }
    }
}
