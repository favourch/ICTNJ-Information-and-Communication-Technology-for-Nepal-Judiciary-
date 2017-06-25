using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEvaluationCriteria
    {
        private int _EvaluationCriteriaID;
        public int EvaluationCriteriaID
        {
            get { return this._EvaluationCriteriaID; }
            set { this._EvaluationCriteriaID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private int _GroupID;
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private string _EvaluationCriteriaName;
        public string EvaluationCriteriaName
        {
            get { return this._EvaluationCriteriaName.Trim(); }
            set { this._EvaluationCriteriaName = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTEvaluationCriteriaGrade> _LstEvaluationCriteriaGrade = new List<ATTEvaluationCriteriaGrade>();
        public List<ATTEvaluationCriteriaGrade> LstEvaluationCriteriaGrade
        {
            get { return this._LstEvaluationCriteriaGrade; }
            set { this._LstEvaluationCriteriaGrade = value; }
        }

        public ATTEvaluationCriteria()
        {
        }
    }
}
