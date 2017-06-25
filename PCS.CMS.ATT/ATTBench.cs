using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTBench
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
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
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        private string _EntryBY;
        public string EntryBy
        {
            get { return _EntryBY; }
            set { _EntryBY = value; }
        }
        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        public ATTBench()
        {
        }
	
    }
}
