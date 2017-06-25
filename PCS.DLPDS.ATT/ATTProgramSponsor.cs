using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTProgramSponsor
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _ProgramID;
        public int ProgramID
        {
            get { return this._ProgramID; }
            set { this._ProgramID = value; }
        }

        private int _SponsorID;
        public int SponsorID
        {
            get { return this._SponsorID; }
            set { this._SponsorID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private double _Budget;
        public double Budget
        {
            get { return this._Budget; }
            set { this._Budget = value; }
        }

        private string _Currency;
        public string Currency
        {
            get { return this._Currency; }
            set { this._Currency = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private ATTSponsor _SponsorOBJ = new ATTSponsor();
        public ATTSponsor SponsorOBJ
        {
            get { return this._SponsorOBJ; }
            set { this._SponsorOBJ = value; }
        }

        public string SponsorName
        {
            get { return SponsorOBJ.SponsorName; }
        }

        



        public ATTProgramSponsor()
        { }

        public ATTProgramSponsor(int orgID, int programID, int sponsorID, string fromDate, double budget, string currency, string toDate, string action)
        {
            this.OrgID = orgID;
            this.ProgramID = programID;
            this.SponsorID = sponsorID;
            this.FromDate = fromDate;
            this.Budget = budget;
            this.Currency = currency;
            this.ToDate = toDate;
            this.Action = action;
        }
                                    
    }
}
