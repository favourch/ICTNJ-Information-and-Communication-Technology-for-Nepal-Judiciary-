using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.LJMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LJMS.DLL
{
    public class DLLLawyerType
    {


        public static DataTable GetLawyerTypeListTable(int? ltID)
        {
            string SP = "SP_GET_LAWYER_TYPES ";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_LAWYER_TYPE_ID", ltID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ACTIVE", "", OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
