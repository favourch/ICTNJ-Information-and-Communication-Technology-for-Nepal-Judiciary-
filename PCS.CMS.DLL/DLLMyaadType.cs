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
    public class DLLMyaadType
    {
        public static DataTable GetMyaadType(int? myaadTypeID, string active)
        {
            try
            {
                string SelectCaseTypeSql = "SP_GET_MYAAD_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":P_MYAAD_TYPE_ID", myaadTypeID, OracleDbType.Int64, ParameterDirection.Input);
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

        public static bool AddEditDeleteMyaadType(ATTMyaadType myaadType)
        {
            string InsertUpdateDeleteSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            try
            {
                if (myaadType.Action == "A")
                    InsertUpdateDeleteSQL = "SP_ADD_MYAAD_TYPE";
                else if (myaadType.Action == "E")
                    InsertUpdateDeleteSQL = "SP_EDIT_MYAAD_TYPE";
                else if (myaadType.Action == "D")
                    InsertUpdateDeleteSQL = "SP_DEL_MYAAD_TYPE";

                OracleParameter[] ParamArray;
                if (myaadType.Action == "A" || myaadType.Action == "E")
                {
                    ParamArray = new OracleParameter[5];
                    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_MYAAD_TYPE_ID", myaadType.MyaadTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_MYAAD_TYPE_NAME", myaadType.MyaadTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                    //ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_MYAAD_ISSUE", myaadType.MyaadIssue, OracleDbType.Varchar2, ParameterDirection.Input);                   
                    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", myaadType.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", myaadType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                    myaadType.MyaadTypeID = int.Parse(ParamArray[0].Value.ToString());
                    myaadType.Action = "";





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
