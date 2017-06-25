using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.DLPDS.DLL
{
    public class DLLDurationType
    {

        public static DataTable GetDurationTypeTable(int durationID)
        {
            string SelectSP = "SP_GET_DURATION_TYPE";

            OracleParameter[] paramArray = new OracleParameter[2];
            if (durationID > 0)
                paramArray[0] = Utilities.GetOraParam(":p_DURATION_TYPE_ID", durationID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[0] = Utilities.GetOraParam(":p_DURATON_TYPE_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[1].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
