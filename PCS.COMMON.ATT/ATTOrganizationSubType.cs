using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
   public class ATTOrganizationSubType
    {
        private string  _OrgTypeCode;

        public string  OrgTypeCode
        {
            get { return _OrgTypeCode; }
            set { _OrgTypeCode = value; }
        }
        private string  _OrgSubTypeCode;

        public string  OrgSubTypeCode
        {
            get { return _OrgSubTypeCode; }
            set { _OrgSubTypeCode = value; }
        }
        private string  _OrgSubTypeDesc;

        public string  OrgSubTypeDesc
        {
            get { return _OrgSubTypeDesc; }
            set { _OrgSubTypeDesc = value; }
        }

       public ATTOrganizationSubType(string OrgTypeCode, string OrgSubTypeCode, string OrgSubTypeDesc)
       {
           this.OrgTypeCode = OrgTypeCode;
           this.OrgSubTypeCode = OrgSubTypeCode;
           this.OrgSubTypeDesc = OrgSubTypeDesc;
       }
	
    }
}
