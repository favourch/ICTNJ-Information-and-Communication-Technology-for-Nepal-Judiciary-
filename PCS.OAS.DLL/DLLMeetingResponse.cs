using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.OAS.DLL
{
    public class DLLMeetingResponse
    {
        public static bool SaveMeetingResponse(ATTMeetingResponse objMResponse)
        {
            string SaveSQL = "SP_UPDATE_MINUTE_NOTE";
            
            OracleParameter[] paramArray = new OracleParameter[5];
            paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMResponse.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMResponse.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":P_PART_ID", objMResponse.ParticipantID, OracleDbType.Int64, ParameterDirection.Input);
            //paramArray[3] = Utilities.GetOraParam(":P_RESPONSE_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[3] = Utilities.GetOraParam(":P_NOTE", objMResponse.Response, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":P_IS_AGREE", objMResponse.IsAgree, OracleDbType.Varchar2, ParameterDirection.Input);
             
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveSQL, paramArray);
                  
                Tran.Commit();
        
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }
        public static DataTable GetMeetingResponseTable(ATTMeetingResponse objMResponse)
        {
            //string SelectSQL = "SP_GET_PART_RESPONSE";
            string SelectSQL = "SP_GET_MINUTE_NOTE";

            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID",objMResponse.OrgID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_MEETING_ID",objMResponse.MeetingID, OracleDbType.Int16, ParameterDirection.Input);
            //paramArray[2] = Utilities.GetOraParam(":p_PARTICIPANT_ID",objMResponse.ParticipantID, OracleDbType.Int16, ParameterDirection.Input);
            //paramArray[3] = Utilities.GetOraParam(":p_RESPONSE_ID",objMResponse.ResponseID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[2].Value).GetDataReader();

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
