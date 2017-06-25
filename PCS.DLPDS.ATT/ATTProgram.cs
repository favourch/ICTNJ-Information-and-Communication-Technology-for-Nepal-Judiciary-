using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTProgram
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
            get {return this._ProgramID; }
            set { this._ProgramID = value; }
        }

        private string _ProgramName;
        public string ProgramName
        {
            get { return this._ProgramName; }
            set { this._ProgramName = value; }
        }

        private int _ProgramTypeID;
        public int ProgramTypeID
        {
            get { return this._ProgramTypeID; }
            set { this._ProgramTypeID = value; }
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

        private string _LaunchDate;
        public string LaunchDate
        {
            get { return this._LaunchDate; }
            set { this._LaunchDate = value; }
        }

        private string _Duration;
        public string Duration
        {
            get { return this._Duration; }
            set { this._Duration = value; }
        }

        private int _DurationTypeID;
        public int DurationTypeID
        {
            get { return this._DurationTypeID; }
            set { this._DurationTypeID = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private string _Location;
        public string Location
        {
            get { return this._Location; }
            set { this._Location = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTProgramCoordinator> _PrgCoordinatorLST=new List<ATTProgramCoordinator>();
        public List<ATTProgramCoordinator> PrgCoordinatorLST
        {
            get { return _PrgCoordinatorLST; }
            set { _PrgCoordinatorLST = value; }
        }
	

        private List<ATTProgramSponsor> _PrgSponsorLST = new List<ATTProgramSponsor>();
        public List<ATTProgramSponsor> PrgSponsorLST
        {
            get { return this._PrgSponsorLST; }
            set { this._PrgSponsorLST = value; }
        }

        private List<ATTSession> _SessionLST = new List<ATTSession>();
        public List<ATTSession> SessionLST
        {
            get { return this._SessionLST; }
            set { this._SessionLST = value; }
        }

        private List<ATTCourse> _CourseLST = new List<ATTCourse>();
        public List<ATTCourse> CourseLST
        {
            get { return this._CourseLST; }
            set { this._CourseLST = value; }
        }


        public ATTProgram(int orgID, int programID, string programName, int porgramTypeID, string description, string active, string launchDate, string duration, int durationTypeID, string toDate, string location, string action)
        {
            this.OrgID = orgID;
            this.ProgramID = programID;
            this.ProgramName = programName;
            this.ProgramTypeID = porgramTypeID;
            this.Description = description;
            this.Active = active;
            this.LaunchDate = launchDate;
            this.Duration = duration;
            this.DurationTypeID = durationTypeID;
            this.Action = action;
            this.ToDate = toDate;
            this.Location = location;
        }
    }
}
