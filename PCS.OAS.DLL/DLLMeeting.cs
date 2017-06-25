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
using PCS.SECURITY.ATT;


namespace PCS.OAS.DLL
{
    public class DLLMeeting
    {
        public static string SaveMeetingEvents(ATTMeeting objMeeting)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            if (objMeeting.VenueType == "INS")
            {
                int bookedVenueCount = CheckVenueAvailability(objMeeting, Tran);

                if (bookedVenueCount < 1)
                {
                    Tran.Commit();
                    return "-1";
                }

                int venueInUseCount = CheckVenueInUse(objMeeting, Tran);

                if (venueInUseCount > 0)
                {
                    Tran.Commit();
                    return "-2";
                }
            }

            string SaveSQL = "SP_ADD_MEETING";
            string eventIDs = "";
            int CountMeetingAgenda = objMeeting.LstMeetingAgenda.Count;
            int CountMeetingParticipant = objMeeting.LstMeetingParticipant.Count;

         

            OracleParameter[] paramArray = new OracleParameter[18];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_MEETING_ID", null, OracleDbType.Int64, ParameterDirection.Output);
            paramArray[2] = Utilities.GetOraParam(":P_MTYPE_ID", objMeeting.MeetingTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_VENUE_ID", objMeeting.VenueID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":P_MEETING_SUBJECT", objMeeting.Subject, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":P_MEETING_DATE", objMeeting.MeetingDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":P_CALLED_BY", objMeeting.CalledBy, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[7] = Utilities.GetOraParam(":P_START_TIME", objMeeting.StartTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[8] = Utilities.GetOraParam(":P_END_TIME", objMeeting.EndTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objMeeting.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objMeeting.EntryOn, OracleDbType.Date, ParameterDirection.Input);
            paramArray[11] = Utilities.GetOraParam(":P_STATUS", objMeeting.Status, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[12] = Utilities.GetOraParam(":P_REMARKS", objMeeting.Remark, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[13] = Utilities.GetOraParam(":P_IS_GRP_CALLER ", objMeeting.IsGrpCaller, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[14] = Utilities.GetOraParam(":P_CALLED_BY_P_ID",objMeeting.CalledByPID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[15] = Utilities.GetOraParam(":P_VENUE_TYPE",objMeeting.VenueType, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[16] = Utilities.GetOraParam(":P_VENUE_DATA",objMeeting.VenueData, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[17] = Utilities.GetOraParam(":P_VENUE_BOOKING_ID", objMeeting.VenueBookingID, OracleDbType.Int64, ParameterDirection.Input);
           
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveSQL, paramArray);
                objMeeting.MeetingID = int.Parse(paramArray[1].Value.ToString());

                eventIDs += paramArray[1].Value.ToString() + "/";

                if (CountMeetingAgenda > 0)
                    eventIDs += DLLMeetingAgenda.SaveMeetingAgenda(objMeeting, Tran);

                if (CountMeetingParticipant > 0)
                    eventIDs += DLLMeetingParticipant.SaveMeetingParticipant(objMeeting,Tran);
               
                Tran.Commit();

                if (eventIDs.Length > 0)
                {
                    eventIDs = eventIDs.Substring(0, eventIDs.Length - 1);
                }
 
                return eventIDs;
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

        public static string UpdateMeetingEvents(ATTMeeting objMeeting)
        {

            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            if (objMeeting.VenueType == "INS")
            {
                int bookedVenueCount = CheckVenueAvailability(objMeeting, Tran);

                if (bookedVenueCount < 1)
                {
                    Tran.Commit();
                    return "-1";
                }

                int venueInUseCount = CheckVenueInUse(objMeeting, Tran);

                if (venueInUseCount > 0)
                {
                    Tran.Commit();
                    return "-2";
                }
            }

            string updateSQL = "SP_EDIT_MEETING";
            string eventIDs = "";
            int countMeetingAgenda = objMeeting.LstMeetingAgenda.Count;
            int countMeetingParticipant = objMeeting.LstMeetingParticipant.Count;

            OracleParameter[] paramArray = new OracleParameter[18];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_MEETING_ID", objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[2] = Utilities.GetOraParam(":P_MTYPE_ID", objMeeting.MeetingTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_VENUE_ID", objMeeting.VenueID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":P_MEETING_SUBJECT", objMeeting.Subject, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":P_MEETING_DATE", objMeeting.MeetingDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":P_CALLED_BY", objMeeting.CalledBy, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[7] = Utilities.GetOraParam(":P_START_TIME", objMeeting.StartTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[8] = Utilities.GetOraParam(":P_END_TIME", objMeeting.EndTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objMeeting.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objMeeting.EntryOn, OracleDbType.Date, ParameterDirection.Input);
            paramArray[11] = Utilities.GetOraParam(":P_STATUS", objMeeting.Status, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[12] = Utilities.GetOraParam(":P_REMARKS", objMeeting.Remark, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[13] = Utilities.GetOraParam(":P_IS_GRP_CALLER ", objMeeting.IsGrpCaller, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[14] = Utilities.GetOraParam(":P_CALLED_BY_P_ID", objMeeting.CalledByPID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[15] = Utilities.GetOraParam(":P_VENUE_TYPE", objMeeting.VenueType, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[16] = Utilities.GetOraParam(":P_VENUE_DATA", objMeeting.VenueData, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[17] = Utilities.GetOraParam(":P_VENUE_BOOKING_ID", objMeeting.VenueBookingID, OracleDbType.Int64, ParameterDirection.Input);
           

            try
            {
                

                if (countMeetingAgenda > 0)
                    eventIDs += DLLMeetingAgenda.UpdateMeetingAgenda(objMeeting.LstMeetingAgenda, Tran);

                if (countMeetingParticipant > 0)
                    eventIDs += DLLMeetingParticipant.UpdateMeetingParticipant(objMeeting.LstMeetingParticipant,Tran);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, updateSQL, paramArray);
                Tran.Commit();

                return eventIDs;
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

        public static bool DeleteMeetingEvents(ATTMeeting objMeeting)
        {
            string deleteSQL = "SP_DEL_MEETING";
            int CountMeetingAgenda = objMeeting.LstMeetingAgenda.Count;
            int CountMeetingParticipant = objMeeting.LstMeetingParticipant.Count;

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_MEETING_ID", objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try 
	        {
                if (CountMeetingAgenda > 0)
                    DLLMeetingAgenda.DeleteMeetingAgenda(objMeeting,Tran);

                if (CountMeetingParticipant > 0)
                    DLLMeetingParticipant.DeleteMeetingParticipant(objMeeting, Tran);

                DLLMeetingMinute.DeleteMeetingMinute(objMeeting, Tran);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);
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

        public static DataTable GetMeetingEventListTable(string dateString,ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT distinct m.org_id, m.meeting_id, m.mtype_id, m.venue_id,m.venue_type,m.venue_data,m.venue_booking_id, " +
                                   " m.meeting_subject, m.meeting_date,m.IS_GRP_CALLER, m.called_by,m.CALLED_BY_P_ID, m.start_time,m.end_time,m.status,MSTATUS_COLOR,entry_by,m_entry_by " +
                                   " FROM vw_meeting_events m ";

                if (dateString.Length > 0)
                {
                    selectSQL += " WHERE m.meeting_date  between" + CalDateRange(dateString);
                }

                if(login !=null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND participant_id = " + login.PID;

                selectSQL += "  UNION SELECT distinct m.org_id, m.meeting_id, m.mtype_id, m.venue_id,m.venue_type,m.venue_data,m.venue_booking_id ," +
                                   " m.meeting_subject, m.meeting_date,m.IS_GRP_CALLER, m.called_by,m.CALLED_BY_P_ID, m.start_time,m.end_time,m.status,MSTATUS_COLOR,entry_by,m_entry_by " +
                                   " FROM vw_meeting_events m ";


                if (dateString.Length > 0)
                {
                    selectSQL += " WHERE m.meeting_date  between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND CALLED_BY_P_ID = " + login.PID;

                selectSQL += "  UNION SELECT distinct m.org_id, m.meeting_id, m.mtype_id, m.venue_id,m.venue_type,m.venue_data,m.venue_booking_id ," +
                                   " m.meeting_subject, m.meeting_date,m.IS_GRP_CALLER, m.called_by,m.CALLED_BY_P_ID, m.start_time,m.end_time,m.status,MSTATUS_COLOR,entry_by,m_entry_by " +
                                   " FROM vw_meeting_events m ";


                if (dateString.Length > 0)
                {
                    selectSQL += " WHERE m.meeting_date  between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND ENTRY_BY = '" + login.UserName.Trim() + "' ";


                selectSQL += "  UNION SELECT distinct m.org_id, m.meeting_id, m.mtype_id, m.venue_id,m.venue_type,m.venue_data,m.venue_booking_id ," +
                                   " m.meeting_subject, m.meeting_date,m.IS_GRP_CALLER, m.called_by,m.CALLED_BY_P_ID, m.start_time,m.end_time,m.status,MSTATUS_COLOR,entry_by,m_entry_by " +
                                   " FROM vw_meeting_events m ";


                if (dateString.Length > 0)
                {
                    selectSQL += " WHERE m.meeting_date  between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND m_entry_by = '" + login.UserName.Trim() + "'";
                
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
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

        public static string CalDateRange(string dateString)
        {
            try
            {
                string rqdDateRange = "";
                char[] token ={ '/' };

                int year = int.Parse(dateString.Split(token)[0]);
                int month = int.Parse(dateString.Split(token)[1]);
                int tDay = int.Parse(dateString.Split(token)[4]);

                rqdDateRange = "'" + year.ToString() + "/" + GetFormated(month.ToString()) + "/01'";
                //rqdDateRange += " AND '" + year.ToString() + "/" + GetFormated(month.ToString()) + "/" + (tDay - 1).ToString() + "'";
                rqdDateRange += " AND '" + year.ToString() + "/" + GetFormated(month.ToString()) + "/" + (tDay).ToString() + "'";

                return rqdDateRange;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static string GetFormated(string value)
        {
            value = "00" + value;
            return value.Substring(value.Length - 2, 2);
        }

        public static int CheckVenueInUse(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
               /* string venueInUseSQL = "SELECT  CHECK_MEETING_AVAILABILITY(" + objMeeting.OrgID + ","
                                                                             + objMeeting.MeetingID + ","
                                                                             + int.Parse(objMeeting.VenueData.ToString()) + ",'"
                                                                             + objMeeting.MeetingDate + "','"
                                                                             + objMeeting.StartTime + "','"
                                                                             + objMeeting.EndTime + "')" +
                                        "FROM DUAL";*/

                string venueInUseSQL = "SELECT  CHECK_MEETING_AVAILABILITY(" + objMeeting.OrgID + ","
                                                                             + objMeeting.MeetingID + ","
                                                                             + objMeeting.VenueBookingID + ",'"
                                                                             + objMeeting.MeetingDate + "','"
                                                                             + objMeeting.StartTime + "','"
                                                                             + objMeeting.EndTime + "')" +
                                        "FROM DUAL";


                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text, venueInUseSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                int venueInUseCount = int.Parse(tbl.Rows[0][0].ToString());

                return venueInUseCount;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public  static int CheckVenueAvailability(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
                /*string chkVenueSQL = "SELECT  CHECK_VENUE_AVAILABILITY(" + objMeeting.OrgID + ",'"
                                                                         + objMeeting.MeetingDate + "',"
                                                                         + int.Parse(objMeeting.VenueData.ToString()) + ",'"
                                                                         + objMeeting.StartTime + "','"
                                                                         + objMeeting.EndTime + "')" +
                                     "FROM DUAL";*/

                string chkVenueSQL = "SELECT  CHECK_VENUE_AVAILABILITY(" + objMeeting.OrgID + ",'"
                                                                         + objMeeting.MeetingDate + "',"
                                                                         + objMeeting.VenueBookingID + ",'"
                                                                         + objMeeting.StartTime + "','"
                                                                         + objMeeting.EndTime + "')" +
                                     "FROM DUAL";


                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text, chkVenueSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                int bookedVenueCount = int.Parse(tbl.Rows[0][0].ToString());

                return bookedVenueCount;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

       
    }
}
