using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTUserRoles
    {
        private string _UserName;
        public string UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }

        private int _RoleID;
        public int RoleID
        {
            get { return this._RoleID; }
            set { this._RoleID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private int  _ApplID;
        public int  ApplID
        {
            get { return this._ApplID; }
            set { this._ApplID = value; }
        }


        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private ATTRoles _ObjRoles;
        public ATTRoles ObjRoles
        {
            get { return this._ObjRoles; }
            set { this._ObjRoles = value; }
        }

        public string RoleName
        {
            get { return this.ObjRoles.RoleName; }
        }

        private  ATTApplication _objApplications;
        public ATTApplication ObjApplications
        {
            get { return this._objApplications; }
            set { this._objApplications = value; }
        }

        public string ApplicationName
        {
            get { return this.ObjApplications.ApplicationFullName; }
        }
        

        public  ATTUserRoles
                                (
                                    string userName,
                                    int roleID,
                                    string fromDate,
                                    string toDate,
                                    int applID,
                                    string action
                                )
        {
            this.UserName =userName ;
            this.RoleID=roleID;
            this.FromDate =fromDate ;
            this.ToDate =toDate;
            this.ApplID = applID;
            this.Action = action;
        }

    }
}
