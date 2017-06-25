using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.CMS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
namespace PCS.CMS.DLL
{
   public class DLLBenchFormation
    {
        public static bool SaveBenchFormation(ATTBenchFormation objBenchFormation)
        {
            string InsertUpdateSQL = "SP_ADD_BENCH_FORMATION";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objBenchFormation.OrgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", objBenchFormation.BenchTypeID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_BENCH_NO", objBenchFormation.BenchNo, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", objBenchFormation.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_SEQ_NO", objBenchFormation.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":P_TO_DATE", objBenchFormation.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objBenchFormation.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
        
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
              
                int seqNo = int.Parse(paramArray[4].Value.ToString());
                DLLBenchJudge.SaveBenchJudge(objBenchFormation.LstBenchJudge, Tran,seqNo);
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

        public static DataTable GetBenchFormation(int orgID)
        {

            string SelectSql = "SP_GET_BENCH_FORMATION";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
            
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));
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
       public static DataTable GetJudgeList(ATTBenchFormation objBenchFormation)
       {

           string SelectSql = "SP_GET_BENCH_JUDGE";
           List<OracleParameter> paramArray = new List<OracleParameter>();
           paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objBenchFormation.OrgID, OracleDbType.Int64, ParameterDirection.Input));
           paramArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", objBenchFormation.BenchTypeID, OracleDbType.Int64, ParameterDirection.Input));
           paramArray.Add(Utilities.GetOraParam(":P_BENCH_NO", objBenchFormation.BenchNo, OracleDbType.Int64, ParameterDirection.Input));
           paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", objBenchFormation.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
           paramArray.Add(Utilities.GetOraParam(":P_SEQ_NO", objBenchFormation.SeqNo, OracleDbType.Int64, ParameterDirection.Input));
           paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
           
           try
           {
               DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, paramArray.ToArray());
               return (DataTable)ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
