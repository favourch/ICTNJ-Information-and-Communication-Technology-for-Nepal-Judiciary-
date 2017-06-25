using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.DLL;
using PCS.COMMON.ATT;


namespace PCS.COMMON.BLL
{
   public  class BLLOrganizationSubType
    {

        public static List<ATT.ATTOrganizationSubType> GetOrgSubType()
        {
            List<ATT.ATTOrganizationSubType> LstOrgSubType = new List<PCS.COMMON.ATT.ATTOrganizationSubType>();

            foreach (DataRow row in DLL.DLLOrganizationSubType.GetOrgSubType().Rows)
            {
                ATT.ATTOrganizationSubType ObjAttSubType = new PCS.COMMON.ATT.ATTOrganizationSubType
                                                   (
                                                   (string)row["ORG_TYPE_CD"],
                                                   (string)row["ORG_SUB_TYPE_CD"],
                                                   (string)row["ORG_SUB_TYPE_DESC"]
                                                   );

                LstOrgSubType.Add(ObjAttSubType);
            }
            return LstOrgSubType;
        }
    }
}
