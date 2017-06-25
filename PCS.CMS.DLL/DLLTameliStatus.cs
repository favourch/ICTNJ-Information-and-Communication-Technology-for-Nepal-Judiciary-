using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PCS.CMS.DLL
{
    public class DLLTameliStatus
    {
        public static DataTable GetTameliStatus(int? tameliStatusID, string active)
        {
            try
            {
                string SelectSql = "SP_GET_TAMELI_STATUS";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":P_TAMELI_STATUS_ID", tameliStatusID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteTameliStatus(ATTTameliStatus tameliStatus)
        {
            string InsertUpdateDeleteSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            try
            {
                if (tameliStatus.Action == "A")
                    InsertUpdateDeleteSQL = "SP_ADD_TAMELI_STATUS";
                else if (tameliStatus.Action == "E")
                    InsertUpdateDeleteSQL = "SP_EDIT_TAMELI_STATUS";
                else if (tameliStatus.Action == "D")
                    InsertUpdateDeleteSQL = "SP_DEL_TAMELI_STATUS";

                OracleParameter[] ParamArray;
                if (tameliStatus.Action == "A" || tameliStatus.Action == "E")
                {
                    ParamArray = new OracleParameter[4];
                    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_TAMELI_STATUS_ID", tameliStatus.TameliStatusID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_TAMELI_STATUS_NAME", tameliStatus.TameliStatusName, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", tameliStatus.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", tameliStatus.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                    tameliStatus.TameliStatusID = int.Parse(ParamArray[0].Value.ToString());
                    tameliStatus.Action = "";





                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
