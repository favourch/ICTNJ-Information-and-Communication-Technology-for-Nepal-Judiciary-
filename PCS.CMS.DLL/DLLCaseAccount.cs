using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;
using System.Data;

namespace PCS.CMS.DLL
{
    public class DLLCaseAccount
    {
        public static bool SaveCaseAccount(ATTCaseAccount attCA)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            //OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            string InsertUpdateSQL = "";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_INVOICE_NO", attCA.InVoiceNumber, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCA.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", attCA.AccountTypeID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_DATE", attCA.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_AMOUNT", attCA.TransactionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REMARKS", attCA.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCA.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //if (attCA.Action == "A")
                    InsertUpdateSQL = "SP_ADD_CASE_ACCOUNT";
              //  else
                  //  InsertUpdateSQL = "SP_EDIT_CASE_ACCOUNT";
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCaseAccount(double caseID)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            string SelectSQL = "SP_GET_CASE_ACCOUNT";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RC",null, OracleDbType.RefCursor, ParameterDirection.Output));

                 DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray.ToArray());
                 DataTable tbl = new DataTable();
                 tbl = (DataTable)ds.Tables[0];
                 return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
