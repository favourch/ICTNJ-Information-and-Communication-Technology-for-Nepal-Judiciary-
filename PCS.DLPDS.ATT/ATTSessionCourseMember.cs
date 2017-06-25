using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTSessionCourseMember
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

        private int ? _CourseID;
        public int ? CourseID
        {
            get { return this._CourseID; }
            set { this._CourseID = value; }
        }

        private int _FacultyID;
        public int FacultyID
        {
            get { return this._FacultyID; }
            set { this._FacultyID = value; }
        }

        private int _PID;
        public int PID
        {
            get { return this._PID; }
            set { this._PID = value; }
        }

        private string _PersonName;
        public string PersonName
        {
            get { return this._PersonName; }
            set { this._PersonName = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }

        private string _AssignmentDate;
        public string AssignmentDate
        {
            get { return this._AssignmentDate.Trim(); }
            set { this._AssignmentDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate.Trim(); }
            set { this._ToDate = value; }
        }

        private int _MarksObtained;
        public int MarksObtained
        {
            get { return this._MarksObtained; }
            set { this._MarksObtained = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTSessionCourseMember()
        {
        }

        public ATTSessionCourseMember(int orgID, int programID, int sessionID, int ? courseID, int facultyID, int pID,string personName, string fromDate, int marksObtained)
        {
            this.OrgID = orgID;
            this.ProgramID = programID;
            this.SessionID = sessionID;
            this.CourseID = courseID;
            this.FacultyID = facultyID;
            this.PID = pID;
            this.PersonName = personName;
            this.FromDate = fromDate;
            this.MarksObtained = marksObtained;
        }
    }
}
