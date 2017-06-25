using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTInsurance
    {
        private double _EmpID;

        public double EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private int _SeqNo;

        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }
	
	
        private string  _CompanyName;

        public string  CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        private string _InsuranceNo;

        public string InsuranceNo
        {
            get { return _InsuranceNo; }
            set { _InsuranceNo = value; }
        }

        private string _FromDate;

        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _MaturityDate;

        public string MaturityDate
        {
            get { return _MaturityDate; }
            set { _MaturityDate = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
	
        public ATTInsurance()
        {
        }

        public ATTInsurance(double empId,int seqNo,string companyName,string insuranceNo,string fromDate,string maturityDate,string entryBy)
        {
            this.EmpID = empId;
            this.SeqNo = seqNo;
            this.CompanyName = companyName;
            this.InsuranceNo = insuranceNo;
            this.FromDate = fromDate;
            this.MaturityDate = maturityDate;
            this.EntryBy = entryBy;
        }
    }
}
