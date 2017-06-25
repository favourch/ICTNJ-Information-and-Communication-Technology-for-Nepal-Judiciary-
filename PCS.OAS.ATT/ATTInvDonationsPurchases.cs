using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvDonationsPurchases
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int? _ItemsCategoryID;
        public int? ItemsCategoryID
        {
            get { return _ItemsCategoryID; }
            set { _ItemsCategoryID = value; }
        }

        private int? _ItemsSubCategoryID;
        public int? ItemsSubCategoryID
        {
            get { return _ItemsSubCategoryID; }
            set { _ItemsSubCategoryID = value; }
        }

        private int _ItemsID;
        public int ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }

        private string _DonationPurchaseDate;
        public string DonationPurchaseDate
        {
            get { return _DonationPurchaseDate; }
            set { _DonationPurchaseDate = value; }
        }

        private int? _DonationPurchaseSeq;
        public int? DonationPurchaseSeq
        {
            get { return _DonationPurchaseSeq; }
            set { _DonationPurchaseSeq = value; }
        }

        private string _DonationPurchaseType;
        public string DonationPurchaseType
        {
            get { return _DonationPurchaseType; }
            set { _DonationPurchaseType = value; }
        }

        private string _DonationPurchaseOrg;
        public string DonationPurchaseOrg
        {
            get { return _DonationPurchaseOrg; }
            set { _DonationPurchaseOrg = value; }
        }

        private int _DonationPurchaseQty;
        public int DonationPurchaseQty
        {
            get { return _DonationPurchaseQty; }
            set { _DonationPurchaseQty = value; }
        }

        private int _DonationPurchaseUnitPrice;
        public int DonationPurchaseUnitPrice
        {
            get { return _DonationPurchaseUnitPrice; }
            set { _DonationPurchaseUnitPrice = value; }
        }

        private int _ReceivedBy;
        public int ReceivedBy
        {
            get { return _ReceivedBy; }
            set { _ReceivedBy = value; }
        }

        private string _ReceivedDate;
        public string ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }

        private string _EntryBy;
        public string EntrBy
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

        public ATTInvDonationsPurchases() { }
    }
}
