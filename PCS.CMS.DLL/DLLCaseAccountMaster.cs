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
    public class DLLCaseAccountMaster
    {
        public static bool SaveCaseAccountMaster(ATTCaseAccountMaster attCAM)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            string InsertUpdateSQL = "SP_ADD_CASE_ACCOUNT_MASTER";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAM.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_DATE", attCAM.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_SEQ", attCAM.TransactionSequence, OracleDbType.Int64, ParameterDirection.InputOutput));
                if(attCAM.LitigantID==0)
                paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", null, OracleDbType.Double, ParameterDirection.Input));
                else
                paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", attCAM.LitigantID, OracleDbType.Double, ParameterDirection.Input));
                if (attCAM.AttorneyID == 0)
                    paramArray.Add(Utilities.GetOraParam(":P_ATTORNEY_ID", null, OracleDbType.Double, ParameterDirection.Input));
                else
                paramArray.Add(Utilities.GetOraParam(":P_ATTORNEY_ID", attCAM.AttorneyID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_REMARKS", attCAM.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCAM.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_OLD_TRAN_DATE",null, OracleDbType.Varchar2, ParameterDirection.Input));
                
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());

                DLLCaseAccountDetails.SaveCaseAccountDetail(attCAM.LstAccountDetails, Tran);
                DLLCaseAccountForward.SaveCaseAccountForward(attCAM.LstAccountForward, Tran, attCAM.CaseID);
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCaseAccountMaster(ATTCaseAccountMaster attCAM)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            string SelectSQL = "SP_GET_CASE_ACCOUNT_MASTER";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAM.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_DATE", attCAM.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TRAN_SEQ", attCAM.TransactionSequence, OracleDbType.Int64, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", attCAM.LitigantID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ATTORNEY_ID", attCAM.AttorneyID, OracleDbType.Double, ParameterDirection.Input));
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
