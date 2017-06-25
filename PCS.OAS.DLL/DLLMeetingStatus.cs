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
    public class DLLMeetingStatus
    {
        public static DataTable GetMeetingStatusTable(int? msID)
        {
            string SP = "SP_GET_MEETING_STATUS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_ms_id", msID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddMeetingStatus(ATTMeetingStatus status)
        {
            string SP = "";

            if (status.Action == "A")
                SP = "sp_add_meeting_status";
            else if (status.Action == "E")
                SP = "sp_edit_meeting_status";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_ms_id", status.MeetingStatusID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("p_ms_name", status.MeetingStatusName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_ms_color", status.MeetingStatusColor, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);

                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                status.MeetingStatusID = int.Parse(paramArray[0].Value.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }
    }
}