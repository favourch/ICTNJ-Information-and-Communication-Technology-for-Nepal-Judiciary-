using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTBenchJudge
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private int _BenchTypeID;
        public int BenchTypeID
        {
            get { return _BenchTypeID; }
            set { _BenchTypeID = value; }
        }
        private int _BenchNo;
        public int BenchNo
        {
            get { return _BenchNo; }
            set { _BenchNo = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        private int _SeqNo;
        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }
        private double _JudgeID;
        public double JudgeID
        {
            get { return _JudgeID; }
            set { _JudgeID = value; }
        }
        private string _JudgeName;
        public string JudgeName
        {
            get { return _JudgeName; }
            set { _JudgeName = value; }
        }
	
        private string _BJFromDate;
        public string BJFromDate
        {
            get { return _BJFromDate; }
            set { _BJFromDate = value; }
        }
	
        private string _BJToDate;
        public string BJToDate
        {
            get { return _BJToDate; }
            set { _BJToDate = value; }
        }
        private string _EntryBY;
        public string EntryBy
        {
            get { return _EntryBY; }
            set { _EntryBY = value; }
        }
       
        public ATTBenchJudge()
        {
        }
    }
}
