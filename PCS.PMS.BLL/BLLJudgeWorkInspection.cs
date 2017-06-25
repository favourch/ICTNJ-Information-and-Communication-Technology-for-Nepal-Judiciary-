using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLJudgeWorkInspection
    {
        public static ATTJudgeWorkInspection GetJudgeWorkInspection(int? empID, string fiscalYear)
        {
            try
            {
                DataTable dt = DLLJudgeWorkInspection.GetJudgeWorkInspection(empID, fiscalYear);
                if (dt.Rows.Count > 0)
                {
                    ATTJudgeWorkInspection obj = new ATTJudgeWorkInspection(int.Parse(dt.Rows[0]["EMP_ID"].ToString()), int.Parse(dt.Rows[0]["INSP_EMP_ID"].ToString()), dt.Rows[0]["FISCAL_YEAR"].ToString(), DateTime.Parse(dt.Rows[0]["INSP_DATE"].ToString()), "");

                    obj.EmployeeName = dt.Rows[0]["JUDGEFULLNAME"].ToString();
                    obj.InspEmpName = dt.Rows[0]["INSPFULLNAME"].ToString();
                    obj.Details = BLLJudgeWorkInspectionDetails.GetJudgeWorkInspectionDetails(empID, fiscalYear);
                    return obj;
                }
                return null;
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static bool SaveJudgeWorkInspection(ATTJudgeWorkInspection objWorkInspection)
        {
            try
            {
                return DLLJudgeWorkInspection.SaveJudgeWorkInspection(objWorkInspection);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
