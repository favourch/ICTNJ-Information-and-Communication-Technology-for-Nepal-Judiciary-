using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTParticipantSearch
    {
        private double _ParticipantID;
        public double ParticipantID
        {
            get {return this._ParticipantID;}
            set {this._ParticipantID=value;}
        }

        private string _FirstName;
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return this._MiddleName; }
            set { this._MiddleName = value; }
        }

        private string _SurName;
        public string SurName
        {
            get { return this._SurName; }
            set { this._SurName = value; }
        }

        public string RDFullName
        {
            get
            {
                string strFullName;
                strFullName = this.FirstName;
                strFullName += (this.MiddleName == "" ? "" : " " + this.MiddleName);
                strFullName += (this.SurName == "" ? "" : " " + this.SurName);
                return strFullName;
            }
        }


        private string _Gender;
        public string Gender
        {
            get { return this._Gender; }
            set { this._Gender = value; }
        }

        public string RDGender
        {
            get
            {
                if (this.Gender == "M") return "k'?if";
                else if (this.Gender == "F") return "dlxnf";
                else if (this.Gender == "O") return "cGo";
                else return "";
            }
        }

        private string _DOB;
        public string DOB
        {
            get { return this._DOB; }
            set { this._DOB = value; }
        }

        private string _District;
        public string District
        {
            get { return this._District; }
            set { this._District = value; }
        }

        private string _FatherName;
        public string FatherName
        {
            get { return this._FatherName; }
            set { this._FatherName = value; }
        }

        private string _GFatherName;
        public string GFatherName
        {
            get { return this._GFatherName; }
            set { this._GFatherName = value; }
        }

        public ATTParticipantSearch()
        {
        }

        public ATTParticipantSearch(double participantID, string fName, string mName, string surName,
            string gender, string dob, string district, string fatherName, string gfatherName)
        {
            this.ParticipantID = participantID;
            this.FirstName = fName;
            this.MiddleName = mName;
            this.SurName = surName;
            this.Gender = gender;
            this.DOB = dob;
            this.District = district;
            this.FatherName = fatherName;
            this.GFatherName = gfatherName;
        }
    }
}
