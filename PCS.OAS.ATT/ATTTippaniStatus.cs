using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class StatusList
    {
        private string _Status;
        public string Status
        {
            get { return this._Status.Trim(); }
            set { this._Status = value; }
        }

        public StatusList()
        {
        }
    }

    public class ATTTippaniStatus
    {
        private int _TippaniStatusID;
        public int TippaniStatusID
        {
            get { return this._TippaniStatusID; }
            set { this._TippaniStatusID = value; }
        }

        private string _TippaniStatusName;
        public string TippaniStatusName
        {
            get { return this._TippaniStatusName.Trim(); }
            set { this._TippaniStatusName = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTTippaniStatus()
        {
        }
    }
}
