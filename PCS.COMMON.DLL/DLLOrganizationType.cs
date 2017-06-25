using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.DLL
{
    public class DLLOrganizationType
    {
        public static DataTable GetOrgType()
        {
            string SelectOrgTypeSQL = "SP_GET_ORG_TYPES";

            try
            {
                OracleParameter[] ParamArray = new OracleParameter[2];

                ParamArray[0] = Utilities.GetOraParam(":p_ORG_TYPE_CD", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectOrgTypeSQL, ParamArray);

                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
