using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTLitigantPrisonDetails
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private double _LitigantID;
        public double LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
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

        private string _PrisonPlace;
        public string PrisonPlace
        {
            get { return _PrisonPlace; }
            set { _PrisonPlace = value; }
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
