using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.COMMON.BLL;
using PCS.FRAMEWORK;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEmployeeEvaluationDetail
    {
        public static List<ATTEmployeeEvaluationDetail> GetEmployeeEvaluationDetail(double empID, string fromDate)
        {
            List<ATTEmployeeEvaluationDetail> detailLst = new List<ATTEmployeeEvaluationDetail>();
            try
            {
                DataTable tbl = DLLEmployeeEvaluationDetail.GetEmployeeEvaluationDetail(empID, fromDate);
                foreach (DataRow row in tbl.Rows)
                {
                    ATTEmployeeEvaluationDetail detail = new ATTEmployeeEvaluationDetail();

                    detail.EmpID = double.Parse(row["Emp_ID"].ToString());
                    detail.EvalFromDate = row["Eval_from_date"].ToString();
                    detail.EvaluationCriteriaID = int.Parse(row["eval_crit_id"].ToString());
                    detail.FromDate = row["from_date"].ToString();
                    detail.EvaluationGradeID = int.Parse(row["eval_grade_id"].ToString());
                    detail.EntryBy = row["entry_by"].ToString();
                    detail.EntryOn = DateTime.Parse(row["entry_on"].ToString());
                    detail.Action = "N";

                    detail.GroupName = row["EVAL_GROUP_NAME"].ToString();
                    detail.EvaluationCriteriaName = row["eval_crit_name"].ToString();
                    detail.EvaluationGradeName = row["eval_grade_name"].ToString();
                    
                    detailLst.Add(detail);
                }

                return detailLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
