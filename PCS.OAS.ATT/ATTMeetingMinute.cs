using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    [Serializable]
    public class ATTMeetingMinute
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _MeetingID;
        public int MeetingID
        {
            get { return this._MeetingID; }
            set { this._MeetingID = value; }
        }

        private int _MinuteID;
        public int MinuteID
        {
            get { return this._MinuteID; }
            set { this._MinuteID = value; }
        }

        private string _Minute;
        public string Minute
        {
            get { return this._Minute.Trim(); }
            set { this._Minute = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTMeetingMinute()
        {
        }
    }
}
