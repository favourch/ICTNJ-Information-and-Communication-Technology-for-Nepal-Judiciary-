using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTPrivateLawyerRenewal
    {
        private double _PersonID;
        public double PersonID
        {
            get { return this._PersonID; }
            set { this._PersonID = value; }
        }

        private int _LawyerTypeID;
        public int LawyerTypeID
        {
            get { return this._LawyerTypeID; }
            set { this._LawyerTypeID = value; }
        }

        private string _Lisence;
        public string Lisence
        {
            get { return this._Lisence.Trim(); }
            set { this._Lisence = value; }
        }

        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }


        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName; }
            set { this._UnitName = value; }
        }

        private string _RenewalDate;
        public string RenewalDate
        {
            get { return this._RenewalDate.Trim(); }
            set { this._RenewalDate = value; }
        }

        private string _RenewalUpto;
        public string RenewalUpto
        {
            get { return this._RenewalUpto.Trim(); }
            set { this._RenewalUpto = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }
    }
}
