using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;

namespace PCS.COMMON.BLL
{
   public class BLLOrganizationType
    {
       public static List<ATT.ATTOrganizationType> GetOrgType()
       {
           try
           {
               List<ATTOrganizationSubType> ObjOrgSubType = BLL.BLLOrganizationSubType.GetOrgSubType();

               List<ATT.ATTOrganizationType> LstOrgType = new List<PCS.COMMON.ATT.ATTOrganizationType>();

               foreach (DataRow row in DLL.DLLOrganizationType.GetOrgType().Rows)
               {
                   ATT.ATTOrganizationType ObjAttType = new PCS.COMMON.ATT.ATTOrganizationType
                                                      (
                                                      (string)row["ORG_TYPE_CD"],
                                                      (string)row["ORG_TYPE_DESC"]
                                                      );
                   ObjAttType.LstOrgSubType = ObjOrgSubType.FindAll(delegate(ATTOrganizationSubType SubType) { return SubType.OrgTypeCode == ObjAttType.OrgTypeCode; });

                   LstOrgType.Add(ObjAttType);
               }
               return LstOrgType;

           }
           catch (Exception ex)
           {
               
               throw ex;
           }
          
       }
    }
}
