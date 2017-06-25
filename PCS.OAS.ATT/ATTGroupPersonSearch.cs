using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTGroupPersonSearch : PCS.COMMON.ATT.ATTPersonSearch
    {
        private int _GroupID;
        public int GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private string _GroupName;
        public string GroupName
        {
            get { return this._GroupName; }
            set { this._GroupName = value; }
        }

        private int _GMPositionID;
        public int GMPositionID
        {
            get { return this._GMPositionID; }
            set { this._GMPositionID = value; }
        }

        private string _GMPositionName;
        public string GMPositionName
        {
            get { return this._GMPositionName; }
            set { this._GMPositionName = value; }
        }

        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _DesID;
        public int DesID
        {
            get { return this._DesID; }
            set { this._DesID = value; }
        }

        private string _CreatedDate;
        public string CreatedDate
        {
            get { return this._CreatedDate.Trim(); }
            set { this._CreatedDate = value; }
        }

        private int _PostID;
        public int PostID
        {
            get { return this._PostID; }
            set { this._PostID = value; }
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

        private string _UnitFromDate;
        public string UnitFromDate
        {
            get { return this._UnitFromDate.Trim(); }
            set { this._UnitFromDate = value; }
        }

        private string _PostFromDate;
        public string PostFromDate
        {
            get { return this._PostFromDate.Trim(); }
            set { this._PostFromDate = value; }
        }

        private string _SymbolNo = "";
        public string SymbolNo
        {
            get { return this._SymbolNo; }
            set { this._SymbolNo = value; }
        }
    }
}
