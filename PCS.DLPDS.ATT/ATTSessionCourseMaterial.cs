using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTSessionCourseMaterial
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _ProgramID;
        public int ProgramID
        {
            get { return this._ProgramID; }
            set { this._ProgramID = value; }
        }

        private int _SessionID;
        public int SessionID
        {
            get { return this._SessionID; }
            set { this._SessionID = value; }
        }

        private int _CourseID;
        public int CourseID
        {
            get { return this._CourseID; }
            set { this._CourseID = value; }
        }

        private int _MaterialID;
        public int MaterialID
        {
            get { return this._MaterialID; }
            set { this._MaterialID = value; }
        }

        //private string _ServerPath;
        //public string ServerPath
        //{
        //    get { return this._ServerPath.Trim(); }
        //    set { this._ServerPath = value; }
        //}

        private string _MaterialName;
        public string MaterialName
        {
            get { return this._MaterialName.Trim(); }
            set { this._MaterialName = value; }
        }

        //private byte[] _FileBytes;
        //public byte[] FileBytes
        //{
        //    get { return this._FileBytes; }
        //    set { this._FileBytes = value; }
        //}

        private int? _MaterialTypeID;
        public int? MaterialTypeID
        {
            get { return this._MaterialTypeID; }
            set { this._MaterialTypeID = value; }
        }

        private object _FileUploader;
        public object FileUploader
        {
            get { return this._FileUploader; }
            set { this._FileUploader = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTSessionCourseMaterial() { }

        public ATTSessionCourseMaterial(int orgID, int progID, int sessionID, int courseID, int materialID, string materialName, int? typeID, string action,object obj)
        {
            this.OrgID = orgID;
            this.ProgramID = progID;
            this.SessionID = sessionID;
            this.CourseID = courseID;
            this.MaterialID = materialID;
            this.MaterialName = materialName;
            //this.FileBytes = filebyte;
            this.MaterialTypeID = typeID;
            this.Action = action;
            this.FileUploader = obj;
            //this.ServerPath = serverPath;
        }
    }
}
