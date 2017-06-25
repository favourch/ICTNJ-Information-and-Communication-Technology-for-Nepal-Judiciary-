using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTDocumentProcess
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

        private double _DocSequence ;
        public double DocSequence
        {
            get { return this._DocSequence; }
            set { this._DocSequence = value; }
        }
        
        private string _CreatedBy ="Er.Razu";
        public string CreatedBy
        {
            get { return this._CreatedBy;}
            set { this._CreatedBy = value;}
        }

        private string _SentTo;
        public string SentTo
        {
            get { return this._SentTo; }
            set { this._SentTo = value; }
        }

        private string _SentType;
        public string SentType
        {
            get { return this._SentType; }
            set { this._SentType = value; }
        }

        private string _Status;
        public string Status
        {
            get { return this._Status; }
            set { this._Status = value; }
        }

        private string _HasReceived ="N";
        public string HasReceived
        {
            get { return this._HasReceived;}
            set { this._HasReceived= value;}
        }

        private string _Note;
        public string Note
        {
            get { return this._Note;}
            set { this._Note = value;}
        }

        public ATTDocumentProcess()
        {

        }

        public ATTDocumentProcess(int orgID, int unitID, int docID, double docSequence, string createdBy, 
                                       string sentTo,string sentType,string status, string hasReceived,string note )
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.DocID = docID;
            this.DocSequence = docSequence;
            this.CreatedBy = createdBy;
            this.SentTo = sentTo;
            this.SentType = sentType;
            this.Status = status;
            this.HasReceived = hasReceived;
            this.Note = note;
        }

        public ATTDocumentProcess(string sentTo, string sentType, string status, string note)
        {
            this.SentTo = sentTo;
            this.SentType = sentType;
            this.Status = status;
            this.Note = note;
        }

        //public ATTDocumentProcess(int orgID, int unitID, int docID, double docSequence,string sentTo) //, string sentTo)
        //{
        //    this.OrgID = orgID;
        //    this.UnitID = unitID;
        //    this.DocID = docID;
        //    this.DocSequence = docSequence;
        //    this.SentTo = sentTo;
            
        //    //this.SentTo = sentTo;
        //}
    }
}
