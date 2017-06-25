using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTAppointmentStatus
    {
        private int _AppointmentStatusID;
        public int AppointmentStatusID
        {
            get { return this._AppointmentStatusID; }
            set { this._AppointmentStatusID = value; }
        }

        private string _AppointmentStatusName;
        public string AppointmentStatusName
        {
            get { return this._AppointmentStatusName.Trim(); }
            set { this._AppointmentStatusName = value; }
        }

        private string _AppointmentStatusColor;
        public string AppointmentStatusColor
        {
            get { return this._AppointmentStatusColor.Trim(); }
            set { this._AppointmentStatusColor = value; }
        }

        public System.Drawing.Color RDStatusColor
        {
            get
            {
                return System.Drawing.Color.FromName(this._AppointmentStatusColor);
            }
        }


        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTAppointmentStatus()
        {
        }

        public ATTAppointmentStatus(int appointmentStatusID, string appointmentStatusName, string appointmentStatusColor)
        {
            this.AppointmentStatusID = appointmentStatusID;
            this.AppointmentStatusName = appointmentStatusName;
            this.AppointmentStatusColor = appointmentStatusColor;
        }
    }
}
