using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTUnit
    {
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

        private string _UnitAddress;
        public string UnitAddress
        {
            get { return this._UnitAddress.Trim(); }
            set { this._UnitAddress = value; }
        }

        private string _UnitPhone;
        public string UnitPhone
        {
            get { return this._UnitPhone.Trim(); }
            set { this._UnitPhone = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active.Trim(); }
            set { this._Active = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTUnit()
        {
        }
    }
}
