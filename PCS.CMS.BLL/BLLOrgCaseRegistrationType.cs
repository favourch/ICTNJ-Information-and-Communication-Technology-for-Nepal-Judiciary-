using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLOrgCaseRegistrationType
    {
        public static List<ATTOrgCaseRegistrationType> GetOrgCaseRegType(int OrgID,int CaseTypeID,int? RegTypeID,string active,int CaseRegTypeDV)
        {
            List<ATTOrgCaseRegistrationType> LstOrgCaseType = new List<ATTOrgCaseRegistrationType>();
            try
            {
                foreach (DataRow row in DLLOrgCaseRegistrationType.GetOrgCaseRegType(OrgID,CaseTypeID,RegTypeID,active).Rows)
                {
                    ATTOrgCaseRegistrationType attOCRT = new ATTOrgCaseRegistrationType
                                              (
                                                int.Parse(row["ORG_ID"].ToString()),
                                                int.Parse(row["CASE_TYPE_ID"].ToString()),
                                                int.Parse(row["REG_TYPE_ID"].ToString()),
                                                row["REG_TYPE_NAME"].ToString(),
                                                row["ACTIVE"].ToString(),
                                                ""
                                              );
                    attOCRT.OrgCaseRegTypeCheckListLST = BLLOrgCaseRegTypeCheckList.GetOrgCaseRegTypeCheckList(int.Parse(row["ORG_ID"].ToString()), int.Parse(row["CASE_TYPE_ID"].ToString()), int.Parse(row["REG_TYPE_ID"].ToString()), null, "Y");

                                                

                    LstOrgCaseType.Add(attOCRT);
                }
                if (CaseRegTypeDV!=0)
                    LstOrgCaseType.Insert(0,new ATTOrgCaseRegistrationType(0,0,0,"छान्नुहोस","",""));
                return LstOrgCaseType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveOrgCaseRegType(List<ATTOrgCaseRegistrationType> lstOrgCaseRegType)
        {
            try
            {
                return DLLOrgCaseRegistrationType.SaveOrgCaseRegType(lstOrgCaseRegType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
