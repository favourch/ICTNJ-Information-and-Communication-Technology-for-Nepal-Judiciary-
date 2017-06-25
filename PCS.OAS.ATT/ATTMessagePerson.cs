using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMessagePerson
    {
        private int _PID;
        public int PID
        {
            get { return this._PID; }
            set { this._PID = value; }
        }

        private string _PersonName;
        public string PersonName
        {
            get { return this._PersonName; }
            set { this._PersonName = value; }
        }

        public ATTMessagePerson()
        {
        }

        public ATTMessagePerson(int pid,string personName)
        {
            this.PID = pid;
            this.PersonName = personName;
        }
    }
}
