using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingAgenda
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

        private int _AgendaID;
        public int AgendaID
        {
            get { return this._AgendaID; }
            set { this._AgendaID = value; }
        }


        private string _Agenda = "";
        public string Agenda
        {
            get { return this._Agenda.Trim(); }
            set { this._Agenda = value; }
        }

        private string _EntryBy="" ;
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

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTMeetingAgenda()
        {
        }

        public ATTMeetingAgenda(string agenda,string action)
        {
            this.Agenda = agenda;
            this.Action = action;
        }

        public ATTMeetingAgenda(string agenda, string action, string entryBy)
        {
            this.Agenda = agenda;
            this.Action = action;
            this.EntryBy = entryBy;
        }

        public ATTMeetingAgenda(string agenda)
        {
            this.Agenda = agenda;
        }


        //public ATTMeetingAgenda(int orgID,int unitID,int meetingID,int agendaID,string agenda)
        //{
        //    this.OrgID = orgID;
        //    this.UnitID = unitID;
        //    this.MeetingID = meetingID;
        //    this.AgendaID = agendaID;
        //    this.Agenda = agenda;

        //}

        public ATTMeetingAgenda(int orgID, int meetingID, int agendaID, string agenda)
        {
            this.OrgID = orgID;
           // this.UnitID = unitID;
            this.MeetingID = meetingID;
            this.AgendaID = agendaID;
            this.Agenda = agenda;

        }
    }
}
