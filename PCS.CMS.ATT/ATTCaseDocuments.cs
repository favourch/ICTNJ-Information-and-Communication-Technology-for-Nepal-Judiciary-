using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTCaseDocuments
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _DocSeq;
        public int DocSeq
        {
            get { return _DocSeq; }
            set { _DocSeq = value; }
        }
	


        private int _DocumentID;
        public int DocumentID
        {
            get { return _DocumentID; }
            set { _DocumentID = value; }
        }

        private string _DocumentFileName;
        public string DocumentFileName
        {
            get { return _DocumentFileName; }
            set { _DocumentFileName = value; }
        }

        private byte[] _DocumentContent;
        public byte[] DocumentContent
        {
            get { return _DocumentContent; }
            set { _DocumentContent = value; }
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
