using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;

using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.CMS.DLL
{
    public class DLLCourtFee
    {
        public static bool SaveCourtFee(List<ATTCourtFee> CourtFeeLST)
        {
            string InsertUpdateSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {

                foreach (ATTCourtFee objCourtFee in CourtFeeLST)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", null, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_FROM_AMOUNT", objCourtFee.FromAmount, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_TO_AMOUNT", objCourtFee.ToAmount, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_AMT_PER", objCourtFee.AmtPer, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_AMT_PER_TYPE", objCourtFee.AmtPerType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objCourtFee.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));


                    //if (objBenchType.Action == "A")
                        InsertUpdateSQL = "SP_ADD_COURT_FEE";
                    //else if (objBenchType.Action == "E")
                    //    InsertUpdateSQL = "SP_EDIT_BENCH_TYPE";

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    //objBenchType.BenchTypeID = int.Parse(paramArray[0].Value.ToString());
                    //objBenchType.Action = "";

                    paramArray.Clear();
                }
             
                


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

        public static DataTable GetCourtFee()
        {

            string SelectSql = "SP_GET_COURT_FEE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
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
