using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.OAS.DLL
{
    public class DLLDocumentCategory
    {
        public static DataTable GetDocCategoryListTable(int? fileCatID)
        {

            string SelectSQL = "SP_GET_FILE_DOC_CATEGORY";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_FILE_CAT_ID", fileCatID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);

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
