using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLSubmissionDetails
    {
        public static bool SaveSubmissionDetails(ATTSubmissionDetails objSD)
        {
            GetConnection Conn = new GetConnection();
            try
            {
                string SaveSQL = "SP_ADD_SUBMISSIONDETAILS";
                
                //OracleConnection DBConn = Conn.GetDbConn("PMS_ADMIN", "PMS_ADMIN");
                OracleConnection DBConn = Conn.GetDbConn(Module.PMS);
                OracleParameter[] paramArray = new OracleParameter[4];
                paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", objSD.EmpID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_SUB_DATE", objSD.SubmissionDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_SUB_OFFICE", objSD.SubmissionOffice, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam("::p_SUB_OFFICE_PLACE", objSD.SubmissionPlace, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SaveSQL, paramArray);
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
