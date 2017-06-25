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
    public class DLLMeetingMinute
    {
        public static DataTable GetMeetingMinuteTable(int orgID,int meetingID, int? minuteID)
        {
            string SP = "SP_GET_MEETING_MINUTE";
            
            List<OracleParameter> paramArray = new List<OracleParameter>();
            
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_meeting_id", meetingID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_minute_id", minuteID, OracleDbType.Int16, ParameterDirection.Input));
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

        public static bool AddMeetingMinute(List<ATTMeetingMinute> lst)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();

            GetConnection DBConn = new GetConnection();
            OracleTransaction Tran = DBConn.GetDbConn(Module.OAS).BeginTransaction();
            try
            {
                foreach (ATTMeetingMinute minute in lst)
                {
                    if (minute.Action == "A")
                        SP = "SP_ADD_MEETING_MINUTE";
                    else if (minute.Action == "E")
                        SP = "SP_EDIT_MEETING_MINUTE";
                    else if (minute.Action == "D")
                        SP = "SP_DEL_MEETING_MINUTE";

                    if (minute.Action != "N")
                    {
                        paramArray.Add(Utilities.GetOraParam("p_org_id", minute.OrgID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_meeting_id", minute.MeetingID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_minute_id", minute.MinuteID, OracleDbType.Int16, ParameterDirection.InputOutput));
                        if (minute.Action != "D")
                        {
                            paramArray.Add(Utilities.GetOraParam("p_minute", minute.Minute, OracleDbType.Varchar2, ParameterDirection.Input));
                            paramArray.Add(Utilities.GetOraParam("p_entry_by", minute.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        }
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        minute.MinuteID = int.Parse(paramArray[2].Value.ToString());
                        paramArray.Clear();
                    }
                }

                Tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static bool DeleteMeetingMinute(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
                string deleteSQL = "SP_DEL_MEETING_MINUTE";

                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_MINUTE_ID", null, OracleDbType.Int64, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);

                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
