using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTCourse
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

        private int _CourseID;
        public int CourseID
        {
            get { return this._CourseID; }
            set { this._CourseID = value; }
        }

        private string _CourseTitle;
        public string CourseTitle
        {
            get { return this._CourseTitle; }
            set { this._CourseTitle = value; }
        }

        private string _Description;
        public string Description
        {
            get { return this._Description; }
            set { this._Description = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTCourse(int orgID, int programID, int courseID, string courseTitle, string description, string active, string action)
        {
            this.OrgID = orgID;
            this.ProgramID = programID;
            this.CourseID = courseID;
            this.CourseTitle = courseTitle;
            this.Description = description;
            this.Active = active;
            this.Action = action;
        }

    }
}
