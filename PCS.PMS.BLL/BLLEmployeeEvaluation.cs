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
    public class BLLEmployeeEvaluation
    {
        public static ObjectValidation Validate(ATTEmployeeEvaluation obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.EvalFromDate.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Evaluation from date cannot be empty.";
                return result;
            }

            if (obj.EvalToDate.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Evaluation to date cannot be empty.";
                return result;
            }

            if (obj.RegistrationNo <= 0)
            {
                result.IsValid = false;
                result.ErrorMessage = "Registration NO cannot less then zero or equal to zero.";
                return result;
            }

            if (obj.Organization.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Organization name cannot be empty.";
                return result;
            }

            if (obj.SubmitedDate.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Submitted date cannot be empty.";
                return result;
            }

            return result;
        }

        public static bool AddEmployeeEvaluation(ATTEmployeeEvaluation obj)
        {
            try
            {
                return DLLEmployeeEvaluation.AddEmployeeEvaluation(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ATTEmployeeEvaluation GetEmployeeEvaluation(double empID, string fromDate)
        {
            ATTEmployeeEvaluation eval = null;
            try
            {
                DataTable tbl = DLLEmployeeEvaluation.GetEmployeeEvaluation(empID, fromDate);
                if (tbl.Rows.Count > 0)
                {
                    eval = new ATTEmployeeEvaluation();
                    
                    DataRow row = tbl.Rows[0];
                    
                    eval.EmpID = double.Parse(row["Emp_ID"].ToString());
                    eval.EvalFromDate = row["Eval_from_date"].ToString();
                    eval.OldEvalFromDate = row["Eval_from_date"].ToString();
                    eval.EvalToDate = row["Eval_to_date"].ToString();
                    eval.RegistrationNo = double.Parse(row["Registration_no"].ToString());
                    eval.Organization = row["Organization"].ToString();
                    eval.SubmitedDate = row["submited_date"].ToString();
                    eval.EntryBy = row["Entry_By"].ToString();
                    eval.EntryOn = DateTime.Parse(row["Entry_On"].ToString());
                    eval.Action = "E";

                    eval.LstEmployeeWork = BLLEmployeeWork.GetEmployeeWork(empID, fromDate);
                    eval.LstEvaluationDetail = BLLEmployeeEvaluationDetail.GetEmployeeEvaluationDetail(empID, fromDate);
                    eval.LstEmployeeEvaluator = BLLEmployeeEvaluator.GetEmployeeEvaluationList(empID, fromDate);
                }

                return eval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTEmployeeEvaluation> GetEmployeeEvaluationList(double empID, string fromDate)
        {
            ATTEmployeeEvaluation eval = null;
            List<ATTEmployeeEvaluation> lst = new List<ATTEmployeeEvaluation>();
            try
            {
                DataTable tbl = DLLEmployeeEvaluation.GetEmployeeEvaluation(empID, fromDate);
                foreach (DataRow  row in tbl.Rows)
                {
                    eval = new ATTEmployeeEvaluation();

                    eval.EmpID = double.Parse(row["Emp_ID"].ToString());
                    eval.EvalFromDate = row["Eval_from_date"].ToString();
                    eval.OldEvalFromDate = row["Eval_from_date"].ToString();
                    eval.EvalToDate = row["Eval_to_date"].ToString();
                    eval.RegistrationNo = double.Parse(row["Registration_no"].ToString());
                    eval.Organization = row["Organization"].ToString();
                    eval.SubmitedDate = row["submited_date"].ToString();
                    eval.EntryBy = row["Entry_By"].ToString();
                    eval.EntryOn = DateTime.Parse(row["Entry_On"].ToString());
                    eval.Action = "E";

                    lst.Add(eval);

                    //eval.LstEmployeeWork = BLLEmployeeWork.GetEmployeeWork(empID, fromDate);
                    //eval.LstEvaluationDetail = BLLEmployeeEvaluationDetail.GetEmployeeEvaluationDetail(empID, fromDate);
                    //eval.LstEmployeeEvaluator = BLLEmployeeEvaluator.GetEmployeeEvaluationList(empID, fromDate);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetEmployeeTransferedOrg(double empID, string fromDate, string toDate)
        {
            string orgList = "";
            try
            {
                DataTable tbl = DLLEmployeeEvaluation.GetEmployeeTransferedOrg(empID, fromDate, toDate);
                if (tbl == null || tbl.Rows.Count <= 0)
                    return orgList;
                else
                {
                    foreach (DataRow row in tbl.Rows)
                    {
                        orgList = orgList + row["org_name"].ToString() + ", ";
                    }
                    orgList = orgList.Remove(orgList.LastIndexOf(','));
                    return orgList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
