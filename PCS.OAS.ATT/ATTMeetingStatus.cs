using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingStatus
    {
        private int _MeetingStatusID;
        public int MeetingStatusID
        {
            get { return this._MeetingStatusID; }
            set { this._MeetingStatusID = value; }
        }

        private string _MeetingStatusName;
        public string MeetingStatusName
        {
            get { return this._MeetingStatusName.Trim(); }
            set { this._MeetingStatusName = value; }
        }

        private string _MeetingStatusColor;
        public string MeetingStatusColor
        {
            get { return this._MeetingStatusColor.Trim(); }
            set { this._MeetingStatusColor = value; }
        }

        public System.Drawing.Color RDStatusColor
        {
            get
            {
                return System.Drawing.Color.FromName(this._MeetingStatusColor);
            }
        }


        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTMeetingStatus()
        {
        }
    }
}
