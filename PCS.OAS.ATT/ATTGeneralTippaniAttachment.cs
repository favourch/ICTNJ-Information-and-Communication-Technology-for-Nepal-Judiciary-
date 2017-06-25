using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTGeneralTippaniAttachment
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _TippaniID;
        public int TippaniID
        {
            get { return this._TippaniID; }
            set { this._TippaniID = value; }
        }

        private int _TippaniProcessID;
        public int TippaniProcessID
        {
            get { return this._TippaniProcessID; }
            set { this._TippaniProcessID = value; }
        }


        private int _AttachmentID;
        public int AttachmentID
        {
            get { return this._AttachmentID; }
            set { this._AttachmentID = value; }
        }

        private string _DocumentName;
        public string DocumentName
        {
            get { return this._DocumentName.Trim(); }
            set { this._DocumentName = value; }
        }

        private string _Description;
        public string Description
        {
            get { return this._Description.Trim(); }
            set { this._Description = value; }
        }

        private byte[] _RawContent;
        public byte[] RawContent
        {
            get { return this._RawContent; }
            set { this._RawContent = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTGeneralTippaniAttachment()
        {
        }
    }
}
