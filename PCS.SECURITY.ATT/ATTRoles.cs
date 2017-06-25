using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTRoles
    {
        private int? _RoleID;
        public int? RoleID
        {
            get { return this._RoleID; }
            set { this._RoleID = value; }
        }

        private int? _ApplicationID;
        public int? ApplicationID
        {
            get { return this._ApplicationID; }
            set { this._ApplicationID = value; }
        }

        private string _RoleName;
        public string RoleName
        {
            get { return this._RoleName.Trim(); }
            set { this._RoleName = value.Trim(); }
        }

        private string _RoleDescription;
        public string RoleDescription
        {
            get { return this._RoleDescription.Trim(); }
            set { this._RoleDescription = value.Trim(); }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private List<ATTRoleMenus> _LstRoleMenus = new List<ATTRoleMenus>();
        public List<ATTRoleMenus> LstRoleMenus
        {
            get { return this._LstRoleMenus; }
            set { this._LstRoleMenus = value; }
        }
               
        public ATTRoles()
        {
        }

        public ATTRoles(int? roleID, int? applicationID, string roleName, string roleDescription, string action)
        {
            this.RoleID = roleID;
            this.ApplicationID = applicationID;
            this.RoleName = roleName;
            this.RoleDescription = roleDescription;
            this.Action = action;
        }
    }
}
