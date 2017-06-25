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
    public class DLLEmployeeEvaluation
    {
        public static bool AddEmployeeEvaluation(ATTEmployeeEvaluation obj)
        {
            string InsertSQL="";

            if (obj.Action == "A")
                InsertSQL = "SP_ADD_EMPLOYEE_EVALUATION";
            else
                InsertSQL = "SP_EDIT_EMPLOYEE_EVALUATION";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_EMP_ID", obj.EmpID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_EVAL_FROM_DATE", obj.EvalFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_EVAL_TO_DATE", obj.EvalToDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_REG_NO", obj.RegistrationNo, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ORG_NAME", obj.Organization, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_SUBMITED_DATE", obj.SubmitedDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ENTRY_ON", obj.EntryOn, OracleDbType.Date, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_OLD_EVAL_FROM_DATE", obj.OldEvalFromDate, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            OracleTransaction Tran = DBConn.GetDbConn(Module.PMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertSQL, paramArray.ToArray());

                DLLEmployeeWork.AddEmployeeWork(obj.LstEmployeeWork, Tran);

                DLLEmployeeEvaluationDetail.AddEmployeeEvaluationDetail(obj.LstEvaluationDetail, Tran);

                DLLEmployeeEvaluator.AddEmployeeEvaluator(obj.LstEmployeeEvaluator, Tran);

                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static DataTable GetEmployeeEvaluation(double empID, string fromDate)
        {
            string SelectSP = "SP_GET_EMPLOYEE_EVALUATION";

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
        public static DataTable GetEmployeeTransferedOrg(double empID, string fromDate, string toDate)
        {
            string SelectSP = "SP_GET_EMP_TRANSFERED_ORG";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("p_emp_id", empID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_from_date", fromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_to_date", toDate, OracleDbType.Varchar2, ParameterDirection.Input));
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
