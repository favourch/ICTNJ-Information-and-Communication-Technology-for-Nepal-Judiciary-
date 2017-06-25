using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingType
    {
        private int _MeetingTypeID;
        public int MeetingTypeID
        {
            get { return this._MeetingTypeID; }
            set { this._MeetingTypeID = value; }
        }

        private string _MeetingTypeName;
        public string MeetingTypeName
        {
            get { return this._MeetingTypeName.Trim(); }
            set { this._MeetingTypeName = value; }
        }

        private string __MeetingTypeDesc;
        public string MeetingTypeDesc
        {
            get { return this.__MeetingTypeDesc.Trim(); }
            set { this.__MeetingTypeDesc = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTMeetingType()
        {
        }

        public ATTMeetingType(int meetingTypeID, string meetingTypeName, string meetingTypeDesc)
        {
            this.MeetingTypeID = meetingTypeID;
            this.MeetingTypeName = meetingTypeName;
            this.MeetingTypeDesc = meetingTypeDesc;
        }
    }
}
