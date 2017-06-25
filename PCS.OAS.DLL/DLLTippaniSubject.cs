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
    public class DLLTippaniSubject
    {
        public static DataTable GetTippaniSubjectList(int orgID)
        {
            string SelectSQL = "SP_GET_TIPPANI_SUBJECT";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.OAS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
