using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTAuctionMaster
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int _AuctionSeq;

        public int AuctionSeq
        {
            get { return _AuctionSeq; }
            set { _AuctionSeq = value; }
        }

        private string _AuctionDate;

        public string AuctionDate
        {
            get { return _AuctionDate; }
            set { _AuctionDate = value; }
        }

        private double _App_By;

        public double App_By
        {
            get { return _App_By; }
            set { _App_By = value; }
        }

        private string _App_Date;

        public string App_Date
        {
            get { return _App_Date; }
            set { _App_Date = value; }
        }

        private string _App_Yes_No;

        public string App_Yes_No
        {
            get { return _App_Yes_No; }
            set { _App_Yes_No = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _EntryDate;

        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        private List<ATTAuctionDetails> _LstAuctionDetails = new List<ATTAuctionDetails>();
        public List<ATTAuctionDetails> LstAuctionDetails
        {
            get { return this._LstAuctionDetails; }
            set { this._LstAuctionDetails = value; }
        }

        public ATTAuctionMaster()
        {
        }
    }
}
