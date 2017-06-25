using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTTameliWitnessPerson
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

        private int _WitnessID;
        public int WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }
	

        private string _IssuedDate;
        public string IssuedDate
        {
            get { return _IssuedDate; }
            set { _IssuedDate = value; }
        }

        private int _SeqNo;
        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }

        private int _WitSeqNo;
        public int WitSeqNo
        {
            get { return _WitSeqNo; }
            set { _WitSeqNo = value; }
        }

        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        private string _Post;
        public string Post
        {
            get { return _Post; }
            set { _Post = value; }
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

        public ATTTameliWitnessPerson()
        { }
	
    }
}
