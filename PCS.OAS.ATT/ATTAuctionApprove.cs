using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTAuctionApprove
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private string _AuctionDate;

        public string AuctionDate
        {
            get { return _AuctionDate; }
            set { _AuctionDate = value; }
        }

        private string _AppYesNo;

        public string AppYesNo
        {
            get { return _AppYesNo; }
            set { _AppYesNo = value; }
        }

        private int _AuctionSeq;

        public int AuctionSeq
        {
            get { return _AuctionSeq; }
            set { _AuctionSeq = value; }
        }

        private string _AppBy;

        public string AppBy
        {
            get { return _AppBy; }
            set { _AppBy = value; }
        }

        private string _AppDate;

        public string AppDate
        {
            get { return _AppDate; }
            set { _AppDate = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	
	
        public ATTAuctionApprove()
        {
        }   
	
	
    }
}
