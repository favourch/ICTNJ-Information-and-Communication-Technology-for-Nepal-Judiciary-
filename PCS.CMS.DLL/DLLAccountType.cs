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
   public class DLLAccountType
    {
        public static bool SaveAccountType(ATTAccountType objAccountType)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", objAccountType.AccountTypeID, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_NAME", objAccountType.AccountTypeName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objAccountType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objAccountType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
            if (objAccountType.Action == "A")
                InsertUpdateSQL = "SP_ADD_ACCOUNT_TYPE";
            else if (objAccountType.Action == "E")
                InsertUpdateSQL = "SP_EDIT_ACCOUNT_TYPE";
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                objAccountType.AccountTypeID = int.Parse(paramArray[0].Value.ToString());
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

        public static DataTable GetAccountType(int? AccountType, string active)
        {

            string SelectSql = "SP_GET_ACCOUNT_TYPE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", AccountType, OracleDbType.Int64, ParameterDirection.Input));
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
