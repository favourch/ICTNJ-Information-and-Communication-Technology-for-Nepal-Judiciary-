using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.PMS.DLL
{
    public class DLLAttendance
    {
        public static DataTable GetEmpAttendance(int orgid,int desid,string yearmonth)
        {
            GetConnection conn = new GetConnection();
            OracleConnection obj = conn.GetDbConn(Module.PMS);
            string SelectSP = "SP_GET_EMP_ATTENDANCE";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", orgid, OracleDbType.Int32, ParameterDirection.Input));
            if (desid == 0)
            {
                paramArray.Add(Utilities.GetOraParam("P_DES_ID", null, OracleDbType.Int32, ParameterDirection.Input));
            }
            else if (desid > 0)
            {
                paramArray.Add(Utilities.GetOraParam("P_DES_ID", desid, OracleDbType.Int32, ParameterDirection.Input));
            }
            paramArray.Add(Utilities.GetOraParam("P_YEARMONTH", yearmonth, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
