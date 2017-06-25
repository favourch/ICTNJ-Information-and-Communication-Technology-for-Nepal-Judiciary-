using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTAppointmentOutdoorParticipant
    {
        private string _AppointeeName;
        public string AppointeeName
        {
            get { return this._AppointeeName.Trim(); }
            set { this._AppointeeName = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName.Trim(); }
            set { this._OrgName = value; }
        }

        private string _IsIndoorAppointee;
        public string IsIndoorAppointee
        {
            get { return this._IsIndoorAppointee; }
            set { this._IsIndoorAppointee = value; }
        }

        private DateTime _DateCreated;
        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }

        public ATTAppointmentOutdoorParticipant()
        {
        }


        public  ATTAppointmentOutdoorParticipant(string appointeeName,string orgName,DateTime dateCreated)
        {
            AppointeeName = appointeeName;
            OrgName = orgName;
            DateCreated = dateCreated;
        }
    }
}
