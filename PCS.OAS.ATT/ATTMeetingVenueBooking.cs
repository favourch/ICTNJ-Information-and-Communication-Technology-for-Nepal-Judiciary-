using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingVenueBooking
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
	

        private int _BookingID;
        public int BookingID
        {
            get { return this._BookingID; }
            set { this._BookingID = value; }
        }


        private int? _BookedBy;
        public int? BookedBy
        {
            get { return this._BookedBy; }
            set { this._BookedBy = value; }
        }

        private string _BookedByName;

        public string BookedByName
        {
            get { return _BookedByName; }
            set { _BookedByName = value; }
        }
	

        private string _Purpose;
        public string Purpose
        {
            get { return this._Purpose; }
            set { this._Purpose = value; }
        }

        private string _BookingDate ="";
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

        private string _Active = "Y";
        public string Active
        {
            get { return this._Active.Trim(); }
            set { this._Active = value; }
        }

        private string _EntryBy ;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private List<ATTMeetingVenueResources> _LstBookedResources = new List<ATTMeetingVenueResources>();
        public List<ATTMeetingVenueResources> LstBookedResources
        {
            get { return _LstBookedResources; }
            set { _LstBookedResources = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        private string _Action = "";
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }


        public ATTMeetingVenueBooking()
        {

        }




    }
}
