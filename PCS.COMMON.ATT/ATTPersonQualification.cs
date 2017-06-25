using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonQualification
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private int _SeqNo;
        public int SeqNo
        {
            get { return this._SeqNo; }
            set { this._SeqNo = value; }
        }

        private string _Subject;
        public string Subject
        {
            get { return this._Subject; }
            set { this._Subject = value; }
        }

        private int _DegreeID;
        public int DegreeID
        {
            get { return this._DegreeID; }
            set { this._DegreeID = value; }
        }

        private string _DegreeName;
        public string DegreeName
        {
            get { return this._DegreeName; }
            set { this._DegreeName = value; }
        }
        
        private long? _InstitutionID;
        public long? InstitutionID
        {
            get { return this._InstitutionID; }
            set { this._InstitutionID = value; }
        }

        private string _InstitutionName;
        public string InstitutionName
        {
            get { return this._InstitutionName; }
            set { this._InstitutionName = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
        }

        private string _Grade;
        public string Grade
        {
            get { return this._Grade; }
            set { this._Grade = value; }
        }

        private float? _Percentage;
        public float? Percentage
        {
            get { return this._Percentage; }
            set { this._Percentage = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return this._Remarks; }
            set { this._Remarks = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return this._EntryDate; }
            set { this._EntryDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTPersonQualification()
        {
        }

        public ATTPersonQualification(double empID, int seqNo, string subject, int degreeID, long? institutionID, string fromDate, string toDate, string grade, float? percentage, string remarks, string entryBy)
        {
            this.EmpID = empID;
            this.SeqNo = seqNo;
            this.Subject = subject;
            this.DegreeID = degreeID;
            this.InstitutionID = institutionID;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Grade = grade;
            this.Percentage = percentage;
            this.Remarks = remarks;
            this.EntryBy = entryBy;
        }
    }
}
