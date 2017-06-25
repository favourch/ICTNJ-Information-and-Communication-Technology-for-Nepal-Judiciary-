using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
   public class BLLOrgCaseRegTypeCheckList
    {
        public static List<ATTOrgCaseRegTypeCheckList> GetOrgCaseRegTypeCheckList(int OrgID, int CaseTypeID, int RegTypeID,int? CheckListID, string active)
        {
            List<ATTOrgCaseRegTypeCheckList> LstOrgCaseTypeChkLst = new List<ATTOrgCaseRegTypeCheckList>();
            try
            {
                foreach (DataRow row in DLLOrgCaseRegTypeCheckList.GetOrgCaseRegTypeCheckList(OrgID, CaseTypeID, RegTypeID, CheckListID, active).Rows)
                {
                    ATTOrgCaseRegTypeCheckList attOCRTC = new ATTOrgCaseRegTypeCheckList
                                              (
                                                int.Parse(row["ORG_ID"].ToString()),
                                                int.Parse(row["CASE_TYPE_ID"].ToString()),
                                                int.Parse(row["REG_TYPE_ID"].ToString()),
                                                int.Parse(row["CHECK_LIST_ID"].ToString()),
                                                row["CHECK_LIST_NAME"].ToString(),
                                                 "",
                                                row["ACTIVE"].ToString(),
                                                ""
                                              );
                    attOCRTC.CheckListType = row["CHECK_LIST_TYPE"].ToString();

                    LstOrgCaseTypeChkLst.Add(attOCRTC);
                }
                return LstOrgCaseTypeChkLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static bool SaveOrgCaseRegTypeCheckList(List<ATTOrgCaseRegTypeCheckList> lstOrgCaseRegTypeChkLst)
        {
            try
            {
                return DLLOrgCaseRegTypeCheckList.SaveOrgCaseRegTypeCheckList(lstOrgCaseRegTypeChkLst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
