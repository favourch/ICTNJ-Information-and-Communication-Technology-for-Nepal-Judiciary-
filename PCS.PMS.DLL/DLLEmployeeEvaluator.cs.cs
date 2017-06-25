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
    public class DLLEmployeeEvaluator
    {
        public static bool AddEmployeeEvaluator(List<ATTEmployeeEvaluator> lst, OracleTransaction Tran)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTEmployeeEvaluator evaluator in lst)
                {
                    if (evaluator.Action == "A")
                        SP = "SP_ADD_EVALUATOR";
                    else if (evaluator.Action == "D")
                        SP = "SP_DEL_EMPLOYEE_EVALUATOR";

                    if (evaluator.Action != "N")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", evaluator.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EVAL_FROM_DATE", evaluator.EvalFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_EVAL_GRP_ID", evaluator.GroupID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PERSON_ID", evaluator.PersonID, OracleDbType.Double, ParameterDirection.Input));
                        if (evaluator.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("P_DESIGNATION", evaluator.Designation, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_SYMBOL_NO", evaluator.SymbolNo, OracleDbType.Double, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_DATE", evaluator.Date, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_REMARK", evaluator.Remark, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", evaluator.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("P_ENTRY_ON", evaluator.EntryOn, OracleDbType.Date, ParameterDirection.Input));
                        }

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        if (evaluator.Action == "A")
                            evaluator.Action = "N";
                        else if (evaluator.Action == "D")
                            evaluator.Action = "D";
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

        public static DataTable GetEmployeeEvaluator(double empID, string fromDate)
        {
            string SelectSP = "SP_GET_EMPLOYEE_EVALUATOR";

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
