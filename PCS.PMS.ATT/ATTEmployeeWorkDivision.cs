using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeeWorkDivision
    {
        private int? _EmpID;
        public int? EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
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

        private string _CreatedDate;
        public string CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
	
        private string _SymbolNo;
        public string SymbolNo
        {
            get { return _SymbolNo; }
            set { _SymbolNo = value; }
        }

        private int _OrgEmpNo;
        public int OrgEmpNo
        {
            get { return _OrgEmpNo; }
            set { _OrgEmpNo = value; }
        }
	
        private int? _OrgUnitID;
        public int? OrgUnitID
        {
            get { return _OrgUnitID; }
            set { _OrgUnitID = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return _UnitName; }
            set { _UnitName = value; }
        }

        private string _UnitType;
        public string UnitType
        {
            get { return _UnitType; }
            set { _UnitType = value; }
        }
	
        private int _SectionID;
        public int SectionID
        {
            get { return _SectionID; }
            set { _SectionID = value; }
        }

        private string _SectionName;
        public string SectionName
        {
            get { return _SectionName; }
            set { _SectionName = value; }
        }
	
        private string _UnitFromDate;
        public string UnitFromDate
        {
            get { return _UnitFromDate; }
            set { _UnitFromDate = value; }
        }

        private string _Post;
        public string Post
        {
            get { return _Post; }
            set { _Post = value; }
        }

        private int _PostID;
        public int PostID
        {
            get { return _PostID; }
            set { _PostID = value; }
        }
	
	
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _Responsibility;
        public string Responsibility
        {
            get { return _Responsibility; }
            set { _Responsibility = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _IsHeadOfUnit;

        public string IsHeadOfUnit
        {
            get { return _IsHeadOfUnit; }
            set { _IsHeadOfUnit = value; }
        }
        private string _IsHeadOfSection;

        public string IsHeadOfSection
        {
            get { return _IsHeadOfSection; }
            set { _IsHeadOfSection = value; }
        }
        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
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
	
        private string _Gender;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private string _fullGender;
        public string fullGender
        {
            get
            {
                return (this.Gender == "M" ? "पुरुष" : "महिला");
            }
        }
	
        private string _DesType;

        public string DesType
        {
            get { return _DesType; }
            set { _DesType = value; }
        }

        private string _EntryDate;

        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _ToDate;

        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        public ATTEmployeeWorkDivision()
        { }

        public ATTEmployeeWorkDivision(int empid,string symbolno,string fullname,int? orgid, string orgname,int orgunitid,string unitname,string post,string fromdate,string responsibility,string entryby,string action,int orgempno,string gender,string destype)
        {
            this.EmpID = empid;
            this.SymbolNo = symbolno;
            this.FullName = fullname;          
            this.OrgID = orgid;
            this.OrgName = orgname;
            this.OrgUnitID = orgunitid;
            this.OrgEmpNo = orgempno;
            this.UnitName = unitname;
            this.Post = post;
            this.FromDate = fromdate;
            this.Responsibility = responsibility;
            this.EntryBy = entryby;
            this.Gender = gender;
            this.DesType = destype;
            this.Action = action;
        }
        public ATTEmployeeWorkDivision(string orgname,string unitname,string fullname, int empid, int orgid, int unitid,int sectionid, string fromdate, string responsibility, string entryby, string action)
        {
            this.OrgName = orgname;
            this.UnitName = unitname;
            this.FullName = fullname;
            this.EmpID = empid;
            this.OrgID = orgid;
            this.OrgUnitID = unitid;
            this.SectionID = sectionid;
            this.FromDate = fromdate;
            this.Responsibility = responsibility;
            this.EntryBy = entryby;
            this.Action = action;
        }
    }
}
