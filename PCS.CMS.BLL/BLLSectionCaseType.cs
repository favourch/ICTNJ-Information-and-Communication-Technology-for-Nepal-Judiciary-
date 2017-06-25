using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
   public class BLLSectionCaseType
    {
       public static bool SaveSectionCaseType(List<ATTSectionCaseType> lstSCT)
       {
           try
           {
               return DLLSectionCaseType.SaveSectionCaseType(lstSCT);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
        public static List<ATTSectionCaseType> GetSectionCaseType(int orgID, int unitID, int? caseTypeID, string fromDate)
        {
            List<ATTSectionCaseType> SectionCaseTypeLST = new List<ATTSectionCaseType>();
            try
            {
                foreach (DataRow row in DLLSectionCaseType.GetSectionCasetype(orgID, unitID, caseTypeID, fromDate).Rows)
                {
                    ATTSectionCaseType objSectionCaseType = new ATTSectionCaseType();
                    objSectionCaseType.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objSectionCaseType.UnitID = int.Parse(row["UNIT_ID"].ToString());
                    objSectionCaseType.CaseTypeID = int.Parse(row["CASE_TYPE_ID"].ToString());
                    objSectionCaseType.FromDate = row["FROM_DATE"].ToString();
                    objSectionCaseType.ToDate = row["TO_DATE"].ToString();
                    SectionCaseTypeLST.Add(objSectionCaseType);
                }
              
                return SectionCaseTypeLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public static List<ATTSectionCaseType> GetSecCaseType(int orgID, int caseTypeID)
       {
           List<ATTSectionCaseType> SectionCaseTypeLST = new List<ATTSectionCaseType>();
           try
           {
               foreach (DataRow row in DLLSectionCaseType.GetSecCaseType(orgID, caseTypeID).Rows)
               {
                   ATTSectionCaseType objSectionCaseType = new ATTSectionCaseType();
                   objSectionCaseType.OrgID = int.Parse(row["ORG_ID"].ToString());
                   objSectionCaseType.UnitID = int.Parse(row["UNIT_ID"].ToString());
                   objSectionCaseType.UnitName = row["UNIT_NAME"].ToString();
                   objSectionCaseType.CaseTypeID = int.Parse(row["CASE_TYPE_ID"].ToString());
                   objSectionCaseType.FromDate = row["FROM_DATE"].ToString();
                   SectionCaseTypeLST.Add(objSectionCaseType);
               }

               return SectionCaseTypeLST;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
