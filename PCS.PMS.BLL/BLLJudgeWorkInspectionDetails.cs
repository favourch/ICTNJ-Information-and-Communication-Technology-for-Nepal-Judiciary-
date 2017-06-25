using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLJudgeWorkInspectionDetails
    {
        public static List<ATTJudgeWorkInspectionDetails> GetJudgeWorkInspectionDetails(int? empId, string fiscalYear)
        {
            List<ATTJudgeWorkInspectionDetails> LstJudgeWorkInspectionDetails = new List<ATTJudgeWorkInspectionDetails>();

            try
            {


                foreach (DataRow row in DLLJudgeWorkInspectionDetails.GetJudgeWorkInspectionDetails(empId, fiscalYear).Rows)
                {

                    ATTJudgeWorkInspectionDetails ObjJudgeWorkInspectionDetails = new ATTJudgeWorkInspectionDetails();
                    ObjJudgeWorkInspectionDetails.EmployeeID = int.Parse(row["EMP_ID"].ToString());
                    ObjJudgeWorkInspectionDetails.FiscalYear = row["FISCAL_YEAR"].ToString();
                    ObjJudgeWorkInspectionDetails.JwcID = int.Parse(row["JWC_ID"].ToString());
                    ObjJudgeWorkInspectionDetails.WorkDone = (row["WORKDONE"].ToString() == "Y") ? true : false;
                    ObjJudgeWorkInspectionDetails.NoOfCase = (row["NOOFCASE"].ToString() == "" ? 0 : int.Parse(row["NOOFCASE"].ToString()));

                    ObjJudgeWorkInspectionDetails.NoDoneReason = (row["NODONE_REASON"] == DBNull.Value) ? "" : row["NODONE_REASON"].ToString();
                    ObjJudgeWorkInspectionDetails.IsReasonValid = (row["ISREASONVAILID"].ToString() == "Y") ? true : false;
                    ObjJudgeWorkInspectionDetails.Remarks = (row["REMARKS"] == DBNull.Value) ? "" : row["REMARKS"].ToString();
                    ObjJudgeWorkInspectionDetails.InspectionCaseNo = (row["INSP_CASENO"].ToString() == "" ? 0 : int.Parse(row["INSP_CASENO"].ToString()));
                    //ObjJudgeWorkInspectionDetails.Action = "";
                    ObjJudgeWorkInspectionDetails.EntryBy = "";
                    ObjJudgeWorkInspectionDetails.JwcName = row["JWC_NAME"].ToString();

                    LstJudgeWorkInspectionDetails.Add(ObjJudgeWorkInspectionDetails);
                }
                return LstJudgeWorkInspectionDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //public static bool SaveJudgeWorkInspectionDetails(List<ATTJudgeWorkInspectionDetails> WorkInspectionDetailsList)
        //{
        //    try
        //    {
        //        return DLLJudgeWorkInspectionDetails.SaveJudgeWorkInspectionDetails(WorkInspectionDetailsList);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
