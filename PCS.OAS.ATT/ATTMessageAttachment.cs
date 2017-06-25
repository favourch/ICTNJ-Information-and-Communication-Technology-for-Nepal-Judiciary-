using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMessageAttachment
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int? _MessageID;
        public int? MessageID
        {
            get { return this._MessageID; }
            set { this._MessageID = value; }
        }

        private int _AttachmentID;
        public int AttachmentID
        {
            get { return this._AttachmentID; }
            set { this._AttachmentID = value; }
        }


        private string _FileName;
        public string FileName
        {
            get { return this._FileName; }
            set { this._FileName = value; }
        }

        private string _DisplayName;
        public string DisplayName
        {
            get { return this._DisplayName; }
            set { this._DisplayName = value; }
        }


        private byte[] _ContentFile = null;
        public byte[] ContentFile
        {
            get { return this._ContentFile; }
            set { this._ContentFile = value; }
        }

        private string _CFileType = "";
        public string CFileType
        {
            get { return this._CFileType.Trim(); }
            set { this._CFileType = value; }
        }

        private DateTime _DateCreated;

        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }
	

        public ATTMessageAttachment()
        {
        }

        public ATTMessageAttachment(int orgID,int messageID,int attachmentID,string filename,byte[] contentFile)
        {
            this.OrgID = orgID;
            this.MessageID = messageID;
            this.AttachmentID = attachmentID;
            this.FileName = filename;
            this.ContentFile = contentFile;
        }

        public ATTMessageAttachment(byte[] contentFile, string cFileType, string filename,DateTime dateCreated)
        {
            this.ContentFile = contentFile;
            this.CFileType = cFileType;
            this.FileName = filename;
            this.DateCreated = dateCreated;
        }

        public ATTMessageAttachment(byte[] contentFile, string cFileType, string filename,string displayName, DateTime dateCreated)
        {
            this.ContentFile = contentFile;
            this.CFileType = cFileType;
            this.FileName = filename;
            this.DisplayName = displayName;
            this.DateCreated = dateCreated;
        }
    }
}
