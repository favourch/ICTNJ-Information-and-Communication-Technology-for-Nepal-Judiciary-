using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Collections.Generic;

using PCS.SECURITY.ATT;

/// <summary>
/// Summary description for AttUsers
/// </summary>
/// 


namespace PCS.SECURITY.ATT
{
    public class ATTUsers
    {

        private string _Username;
        public string Username
        {
            get { return this._Username; }
            set { this._Username = value; }
        }

        private double ? _PID;
        public double ? PID
        {
            get { return this._PID; }
            set { this._PID = value; }
        }

        private  string _Password;
        public string Password
        {
            get { return this._Password; }
            set { this._Password = value; }
        }

        private string _RePassword;
        public string RePassword
        {
            get { return this._RePassword; }
            set { this._RePassword = value; }
        }

        private string _CreatedBy;
        public string CreatedBy
        {
            get { return this._CreatedBy; }
            set { this._CreatedBy = value; }
        }

        private DateTime _CreatedDate;
        public DateTime  CreatedDate
        {
            get { return this._CreatedDate; }
            set { this._CreatedDate = value; }
        }

        private DateTime _ValidUpto;
        public DateTime ValidUpto
        {
            get { return this._ValidUpto; }
            set { this._ValidUpto = value; }
        }

        private string  _Active;
        public string  Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTUserRoles> _LSTUserRoles = new List<ATTUserRoles>();
        public List<ATTUserRoles> LSTUserRoles
        {
            get { return this._LSTUserRoles; }
            set { this._LSTUserRoles = value; }
        }

        
        private List<ATTRoles> _LSTRoles = new List<ATTRoles>();
        public List<ATTRoles> lSTRoles
        {
            get {return  this._LSTRoles; }
            set { this._LSTRoles = value; }
        }

        private ATTRoles _ObjRoles;
        public ATTRoles ObjRoles
        {
            get { return this._ObjRoles; }
            set { this._ObjRoles = value; }
        }


        public ATTUsers()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public   ATTUsers(string userName, string password,string rePassword, string createdBy, DateTime createdDate,DateTime validUpto, string  active,string action,double? pID)
        {
            this.Username = userName;
            this.PID = pID;
            this.Password = password;
            this.RePassword = rePassword;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.ValidUpto = validUpto;
            this.Active = active;
            this.Action = action;
        }
    }
}
