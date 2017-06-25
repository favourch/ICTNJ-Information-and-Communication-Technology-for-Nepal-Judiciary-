using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTOrganizationUsers
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _Username;
        public string Username
        {
            get { return this._Username; }
            set { this._Username = value; }
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

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }


        private ATTUsers _ObjUsers;
        public ATTUsers ObjUsers
        {
            get { return this._ObjUsers; }
            set { this._ObjUsers = value; }
        }

        private List<ATTUserRoles> _LSTUserRoles;
        public List<ATTUserRoles> LSTUserRoles
        {
            get {return  this._LSTUserRoles; }
            set { this._LSTUserRoles = value; }
        }
       

        private List<ATTApplication> _LSTApplications = new List<ATTApplication>();
        public List<ATTApplication> LSTApplications
        {
            get {return  this._LSTApplications; }
            set { this._LSTApplications = value;  }
        }

        public ATTOrganizationUsers()
        {
        }


        


        public ATTOrganizationUsers(
                                            int orgID,
                                            string userName,
                                            string fromDate,
                                            string toDate,
                                            string action
                                         )
        {
            this.OrgID = orgID;
            this.Username = userName;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Action = action;
        }   
    }
}
