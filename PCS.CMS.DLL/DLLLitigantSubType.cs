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
    public class DLLLitigantSubType
    {
        public static DataTable GetLitigantSubType(int? litigantSubTypeID, string active)
        {
            try
            {
                string SelectSql = "SP_GET_LITIGANT_SUB_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":P_LITIGANT_SUB_TYPE_ID", litigantSubTypeID, OracleDbType.Int64, ParameterDirection.Input);
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

        public static bool AddEditDeleteLitigantSubType(ATTLitigantSubType litigantSubType)
        {
            string InsertUpdateDeleteSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            try
            {
                if (litigantSubType.Action == "A")
                    InsertUpdateDeleteSQL = "SP_ADD_LITIGANT_SUB_TYPE";
                else if (litigantSubType.Action == "E")
                    InsertUpdateDeleteSQL = "SP_EDIT_LITIGANT_SUB_TYPE";
                else if (litigantSubType.Action == "D")
                    InsertUpdateDeleteSQL = "SP_DEL_LITIGANT_SUB_TYPE";

                OracleParameter[] ParamArray;
                if (litigantSubType.Action == "A" || litigantSubType.Action == "E")
                {
                    ParamArray = new OracleParameter[4];
                    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_SUB_TYPE_ID", litigantSubType.LitigantSubTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_SUB_TYPE_NAME", litigantSubType.LitigantSubTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", litigantSubType.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", litigantSubType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                    litigantSubType.LitigantSubTypeID = int.Parse(ParamArray[0].Value.ToString());
                    litigantSubType.Action = "";





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
