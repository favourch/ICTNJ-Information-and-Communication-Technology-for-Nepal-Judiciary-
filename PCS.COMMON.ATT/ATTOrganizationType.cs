using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTOrganizationType
    {
        private string _OrgTypeCode;
        public string OrgTypeCode
        {
            get { return _OrgTypeCode; }
            set { _OrgTypeCode = value; }
        }

        private string _OrgTypeDesc;
        public string OrgTypeDesc
        {
            get { return _OrgTypeDesc; }
            set { _OrgTypeDesc = value; }
        }
       
        private List<ATTOrganizationSubType> _LstOrgSubType;
        public List<ATTOrganizationSubType> LstOrgSubType
        {
            get { return _LstOrgSubType; }
            set { _LstOrgSubType = value; }
        }
	
       
      
        public ATTOrganizationType(string OrgTypeCode, string OrgTypeDesc)
        {
            this.OrgTypeCode = OrgTypeCode;
            this.OrgTypeDesc = OrgTypeDesc;
        }
    }
}
