using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTTarikh
    {
        private int _CaseID;
        public int CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        public int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }
        private string _TarikhDate;
        public string TarikhDate
        {
            get { return _TarikhDate; }
            set { _TarikhDate = value; }
        }

        private string _TarikhTime;
        public string TarikhTime
        {
            get { return _TarikhTime; }
            set { _TarikhTime = value; }
        }

        private string _PresentDate;
        public string PresentDate
        {
            get { return _PresentDate; }
            set { _PresentDate = value; }
        }

        private string _PersonName;
        public string PersonName
        {
            get { return _PersonName; }
            set { _PersonName = value; }
        }

        private string _PersonType;
        public string PersonType
        {
            //get { return (_PersonType== "S" ? "स्वयं" : "वारिस");}
            get { return _PersonType; }
            set { _PersonType = value; }
        }
        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private string _TakenTime;
        public string TakenTime
        {
            get { return _TakenTime; }
            set { _TakenTime = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
              
        }

        public ATTTarikh() { }
        public ATTTarikh(string name, string type, string tarikhdate, string tarikhtime, string takentime, string presentdate, string remarks)
        {
            this.PersonName = name;
            this.PersonType = type;
            this.TarikhDate = tarikhdate;
            this.TarikhTime = tarikhtime;
            this.TakenTime = takentime;
            this.PresentDate = presentdate;
            this.Remarks = remarks;
        }

    }
}
