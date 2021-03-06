using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseDocumentsLit
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private string _LitType;
        public string LitType
        {
            get { return _LitType; }
            set { _LitType = value; }
        }

        public string LitigantType
        {
            get { return LitType == "A" ? "वादि" : "प्रतिवादि"; }
        }
	

        private double _LitigantID;
        public double LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private string _LitigantName;
        public string LitigantName
        {
            get { return _LitigantName; }
            set { _LitigantName = value; }
        }
	

        private int _DocumentID;
        public int DocumentID
        {
            get { return _DocumentID; }
            set { _DocumentID = value; }
        }

        private int _DocSeq;
        public int DocSeq
        {
            get { return _DocSeq; }
            set { _DocSeq = value; }
        }

	

        private string _DocumentFileName;
        public string FileName
        {
            get { return _DocumentFileName; }
            set { _DocumentFileName = value; }
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
