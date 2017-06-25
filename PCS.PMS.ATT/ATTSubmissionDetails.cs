using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTSubmissionDetails
    {
        private int _EmpID;
        public int EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _SubmissionDate;
        public string SubmissionDate
        {
            get { return this._SubmissionDate; }
            set { this._SubmissionDate = value; }
        }

        private string _SubmissionOffice;
        public string SubmissionOffice
        {
            get { return this._SubmissionOffice; }
            set { this._SubmissionOffice = value; }
        }

        private string _SubmissionPlace;
        public string SubmissionPlace
        {
            get { return this._SubmissionPlace; }
            set { this._SubmissionPlace = value; }
        }


    }
}
