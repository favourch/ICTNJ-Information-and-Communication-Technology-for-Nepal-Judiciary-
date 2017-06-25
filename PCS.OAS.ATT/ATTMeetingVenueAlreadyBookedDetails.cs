using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingVenueAlreadyBookedDetails
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _orgName;

        public string OrgName
        {
            get { return _orgName; }
            set { _orgName = value; }
        }


        private int _VenueID;
        public int VenueID
        {
            get { return this._VenueID; }
            set { this._VenueID = value; }
        }

        private string _VenueName;

        public string VenueName
        {
            get { return _VenueName; }
            set { _VenueName = value; }
        }


        private int? _BookedBy;
        public int? BookedBy
        {
            get { return this._BookedBy; }
            set { this._BookedBy = value; }
        }

        private string _BookerName;

        public string BookerName
        {
            get { return _BookerName; }
            set { _BookerName = value; }
        }


        private string _Purpose;
        public string Purpose
        {
            get { return this._Purpose; }
            set { this._Purpose = value; }
        }

        private string _BookingDate = "";
        public string BookingDate
        {
            get { return this._BookingDate; }
            set { this._BookingDate = value; }
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
    }
}
