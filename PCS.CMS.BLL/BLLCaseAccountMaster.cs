using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseAccountMaster
    {
        public static List<ATTCaseAccountMaster> GetCaseAccountMaster(ATTCaseAccountMaster attCAM)
        {
            List<ATTCaseAccountMaster> CAMList = new List<ATTCaseAccountMaster>();

            try
            {
                foreach (DataRow row in DLLCaseAccountMaster.GetCaseAccountMaster(attCAM).Rows)
                {
                    ATTCaseAccountMaster att = new ATTCaseAccountMaster
                        (
                            int.Parse(row["CASE_ID"].ToString()),
                            row["TRAN_DATE"].ToString(),
                            int.Parse(row["TRAN_SEQ"].ToString()),
                            int.Parse(row["LITIGANT_ID"].ToString()),
                            int.Parse(row["ATTORNEY_ID"].ToString()),
                            row["REMARKS"].ToString()
                        );
                    CAMList.Add(att);
                }
                return CAMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveCaseAccountMaster(ATTCaseAccountMaster attCAM)
        {
            try
            {
                return DLLCaseAccountMaster.SaveCaseAccountMaster(attCAM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
