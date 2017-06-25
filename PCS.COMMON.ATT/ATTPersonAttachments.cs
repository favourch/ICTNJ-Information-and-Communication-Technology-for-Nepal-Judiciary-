using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonAttachments
    {
        private double _EmpID;

        public double EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private int _AttSeq;

        public int AttSeq
        {
            get { return _AttSeq; }
            set { _AttSeq = value; }
        }

        private string _AttachmentDate;

        public string AttachmentDate
        {
            get { return _AttachmentDate; }
            set { _AttachmentDate = value; }
        }

        private string _AttachmentTitle;

        public string AttachmentTitle
        {
            get { return _AttachmentTitle; }
            set { _AttachmentTitle = value; }
        }

        private string _AttachmentContent;

        public string AttachmentContent
        {
            get { return _AttachmentContent; }
            set { _AttachmentContent = value; }
        }

        private string _AttachmentDesc;

        public string AttachmentDesc
        {
            get { return _AttachmentDesc; }
            set { _AttachmentDesc = value; }
        }

        private byte[] _AttachmentDocs;

        public byte[] AttachmentDocs
        {
            get { return _AttachmentDocs; }
            set { _AttachmentDocs = value; }
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

        public ATTPersonAttachments()
        {

        }
	
    }
}
