using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseAccountDetails
    {
        public static List<ATTCaseAccountDetails> GetCaseAccountDetail(ATTCaseAccountDetails attCAD)
        {
            List<ATTCaseAccountDetails> CADList = new List<ATTCaseAccountDetails>();

            try
            {
                foreach (DataRow row in DLLCaseAccountDetails.GetCaseAccountDetails(attCAD).Rows)
                {
                    ATTCaseAccountDetails att = new ATTCaseAccountDetails
                        (
                            int.Parse(row["CASE_ID"].ToString()),
                            row["TRAN_DATE"].ToString(),
                            int.Parse(row["TRAN_SEQ"].ToString()),
                            int.Parse(row["ACCOUNT_TYPE_ID"].ToString()),
                            int.Parse(row["TOT_AMOUNT"].ToString())
                        );
                    CADList.Add(att);
                }
                return CADList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool SaveCaseAccountDetail(ATTCaseAccountDetails attCAD)
        //{
        //    try
        //    {
        //        return DLLCaseAccountDetails.SaveCaseAccountDetail(attCAD);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
