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
    public class DLLEmployeeLeave
    {
        public static DataTable GetEmployeeLeave(int? empID, string REQ_REC_APP)
        {
            try
            {
                GetConnection conn = new GetConnection();
                OracleConnection obj = conn.GetDbConn(Module.PMS);
                string GetLeaveTypeEmployeeSQL = "" ;
                if (REQ_REC_APP == "REQ")
                {
                    GetLeaveTypeEmployeeSQL = "SP_GET_EMP_LEAVE_REQ";
                }
                else if (REQ_REC_APP == "REC")
                {
                    GetLeaveTypeEmployeeSQL = "SP_GET_EMP_LEAVE_REC";
                }
                else if (REQ_REC_APP == "APP")
                {
                    GetLeaveTypeEmployeeSQL = "SP_GET_EMP_LEAVE_APP";
                }
                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":P_EMP_ID", empID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.StoredProcedure, GetLeaveTypeEmployeeSQL, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public static DataTable GetEmpDesLeave(int eid)
        {
            try
            {
                GetConnection conn = new GetConnection();
                OracleConnection obj = conn.GetDbConn(Module.PMS);
                string GetEmpDesLeaveSQL = "SP_GET_EMP_DES_LEAVE" ;
                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":P_EMP_ID", eid, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(obj, CommandType.StoredProcedure, GetEmpDesLeaveSQL, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static bool SaveEmpLeaveApplication(List<ATTEmployeeLeave> LSTEmpLeave)
        {
            OracleTransaction Tran;
            GetConnection conn = new GetConnection();
            OracleConnection DBConn = conn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();
            try
            {
                string InsertUpdateDLSP = "";
                foreach (ATTEmployeeLeave var in LSTEmpLeave)
                {
                    if (var.Action == "A")
                    {
                        InsertUpdateDLSP = "SP_ADD_LEAVE_APPL_EMP";
                    }
                    else if (var.Action == "E")
                    {
                        InsertUpdateDLSP = "SP_EDIT_LEAVE_APPL_EMP";
                    }
                    else if (var.Action == "D")
                    {
                        InsertUpdateDLSP = "SP_DEL_LEAVE_APPL_EMP";
                    }
                    if (var.Action == "A" || var.Action == "E" || var.Action == "D")
                    {
                        OracleParameter[] paramArray = new OracleParameter[22];

                        paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", var.EmpID, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_APPL_DATE", var.ApplDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_LEAVE_TYPE_ID", var.LeaveTypeID, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":P_REQ_FROM_DATE", var.ReqdFrom, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_REQ_TO_DATE", var.ReqdTo, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_REQ_NO_OF_DAYS", var.EmpDays, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_REQ_REASON", var.EmpReason, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":P_REC_BY", var.RecByID, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":P_REC_DATE", var.RecDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam(":P_REC_FROM_DATE", var.RecFrom, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":P_REC_TO_DATE", var.RecTo, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[11] = Utilities.GetOraParam(":P_REC_NO_OF_DAYS", var.RecDays, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[12] = Utilities.GetOraParam(":P_REC_YES_NO", var.Recommended, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[13] = Utilities.GetOraParam(":P_REC_REASON", var.RecReason, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[14] = Utilities.GetOraParam(":P_APP_BY", var.AppByID, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[15] = Utilities.GetOraParam(":P_APP_DATE", var.AppDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[16] = Utilities.GetOraParam(":P_APP_FROM_DATE", var.AppFrom, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[17] = Utilities.GetOraParam(":P_APP_TO_DATE", var.AppTo, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[18] = Utilities.GetOraParam(":P_APP_NO_OF_DAYS", var.AppDays, OracleDbType.Int32, ParameterDirection.Input);
                        paramArray[19] = Utilities.GetOraParam(":P_APP_YES_NO", var.Approved, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[20] = Utilities.GetOraParam(":P_APP_REASON", var.AppReason, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[21] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDLSP, paramArray);
                    }
                }                    
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;

            }
            Tran.Commit();
            return true;
        }
    }
}