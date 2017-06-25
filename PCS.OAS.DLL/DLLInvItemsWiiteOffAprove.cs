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
    public class DLLInvItemsWiiteOffAprove
    {
        public static DataTable GetWriteOffDateDetails(int orgid, string WriteOffDate, string AppYesNo)
        {
            string SelectSQL = "SP_INV_GET_ITEMS_WRITEOFF";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgid, OracleDbType.Int32, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_WRITEOFF_DATE", WriteOffDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_APP_YES_NO", AppYesNo, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
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
