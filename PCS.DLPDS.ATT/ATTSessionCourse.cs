using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
   public class ATTSessionCourse
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int _ProgramID;

        public int ProgramID
        {
            get { return _ProgramID; }
            set { _ProgramID = value; }
        }

        private int _SessionID;

        public int SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }

        private int _CourseID;

        public int CourseID
        {
            get { return _CourseID; }
            set { _CourseID = value; }
        }


       private string _CourseName = "";
        public string CourseName
        {
            get { return this._CourseName.Trim(); }
            set { this._CourseName = value; }
        }





       private ATTCourse _CourseOBJ;
        public ATTCourse CourseOBJ
        {
            get { return _CourseOBJ; }
            set { _CourseOBJ = value; }
        }
	

        public string CourseTitle
        {
            get { return CourseOBJ.CourseTitle; }
            
        }
	

        private string  _FromDate;

        public string  FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string  _ToDate;

        public string  ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        private string  _SyllabusDocPath;

        public string  SyllbusDocPath
        {
            get { return _SyllabusDocPath; }
            set { _SyllabusDocPath = value; }
        }
        private string  _Action;

        public string  Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private List<ATTSessionCourseMaterial> _LstSessionCourseMaterial = new List<ATTSessionCourseMaterial>();
        public List<ATTSessionCourseMaterial> LstSessionCourseMaterial
        {
            get { return this._LstSessionCourseMaterial; }
            set { this._LstSessionCourseMaterial = value; }
        }

        private List<ATTSessionCourseMember> _LstSessionCourseMember = new List<ATTSessionCourseMember>();
        public List<ATTSessionCourseMember> LstSessionCourseMember
        {
            get { return this._LstSessionCourseMember; }
            set { this._LstSessionCourseMember = value; }
        }

       public ATTSessionCourse()
       {
       }

       public ATTSessionCourse(int orgID, int programID, int sessionID, int courseID, string fromDate, string toDate, string syllabusDocPath,string action)
       {
           this.OrgID = orgID;
           this.ProgramID = programID;
           this.SessionID = sessionID;
           this.CourseID = courseID;
           this.FromDate = fromDate;
           this.ToDate = toDate;
           this.SyllbusDocPath = syllabusDocPath;
           this.Action = action;
       }
	
	
	
	
    }
}
