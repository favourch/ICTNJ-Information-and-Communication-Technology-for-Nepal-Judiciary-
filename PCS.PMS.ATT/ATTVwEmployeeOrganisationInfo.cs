using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTVwEmployeeOrganisationInfo
    {
        private int _EmpID;
        public int EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return this._MiddleName; }
            set { this._MiddleName = value; }
        }

        private string _SurName;
        public string SurName
        {
            get { return this._SurName; }
            set { this._SurName = value; }
        }

        public string FullName
        {
            get
            {
                string strFullName;
                strFullName = this.FirstName;
                strFullName += (this.MiddleName == "" ? "" : " " + this.MiddleName);
                strFullName += (this.SurName == "" ? "" : " " + this.SurName);
                return strFullName;
            }
        }

        private string _DesignationName;
        public string DesignationName
        {
            get { return _DesignationName; }
            set { _DesignationName = value; }
        }

        private string _LevelName;
        public string LevelName
        {
            get { return _LevelName; }
            set { _LevelName = value; }
        }

        public ATTVwEmployeeOrganisationInfo()
        {
        }


        public ATTVwEmployeeOrganisationInfo(int empID, int orgID,string orgName, string firstName, string middleName,string surName,
                                                                                             string designationName,string levelName)
        {
            this.EmpID = empID;
            this.OrgID = orgID;
            this.OrgName = orgName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.SurName = surName;
            this.DesignationName = designationName;
            this.LevelName = levelName;
        }

        
    }
}
