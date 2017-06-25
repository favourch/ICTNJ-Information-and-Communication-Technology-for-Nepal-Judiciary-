using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTSponsor
    {
        private int _SponsorID;
        public int SponsorID
        {
            get { return this._SponsorID; }
            set { this._SponsorID = value; }
        }

        private string _SponsorName;
        public string SponsorName
        {
            get { return this._SponsorName; }
            set { this._SponsorName = value; }
        }

        private string _Action;
        public string Action
        {
            get {return  this._Action; }
            set { this._Action = value; }
        }

        public ATTSponsor()
        { }

        public ATTSponsor(int sponsorID, string sponsorName, string action)
        {
            this.SponsorID = sponsorID;
            this.SponsorName = sponsorName;
            this.Action = action;
        }
    }
}
