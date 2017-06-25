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
    public class DLLTameliType
    {
        public static DataTable GetTameliType(int? tameliTypeID, string active)
        {
            try
            {
                string SelectCaseTypeSql = "SP_GET_TAMELI_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":P_TAMELI_TYPE_ID", tameliTypeID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectCaseTypeSql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteTameliType(ATTTameliType tameliType)
        {
            string InsertUpdateDeleteSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            try
            {
                if (tameliType.Action == "A")
                    InsertUpdateDeleteSQL = "SP_ADD_TAMELI_TYPE";
                else if (tameliType.Action == "E")
                    InsertUpdateDeleteSQL = "SP_EDIT_TAMELI_TYPE";
                else if (tameliType.Action == "D")
                    InsertUpdateDeleteSQL = "SP_DEL_TAMELI_TYPE";

                OracleParameter[] ParamArray;
                if (tameliType.Action == "A" || tameliType.Action == "E")
                {
                    ParamArray = new OracleParameter[4];
                    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_TAMELI_TYPE_ID", tameliType.TameliTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_TAMELI_TYPE_NAME", tameliType.TameliTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", tameliType.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", tameliType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                    tameliType.TameliTypeID = int.Parse(ParamArray[0].Value.ToString());
                    tameliType.Action = "";





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
