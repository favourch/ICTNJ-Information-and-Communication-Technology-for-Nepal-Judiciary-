using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeeting
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private int _MeetingID;
        public int MeetingID
        {
            get { return this._MeetingID; }
            set { this._MeetingID = value; }
        }

        private int _MeetingTypeID;
        public int MeetingTypeID
        {
            get { return this._MeetingTypeID; }
            set { this._MeetingTypeID = value; }
        }

        private int _VenueID;
        public int VenueID
        {
            get { return this._VenueID; }
            set { this._VenueID = value; }
        }

        private string _Subject = "";
        public string Subject
        {
            get { return this._Subject.Trim(); }
            set { this._Subject = value; }
        }

        private string _MeetingDate;
        public string MeetingDate
        {
            get { return this._MeetingDate; }
            set { this._MeetingDate = value; }
        }

        private int? _CalledBy ;
        public int? CalledBy
        {
            get { return this._CalledBy; }
            set { this._CalledBy = value; }
        }

        private int? _CalledByPID;
        public int? CalledByPID
        {
            get { return this._CalledByPID; }
            set { this._CalledByPID = value; }
        }

        private string _IsGrpCaller;
        public string IsGrpCaller
        {
            get { return this._IsGrpCaller; }
            set { this._IsGrpCaller = value; }
        }

        private string _StartTime;
        public string StartTime
        {
            get { return this._StartTime; }
            set { this._StartTime = value; }
        }

        private string _EndTime;
        public string EndTime
        {
            get { return this._EndTime; }
            set { this._EndTime = value; }
        }


     
        private string _EntryBy="";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        private int _Status ;
        public int Status
        {
            get { return this._Status; }
            set { this._Status = value; }
        }

        

        private string _Remark = "";
        public string Remark
        {
            get { return this._Remark.Trim(); }
            set { this._Remark = value; }
        }

        private string _VenueType;

        public string VenueType
        {
            get { return _VenueType; }
            set { _VenueType = value; }
        }

        private string  _VenueData = "";

        public string VenueData
        {
            get { return _VenueData; }
            set { _VenueData = value; }
        }

        private int? _VenueBookingID = null;

        public int? VenueBookingID
        {
            get { return _VenueBookingID; }
            set { _VenueBookingID = value; }
        }

        private List<ATTMeetingAgenda> _LstMeetingAgenda = new List<ATTMeetingAgenda>();
        public List<ATTMeetingAgenda> LstMeetingAgenda
        {
            get { return _LstMeetingAgenda; }
            set { _LstMeetingAgenda = value; }
        }

        private List<ATTMeetingParticipant> _LstMeetingParticipant = new List<ATTMeetingParticipant>();
        public List<ATTMeetingParticipant> LstMeetingParticipant
        {
            get { return _LstMeetingParticipant; }
            set { _LstMeetingParticipant = value; }
        }

        public ATTMeeting()
        {
        }

       
        public ATTMeeting(int orgID, int unitID, int meetingID, int meetingTypeID, int venueID, string subject, string meetingDate,
                       int? calledBy, string startTime, string endTime)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.MeetingID = meetingID;
            this.MeetingTypeID = meetingTypeID;
            this.VenueID = venueID;
            this.Subject = subject;
            this.MeetingDate = meetingDate;
            this.CalledBy = calledBy;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public ATTMeeting(int orgID, int meetingID, int meetingTypeID, int venueID, string subject, string meetingDate,
                      int? calledBy, string startTime, string endTime)
        {
            this.OrgID = orgID;
            this.MeetingID = meetingID;
            this.MeetingTypeID = meetingTypeID;
            this.VenueID = venueID;
            this.Subject = subject;
            this.MeetingDate = meetingDate;
            this.CalledBy = calledBy;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
