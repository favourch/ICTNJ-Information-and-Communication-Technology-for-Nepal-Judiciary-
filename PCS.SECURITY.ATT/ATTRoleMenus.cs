using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTRoleMenus
    {
        private int? _RoleID;
        public int? RoleID
        {
            get { return this._RoleID; }
            set { this._RoleID = value; }
        }

        private int? _MenuID;
        public int? MenuID
        {
            get { return this._MenuID; }
            set { this._MenuID = value; }
        }

        private string _MenuName;
        public string MenuName
        {
            get { return this._MenuName; }
            set { this._MenuName = value; }
        }

        private int? _ApplicationID;
        public int? ApplicationID
        {
            get { return this._ApplicationID; }
            set { this._ApplicationID = value; }
        }

        private int? _FormID;
        public int? FormID
        {
            get { return this._FormID; }
            set { this._FormID = value; }
        }

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

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public bool RDPSelect
        {
            get { return (this.PSelect == "Y" ? true : false); }
        }

        public bool RDPAdd
        {
            get { return (this.PAdd == "Y" ? true : false); }
        }

        public bool RDPEdit
        {
            get { return (this.PEdit == "Y" ? true : false); }
        }

        public bool RDPDelete
        {
            get { return (this.PDelete == "Y" ? true : false); }
        }

        public ATTRoleMenus()
        {
        }

        public ATTRoleMenus(int? roleID, int? menuID, int? applicationID, int? formID, string pSelect, string pAdd, string pEdit, string pDelete)
        {
            this.RoleID = roleID;
            this.MenuID = menuID;
            this.ApplicationID = applicationID;
            this.FormID = formID;
            this.PSelect = pSelect;
            this.PAdd = pAdd;
            this.PEdit = pEdit;
            this.PDelete = pDelete;
        }


    }
}
