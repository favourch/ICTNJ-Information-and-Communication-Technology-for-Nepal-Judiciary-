using System;
using System.Collections.Generic;
using System.Text;

using PCS.SECURITY.ATT;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.COMMON.ATT
{
    [Serializable]
    public class ATTOrganization
    {
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


        private string _OrgSubType;
        public string OrgSubType
        {
            get { return this._OrgSubType; }
            set { this._OrgSubType = value; }
        }

        private string _OrgType;
        public string OrgType
        {
            get { return this._OrgType; }
            set { this._OrgType = value; }
        }

        private int? _ParentId;
        public int? ParentId
        {
            get { return this._ParentId; }
            set { this._ParentId = value; }
        }

        private string _OrgAddress;
        public string OrgAddress
        {
            get { return _OrgAddress; }
            set { _OrgAddress = value; }
        }

        private string _OrgStreetName;
        public string OrgStreetName
        {
            get { return _OrgStreetName; }
            set { _OrgStreetName = value; }
        }
        private int _OrgVdcMuni;

        public int OrgVdcMuni
        {
            get { return _OrgVdcMuni; }
            set { _OrgVdcMuni = value; }
        }
        private string _OrgUrl;
        public string OrgUrl
        {
            get { return _OrgUrl; }
            set { _OrgUrl = value; }
        }
        private int _OrgWardNo;
        public int OrgWardNo
        {
            get { return _OrgWardNo; }
            set { _OrgWardNo = value; }
        }
        private int _OrgDistrict;

        public int OrgDistrict
        {
            get { return _OrgDistrict; }
            set { _OrgDistrict = value; }
        }
        private int _OrgEquCode;
        public int OrgEquCode
        {
            get { return _OrgEquCode; }
            set { _OrgEquCode = value; }
        }
        private string _OrgEquCodes;
        public string OrgEquCodes
        {
            get { return _OrgEquCodes; }
            set { _OrgEquCodes = value; }
        }
        private int _ZoneId;

        public int ZoneId
        {
            get { return _ZoneId; }
            set { _ZoneId = value; }
        }
// Below 3 properties is added by shanjeev sah
        private string _NepDistname;
        public string NepDistname
        {
            get
            {
                return _NepDistname;

            }
            set
            {
                _NepDistname = value;

            }
        }
        private string _ZoneName;
        public string ZoneName
        {
            get
            {
                return _ZoneName;

            }
            set
            {
                _ZoneName = value;

            }
        }


        private string _NepVdcname;
        public string NepVdcname
        {
            get
            {
                return _NepVdcname;

            }
            set
            {
                _NepVdcname = value;

            }
        }



        private List<ATTEmail> _LstEmail = new List<ATTEmail>();
        public List<ATTEmail> LstEmail
        {
            get { return _LstEmail; }
            set { _LstEmail = value; }
        }
        private List<ATTPhone> _LstPhone = new List<ATTPhone>();
        public List<ATTPhone> LstPhone
        {
            get { return _LstPhone; }
            set { _LstPhone = value; }
        }

        private List<ATTOrganizationApplications> _LSTOrgApplications = new List<ATTOrganizationApplications>();
        public List<ATTOrganizationApplications> LSTOrgApplications
        {
            get { return this._LSTOrgApplications; }
            set { this._LSTOrgApplications = value; }
        }

        private List<ATTOrganizationUsers> _LSTOrgUsers = new List<ATTOrganizationUsers>();
        public List<ATTOrganizationUsers> LSTOrgUsers
        {
            get { return this._LSTOrgUsers; }
            set { this._LSTOrgUsers = value; }
        }

        private List<ATTOrganizationUnit> _LSTOrgUnit=new List<ATTOrganizationUnit>();

        public List<ATTOrganizationUnit> LSTOrgUnit
        {
            get { return this._LSTOrgUnit; }
            set { this._LSTOrgUnit = value; }
        }

        //private List<ATTOrganizationSection> _LSTOrgSection = new List<ATTOrganizationSection>();

        //public List<ATTOrganizationSection> LSTOrgSection
        //{
        //    get { return this._LSTOrgSection; }
        //    set { this._LSTOrgSection = value; }
        //}

        public ATTOrganization CreateDeepCopy()
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, this);
            m.Position = 0;
            ATTOrganization obj = (ATTOrganization)b.Deserialize(m);
            m.Close();
            m.Dispose();
            return obj;
        }
	

        public ATTOrganization()
        {
        }

        public ATTOrganization(int orgID, string orgName)
        {
            this.OrgID = orgID;
            this.OrgName = orgName;

        }

        public ATTOrganization(int OrgID, string OrgName, string OrgType, string OrgSubType, int? OrgParent)
        {
            this.OrgID = OrgID;
            this.OrgName = OrgName;
            this.ParentId = OrgParent;
            this.OrgSubType = OrgSubType;
            this.OrgType = OrgType;
        }

        public ATTOrganization(int OrgID, string OrgName, string OrgType, string OrgSubType, int OrgParent, int OrgEquCode)
        {
            this.OrgID = OrgID;
            this.OrgName = OrgName;
            this.ParentId = OrgParent;
            this.OrgSubType = OrgSubType;
            this.OrgType = OrgType;
            this.OrgEquCode = OrgEquCode;
        }

        public ATTOrganization(string OrgName, string OrgSubType, string OrgType, int OrgParent)
        {

            this.OrgName = OrgName;
            this.ParentId = OrgParent;
            this.OrgSubType = OrgSubType;
            this.OrgType = OrgType;
        }

        public ATTOrganization(string orgSubType, int orgID, int parentID, string orgType, string orgName, string orgAddress, string orgStreetName, int orgVdcMuni, string orgUrl, int orgWardNo, int orgDist, string orgEquCode)
        {
            // added by shanjeev sah


            this.OrgSubType = orgSubType;
            this.OrgID = orgID;
            this.ParentId = parentID;
            this.OrgType = orgType;
            this.OrgName = orgName;
            this.OrgAddress = orgAddress;
            this.OrgStreetName = orgStreetName;
            this.OrgVdcMuni = orgVdcMuni;
            this.OrgUrl = orgUrl;
            this.OrgWardNo = orgWardNo;
            this.OrgDistrict = orgDist;
            this.OrgEquCodes = orgEquCode;
        }	


        public ATTOrganization(int OrgID, string OrgName, string OrgType, string OrgSubType, int OrgParent, string OrgAddress, string OrgStreetName, int OrgVdc, string OrgUrl, int OrgWard, int OrgDistrict, int CourtCode, int ZoneId)
        {
            this.OrgID = OrgID;
            this.OrgName = OrgName;
            this.ParentId = OrgParent;
            this.OrgType = OrgType;
            this.OrgSubType = OrgSubType;
            this.OrgAddress = OrgAddress;
            this.OrgStreetName = OrgStreetName;
            this.OrgVdcMuni = OrgVdc;
            this.OrgWardNo = OrgWard;
            this.OrgUrl = OrgUrl;
            this.OrgDistrict = OrgDistrict;
            this.OrgEquCode = CourtCode;
            this.ZoneId = ZoneId;
        }
    }
}
