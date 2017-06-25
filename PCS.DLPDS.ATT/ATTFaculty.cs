using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTFaculty
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _FacultyID;
        public int FacultyID
        {
            get { return _FacultyID; }
            set { _FacultyID = value; }
        }

        private string _FacultyName;
        public string FacultyName
        {
            get { return _FacultyName; }
            set { _FacultyName = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public ATTFaculty()
        { }
	
    }
}
