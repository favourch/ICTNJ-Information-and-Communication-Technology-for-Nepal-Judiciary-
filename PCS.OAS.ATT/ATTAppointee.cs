using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTAppointee
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _AppointmentID;
        public int AppointmentID
        {
            get { return this._AppointmentID; }
            set { this._AppointmentID = value; }
        }

        private int? _ApID;
        public int? ApID
        {
            get { return this._ApID; }
            set { this._ApID = value; }
        }


        private int? _AppointeeID;
        public int? AppointeeID
        {
            get { return this._AppointeeID; }
            set { this._AppointeeID = value; }
        }

        private string _Appointee;
        public string Appointee
        {
            get { return this._Appointee.Trim(); }
            set { this._Appointee = value; }
        }

        private string _IsIndoorAppointee;
        public string IsIndoorAppointee
        {
            get { return this._IsIndoorAppointee; }
            set { this._IsIndoorAppointee = value; }
        }

        private string _Note = "";
        public string Note
        {
            get { return this._Note.Trim(); }
            set { this._Note = value; }
        }

        private DateTime _NoteOn;
        public DateTime NoteOn
        {
            get { return this._NoteOn.Date; }
            set { this._NoteOn = value; }
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
            get { return this._EntryOn; }
            set { this._EntryOn = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }


        private string _OutdoorOrgName;
        public string OutdoorOrgName
        {
            get { return this._OutdoorOrgName.Trim(); }
            set { this._OutdoorOrgName = value; }
        }

        private string _Flag ="";

        public string Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }

        private string _Remark="";

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
	


        public ATTAppointee()
        {
        }

        public ATTAppointee(int? appointeeID, string appointee, string isIndoorAppointee,string outdoorOrgName,string action,string entryBy,DateTime entryOn)
        {
            AppointeeID = appointeeID;
            Appointee = appointee;
            IsIndoorAppointee = isIndoorAppointee;
            OutdoorOrgName = outdoorOrgName;
            Action = action;
            EntryBy = entryBy;
            EntryOn = entryOn;
        }

        public ATTAppointee(int orgID,int appointmentID,int? appointeeID,string appointee, string isIndoorAppointee,string action)
        {
            OrgID = orgID;
            AppointmentID = appointmentID;
            AppointeeID = appointeeID;
            Appointee = appointee;
            IsIndoorAppointee = isIndoorAppointee;
            Action = action;
        }
    }
}
