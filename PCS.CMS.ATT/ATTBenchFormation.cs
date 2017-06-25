using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PCS.CMS.ATT
{
    public class ATTBenchFormation
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
        private string _BenchDesc;

        public string BenchDesc
        {
            get { return _BenchDesc; }
            set { _BenchDesc = value; }
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
        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        private string _EntryBY;
        public string EntryBy
        {
            get { return _EntryBY; }
            set { _EntryBY = value; }
        }
        private int _Cardinality;
        public int Cardinality
        {
            get { return _Cardinality; }
            set { _Cardinality = value; }
        }
        private string _BenchTypeName;
        public string BenchTypeName
        {
            get { return _BenchTypeName; }
            set { _BenchTypeName = value; }
        }
	

        public string Name
        {
            get { return this.BenchTypeName+" ("+this.BenchDesc+")"; }
            
        }
        public string CompositeKey
        {
            get { return this.OrgID.ToString() + this.BenchTypeID.ToString() + this.BenchNo.ToString()  ; }

        }

        private DataTable _JudgeList;
	    public DataTable JudgeList
	    {
		    get { return _JudgeList;}
		    set {_JudgeList=value;}
	    }
	
	
        private List<ATTBenchJudge> _LstBenchJudge=new List<ATTBenchJudge>();
        public List<ATTBenchJudge> LstBenchJudge
        {
            get { return _LstBenchJudge; }
            set { _LstBenchJudge = value; }
        }

        public ATTBenchFormation()
        {
        }
    }
}
