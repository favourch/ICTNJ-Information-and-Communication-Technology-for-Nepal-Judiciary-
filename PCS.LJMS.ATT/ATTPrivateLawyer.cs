using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTPrivateLawyer
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

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName; }
            set { this._UnitName = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate.Trim(); }
            set { this._ToDate = value; }
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

        private List<ATTPrivateLawyerRenewal> _LstRenewal = new List<ATTPrivateLawyerRenewal>();
        public List<ATTPrivateLawyerRenewal> LstRenewal
        {
            get { return this._LstRenewal; }
            set { this._LstRenewal = value; }
        }

        public ATTPrivateLawyer()
        {
        }
    }
}
