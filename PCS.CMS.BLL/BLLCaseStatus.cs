using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
  public class BLLCaseStatus
    {
        public static bool SaveCaseStatus(ATTCaseStatus objCaseStatus)
        {
            try
            {
                return DLLCaseStatus.SaveCaseStatus(objCaseStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTCaseStatus> GetCaseStatus(int? CaseStatus, string active, int defaultFlag)
        {
            List<ATTCaseStatus> CaseStatusList = new List<ATTCaseStatus>();
            try
            {
                foreach (DataRow row in DLLCaseStatus.GetCaseStatus(CaseStatus, active).Rows)
                {
                    ATTCaseStatus Reglst = new ATTCaseStatus(
                        int.Parse(row["CASE_STATUS_ID"].ToString()),
                        row["CASE_STATUS_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    CaseStatusList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    CaseStatusList.Insert(0, new ATTCaseStatus(0, "छान्नुहोस", ""));
                return CaseStatusList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
