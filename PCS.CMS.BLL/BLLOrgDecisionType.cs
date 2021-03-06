using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLOrgDecisionType
    {
        public static List<ATTOrgDecisionType> GetOrgDecisionType(int orgID,int? decTypeID, string active,string loadAll, int defaultFlag)
        {
            List<ATTOrgDecisionType> OrgDecTypeList = new List<ATTOrgDecisionType>();
            try
            {
                foreach (DataRow row in DLLOrgDecisionType.GetOrgDecisionType(orgID,decTypeID, active,loadAll).Rows)
                {
                    ATTOrgDecisionType objOrgDecType = new ATTOrgDecisionType(
                        int.Parse(row["ORG_ID"].ToString()),
                        int.Parse(row["DEC_TYPE_ID"].ToString()),
                        row["ACTIVE"].ToString());
                    OrgDecTypeList.Add(objOrgDecType);

                }

                if (defaultFlag > 0) ;
                    //OrgDecTypeList.Insert(0, new ATTOrgDecisionType(0, "छान्नुहोस", ""));
                return OrgDecTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
