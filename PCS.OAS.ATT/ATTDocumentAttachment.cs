using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTDocumentAttachment
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

        private double _DocSequence;
        public double DocSequence
        {
            get { return this._DocSequence; }
            set { this._DocSequence = value; }
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

        private string _FileDescription;
        public string FileDescription
        {
            get { return this._FileDescription; }
            set { this._FileDescription = value; }
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

        public ATTDocumentAttachment()
        {
        }

        public ATTDocumentAttachment(int orgID, int unitID, int docID, double docSequence, int attachmentID, byte[] contentFile,
                                    string fileName,string fileDescription)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.DocID = docID;
            this.DocSequence = docSequence;
            this.AttachmentID = attachmentID;
            this.ContentFile = contentFile;
            this.FileName = fileName;
            this.FileDescription = fileDescription;
        }

        public ATTDocumentAttachment(byte[] contentFile, string cFileType, string filename, string fileDescription)
        {
            this.ContentFile = contentFile;
            this.CFileType = cFileType;
            this.FileName = filename;
            this.FileDescription = fileDescription;
        }

    }
}
