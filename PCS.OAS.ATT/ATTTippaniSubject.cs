using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    [Serializable()]
    public class ATTTippaniSubject
    {
        private int _TippaniSubjectID;
        public int TippaniSubjectID
        {
            get { return this._TippaniSubjectID; }
            set { this._TippaniSubjectID = value; }
        }

        private string _TippaniSubjectName;
        public string TippaniSubjectName
        {
            get { return this._TippaniSubjectName.Trim(); }
            set { this._TippaniSubjectName = value; }
        }

        private string _TippaniSubjectText;
        public string TippaniSubjectText
        {
            get { return this._TippaniSubjectText.Trim(); }
            set { this._TippaniSubjectText = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTTippaniSubject()
        {
        }
    }
}
