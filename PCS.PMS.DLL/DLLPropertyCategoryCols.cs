using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;

namespace PCS.PMS.DLL
{
    public class DLLPropertyCategoryCols
    {
        public static DataTable GetPropertyCateogryColListTable(int? pCatID)
        {
            try
            {

                string SelectSQL = "SP_GET_PROPERTY_CATEGORY_COL";

                OracleParameter[] paramArray = new OracleParameter[2];
                paramArray[0] = Utilities.GetOraParam(":p_PCAT_ID", pCatID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);


               // DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, "PMS_ADMIN", "PMS_ADMIN", paramArray);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.PMS, paramArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool SavePropertyCategoryCols(List<ATTPropertyCategoryColumns> lstPCCols)
        {
            GetConnection Conn = new GetConnection();

            try
            {
                string SaveSQL = "SP_ADD_PROPERTY_CAT_COL";
                OracleConnection DBConn = Conn.GetDbConn(Module.PMS);

                foreach (ATTPropertyCategoryColumns objPCCols in lstPCCols)
                {

                    OracleParameter[] paramArray = new OracleParameter[5];
                    paramArray[0] = Utilities.GetOraParam(":P_PCAT_ID ", objPCCols.PCategoryID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[1] = Utilities.GetOraParam(":P_COL_NAME ", objPCCols.ColName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_COL_NO ",objPCCols.ColNo, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":P_COL_DATA_TYPE ",objPCCols.ColDataType, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":P_ACTIVE ",objPCCols.Active, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SaveSQL, paramArray);

                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }
    }
}
