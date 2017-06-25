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
    public class DLLOrganisationBenchType
    {
        public static bool SaveOrganisationBenchType(List<ATTOrganisationBenchType> OrgBenchTypeLST)
        {
            string InsertUpdateSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                foreach (ATTOrganisationBenchType OrgBenchType in OrgBenchTypeLST)
                {
                    if (OrgBenchType.Action == "A") InsertUpdateSQL = "SP_ADD_ORG_BENCH_TYPE";
                    else if (OrgBenchType.Action == "E") InsertUpdateSQL = "SP_EDIT_ORG_BENCH_TYPE";
                    else if (OrgBenchType.Action == "D") InsertUpdateSQL = "SP_DEL_ORG_BENCH_TYPE";

                    if (OrgBenchType.Action == "A" || OrgBenchType.Action == "E")
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", OrgBenchType.OrganisationID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", OrgBenchType.BenchTypeID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", OrgBenchType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", OrgBenchType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                    else if (OrgBenchType.Action == "D")
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", OrgBenchType.OrganisationID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", OrgBenchType.BenchTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    }
                    if (OrgBenchType.Action != "")
                    {
                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    }
                    paramArray.Clear();
                }
                Tran.Commit();

                foreach (ATTOrganisationBenchType OrgBenchType in OrgBenchTypeLST)
                {
                    OrgBenchType.Action = "";
                }

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

        public static DataTable GetOrganisationBenchType(int? OrgID, int? BenchTypeID, string Active)
        {
            string SelectSql = "SP_GET_ORG_BENCH_TYPE";

            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", OrgID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_BENCH_TYPE_ID", BenchTypeID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", Active, OracleDbType.Varchar2, ParameterDirection.Input));
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
