using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;

using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLPesiType
    {
        public static bool SavePesiType(ATTPesiType objPesiType)
        {
            string InsertUpdateSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                paramArray.Add(Utilities.GetOraParam(":P_PESI_TYPE_ID", objPesiType.PesiTypeID, OracleDbType.Int64, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam(":P_PESI_TYPE_NAME", objPesiType.PesiTypeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objPesiType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objPesiType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                if (objPesiType.Action == "A")
                    InsertUpdateSQL = "SP_ADD_BENCH_TYPE";
                else if (objPesiType.Action == "E")
                    InsertUpdateSQL = "SP_EDIT_BENCH_TYPE";

                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                objPesiType.PesiTypeID = int.Parse(paramArray[0].Value.ToString());
                objPesiType.Action = "";



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

        public static DataTable GetPesiType(int? PesiTypeID, string active)
        {

            string SelectSql = "SP_GET_PESI_TYPE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_PESI_TYPE_ID", PesiTypeID, OracleDbType.Int64, ParameterDirection.Input));
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
