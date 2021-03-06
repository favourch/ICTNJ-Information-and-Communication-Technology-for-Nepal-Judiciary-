using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeDeputaion
    {
        private double _EmpID;

        public double EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private string _EmpName;

        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }

        private string _Gender;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private string _GenderDesc;

        public string GenderDesc
        {
            get
            {
                return (this.Gender == "M" ? "पुरुष" : "महिला");
            }
        }

        private int? _OrgID;

        public int? OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private string _OrgName;

        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }

        private string _SymbolNo;
        public string SymbolNo
        {
            get { return _SymbolNo; }
            set { _SymbolNo = value; }
        }

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _MiddleName;

        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }
        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        private string _DOB;

        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        private int _DesID;

        public int DesID
        {
            get { return _DesID; }
            set { _DesID = value; }
        }

        private string _DesName;

        public string DesName
        {
            get { return _DesName; }
            set { _DesName = value; }
        }

        private int? _OrgEmpNo;
        public int? OrgEmpNo
        {
            get { return _OrgEmpNo; }
            set { _OrgEmpNo = value; }
        }
        private string _CreatedDate;

        public string CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private int _PostID;

        public int PostID
        {
            get { return _PostID; }
            set { _PostID = value; }
        }

        private string _PostCreatedDate;

        public string PostCreatedDate
        {
            get { return _PostCreatedDate; }
            set { _PostCreatedDate = value; }
        }



        //private int _UnitID;

        //public int UnitID
        //{
        //    get { return _UnitID; }
        //    set { _UnitID = value; }
        //}

        //private int _SectionID;

        //public int SectionID
        //{
        //    get { return _SectionID; }
        //    set { _SectionID = value; }
        //}

        private string _FromDate;

        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _PostFromDate;

        public string PostFromDate
        {
            get { return _PostFromDate; }
            set { _PostFromDate = value; }
        }


        private string _DecisionDate;

        public string DecisionDate
        {
            get { return _DecisionDate; }
            set { _DecisionDate = value; }
        }

        private int _DepOrgID;

        public int DepOrgID
        {
            get { return _DepOrgID; }
            set { _DepOrgID = value; }
        }

        private string _DepOrgName;

        public string DepOrgName
        {
            get { return _DepOrgName; }
            set { _DepOrgName = value; }
        }



        private string _LeaveDate;

        public string LeaveDate
        {
            get { return _LeaveDate; }
            set { _LeaveDate = value; }
        }

        private int? _LeaveVerifiedBy;

        public int? LeaveVerifiedBy
        {
            get { return _LeaveVerifiedBy; }
            set { _LeaveVerifiedBy = value; }
        }

        private string _ReturnDate;

        public string ReturnDate
        {
            get { return _ReturnDate; }
            set { _ReturnDate = value; }
        }

        private int? _ReturnVerifiedBy;

        public int? ReturnVerifiedBy
        {
            get { return _ReturnVerifiedBy; }
            set { _ReturnVerifiedBy = value; }
        }

        private string _Responsibilites;

        public string Responsibilities
        {
            get { return _Responsibilites; }
            set { _Responsibilites = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private string _Active;

        public string Active
        {
            get { return _Active; }
            set { _Active = value; }

        }
        private int? _DecisionVerfiedBy;

        public int? DecisionVerifiedBy
        {
            get { return _DecisionVerfiedBy; }
            set { _DecisionVerfiedBy = value; }
        }



        // below three property added by shanjeev
        public string DecisionVerfiedByStatus
        {
            get { return DecisionVerifiedBy ==null ? "Processing" : DecisionVerifiedBy.ToString(); }
        }

        private string _ApplicationDate;

        public string ApplicationDate
        {
            get { return _ApplicationDate; }
            set { _ApplicationDate = value; }
        }
        private int _TipOrgID;
        public int TipOrgID
        {
            get { return _TipOrgID; }
            set { _TipOrgID = value; }
        }
        private int _TippaniID;
        public int TippaniID
        {
            get { return _TippaniID; }
            set { _TippaniID = value; }
        }

        public ATTEmployeeDeputaion()
        {
        }

        public ATTEmployeeDeputaion(double empID, string empName, string gender, int orgID, string orgName, int desID, string desName, string createdDate, int postID, string fromDate, string decisionDate, int depOrgID, int decisionVerBy, string leaveDate, int leaveVerBy, string returnDate, int retrunVerBy, string responsibilities, string entryBy, string action, string active)
        {
            this.EmpID = empID;
            this.EmpName = empName;
            this.Gender = gender;
            this.OrgID = orgID;
            this.OrgName = orgName;
            this.DesID = desID;
            this.DesName = desName;
            this.CreatedDate = createdDate;
            this.PostID = postID;
            this.FromDate = fromDate;
            this.DecisionDate = decisionDate;
            this.DepOrgID = depOrgID;
            this.DecisionVerifiedBy = decisionVerBy;
            this.LeaveDate = leaveDate;
            this.LeaveVerifiedBy = leaveVerBy;
            this.ReturnDate = returnDate;
            this.ReturnVerifiedBy = retrunVerBy;
            this.Responsibilities = responsibilities;
            this.EntryBy = entryBy;
            this.Action = action;
            this.Active = active;
        }
        public ATTEmployeeDeputaion(string symbol, string firstName, string middleName, string surName, string gender, string dob, int orgId, int desId, int depOrgId)
        {
            this.SymbolNo = symbol;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = surName;

            this.Gender = gender;
            this._DOB = dob;
            this.OrgID = orgId;
            this.DesID = desId;
            this.DepOrgID = depOrgId;

        }
        public ATTEmployeeDeputaion(string empName, double empID, string symbol, string firstName, string middleName, string surName, string gender, string dob)
        {
            this.EmpName = EmpName;
            this.EmpID = EmpID;
            this.SymbolNo = symbol;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = surName;

            this.Gender = gender;
            this._DOB = dob;


        }



        public ATTEmployeeDeputaion(int depOrgID, string depOrgName)
        {

            this.DepOrgID = depOrgID;
            this.DepOrgName = DepOrgName;
        }

        public ATTEmployeeDeputaion(double empID, int orgID, int desID, string createdDate, int postID, string fromDate, string applicationDate, int depOrgID, int decisionVerBy, string leaveDate, int leaveVerBy, string returnDate, int retrunVerBy, string responsibilities, string active, string entryBy, string entryDate, int tipOrgID, int tippaniID, string decisionDate, string action)
        {
            // Added by shanjeev Sah 
            this.EmpID = empID;
            this.OrgID = orgID;
            this.DesID = desID;
            this.CreatedDate = createdDate;
            this.PostID = postID;
            this.FromDate = fromDate;//
            this.ApplicationDate = applicationDate;

            this.DepOrgID = depOrgID;
            this.DecisionVerifiedBy = decisionVerBy;
            this.LeaveDate = leaveDate;
            this.LeaveVerifiedBy = leaveVerBy;

            this.ReturnDate = returnDate;
            this.ReturnVerifiedBy = retrunVerBy;
            this.Responsibilities = responsibilities;
            this.Active = active;
            this.EntryBy = entryBy;
            this.TipOrgID = tipOrgID;
            this.TippaniID = tippaniID;
            this.DecisionDate = decisionDate;
            this.Action = action;

        }



    }
}
