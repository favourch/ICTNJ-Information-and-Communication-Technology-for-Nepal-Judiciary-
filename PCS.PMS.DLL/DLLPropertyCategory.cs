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
    public class DLLPropertyCategory
    {
            public static DataTable GetDocCategoryListTable(int? pCatID)
            {
                try
                {

                    string SelectSQL = "SP_GET_PROPERTY_CATEGORY";

                    OracleParameter[] paramArray = new OracleParameter[2];
                    paramArray[0] = Utilities.GetOraParam(":p_PCAT_ID", pCatID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);


                    //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, "PMS_ADMIN", "PMS_ADMIN", paramArray);
                    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.PMS, paramArray);
                    return (DataTable)ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                         
        }

        public static bool SavePropertyCategory(List<ATTPropertyCategory> lstPCC)
        {
            GetConnection Conn = new GetConnection();
         
            try
            {
                string SaveSQL = "SP_ADD_PROPERTY_CATEGORY";
                OracleConnection DBConn = Conn.GetDbConn(Module.PMS);

                foreach (ATTPropertyCategory objPCC in lstPCC)
                {

                    OracleParameter[] paramArray = new OracleParameter[7];
                    paramArray[0] = Utilities.GetOraParam(":p_CAT_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[1] = Utilities.GetOraParam(":p_CAT_NAME", objPCC.PCategoryName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_NO_OF_COLS", objPCC.NoOfCols, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":p_ACTIVE", objPCC.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_INCOME", objPCC.Income, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_TYPE", objPCC.Type, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":p_MASTERTYPE", int.Parse(objPCC.MasterType), OracleDbType.Int64, ParameterDirection.Input);

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
