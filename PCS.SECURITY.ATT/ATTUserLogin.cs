using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class AccessColumn
    {
        private string _PSelect;
        public string PSelect
        {
            get { return this._PSelect.Trim(); }
            set { this._PSelect = value; }
        }

        private string _PAdd;
        public string PAdd
        {
            get { return this._PAdd.Trim(); }
            set { this._PAdd = value; }
        }

        private string _PEdit;
        public string PEdit
        {
            get { return this._PEdit.Trim(); }
            set { this._PEdit = value; }
        }

        private string _PDelete;
        public string PDelete
        {
            get { return this._PDelete.Trim(); }
            set { this._PDelete = value; }
        }
    }

    public class ATTUserLogin
    {
        private string _UserName;
        public string UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }

        private string _UserMessage;
        public string UserMessage
        {
            get { return this._UserMessage.Trim(); }
            set { this._UserMessage = value; }
        }

        private double _PID;
        public double PID
        {
            get { return this._PID; }
            set { this._PID = value; }
        }

        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }

        private string _OrgAddress;
        public string OrgAddress
        {
            get { return this._OrgAddress; }
            set { this._OrgAddress = value; }
        }
        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName.Trim(); }
            set { this._UnitName = value; }
        }


        private Dictionary<string, AccessColumn> _MenuList = new Dictionary<string, AccessColumn>();
        public Dictionary<string, AccessColumn> MenuList
        {
            get { return this._MenuList; }
            set { this._MenuList = value; }
        }
    }
}
