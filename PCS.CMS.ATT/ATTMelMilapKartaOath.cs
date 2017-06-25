using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTMelMilapKartaOath
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private double _PersonID;
        public double PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
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

        private double _OldJudgeID;
        public double OldJudgeID
        {
            get { return _OldJudgeID; }
            set { _OldJudgeID = value; }
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
