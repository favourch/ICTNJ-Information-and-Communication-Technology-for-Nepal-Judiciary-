using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingVenueResources
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

        private int _BookingID;
        public int BookingID
        {
            get { return this._BookingID; }
            set { this._BookingID = value; }
        }


        private int? _ResourceBookID;
        public int? ResourceBookID
        {
            get { return this._ResourceBookID; }
            set { this._ResourceBookID = value; }
        }


        private int _ResourceID;
        public int ResourceID
        {
            get { return this._ResourceID; }
            set { this._ResourceID = value; }
        }

        private int _ResourceQty;
        public int ResourceQty
        {
            get { return this._ResourceQty; }
            set { this._ResourceQty = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        public ATTMeetingVenueResources()
        {
        }

    }
}
