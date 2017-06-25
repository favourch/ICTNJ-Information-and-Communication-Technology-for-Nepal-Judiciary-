using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    [Serializable]
    public class ATTOrganizationUnit
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName; }
            set { this._UnitName = value; }
        }


        private int? _ParentOrgID;
        public int? ParentOrgID
        {
            get { return this._ParentOrgID; }
            set { this._ParentOrgID = value; }
        }

        private int? _ParentUnitID;
        public int? ParentUnitID
        {
            get { return this._ParentUnitID; }
            set { this._ParentUnitID = value; }
        }

        private string _UnitType;
        public string UnitType
        {
            get { return _UnitType; }
            set { _UnitType = value; }
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


        private int _EmpID;

        public int EmpID
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


        private List<ATTOrganizationUnit> _LstUnitName = new List<ATTOrganizationUnit>();
        public List<ATTOrganizationUnit> LstUnitName
        {
            get { return this._LstUnitName; }
            set { this._LstUnitName = value; }
        }

        public ATTOrganizationUnit()
        {
        }

        public ATTOrganizationUnit(int orgID, int unitID, string unitName)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.UnitName = unitName;
        }

        public ATTOrganizationUnit(int orgID, int unitID, string unitName,string entryBy,string action)
        {
            this.OrgID = orgID;
            this.UnitID = unitID;
            this.UnitName = unitName;
            this.EntryBy = entryBy;
            this.Action = action;
        }
    }
}
