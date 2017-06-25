using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTOrganizationApplications
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _ApplID;
        public int ApplID
        {
            get { return this._ApplID; }
            set { this._ApplID = value; }
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


        private ATTApplication _Applications;
        public ATTApplication Applications
        {
            get { return this._Applications; }
            set { this._Applications = value; }
        }

        public string ApplFullName
        {
            get { return this.Applications.ApplicationFullName; }
        }

        
        private List<ATTRoles> _LSTRoles = new List<ATTRoles>();
        public List<ATTRoles> LSTRoles
        {
            get { return this._LSTRoles; }
            set { this._LSTRoles = value; }
        }



        

       

        public ATTOrganizationApplications
                                       (
                                            int orgID,
                                            int applID,
                                            string fromDate,
                                            string toDate,
                                            string action
                                        )
        {
            this.OrgID = orgID;
            this.ApplID = applID;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Action = action;
        }

    }
}
