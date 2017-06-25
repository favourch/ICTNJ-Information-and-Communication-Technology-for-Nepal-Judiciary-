using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public  class ATTDurationType
    {
        private int _DurationTypeID;
        public int DurationTypeID
        {
            get { return this._DurationTypeID; }
            set { this._DurationTypeID = value; }
        }

        private string _DurationTypeName;
        public string DurationTypeName
        {
            get { return this._DurationTypeName; }
            set { this._DurationTypeName = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTDurationType(int durationTypeID, string durationTypeName, string action)
        {
            this.DurationTypeID = durationTypeID;
            this.DurationTypeName = durationTypeName;
            this.Action = action;
        }
    }
}
