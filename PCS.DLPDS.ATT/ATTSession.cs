using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTSession
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

        private string _SessionName;
        public string SessionName
        {
            get { return this._SessionName; }
            set { this._SessionName = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }
         

        private string _Time;
        public string Time
        {
            get { return this._Time; }
            set { this._Time = value; }
        }


        public string FullSessionName
        {
            get { return this.SessionName + " " + this.FromDate + "/Time: " + this.Time; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action=value;}
        }

        private List<ATTSessionCourse> _LstSessionCourse=new List<ATTSessionCourse>();

        public List<ATTSessionCourse> LstSessionCourse
        {
            get { return _LstSessionCourse; }
            set { _LstSessionCourse = value; }
        }

        public ATTSession()
        {
        }
        
        public ATTSession(int orgID, int programID, int sessionID, string sessionName,string fromDate, string time,string toDate,string action)
        {
            this.OrgID = orgID;
            this.ProgramID = programID;
            this.SessionID = sessionID;
            this.SessionName = sessionName;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Time = time;
            this.Action = action;
        }
    }
}
