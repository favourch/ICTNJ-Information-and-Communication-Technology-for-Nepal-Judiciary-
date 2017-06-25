using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseAccount
    {
        public static List<ATTCaseAccount> GetCaseAccount(double caseID)
        {
            List<ATTCaseAccount> CaseAccountList = new List<ATTCaseAccount>();

            try
            {
                foreach (DataRow row in DLLCaseAccount.GetCaseAccount(caseID).Rows)
                {
                    ATTCaseAccount att = new ATTCaseAccount
                        (
                            int.Parse(row["CASE_ID"].ToString()),
                            int.Parse(row["ACCOUNT_TYPE_ID"].ToString()),
                            row["TRAN_DATE"].ToString(),
                            int.Parse(row["TRAN_AMOUNT"].ToString()),
                            row["REMARKS"].ToString()
                        );
                    att.AccountTypeName = row["ACCOUNT_TYPE_NAME"].ToString();
                    CaseAccountList.Add(att);
                }
                return CaseAccountList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveCaseAccount(ATTCaseAccount attCA)
        {
            try
            {
                return DLLCaseAccount.SaveCaseAccount(attCA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

