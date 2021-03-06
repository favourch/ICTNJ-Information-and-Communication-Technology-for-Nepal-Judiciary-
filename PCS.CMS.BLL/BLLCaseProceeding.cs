using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseProceeding
    {
        public static bool SaveCaseProceeding(ATTCaseProceeding objCaseProceeding)
        {
            try
            {
                return DLLCaseProceeding.SaveCaseProceeding(objCaseProceeding);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTCaseProceeding> GetCaseProceeding(int? CaseProceeding, string active, int defaultFlag)
        {
            List<ATTCaseProceeding> CaseProceedingList = new List<ATTCaseProceeding>();
            try
            {
                foreach (DataRow row in DLLCaseProceeding.GetCaseProceeding(CaseProceeding, active).Rows)
                {
                    ATTCaseProceeding Reglst = new ATTCaseProceeding(
                        int.Parse(row["PROCEEDING_ID"].ToString()),
                        row["PROCEEDING_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    CaseProceedingList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    CaseProceedingList.Insert(0, new ATTCaseProceeding(0, "छान्नुहोस", ""));
                return CaseProceedingList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
