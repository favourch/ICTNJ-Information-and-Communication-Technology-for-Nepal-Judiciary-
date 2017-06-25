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
    public class DLLCaseAccountForward
    {
        public static bool SaveCaseAccountForward(ATTCaseAccountForward attCAF)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            string InsertUpdateSQL = "SP_ADD_CASE_ACCOUNT_FWD";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", attCAF.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", attCAF.AccountTypeID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_TOTAL_AMOUNT", attCAF.TotalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_PAID", attCAF.Paid, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCAF.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveCaseAccountForward(List<ATTCaseAccountForward> lstCAF,OracleTransaction Tran,double ? caseID)
        {
            try
            {
                foreach (ATTCaseAccountForward attCAF in lstCAF)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID == null ? attCAF.CaseID : caseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", attCAF.AccountTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_TOTAL_AMOUNT", attCAF.TotalAmount, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_PAID", attCAF.Paid, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", attCAF.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    string InsertUpdateSQL="" ;
                    if (attCAF.Action=="A")
                    InsertUpdateSQL = "SP_ADD_CASE_ACCOUNT_FWD";
                    else if (attCAF.Action=="E")
                    InsertUpdateSQL = "SP_EDIT_CASE_ACCOUNT_FWD";



                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                }
             
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCaseAccountForward(double caseID,int ? accountTypeID,string paid)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            string SelectSQL = "SP_GET_CASE_ACCOUNT_FORWARD";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_TYPE_ID", accountTypeID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_PAID", paid, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.StoredProcedure, SelectSQL, paramArray.ToArray());
                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetUnPaidAmount(int courtID,string paid)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction  Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            string SelectSQL = "SP_GET_CASE_UNPAID_AMOUNT";
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":P_COURT_ID", courtID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_PAID", paid, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.StoredProcedure, SelectSQL, paramArray.ToArray());
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
