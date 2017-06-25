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
    public class DLLBenchType
    {
        public static bool SaveBenchType(ATTBenchType objBenchType)
        {
            string InsertUpdateSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                    paramArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", objBenchType.BenchTypeID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_NAME", objBenchType.BenchTypeName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objBenchType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objBenchType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (objBenchType.Action == "A")
                        InsertUpdateSQL = "SP_ADD_BENCH_TYPE";
                    else if (objBenchType.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_BENCH_TYPE";

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    objBenchType.BenchTypeID= int.Parse(paramArray[0].Value.ToString());
                    objBenchType.Action = "";



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

        public static DataTable GetBenchType(int? BenchTypeID, string active)
        {

            string SelectSql = "SP_GET_BENCH_TYPE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", BenchTypeID, OracleDbType.Int64, ParameterDirection.Input));
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
