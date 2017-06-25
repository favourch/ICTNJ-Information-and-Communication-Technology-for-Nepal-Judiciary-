using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMemberPosition
    {
        private int? _PositionID;
        public int ? PositionID
        {
            get { return this._PositionID; }
            set { this._PositionID = value; }
        }

        private string _PositionName;
        public string PositionName
        {
            get { return this._PositionName.Trim(); }
            set { this._PositionName = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTMemberPosition()
        {
        }
    }
}
