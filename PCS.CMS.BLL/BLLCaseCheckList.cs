using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.CMS.BLL
{
    public class BLLCaseCheckList
    {

        public static List<ATTCaseCheckList> GetCaseCheckList(double caseID,int  orgID,int ? caseTypeID,int regTypeID,int ? checkListID,int CCLDV)
        {
            List<ATTCaseCheckList> CaseCLLST = new List<ATTCaseCheckList>();
            try
            {
                foreach (DataRow row in DLLCaseCheckList.GetCaseCheckList(caseID,orgID,caseTypeID,regTypeID,checkListID).Rows)
                {
                    ATTCaseCheckList objCaseCL = new ATTCaseCheckList();
                    objCaseCL.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objCaseCL.OrgID= int.Parse(row["ORG_ID"].ToString());
                    objCaseCL.CaseTypeID = int.Parse(row["CASE_TYPE_ID"].ToString());
                    objCaseCL.RegTypeID= int.Parse(row["REG_TYPE_ID"].ToString());
                    objCaseCL.CheckListID= int.Parse(row["CHECK_LIST_ID"].ToString());
                    objCaseCL.FulFilled = row["FULL_FILLED"].ToString();
                    objCaseCL.Remarks = row["REMARKS"].ToString();
                    
                    
                    
                    CaseCLLST.Add(objCaseCL);

                    


                }

                //if (defaultFlag > 0)
                //    CaseStatusList.Insert(0, new ATTCaseStatus(0, "छान्नुहोस", ""));
                return CaseCLLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
