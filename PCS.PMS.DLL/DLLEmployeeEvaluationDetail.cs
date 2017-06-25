using System;
using System.Collections.Generic;
using System.Text;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeEvaluationDetail
    {
        public static bool AddEmployeeEvaluationDetail(List<ATTEmployeeEvaluationDetail> lst, OracleTransaction Tran)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTEmployeeEvaluationDetail detail in lst)
                {
                    if (detail.Action == "A")
                        SP = "SP_ADD_EVAL_DETAIL";
                    else if (detail.Action == "D")
                        SP = "SP_DEL_EVALUATION_DETAIL";

                    if (detail.Action != "N")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", detail.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EVAL_FROM_DATE", detail.EvalFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EVAL_CRIT_ID", detail.EvaluationCriteriaID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", detail.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EVAL_GRADE_ID", detail.EvaluationGradeID, OracleDbType.Int64, ParameterDirection.Input));
                        if (detail.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", detail.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_ON", detail.EntryOn, OracleDbType.Date, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        if (detail.Action == "A")
                            detail.Action = "N";
                        else if (detail.Action == "D")
                            detail.Action = "D";
                        paramArray.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmployeeEvaluationDetail(double empID, string fromDate)
        {
            string SelectSP = "SP_GET_EMPLOYEE_EVAL_DETAIL";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("p_emp_id", empID, OracleDbType.Double, ParameterDirection.Input));

            if (fromDate == "")
                paramArray.Add(Utilities.GetOraParam("p_eval_from_date", null, OracleDbType.Double, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam("p_eval_from_date", fromDate, OracleDbType.Varchar2, ParameterDirection.Input));

            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
