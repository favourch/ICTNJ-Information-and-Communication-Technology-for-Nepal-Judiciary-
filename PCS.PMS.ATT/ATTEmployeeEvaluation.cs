using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeEvaluation
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

        private string _OldEvalFromDate;
        public string OldEvalFromDate
        {
            get { return this._OldEvalFromDate; }
            set { this._OldEvalFromDate = value; }
        }

        private string _EvalToDate;
        public string EvalToDate
        {
            get { return this._EvalToDate; }
            set { this._EvalToDate = value; }
        }

        private double _RegistrationNo;
        public double RegistrationNo
        {
            get { return this._RegistrationNo; }
            set { this._RegistrationNo = value; }
        }

        private string _Organization;
        public string Organization
        {
            get { return this._Organization.Trim(); }
            set { this._Organization = value; }
        }

        private string _SubmitedDate;
        public string SubmitedDate
        {
            get { return this._SubmitedDate; }
            set { this._SubmitedDate = value; }
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

        private List<ATTEmployeeWork> _LstEmployeeWork = new List<ATTEmployeeWork>();
        public List<ATTEmployeeWork> LstEmployeeWork
        {
            get { return this._LstEmployeeWork; }
            set { this._LstEmployeeWork = value; }
        }

        private List<ATTEmployeeEvaluationDetail> _LstEvaluationDetail = new List<ATTEmployeeEvaluationDetail>();
        public List<ATTEmployeeEvaluationDetail> LstEvaluationDetail
        {
            get { return this._LstEvaluationDetail; }
            set { this._LstEvaluationDetail = value; }
        }

        private List<ATTEmployeeEvaluator> _LstEmployeeEvaluator = new List<ATTEmployeeEvaluator>();
        public List<ATTEmployeeEvaluator> LstEmployeeEvaluator
        {
            get { return this._LstEmployeeEvaluator; }
            set { this._LstEmployeeEvaluator = value; }
        }

        public ATTEmployeeEvaluation()
        {
        }
    }
}
