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
    public class DLLSession
    {
        public static DataTable GetSessionTable(int orgID, int programID,int sessionID)
        {
            string SelectSP = "SP_GET_SESSION";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", programID, OracleDbType.Int64, ParameterDirection.Input);

            if (sessionID > 0)
                paramArray[2] = Utilities.GetOraParam(":p_SESSION_ID", sessionID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[2] = Utilities.GetOraParam(":p_SESSION_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

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


        public static bool AddSession(List<ATTSession> LSTSession,int programID, OracleTransaction Tran)
        {
            string InsertUpdateSP = "";

            foreach (ATTSession objSession in LSTSession)
            {
                if (objSession.Action == "A")
                    InsertUpdateSP = "SP_ADD_SESSION";
                else if (objSession.Action == "E")
                    InsertUpdateSP = "SP_EDIT_SESSION";


                OracleParameter[] paramArray = new OracleParameter[7];
                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objSession.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", (objSession.ProgramID==0)?programID:objSession.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_SESSION_ID", objSession.SessionID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":p_SESSION_NAME", objSession.SessionName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_FROM_DATE", objSession.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_TIME", objSession.Time, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_TO_DATE", objSession.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);

                try
                {
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, paramArray);
                    if (objSession.Action == "A")
                    {
                        objSession.SessionID = int.Parse(paramArray[2].Value.ToString());
                        objSession.ProgramID = programID;
                    }
                    objSession.Action = "";

                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
            return true;
        }
    }
}
