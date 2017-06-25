using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTLawyerType
    {
        private int _LawyerTypeID;
        public int LawyerTypeID
        {
            get { return this._LawyerTypeID; }
            set { this._LawyerTypeID = value; }
        }

        private string _LawyerTypeDescription;
        public string LawyerTypeDescription
        {
            get { return this._LawyerTypeDescription.Trim(); }
            set { this._LawyerTypeDescription = value; }
        }

        private string _Active;
        public string Active
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
    }
}
