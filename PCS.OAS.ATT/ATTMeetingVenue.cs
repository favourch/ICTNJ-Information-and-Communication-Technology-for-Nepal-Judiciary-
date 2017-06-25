using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingVenue
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
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
            get { return this._VenueName.Trim(); }
            set { this._VenueName = value; }
        }

        private string _VenueLocation;
        public string VenueLocation
        {
            get { return this._VenueLocation.Trim(); }
            set { this._VenueLocation = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private List<ATTMeetingVenue> _LstVenue;
        public List<ATTMeetingVenue> LstVenue
        {
            get { return _LstVenue; }
            set { _LstVenue = value; }
        }

        public ATTMeetingVenue()
        {
        }

        public ATTMeetingVenue(int orgID, int venueID, string venueName,string venueLocation)
        {
            this.OrgID = orgID;
            this.VenueID = venueID;
            this.VenueName = venueName;
            this.VenueLocation = venueLocation;
        }


    }
}
