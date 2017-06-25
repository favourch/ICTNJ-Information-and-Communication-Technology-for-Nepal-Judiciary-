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
    public class DLLDistrict
    {
        public static DataTable GetDistricts(int? distCode)
        {
            GetConnection GetCon = new GetConnection();

            try
            {
                string SelectSql = "SP_GET_DISTRICTS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":DistCode", distCode, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

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
    }
}
