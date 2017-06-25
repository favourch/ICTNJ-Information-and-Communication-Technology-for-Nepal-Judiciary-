using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingResponse
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

        private int? _ResponseID = null;
        public int? ResponseID
        {
            get { return this._ResponseID; }
            set { this._ResponseID = value; }
        }

        private string _Response;
        public string Response
        {
            get { return this._Response.Trim(); }
            set { this._Response = value; }
        }

        private string _ResponseBy;
        public string ResponseBy
        {
            get { return this._ResponseBy.Trim(); }
            set { this._ResponseBy = value; }
        }


        private string _EntryBy;
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
        private DateTime _NoteOn;
        public DateTime NoteOn
        {
            get
            {
                System.Globalization.CultureInfo CInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                return DateTime.ParseExact(this._NoteOn.ToString(), "G", CInfo);
            }
            set
            {
                System.Globalization.CultureInfo CInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                this._NoteOn = DateTime.ParseExact(value.ToString(), "G", CInfo);
                //his._NoteOn = value;
            }
        }

        private string _IsAgree;
        public string IsAgree
        {
            get { return this._IsAgree; }
            set { this._IsAgree = value; }
        }

        public ATTMeetingResponse()
        {
        }

    }
}
