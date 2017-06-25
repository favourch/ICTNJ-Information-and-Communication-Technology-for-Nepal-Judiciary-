using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEvaluationCriteriaGrade
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

        private int _EvaluationGradeID;
        public int EvaluationGradeID
        {
            get { return this._EvaluationGradeID; }
            set { this._EvaluationGradeID = value; }
        }

        private string _EvaluationGradeName;
        public string EvaluationGradeName
        {
            get { return this._EvaluationGradeName.Trim(); }
            set { this._EvaluationGradeName = value; }
        }

        private float _TotalWeight;
        public float TotalWeight
        {
            get { return this._TotalWeight; }
            set { this._TotalWeight = value; }
        }

        public string RDGradeNameWithWeight
        {
            get 
            {
                if (this.TotalWeight <= 0)
                    return this.EvaluationGradeName;
                else
                    return this.EvaluationGradeName + " :: " + this.TotalWeight; 
            }
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

        public ATTEvaluationCriteriaGrade()
        {
        }
    }
}
