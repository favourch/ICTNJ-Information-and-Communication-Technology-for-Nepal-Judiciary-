using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingParticipant
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

        private int _ParticipantID;
        public int ParticipantID
        {
            get { return this._ParticipantID; }
            set { this._ParticipantID = value; }
        }

        private int? _ParticipantOrgID;
        public int? ParticipantOrgID
        {
            get { return this._ParticipantOrgID; }
            set { this._ParticipantOrgID = value; }
        }

        private string _Participant;
        public string Participant
        {
            get { return this._Participant.Trim(); }
            set { this._Participant = value; }
        }

        private string _IsGrpParticipant;
        public string IsGrpParticipant
        {
            get { return this._IsGrpParticipant; }
            set { this._IsGrpParticipant = value; }
        }

        private int? _PositionID;
        public int? PositionID
        {
            get { return this._PositionID; }
            set { this._PositionID = value; }
        }

        private string _PositionName;
        public string PositionName
        {
            get { return this._PositionName; }
            set { this._PositionName = value; }
        }

        private int? _MeetingMemPosID;
        public int? MeetingMemPosID
        {
            get { return this._MeetingMemPosID; }
            set { this._MeetingMemPosID = value; }
        }

        private string _MeetingMemPosName;
        public string MeetingMemPosName
        {
            get { return this._MeetingMemPosName; }
            set { this._MeetingMemPosName = value; }
        }

        private string _IsAgreeOnMinute = "";
        public string IsAgreeOnMinute
        {
            get { return this._IsAgreeOnMinute.Trim(); }
            set { this._IsAgreeOnMinute = value; }
        }

        private string _IsPresent = "";
        public string IsPresent
        {
            get { return this._IsPresent.Trim(); }
            set { this._IsPresent = value; }
        }

        private string _Note = "";
        public string Note
        {
            get { return this._Note.Trim(); }
            set { this._Note = value; }
        }

        private int? _GroupID;
        public int? GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private int? _pDesID;
        public int? pDesID
        {
            get { return this._pDesID; }
            set { this._pDesID = value; }
        }

        private string _pDesName;
        public string pDesName
        {
            get { return this._pDesName; }
            set { this._pDesName = value; }
        }


        private string _IsGrpCaller;
        public string IsGrpCaller
        {
            get { return this._IsGrpCaller; }
            set { this._IsGrpCaller = value; }
        }

        private string _Action ;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private string _EntryBy = "";
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

        public ATTMeetingParticipant()
        {
        }

        public ATTMeetingParticipant(int? participantOrgID, int participantID, string participant, int? groupID,
                                         string isGrpParticipant, int? positionID, string positionName, int? meetingMemPosID,
                                         string meetingMemPosName, string action, string entryBy, string isGrpCaller)
        {
            this.ParticipantOrgID = participantOrgID;
            this.ParticipantID = participantID;
            this.Participant = participant;
            this.GroupID = groupID;
            this.IsGrpParticipant = isGrpParticipant;
            this.PositionID = positionID;
            this.PositionName = positionName;
            this.MeetingMemPosID = meetingMemPosID;
            this.MeetingMemPosName = meetingMemPosName;
            //this.SaveStatus = SaveStatus;
            this.Action = action;
            this.EntryBy = entryBy;
            //this.pDesID = ds
            this.IsGrpCaller = isGrpCaller;


        }

        public ATTMeetingParticipant(int orgID, int meetingID, int participantID, string participant,
            int? participantOrgID, int? groupID, string note, string isGrpParticipant,
            int? meetingMemPosID,int? positionID,string positionName,string action,string isPresent)
        {
            this.OrgID = orgID;
            this.MeetingID = meetingID;
            this.ParticipantID = participantID;
            this.Participant = participant;
            this.ParticipantOrgID = participantOrgID;
            this.GroupID = groupID;
            this.Note = note;
            this.IsGrpParticipant = isGrpParticipant;
            this.MeetingMemPosID = meetingMemPosID;
            this.PositionID = positionID;
            this.PositionName = positionName;
            this.Action = action;
            this.IsPresent = isPresent;
            //this.PositionID = positionID;;
            //this.Status = status;
        }



    }
}
