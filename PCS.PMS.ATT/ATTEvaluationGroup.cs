using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEvaluationGroup
    {
        private int _GroupID;
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private string _GroupName;
        public string GroupName
        {
            get { return this._GroupName.Trim(); }
            set { this._GroupName = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTEvaluationCriteria> _LstEvaluationCriteria = new List<ATTEvaluationCriteria>();
        public List<ATTEvaluationCriteria> LstEvaluationCriteria
        {
            get { return this._LstEvaluationCriteria; }
            set { this._LstEvaluationCriteria = value; }
        }

        public ATTEvaluationGroup()
        {
        }

        public ATTEvaluationGroup(int groupID, string groupName)
        {
            this.GroupID = groupID;
            this.GroupName = groupName;
        }
    }
}
