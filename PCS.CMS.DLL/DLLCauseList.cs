using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLCauseList
    {
        public static bool SaveCauseList(ATTCauseList objCauseList)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_CL_ENTRY_TYPE_ID", objCauseList.CauseListID, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":P_CL_ENTRY_TYPE_NAME", objCauseList.CauseListName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objCauseList.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objCauseList.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
            
            if (objCauseList.Action == "A")
                InsertUpdateSQL = "SP_ADD_CL_ENTRY_TYPE";
            else if (objCauseList.Action == "E")
                InsertUpdateSQL = "SP_EDIT_CL_ENTRY_TYPE";
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                objCauseList.CauseListID = int.Parse(paramArray[0].Value.ToString());
                Tran.Commit();
                return true;
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }


        public static DataTable GetCauseList(int? CauseListID, string active)
        {

            string SelectSql = "SP_GET_CL_ENTRY_TYPE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CL_ENTRY_TYPE_ID",CauseListID , OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
