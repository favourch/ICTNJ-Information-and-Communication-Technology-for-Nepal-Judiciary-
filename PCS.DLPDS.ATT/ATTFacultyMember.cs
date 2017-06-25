using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.DLPDS.ATT
{
    public class ATTFacultyMember
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int _FacultyID;
        public int FacultyID
        {
            get { return _FacultyID; }
            set { _FacultyID = value; }

        }

        private double _PID;
        public double PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        private string _PName;
        public string PName
        {
            get { return _PName; }
            set { _PName = value; }
        }

        private ATTPerson _ObjPerson;
        public ATTPerson ObjPerson
        {
            get { return this._ObjPerson; }
            set { this._ObjPerson = value; }
        }

        private List<ATTParticipantPost> _LstParticipantPost = new List<ATTParticipantPost>();
        public List<ATTParticipantPost> LstParticipantPost
        {
            get { return this._LstParticipantPost; }
            set { this._LstParticipantPost = value; }
        }



        public ATTFacultyMember(int orgID, int facultyID, double pID, string fromDate, string toDate)
        {
            OrgID = orgID;
            FacultyID = facultyID;
            PID = pID;
            FromDate = fromDate;
            ToDate = toDate;
        }
        public ATTFacultyMember(int orgID, int facultyID, double pID, string fromDate, string toDate, string pName)
        {
            OrgID = orgID;
            FacultyID = facultyID;
            PID = pID;
            FromDate = fromDate;
            ToDate = toDate;
            PName = pName;
        }
    }
}
