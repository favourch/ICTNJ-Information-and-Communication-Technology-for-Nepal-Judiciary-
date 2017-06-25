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
    public class DLLCaseAccountDetails
    {
        public static bool SaveCaseAccountDetail(List<ATTCaseAccountDetails> lstCAD,OracleTransaction Tran)
        {
            string InsertUpdateSQL = "SP_ADD_CASE_ACCOUNT_DETAIL";

            try
            {
                foreach (ATTCaseAccountDetails attCAD in lstCAD)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAD.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_TRAN_DATE", attCAD.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_TRAN_SEQ", attCAD.TransactionSequence, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", attCAD.AccountTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_TOTAL_AMOUNT", attCAD.TotalAmount, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCAD.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_OLD_TRAN_DATE", null, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCaseAccountDetails(ATTCaseAccountDetails attCAD)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            string SelectSQL = "SP_GET_CASE_ACCOUNT_DETAIL";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAD.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_DATE", attCAD.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_SEQ", attCAD.TransactionSequence, OracleDbType.Int64, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", attCAD.AccountTypeID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

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
