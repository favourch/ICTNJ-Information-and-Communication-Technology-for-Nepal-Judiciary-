using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeLeaveApprove
    {
        public static bool LeaveApprove(ATTEmployeeLeave var)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();
            try
            {
                string InsertUpdateDLSP = "SP_LEAVE_APPROVE";
                OracleParameter[] paramArray = new OracleParameter[16];
                paramArray[0] = Utilities.GetOraParam("P_IS_OTHERS", null, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_EMP_ID", var.EmpID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_LEAVE_TYPE_ID", var.LeaveTypeID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":P_APPL_DATE", var.ApplDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":P_APP_BY", var.AppByID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":P_APP_DATE", var.AppDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":P_APP_FROM_DATE", var.AppFrom, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":P_APP_TO_DATE", var.AppTo, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":P_APP_NO_OF_DAYS", var.AppDays, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[9] = Utilities.GetOraParam(":P_APP_YES_NO", var.Approved, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":P_APP_REASON", var.AppReason, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[11] = Utilities.GetOraParam(":P_LEAVE_FY", null, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[12] = Utilities.GetOraParam("P_LEAVE_PERIOD_UNIT", null, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[13] = Utilities.GetOraParam("P_PERIOD_TYPE", null, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[14] = Utilities.GetOraParam("P_PERIOD_COUNT", null, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[15] = Utilities.GetOraParam("P_LEAVE_TAKEN_CNT", null, OracleDbType.Int32, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDLSP, paramArray);
                Tran.Commit();
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                DBConn.Close();
            }

            return true;

        }

        public static DataTable LeaveCheck(ATTEmployeeLeave var)
        {
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            string InsertUpdateDLSP = "SP_LEAVE_CHECK";
            try
            {
                DataTable dt = new DataTable();
                //foreach (ATTEmployeeLeave var in lstEmpLeave)
                //{
                OracleParameter[] paramArray = new OracleParameter[9];
                paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", var.EmpID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam("P_FROM_DATE", var.AppFrom, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam("P_TO_DATE", var.AppTo, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam("P_NO_OF_DAYS", var.AppDays, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam("P_LEAVE_TYPE_ID", var.LeaveTypeID, OracleDbType.Int32, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam("P_OUT_MSG", null, OracleDbType.Varchar2, ParameterDirection.Output);
                paramArray[5].Size = 100;
                paramArray[6] = Utilities.GetOraParam("P_PERIOD_TYPE", null, OracleDbType.Varchar2, ParameterDirection.Output);
                paramArray[6].Size = 1;
                paramArray[7] = Utilities.GetOraParam("P_PERIOD_COUNT", null, OracleDbType.Int32, ParameterDirection.Output);
                paramArray[8] = Utilities.GetOraParam("P_FY", null, OracleDbType.Varchar2, ParameterDirection.Output);
                paramArray[8].Size = 5;

                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, InsertUpdateDLSP, paramArray);

                string out_msg = paramArray[5].Value.ToString();
                string period_type = paramArray[6].Value.ToString();
                int period_count = int.Parse(paramArray[7].Value.ToString());
                string p_fy = paramArray[8].ToString();

                //making a datatable for the above variables
                dt.Columns.Add(new DataColumn("Out_Message"));
                dt.Columns.Add(new DataColumn("Period_Type"));
                dt.Columns.Add(new DataColumn("Period_Count"));
                dt.Columns.Add(new DataColumn("Fiscal_Year"));

                DataRow drw = dt.NewRow();

                drw["Out_Message"] = out_msg;
                drw["Period_Type"] = period_type;
                drw["Period_Count"] = period_count;
                drw["Fiscal_Year"] = p_fy;
                dt.Rows.Add(drw);
                //dt = (DataTable)ds.Tables[0];
                //}
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetApprovedLeaves(string fromdate, string todate,int orgid,int desid)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string selectCmd = "SP_GET_EMPLOYEE_LEAVE";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", fromdate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TO_DATE", todate, OracleDbType.Varchar2, ParameterDirection.Input));
            if (orgid > 0)
            {
                paramArray.Add(Utilities.GetOraParam("P_ORG_ID", orgid, OracleDbType.Int32, ParameterDirection.Input));
            }
            else if (orgid == 0)
            {
                paramArray.Add(Utilities.GetOraParam("P_ORG_ID", null, OracleDbType.Int32, ParameterDirection.Input));
            }
            if (desid >0)
            {
                paramArray.Add(Utilities.GetOraParam("P_DES_ID", orgid, OracleDbType.Int32, ParameterDirection.Input));
            }
            else if (desid == 0)
            {
                paramArray.Add(Utilities.GetOraParam("P_DES_ID", null, OracleDbType.Int32, ParameterDirection.Input));
            }
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectCmd, Module.PMS, paramArray.ToArray()).Tables[0];
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
