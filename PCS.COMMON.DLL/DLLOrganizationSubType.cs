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
    public class DLLOrganizationSubType
    {
        public static DataTable GetOrgSubType()
        {
            string SelectOrgSubTypeSQL = "SP_GET_ORG_SUB_TYPES";

            try
            {

                OracleParameter[] ParamArray = new OracleParameter[3];

                ParamArray[0] = Utilities.GetOraParam(":p_ORG_SUB_TYPE_CD", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_ORG_TYPE_CD", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectOrgSubTypeSQL, ParamArray);

                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
