using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LJMS.ATT
{
    public class ATTLawyerInfoSearch
    {
        private double? _PERSONID;
        public double? PERSONID
        {
            get { return this._PERSONID; }
            set { this._PERSONID = value; }
        }

        private double? _LAWYERID;
        public double? LAWYERID
        {
            get { return this._LAWYERID; }
            set { this._LAWYERID = value; }
        }

        private double? _PLAWYERID;
        public double? PLAWYERID
        {
            get { return this._PLAWYERID; }
            set { this._PLAWYERID = value; }
        }

        private int? _LTYPEID;
        public int? LTYPEID
        {
            get { return this._LTYPEID; }
            set { this._LTYPEID = value; }
        }

        private int? _UNITID;
        public int? UNITID
        {
            get { return this._UNITID; }
            set { this._UNITID = value; }
        }

        private string _FNAME;
        public string FNAME
        {
            get { return this._FNAME; }
            set { this._FNAME = value; }
        }

        private string _MNAME;
        public string MNAME
        {
            get { return this._MNAME; }
            set { this._MNAME = value; }
        }

        private string _SURNAME;
        public string SURNAME
        {
            get { return this._SURNAME; }
            set { this._SURNAME = value; }
        }

        private string _LNAME;
        public string LNAME
        {
            get { return this._LNAME; }
            set { this._LNAME = value; }
        }

        public string RDFullName
        {
            get
            {
                return this.FNAME + " " + this.MNAME + " " + this.LNAME;
            }
        }

        private string _LGENDER;
        public string LGENDER
        {
            get { return this._LGENDER; }
            set { this._LGENDER = value; }
        }

        private string _GENDER;
        public string GENDER
        {
            get { return this._GENDER; }
            set { this._GENDER = value; }
        }

        private string _DOB;
        public string DOB
        {
            get { return this._DOB; }
            set { this._DOB = value; }
        }

        private string _LTYPE;
        public string LTYPE
        {
            get { return this._LTYPE; }
            set { this._LTYPE = value; }
        }

        private string _LICENSENO;
        public string LICENSENO
        {
            get { return this._LICENSENO; }
            set { this._LICENSENO = value; }
        }

        private string _LRENEWALUPTO;
        public string LRENEWALUPTO
        {
            get { return this._LRENEWALUPTO; }
            set { this._LRENEWALUPTO = value; }
        }

        private string _UNITNAME;
        public string UNITNAME
        {
            get { return this._UNITNAME; }
            set { this._UNITNAME = value; }
        }

        private string _PLRENEWALUPTO;
        public string PLRENEWALUPTO
        {
            get { return this._PLRENEWALUPTO; }
            set { this._PLRENEWALUPTO = value; }
        }

        private byte[] _PLawyerPhoto;
        public byte[] PLAWYERPHOTO
        {
            get { return this._PLawyerPhoto; }
            set { this._PLawyerPhoto = value; }
        }

        private string _TODATE;
        public string TODATE
        {
            get { return this._TODATE; }
            set { this._TODATE = value; }
        }

        private string _INRANGE;
        public string INRANGE
        {
            get { return this._INRANGE; }
            set { this._INRANGE = value; }
        }

        private string _ACTIVE;

        public string ACTIVE
        {
            get { return _ACTIVE.Trim(); }
            set { _ACTIVE = value; }
        }

        private string _DISPLAYDATE;
        public string DISPLAYDATE
        {
            get { return this._DISPLAYDATE; }
            set { this._DISPLAYDATE = value; }
        }




        public ATTLawyerInfoSearch()
        {
        }

        public ATTLawyerInfoSearch(double dblPersonId, double dblLawyerId, double dblPLawyerId, int intLTypeId,
            int intUnitId, string strFName, string strMName, string strSurName, string strLName, string strLGender,
            string strGender, string strDOB, string strLType, string strLicenseNo, string strLRenewalUpto,
            string strUnitName, string strPLRenewalUpto, byte[] bytePhoto)
        {
            this.PERSONID = dblPersonId;
            this.LAWYERID = dblLawyerId;
            this.PLAWYERID = dblPLawyerId;
            this.LTYPEID = intLTypeId;
            this.UNITID = intUnitId;
            this.FNAME = strFName;
            this.MNAME = strMName;
            this.SURNAME = strSurName;
            this.LNAME = strLName;
            this.LGENDER = strLGender;
            this.GENDER = strGender;
            this.DOB = strDOB;
            this.LTYPE = strLType;
            this.LICENSENO = strLicenseNo;
            this.LRENEWALUPTO = strLRenewalUpto;
            this.UNITNAME = strUnitName;
            this.PLRENEWALUPTO = strPLRenewalUpto;
            this.PLAWYERPHOTO = bytePhoto;
        }
    }
}
