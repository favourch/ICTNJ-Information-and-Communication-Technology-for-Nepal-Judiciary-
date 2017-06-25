using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingInfo
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _MeetingID;
        public int MeetingID
        {
            get { return this._MeetingID; }
            set { this._MeetingID = value; }
        }

        private string _Subject = "";
        public string Subject
        {
            get { return this._Subject.Trim(); }
            set { this._Subject = value; }
        }

        private string _MeetingTypeName;
        public string MeetingTypeName
        {
            get { return this._MeetingTypeName.Trim(); }
            set { this._MeetingTypeName = value; }
        }

        private string _Venue;
        public string Venue
        {
            get { return this._Venue.Trim(); }
            set { this._Venue = value; }
        }

        private string _MeetingDate;
        public string MeetingDate
        {
            get { return this._MeetingDate.Trim(); }
            set { this._MeetingDate = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate.Trim(); }
            set { this._ToDate = value; }
        }

        private string _CalledBy;
        public string CalledBy
        {
            get { return this._CalledBy.Trim(); }
            set { this._CalledBy = value; }
        }

        private string _StartTime;
        public string StartTime
        {
            get { return this._StartTime.Trim(); }
            set { this._StartTime = value; }
        }

        private string _EndTime;
        public string EndTime
        {
            get { return this._EndTime.Trim(); }
            set { this._EndTime = value; }
        }

        private string _Status;
        public string Status
        {
            get { return this._Status.Trim(); }
            set { this._Status = value; }
        }

        private string _CalledPID;
        public string CalledPID
        {
            get { return this._CalledPID; }
            set { this._CalledPID = value; }
        }

        public ATTMeetingInfo()
        {
        }
    }
}
