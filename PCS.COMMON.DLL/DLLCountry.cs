using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.COMMON.DLL
{
    public class DLLCountry
    {
        public static DataTable GetCountries(int? countryId)
        {
            GetConnection GetCon = new GetConnection();
            OracleConnection DBConn;
            OracleCommand Cmd;

            try
            {
                DBConn = GetCon.GetDbConn();
                Cmd = new OracleCommand();
                string SelectSql = "SP_GET_COUNTRIES";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_CountryID", countryId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds=SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSql, ParamArray);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];

            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static int AddCountries(ATTCountry objCountries)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn().BeginTransaction();
            int CountryID = 0;
            try
            {
                string InsertUpdateSQL = "";

                if (objCountries.CountryId <= 0)
                    InsertUpdateSQL = "SP_ADD_COUNTRIES";
                else
                    InsertUpdateSQL = "SP_EDIT_COUNTRIES";

                OracleParameter[] ParamArray = new OracleParameter[4];

                ParamArray[0] = Utilities.GetOraParam(":p_COUNTRY_ID", objCountries.CountryId, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_COUNTRY_NEP_NAME", objCountries.CountryNepName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_COUNTRY_ENG_NAME", objCountries.CountryEngName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_COUNTRY_CODE", objCountries.CountryCode, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, ParamArray[0], ParamArray);
                CountryID = int.Parse(ParamArray[0].Value.ToString());
                Tran.Commit();

                return CountryID;
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
    }
}
