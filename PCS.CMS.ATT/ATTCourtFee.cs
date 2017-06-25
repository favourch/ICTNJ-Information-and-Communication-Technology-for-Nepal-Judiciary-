using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCourtFee
    {
        private int _CourtFeeID;
        public int CourtFeeID
        {
            get { return _CourtFeeID; }
            set { _CourtFeeID = value; }
        }

        private double? _FromAmount;
        public double ? FromAmount
        {
            get { return _FromAmount; }
            set { _FromAmount = value; }
        }

        private  double ? _ToAmount;
        public double ? ToAmount
        {
            get { return _ToAmount; }
            set { _ToAmount = value; }
        }

        private string _FromToAmt;
        public string FromToAmt
        {
            get { return _FromToAmt; }
            set { _FromToAmt = value; }
        }
	

        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        private double ? _AmtPer;
        public double ? AmtPer
        {
            get { return _AmtPer; }
            set { _AmtPer = value; }
        }

        private string _AmtPerType;
        public string AmtPerType
        {
            get { return _AmtPerType; }
            set { _AmtPerType = value; }
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
	
	
	
	
	
	
	
	
	
    }
}
