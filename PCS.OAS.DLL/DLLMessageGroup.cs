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
    public class DLLMessageGroup
    {
        public static DataTable GetGroupListTable(int? orgID,string type,string searchValue)
        {
            string selectSQL = "SP_GET_GROUP";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_SEARCH_VALUE",searchValue.Trim(), OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_TYPE",type.Trim(), OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure,selectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

                return tbl;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
