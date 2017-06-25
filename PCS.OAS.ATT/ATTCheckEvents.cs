using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTCheckEvents
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _ID;
        public int ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        private string _Date;
        public string Date
        {
            get { return this._Date; }
            set { this._Date = value; }
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

        private string _Subject = "";
        public string Subject
        {
            get { return this._Subject.Trim(); }
            set { this._Subject = value; }
        }

        private string _Type = "";
        public string Type
        {
            get { return this._Type.Trim(); }
            set { this._Type = value; }
        }


        public ATTCheckEvents()
        {
        }


    }
}
