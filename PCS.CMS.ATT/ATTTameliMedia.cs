using System;
using System.Collections.Generic;
using System.Text;

 namespace PCS.CMS.ATT
{
    public class ATTTameliMedia
    {
        private int _CaseID;
        public int CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _LitigantID;
        public int LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private string _IssueDate;
        public string IssueDate
        {
            get { return _IssueDate; }
            set { _IssueDate = value; }
        }

        private int _SeqNo;
	    public int SeqNo
	    {
		    get { return _SeqNo;}
		    set { _SeqNo = value;}
	    }

        private int _AttorneyID;
        public int AttorneyID
        {
            get { return _AttorneyID; }
            set { _AttorneyID = value; }
        }

        private int _WitnessID;
        public int WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }

        private string _MediaFullName;
        public string MediaFullName
        {
            get { return _MediaFullName; }
            set { _MediaFullName = value; }
        }

        private string _MediaPublicationDate;
        public string MediaPublicationDate
        {
            get { return _MediaPublicationDate; }
            set { _MediaPublicationDate = value; }
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

       public ATTTameliMedia()
        { }
	
	
	
	
	

	
	



	
	
    }
}
