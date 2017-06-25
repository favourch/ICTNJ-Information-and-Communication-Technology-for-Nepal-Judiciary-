using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.SECURITY.ATT
{
    public class ATTApplicationForm
    {
        private int _ApplicationID;
        public int ApplicationID
        {
            get { return this._ApplicationID; }
            set { this._ApplicationID = value; }
        }

        private int _FormID;
        public int FormID
        {
            get { return this._FormID; }
            set { this._FormID = value; }
        }

        private string _FormName;
        public string FormName
        {
            get { return this._FormName.Trim(); }
            set { this._FormName = value; }
        }

        private string _FormDescription;
        public string FormDescription
        {
            get { return this._FormDescription.Trim(); }
            set { this._FormDescription = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private List<ATTMenu> _LstMenu = new List<ATTMenu>();
        public List<ATTMenu> LstMenu
        {
            get { return this._LstMenu; }
            set { this._LstMenu = value; }
        }

        public ATTApplicationForm()
        {
        }

        public ATTApplicationForm(int appID, int formID, string formName, string formDesc,string action)
        {
            this.ApplicationID = appID;
            this.FormID = formID;
            this.FormName = formName;
            this.FormDescription = formDesc;
            this.Action = action;
        }

        //public ATTApplicationForm(int appID, int formID, string formName, string formDesc,List<ATTApplicationForm> lstAppForm,List<ATTMenu> lstMenu)
        //{
        //    this.ApplicationID = appID;
        //    this.FormID = formID;
        //    this.FormName = formName;
        //    this.FormDescription = formDesc;

        //    this.LstApplicationForm = lstAppForm;
        //    this.LstMenu = lstMenu;
        //}
    }
}
