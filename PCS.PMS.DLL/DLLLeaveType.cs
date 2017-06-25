using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PCS.PMS.DLL
{
   public class DLLLeaveType
    {
        public static DataTable GetLeaveType(int? LeaveTypeId, string active)
        {
            try
            {
                string SelectLeaveTypeSql = "SP_GET_LEAVE_TYPES";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_LEAVE_TYPE_ID", LeaveTypeId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectLeaveTypeSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static bool SaveLeaveType(ATTLeaveType ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string InsertUpdateLeaveType = "";
            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();

                if (ObjAtt.LeaveTypeID == 0)
                    InsertUpdateLeaveType = "SP_ADD_LEAVE_TYPES";
                else
                    InsertUpdateLeaveType = "SP_EDIT_LEAVE_TYPES";

                OracleParameter[] ParamArray = new OracleParameter[4];

                ParamArray[0] = Utilities.GetOraParam(":p_LEAVE_TYPE_ID", ObjAtt.LeaveTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_LEAVE_TYPE_NAME", ObjAtt.LeaveTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_GENDER", ObjAtt.Gender, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_ACTIVE", ObjAtt.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateLeaveType, ParamArray);
                int LeaveTypeID = int.Parse(ParamArray[0].Value.ToString());
                ObjAtt.LeaveTypeID = LeaveTypeID;
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Conn.CloseDbConn();
            }
        }


       public static bool DeleteLeaveType(int LeaveTypeID)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string DeleteLeaveTypeSql = "SP_DEL_LEAVE_TYPES";

            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();
                OracleParameter[] ParamArray = new OracleParameter[1];
                ParamArray[0] = Utilities.GetOraParam(":p_LEAVE_TYPE_ID", LeaveTypeID, OracleDbType.Int64, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeleteLeaveTypeSql, ParamArray);
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }

    }
}
