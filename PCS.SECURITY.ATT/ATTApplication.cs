using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTApplication
    {
        private int _ApplicationID;
        public int ApplicationID
        {
            get { return this._ApplicationID; }
            set { this._ApplicationID = value; }
        }

        private string _ApplicationShortName;
        public string ApplicationShortName
        {
            get { return this._ApplicationShortName.Trim(); }
            set { this._ApplicationShortName = value; }
        }

        private string _ApplicationFullName;
        public string ApplicationFullName
        {
            get { return this._ApplicationFullName.Trim(); }
            set { this._ApplicationFullName = value; }
        }

        private string _ApplicationDescription;
        public string ApplicationDescription
        {
            get { return this._ApplicationDescription.Trim(); }
            set { this._ApplicationDescription = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private List<ATTApplicationForm> _LstApplicationForm = new List<ATTApplicationForm>();
        public List<ATTApplicationForm> LstApplicationForm
        {
            get { return this._LstApplicationForm; }
            set { this._LstApplicationForm = value; }
        }

        private List<ATTRoles> _LstRoles = new List<ATTRoles>();
        public List<ATTRoles> LstRoles
        {
            get { return this._LstRoles; }
            set { this._LstRoles = value; }
        }

        private List<ATTMenu> _LstMenus = new List<ATTMenu>();
        public List<ATTMenu> LstMenus
        {
            get { return this._LstMenus; }
            set { this._LstMenus = value; }
        }


        public ATTApplication()
        {

        }

        public ATTApplication(int applicationID, string applicationShortName, string applicationFullName, string applicationDescription,string action)
        {
            this.ApplicationID = applicationID;
            this.ApplicationShortName = applicationShortName;
            this.ApplicationFullName = applicationFullName;
            this.ApplicationDescription = applicationDescription;
            this.Action = action;
        }
    }
}
