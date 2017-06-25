using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEvaluationCriteriaGrade
    {
        public static List<ATTEvaluationCriteriaGrade> GetEvaluationCriteriaGradeList(string fromDate, string Active)
        {
            List<ATTEvaluationCriteriaGrade> lst = new List<ATTEvaluationCriteriaGrade>();

            try
            {
                foreach (DataRow row in DLLEvaluationCriteriaGrade.GetEvaluationCriteriaGradeTable(fromDate,Active).Rows)
                {
                    ATTEvaluationCriteriaGrade obj = new ATTEvaluationCriteriaGrade();
                    obj.EvaluationCriteriaID = int.Parse(row["Eval_crit_id"].ToString());
                    obj.FromDate = row["from_date"].ToString();
                    obj.EvaluationGradeID = int.Parse(row["Eval_grade_id"].ToString());
                    obj.EvaluationGradeName = row["eval_grade_name"].ToString();
                    obj.TotalWeight = float.Parse(row["total_weight"].ToString());
                    obj.Active = row["active"].ToString();
                    obj.Action = "N";

                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

