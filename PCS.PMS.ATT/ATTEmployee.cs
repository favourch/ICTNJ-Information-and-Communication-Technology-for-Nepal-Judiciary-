using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.SECURITY.ATT;

namespace PCS.PMS.ATT
{
    public class ATTEmployee
    {
        private string _CitznNo;

        public string CitznNo
        {
            get { return _CitznNo; }
            set { _CitznNo = value; }
        }

        private string _PFNo;

        public string PFNo
        {
            get { return _PFNo; }
            set { _PFNo = value; }
        }
	
	
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _SymbolNo;
        public string SymbolNo
        {
            get { return this._SymbolNo; }
            set { this._SymbolNo = value; }
        }

        private string _OrgEmpNo;
        public string OrgEmpNo
        {
            get { return _OrgEmpNo; }
            set { _OrgEmpNo = value; }
        }
	

        private string _IdentityMark;
        public string IdentityMark
        {
            get { return this._IdentityMark; }
            set { this._IdentityMark = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private ATTPerson _ObjPerson;
        public ATTPerson ObjPerson
        {
            get { return this._ObjPerson; }
            set { this._ObjPerson = value; }
        }

        private List<ATTEmployeeVisits> _LstEmployeeVisits = new List<ATTEmployeeVisits>();
        public List<ATTEmployeeVisits> LstEmployeeVisits
        {
            get { return this._LstEmployeeVisits; }
            set { this._LstEmployeeVisits = value; }
        }

        private List<ATTEmployeeExperience> _LstEmployeeExperience = new List<ATTEmployeeExperience>();
        public List<ATTEmployeeExperience> LstEmployeeExperience
        {
            get { return this._LstEmployeeExperience; }
            set { this._LstEmployeeExperience = value; }
        }


        private List<ATTEmployeePosting> _LstEmployeePosting = new List<ATTEmployeePosting>();
        public List<ATTEmployeePosting> LstEmployeePosting
        {
            get { return this._LstEmployeePosting; }
            set { this._LstEmployeePosting = value; }
        }

        private List<ATTEmployeePublication> _LstEmployeePublication = new List<ATTEmployeePublication>();
        public List<ATTEmployeePublication> LstEmployeePublication
        {
            get { return this._LstEmployeePublication; }
            set { this._LstEmployeePublication = value; }
        }

        private List<ATTEmployeeBeneficiary> _LstEmployeeBeneficiary = new List<ATTEmployeeBeneficiary>();
        public List<ATTEmployeeBeneficiary> LstEmployeeBeneficiary
        {
            get { return this._LstEmployeeBeneficiary; }
            set { this._LstEmployeeBeneficiary = value; }
        }

        private List<ATTVwEmpRelativeBeneficiary> _LstEmpRelativeBeneficiary = new List<ATTVwEmpRelativeBeneficiary>();
        public List<ATTVwEmpRelativeBeneficiary> LstEmpRelativeBeneficiary
        {
            get { return this._LstEmpRelativeBeneficiary; }
            set { this._LstEmpRelativeBeneficiary = value; }
        }
        private List<ATTInsurance> _LSTEmpInsurance = new List<ATTInsurance>();
        public List<ATTInsurance> LSTEmpInsurance
        {
            get { return this._LSTEmpInsurance; }
            set { this._LSTEmpInsurance = value; }
        }

        private List<ATTInsurance> _LSTInsurance = new List<ATTInsurance>();
        public List<ATTInsurance> LstInsurance
        {
            get { return this._LSTInsurance; }
            set { this._LSTInsurance = value; }
        }

        private List<ATTEmployeeDeputaion> _LSTEmpDeputation = new List<ATTEmployeeDeputaion>();
        public List<ATTEmployeeDeputaion> LSTEmpDeputation
        {
            get { return this._LSTEmpDeputation; }
            set { this._LSTEmpDeputation = value; }
        }


        private List<ATTPersonAttachments> _LSTAttachments = new List<ATTPersonAttachments>();
        public List<ATTPersonAttachments> LSTAttachments
        {
            get { return this._LSTAttachments; }
            set { this._LSTAttachments = value; }
        }

        private List<ATTManonayan> _LstManonayan = new List<ATTManonayan>();
        public List<ATTManonayan> LstManonayan
        {
            get { return _LstManonayan; }
            set { _LstManonayan = value; }
        }

        private List<ATTUsers> _LSTUsers = new List<ATTUsers>();
        
        private ATTUsers _ObjUser=new ATTUsers();
        public ATTUsers ObjUser
        {
            get { return _ObjUser; }
            set { _ObjUser = value; }
        }
        private ATTOrganizationUsers _OrgUser = new ATTOrganizationUsers();
        public ATTOrganizationUsers OrgUser
        {
            get { return _OrgUser; }
            set { _OrgUser = value; }
        }

        public ATTEmployee()
        {
        }

        public ATTEmployee(
            string ctznNo,
            string pfNo,
            double empID, 
            string symbolNo,
            string orgEmpNo,
            string identityMark, 
            string entryBy)
        {
            this.CitznNo = ctznNo;
            this.PFNo = pfNo;
            this.EmpID = empID;
            this.SymbolNo = symbolNo;
            this.OrgEmpNo = orgEmpNo;
            this.IdentityMark = identityMark;
            this.EntryBy = entryBy;
        }
        public ATTEmployee(
          double empID,
          string symbolNo,
          string orgEmpNo,
          string identityMark,
          string entryBy)
        {
            this.EmpID = empID;
            this.SymbolNo = symbolNo;
            this.OrgEmpNo = orgEmpNo;
            this.IdentityMark = identityMark;
            this.EntryBy = entryBy;
        }
    }
}
