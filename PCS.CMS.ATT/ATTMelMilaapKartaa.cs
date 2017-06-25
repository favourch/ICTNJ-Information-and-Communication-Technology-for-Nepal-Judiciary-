using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;

namespace PCS.CMS.ATT
{
    public class ATTMelMilaapKartaa
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private double _PID;
        public double PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
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
        private string _Post;
        public string Post
        {
            get { return _Post; }
            set { _Post = value; }
        }
        private string _Experience;
        public string Experience
        {
            get { return _Experience; }
            set { _Experience = value; }
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

        private ATTPerson _objPerson=new ATTPerson();
        public ATTPerson objPerson
        {
            get { return _objPerson; }
            set { _objPerson = value; }
        }

        private List<ATTMelMilapKartaOath> _OathLst=new List<ATTMelMilapKartaOath>();
        public List<ATTMelMilapKartaOath> OathLst
        {
            get { return _OathLst; }
            set { _OathLst = value; }
        }

        private string _OathJudges;
        public string OathJudges
        {
            get { return _OathJudges; }
            set { _OathJudges = value; }
        }        
	
        public ATTMelMilaapKartaa()
        {
        }
	
    }
}
