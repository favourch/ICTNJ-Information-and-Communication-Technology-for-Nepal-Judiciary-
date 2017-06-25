using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvItemUnit
    {
        private int _ItemUnitID;
        public int ItemUnitID
        {
            get { return _ItemUnitID; }
            set { this._ItemUnitID = value; }
        }

        private string _ItemUnitName;
        public string ItemUnitName
        {
            get { return _ItemUnitName; }
            set { this._ItemUnitName = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTInvItemUnit(int ItemUnitID, string ItemUnitName, string active)
        {
            this.ItemUnitID = ItemUnitID;
            this.ItemUnitName = ItemUnitName;
            this.Active = active;
        }

        public ATTInvItemUnit(int ItemUnitID, string ItemUnitName, string active, string entryby)
        {
            this.ItemUnitID = ItemUnitID;
            this.ItemUnitName = ItemUnitName;           
            this.Active = active;
            this.EntryBy = entryby;
        }
    }
}
