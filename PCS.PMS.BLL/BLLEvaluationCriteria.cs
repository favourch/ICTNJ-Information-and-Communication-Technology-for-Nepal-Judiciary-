using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using System.Data;

namespace PCS.PMS.BLL
{
    public class BLLEvaluationCriteria
    {

        public static ObjectValidation Validate(ATTEvaluationCriteria obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.EvaluationCriteriaName=="")
            {
                result.IsValid = false;
                result.ErrorMessage = "Criteria name cannot be empty.";
                return result;
            }

            if (obj.FromDate == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "From date cannot be empty.";
                return result;
            }

            if (obj.ToDate == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "To date cannot be empty.";
                return result;
            }

            if (obj.GroupID <= 0)
            {
                result.IsValid = false;
                result.ErrorMessage = "Evaluation group cannot be empty.";
                return result;
            }

            return result;
        }

        public static bool AddEvaluationCriteria(ATTEvaluationCriteria obj)
        {
            try
            {
                return DLLEvaluationCriteria.AddEvaluationCriteria(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEvaluationCriteria> GetEvaluationCriteriaList(int? grpID, Default defGrade,string active)
        {
            List<ATTEvaluationCriteria> lst = new List<ATTEvaluationCriteria>();
            try
            {
                List<ATTEvaluationCriteriaGrade> lstGrade = BLLEvaluationCriteriaGrade.GetEvaluationCriteriaGradeList("", active);

                foreach (DataRow row in DLLEvaluationCriteria.GetEvaluationCriteriaTable(grpID,active).Rows)
                {
                    ATTEvaluationCriteria obj = new ATTEvaluationCriteria();
                    
                    obj.EvaluationCriteriaID = int.Parse(row["Eval_crit_id"].ToString());
                    obj.FromDate = row["from_date"].ToString();
                    obj.GroupID = int.Parse(row["Eval_group_id"].ToString());
                    obj.EvaluationCriteriaName = row["eval_crit_name"].ToString();
                    obj.ToDate = row["to_date"].ToString();
                    obj.Active = row["active"].ToString();
                    obj.Action = "N";

                    obj.LstEvaluationCriteriaGrade = lstGrade.FindAll
                                                                    (
                                                                        delegate(ATTEvaluationCriteriaGrade grade)
                                                                        {
                                                                            return grade.EvaluationCriteriaID == obj.EvaluationCriteriaID
                                                                            && grade.FromDate == obj.FromDate;
                                                                        }
                                                                    );

                    if (defGrade == Default.Yes)
                    {
                        ATTEvaluationCriteriaGrade defaultGrade = new ATTEvaluationCriteriaGrade();
                        defaultGrade.EvaluationGradeName = "----- भार छन्नुहोस -----";

                        obj.LstEvaluationCriteriaGrade.Insert(0, defaultGrade);
                    }

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
