using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public enum LawyerType
    {
        NepalBarAssociation = 1,
        NepalBarCouncil = 2
    }

    public class ATTLawyerCount
    {
        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName.Trim(); }
            set { this._UnitName = value; }
        }

        private int _LawyerTypeID;
        public int LawyerTypeID
        {
            get { return this._LawyerTypeID; }
            set { this._LawyerTypeID = value; }
        }

        private string _LawyerTypeName;
        public string LawyerTypeName
        {
            get { return this._LawyerTypeName.Trim(); }
            set { this._LawyerTypeName = value; }
        }

        private string _Gender;
        public string Gender
        {
            get { return this._Gender.Trim(); }
            set { this._Gender = value; }
        }

        public string RDGender
        {
            get
            {
                string s;
                if (this._Gender == "M")
                    s = "k'?í";
                else if (this._Gender == "F")
                    s = "dlxnF";
                else
                    s = "";
                return s;
            }
        }

        private int _Total;
        public int Total
        {
            get { return this._Total; }
            set { this._Total = value; }
        }

        private LawyerType _Type;
        public LawyerType Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }

        public ATTLawyerCount()
        {
        }
    }

    public class ATTLawyerSearch
    {
        private double _PersonID;
        public double PersonID
        {
            get { return this._PersonID; }
            set { this._PersonID = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return this._FirstName.Trim(); }
            set { this._FirstName = value.Trim(); }
        }

        private string _MidName;
        public string MidName
        {
            get { return this._MidName.Trim(); }
            set { this._MidName = value.Trim(); }
        }

        private string _SurName;
        public string SurName
        {
            get { return this._SurName.Trim(); }
            set { this._SurName = value.Trim(); }
        }

        public string RDFullName
        {
            get
            {
                return this.FirstName + " " + this.MidName + " " + this.SurName;
            }
        }

        private string _Gender;
        public string Gender
        {
            get { return this._Gender.Trim(); }
            set { this._Gender = value; }
        }

        public string RDGender
        {
            get
            {
                string s;
                if (this._Gender == "M")
                    s = "k'?í";
                else if (this._Gender == "F")
                    s = "dlxnF";
                else
                    s = "";
                return s;
            }
        }

        private string _Lisence;
        public string Lisence
        {
            get { return this._Lisence.Trim(); }
            set { this._Lisence = value; }
        }

        private int _LawyerTypeID;
        public int LawyerTypeID
        {
            get { return this._LawyerTypeID; }
            set { this._LawyerTypeID = value; }
        }

        private string _LawyerTypeName;
        public string LawyerTypeName
        {
            get { return this._LawyerTypeName.Trim(); }
            set { this._LawyerTypeName = value; }
        }

        private string _LastRenewalDate = "";
        public string LastRenewalDate
        {
            get { return this._LastRenewalDate.Trim(); }
            set { this._LastRenewalDate = value; }
        }

        private string _LastRenewalUpto = "";
        public string LastRenewalUpto
        {
            get { return this._LastRenewalUpto.Trim(); }
            set { this._LastRenewalUpto = value; }
        }

        private string _ACTIVE;

        public string ACTIVE
        {
            get { return _ACTIVE.Trim(); }
            set { _ACTIVE = value; }
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
            get { return this._UnitName.Trim(); }
            set { this._UnitName = value; }
        }

        private string _PvtLawyerLastRenewalDate = "";
        public string PvtLawyerLastRenewalDate
        {
            get { return this._PvtLawyerLastRenewalDate.Trim(); }
            set { this._PvtLawyerLastRenewalDate = value; }
        }

        private string _PvtLawyerLastRenewalUpto = "";
        public string PvtLawyerLastRenewalUpto
        {
            get { return this._PvtLawyerLastRenewalUpto.Trim(); }
            set { this._PvtLawyerLastRenewalUpto = value; }
        }

        public ATTLawyerSearch()
        {
        }
    }
}
