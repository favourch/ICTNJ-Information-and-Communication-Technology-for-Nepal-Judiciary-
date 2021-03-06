using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTRetirement
    {
        private int _empID;

        public int empID
        {
            get { return _empID; }
            set { _empID = value; }
        }
        private string _firstName;

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _midName;

        public string midName
        {
            get { return _midName; }
            set { _midName = value; }
        }
        private string _lastName;

        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _fullName;

        public string fullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _gender;

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _sex;

        public string sex
        {
            get
            {
                return (this.gender == "M" ? "पुरुष" : "महिला");
            }
        }

        private string _orgName;

        public string orgName
        {
            get { return _orgName; }
            set { _orgName = value; }
        }
	
        private int _orgID;

        public int orgID
        {
            get { return _orgID; }
            set { _orgID = value; }
        }
        private int _desID;

        public int desID
        {
            get { return _desID; }
            set { _desID = value; }
        }
        private string _desName;

        public string desName
        {
            get { return _desName; }
            set { _desName = value; }
        }
        private string _desType;

        public string desType
        {
            get { return _desType; }
            set { _desType = value; }
        }
        private string _maritalStatus;

        public string maritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }
        private string _dob;

        public string dob
        {
            get { return _dob; }
            set { _dob = value; }
        }
	
        private string _createdDate;

        public string createdDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private int _postID;

        public int postID
        {
            get { return _postID; }
            set { _postID = value; }
        }
        private string _fromDat;

        public string fromDate
        {
            get { return _fromDat; }
            set { _fromDat = value; }
        }
        private string _retirementDate;

        public string retirementDate
        {
            get { return _retirementDate; }
            set { _retirementDate = value; }
        }
        private string _isSelf;

        public string isSelf
        {
            get { return _isSelf; }
            set { _isSelf = value; }
        }

        private string _YesNo;

        public string YesNo
        {
            get
            {
                return (this.isSelf == "Y" ? "हो" : "होइन");
            }
        }

        private string _retirementType;

        public string retirementType
        {
            get { return _retirementType; }
            set { _retirementType = value; }
        }
        private string _ApplDesc;

        public string ApplDesc
        {
            get { return _ApplDesc; }
            set { _ApplDesc = value; }
        }
	
        private string _decisionDate;

        public string decisionDate
        {
            get { return _decisionDate; }
            set { _decisionDate = value; }
        }
        private int? _decisionBy;

        public int? decisionBy
        {
            get { return _decisionBy; }
            set { _decisionBy = value; }
        }
        private string _appDate;

        public string appDate
        {
            get { return _appDate; }
            set { _appDate = value; }
        }
        private int? _appBy;

        public int? appBy
        {
            get { return _appBy; }
            set { _appBy = value; }
        }
        private string _entryBy;

        public string entryBy
        {
            get { return _entryBy; }
            set { _entryBy = value; }
        }
        private string _decisionDesc;

        public string decisionDesc
        {
            get { return _decisionDesc; }
            set { _decisionDesc = value; }
        }
        private string _appDesc;

        public string appDesc
        {
            get { return _appDesc; }
            set { _appDesc = value; }
        }
        private int _intType;

        public int iniType
        {
            get { return _intType; }
            set { _intType = value; }
        }
	
        private string _action;

        public string action
        {
            get { return _action; }
            set { _action = value; }
        }
        private string _decPerson;

        public string decPerson
        {
            get { return _decPerson; }
            set { _decPerson = value; }
        }

        private string _apprPerson;

        public string apprPerson
        {
            get { return _apprPerson; }
            set { _apprPerson = value; }
        }
        private string _isDecided;

        public string isDecided
        {
            get { return _isDecided; }
            set { _isDecided = value; }
        }
        private string _isApproved;

        public string isApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; }
        }
        private string _DecidedYesNo;

        public string DecidedYesNo
        {
            get
            {
                return (this.isDecided == "Y" ? "हो" : "होइन");
            }
        }
        private string _ApprovedYesNo;

        public string ApprovedYesNo
        {
            get
            {
                return (this.isApproved == "Y" ? "हो" : "होइन");
            }
        }

	
        public ATTRetirement()
        {
        }

        public ATTRetirement(int empid,int orgid,int desid,string createddate,int postid,string fromdate,string retirementdate,string isself,string retirementtype,string decisiondate,int decisionby,string appdate,int appby,string entryby,string decisiondesc,string appdesc,string actn)
        {
            this.empID = empid;
            this.orgID = orgid;
            this.desID = desid;
            this.createdDate = createddate;
            this.postID = postid;
            this.fromDate = fromdate;
            this.retirementDate = retirementdate;
            this.isSelf = isself;
            this.retirementType = retirementtype;
            this.decisionDate = decisiondate;
            this.decisionBy = decisionby;
            this.appDate = appdate;
            this.appBy = appby;
            this.entryBy = entryBy;
            this.decisionDesc = decisiondesc;
            this.appDesc = appdesc;
            this.action = actn;
        }
    }
}
