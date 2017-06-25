using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeEvaluationDetail
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _EvalFromDate;
        public string EvalFromDate
        {
            get { return this._EvalFromDate; }
            set { this._EvalFromDate = value; }
        }

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

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn; }
            set { this._EntryOn = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private string _GroupName;
        public string GroupName
        {
            get { return this._GroupName.Trim(); }
            set { this._GroupName = value; }
        }

        private string _EvaluationCriteriaName;
        public string EvaluationCriteriaName
        {
            get { return this._EvaluationCriteriaName.Trim(); }
            set { this._EvaluationCriteriaName = value; }
        }

        private string _EvaluationGradeName;
        public string EvaluationGradeName
        {
            get { return this._EvaluationGradeName.Trim(); }
            set { this._EvaluationGradeName = value; }
        }

        public ATTEmployeeEvaluationDetail()
        {
        }
    }
}
