using System;
using System.Collections.Generic;
using System.Text;

using PCS.SECURITY.ATT;
using Oracle.DataAccess.Client;
using PCS.COREDL;
using System.Data;
using PCS.FRAMEWORK;

namespace PCS.SECURITY.DLL
{
    public class DLLApplication
    {
        public static DataTable GetApplicationTable()
        {
            string SelectSQL = "SP_GET_APPLICATIONS";
            
            List<OracleParameter> paramArray = new List<OracleParameter>();
            
            paramArray.Add(Utilities.GetOraParam(":p_APPL_ID", null, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

            try
            {
                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, paramArray.ToArray()).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetUserApplicationTable(string username)
        {
            string SelectSQL = "SP_GET_USER_APPLICATION";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam(":p_user_name", username, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, paramArray.ToArray()).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddApplication(ATTApplication Applicationobj)
        {
            string InsertAppSQL = "";
            InsertAppSQL = "SP_ADD_APPLICATIONS";

            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran;

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn();
                Tran = DBConn.BeginTransaction();

                OracleParameter[] paramArray = new OracleParameter[4];

                paramArray[0] = Utilities.GetOraParam(":p_APPL_ID", Applicationobj.ApplicationID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":p_DESCRIPTION", Applicationobj.ApplicationDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_APPL_FULL_NAME", Applicationobj.ApplicationFullName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_APPL_SHORT_NAME", Applicationobj.ApplicationShortName, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertAppSQL, paramArray[0], paramArray);
                double applicationID = double.Parse(paramArray[0].Value.ToString());
                Tran.Commit();
                return true;
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
