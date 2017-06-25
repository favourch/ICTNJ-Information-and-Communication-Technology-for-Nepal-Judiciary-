using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.DLPDS.DLL
{
    public class DLLFaculty
    {
        public static DataTable GetFacultyTable(int orgID,int facultyID)
        {
            string SelectSP = "SP_GET_FACULTY";

            OracleParameter[] paramArray = new OracleParameter[3];

            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            if (facultyID > 0)
                paramArray[1] = Utilities.GetOraParam(":p_FACULTY_ID", facultyID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[1] = Utilities.GetOraParam(":p_FACULTY_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[2].Value).GetDataReader();

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
