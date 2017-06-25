using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.COMMON.BLL;

namespace PCS.CMS.BLL
{
    public class BLLLitigantPrisonDetails
    {
        public static List<ATTLitigantPrisonDetails> GetLitigantPrisonDetails(double? caseID, double? litigantID)
        {
            List<ATTLitigantPrisonDetails> LitigantPrisonDetailLST = new List<ATTLitigantPrisonDetails>();
            try
            {
                foreach (DataRow row in DLLLitigantPrisonDetails.GetLitigantPrisonDetails(caseID, litigantID).Rows)
                {
                    ATTLitigantPrisonDetails objLitPD = new ATTLitigantPrisonDetails();
                    objLitPD.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objLitPD.LitigantID = double.Parse(row["LITIGANT_ID"].ToString());
                    objLitPD.FromDate= row["FROM_DATE"].ToString();
                    objLitPD.ToDate = row["TO_DATE"].ToString();
                    objLitPD.PrisonPlace = row["PRISON_PLACE"].ToString();// == System.DBNull.Value ? 0 : int.Parse(row["LITIGANT_SUB_TYPE_ID"].ToString());
                    objLitPD.Action = "";

                    LitigantPrisonDetailLST.Add(objLitPD);

                }


                return LitigantPrisonDetailLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
