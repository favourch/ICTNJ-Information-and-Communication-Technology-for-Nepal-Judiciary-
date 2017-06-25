using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.OAS.DLL
{
    public class DLLTippaniStatus
    {
        public static DataTable GetTippaniStatusTable()
        {
            string SP = "SP_GET_TIPPANI_STATUS";

            OracleParameter[] paramArray = new OracleParameter[1];
            paramArray[0] = Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetStatusList(int orgID, double empID, int subID)
        {
            string SP = "SP_GET_STATUS_LIST";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("p_emp_id", empID, OracleDbType.Double, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam("p_sub_id", subID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
