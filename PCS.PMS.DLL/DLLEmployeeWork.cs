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
    public class DLLEmployeeWork
    {
        public static bool AddEmployeeWork(List<ATTEmployeeWork> Lst, OracleTransaction Tran)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTEmployeeWork work in Lst)
                {
                    if (work.Action == "A")
                        SP = "SP_ADD_EMPLOYEE_WORK";
                    else if (work.Action == "E")
                        SP = "SP_EDIT_EMPLOYEE_WORK";

                    if (work.Action != "N")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", work.EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", work.EvalFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_WORK_ID", work.WorkID, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("P_WORK_DESC", work.WorkDescription, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_UNIT", work.Unit, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_HALF_YEAR_TARGET", work.HalfYearTarget, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_FULL_YEAR_TARGET", work.FullYearTarget, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_WORK_PROGRESS", work.WorkProgress, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_A_B_OFFICE", work.AssignByOffice, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_REMARK", work.Remark, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", work.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_ON", work.EntryOn, OracleDbType.Date, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        work.WorkID = int.Parse(paramArray[2].Value.ToString());
                        work.Action = "N";
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

        public static DataTable GetEmployeeWork(double empID, string fromDate)
        {
            string SelectSP = "SP_GET_EMPLOYEE_WORK";

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
