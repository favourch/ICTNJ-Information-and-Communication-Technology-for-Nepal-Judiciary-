using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTGeneralTippaniSearch:ATTGeneralTippani
    {
        private string _OrgName;
        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }
        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set{_FromDate=value;}
        }

        private string _TippaniSubject;
        public string TippaniSubject
        {
            get { return _TippaniSubject; }
            set { _TippaniSubject = value; }

        }

        private string _TippaniStatus;
        public string TippaniStatus
        {
            get { return _TippaniStatus; }
            set { _TippaniStatus = value; }
        }

        public ATTGeneralTippaniSearch() { }

       
    }
}
