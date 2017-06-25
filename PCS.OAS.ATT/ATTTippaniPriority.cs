using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTTippaniPriority
    {
        private int _PriorityID;
        public int PriorityID
        {
            get { return this._PriorityID; }
            set { this._PriorityID = value; }
        }

        private string _PriorityName;
        public string PriorityName
        {
            get { return this._PriorityName.Trim(); }
            set { this._PriorityName = value; }
        }

        public ATTTippaniPriority()
        {
        }

        public ATTTippaniPriority(int id, string name)
        {
            this.PriorityID = id;
            this.PriorityName = name;
        }
    }
}
