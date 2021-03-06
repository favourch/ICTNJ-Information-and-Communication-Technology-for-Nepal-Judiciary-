using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTAppointmentEvent
    {
        private int _Day;
        public int Day
        {
            get { return this._Day; }
            set { this._Day = value; }
        }

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


        private int _EventID;
        public int EventID
        {
            get { return this._EventID; }
            set { this._EventID = value; }
        }

        private string _Event;
        public string Event
        {
            get { return this._Event; }
            set { this._Event = value; }
        }

        private string _EventDetail;
        public string EventDetail
        {
            get { return this._EventDetail; }
            set { this._EventDetail = value; }
        }

        private List<ATTAppointment> _LstAppointment = new List<ATTAppointment>();
        public List<ATTAppointment> LstAppointment
        {
            get { return _LstAppointment; }
            set { _LstAppointment = value; }
        }

        private string _StatusColor;
        public string StatusColor
        {
            get { return this._StatusColor; }
            set { _StatusColor = value; }
        }

        private string _InOut;
        public string InOut
        {
            get { return this._InOut; }
            set { this._InOut = value; }
        }

        public System.Drawing.Color RDStatusColor
        {
            get
            {
                return System.Drawing.Color.FromName(this._StatusColor);
            }
        }

        public ATTAppointmentEvent()
        {
        }


    }
}
