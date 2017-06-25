using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;

namespace PCS.PMS.ATT
{
   public class ATTJudgeWorkList
    {
        private int ? _JwcID;
        public int ? JwcID
        {
            get { return _JwcID; }
            set { _JwcID = value; }
        }

        private string _JwcName;
        public string JwcName
        {
            get { return _JwcName; }
            set { _JwcName = value; }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }	 

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return _EntryOn; }
            set { _EntryOn = value; }
        }

       private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

       private double _JudgeId;
       public double JudgeId
       {
           get { return this._JudgeId; }
           set { this._JudgeId = value; }
       }

       private string _JudgeName;
       public string JudgeName
       {
           get { return this._JudgeName; }
           set { this._JudgeName = value; }
       }

        public ATTJudgeWorkList()
        { }


        public ATTJudgeWorkList(int ? jwcID, string jwcName,bool active,string entryBy)
        {
            this.JwcID = jwcID;
            this.JwcName = jwcName;
            this.Active = active;
            this.EntryBy = entryBy;
            
        }

       public ATTJudgeWorkList(double judgeID,string judgeName)
       {
           this.JudgeId = judgeID;
           this.JudgeName = judgeName;
       }
		

    }
}
