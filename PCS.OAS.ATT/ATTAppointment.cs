using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public  class ATTAppointment
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

        private int _AppointmentID;
        public int AppointmentID
        {
            get { return this._AppointmentID; }
            set { this._AppointmentID = value; }
        }

        private int _AppointmentCalledBy;
        public int AppointmentCalledBy
        {
            get { return this._AppointmentCalledBy; }
            set { this._AppointmentCalledBy = value; }
        }

        private string _AppointmentSubject = "";
        public string AppointmentSubject
        {
            get { return this._AppointmentSubject.Trim(); }
            set { this._AppointmentSubject = value; }
        }

        private string _AppointmentDate;
        public string AppointmentDate
        {
            get { return this._AppointmentDate; }
            set { this._AppointmentDate = value; }
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

        private string _Venue;
        public string Venue
        {
            get { return this._Venue; }
            set { this._Venue = value; }
        }


        private int _Status;
        public int Status
        {
            get { return this._Status; }
            set { this._Status = value; }
        }

        private string _EntryBy ;
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

        private List<ATTAppointee> _LstAppointee = new List<ATTAppointee>();
        public List<ATTAppointee> LstAppointee
        {
            get { return _LstAppointee; }
            set { _LstAppointee = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTAppointment()
        {
        }

        public ATTAppointment(int orgID,int appointmentID,int appointmentCalledBy,string appointmentSubject,
                              string appointmentDate,string startTime,string endTime,int status,string venue)
        {
            this.OrgID = orgID;
            this.AppointmentID = appointmentID;
            this.AppointmentCalledBy = appointmentCalledBy;
            this.AppointmentSubject = appointmentSubject;
            this.AppointmentDate = appointmentDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Status = status;
            this.Venue = venue;
        }

    }
}
