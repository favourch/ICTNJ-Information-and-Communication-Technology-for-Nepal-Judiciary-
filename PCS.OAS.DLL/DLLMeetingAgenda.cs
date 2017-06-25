using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLMeetingAgenda
    {
        public static bool DeleteMeetingAgenda(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
                string deleteSQL = "SP_DEL_MEETING_AGENDA";
                foreach (ATTMeetingAgenda objMeetingAgenda in objMeeting.LstMeetingAgenda)
                {

                    OracleParameter[] paramArray = new OracleParameter[3];
                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID",objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID",objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_AGENDA_ID",objMeetingAgenda.AgendaID, OracleDbType.Int64, ParameterDirection.Input);
                
                    SqlHelper.ExecuteNonQuery(Tran,CommandType.StoredProcedure,deleteSQL, paramArray);


                }


                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static string UpdateMeetingAgenda(List<ATTMeetingAgenda> lstMeetingAgenda, OracleTransaction Tran)
        {
            try
            {
                string updateSQL = "SP_EDIT_MEETING_AGENDA";
                string agendaIDs = "";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                foreach (ATTMeetingAgenda objMeetingAgenda in lstMeetingAgenda)
                {
                    if (objMeetingAgenda.Action == "E")
                    {
                        paramArray.Add(Utilities.GetOraParam(":p_ORG_ID", objMeetingAgenda.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_MEETING_ID", objMeetingAgenda.MeetingID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_AGENDA_ID", objMeetingAgenda.AgendaID, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam(":P_AGENDA", objMeetingAgenda.Agenda, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objMeetingAgenda.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_ON", objMeetingAgenda.EntryOn, OracleDbType.Date, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, updateSQL, paramArray.ToArray());
                        objMeetingAgenda.Action = "";
                        paramArray.Clear();
                    }
                    else if (objMeetingAgenda.Action == "A")
                    {
                        agendaIDs += SaveMeetingAgenda(objMeetingAgenda, Tran) + "/";
                    }
                    else if (objMeetingAgenda.Action == "D")
                    {
                        DeleteMeetingAgenda(objMeetingAgenda, Tran);
                    }

                }

               
                if (agendaIDs.Length > 0)
                {
                    agendaIDs = agendaIDs.Substring(0, agendaIDs.Length - 1);
                }


                return agendaIDs;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string SaveMeetingAgenda(ATTMeetingAgenda objMeetingAgenda, OracleTransaction Tran)
        {
            try
            {
                string saveSQL = "SP_ADD_MEETING_AGENDA";
                string agendaIDs = "";

                List<OracleParameter> paramArray = new List<OracleParameter>();
               
                if (objMeetingAgenda.Action == "A")
                {
                    paramArray.Add(Utilities.GetOraParam(":p_ORG_ID", objMeetingAgenda.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_MEETING_ID", objMeetingAgenda.MeetingID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_AGENDA_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_AGENDA", objMeetingAgenda.Agenda, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objMeetingAgenda.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_ON", objMeetingAgenda.EntryOn, OracleDbType.Date, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray.ToArray());

                    agendaIDs = paramArray[2].Value.ToString();
                    objMeetingAgenda.Action = "";
                   
                    paramArray.Clear();
                }

             

                return agendaIDs;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static bool DeleteMeetingAgenda(ATTMeetingAgenda objMeetingAgenda, OracleTransaction Tran)
        {
            try
            {
                if (objMeetingAgenda.Action == "D")
                {
                    string deleteSQL = "SP_DEL_MEETING_AGENDA";

                    OracleParameter[] paramArray = new OracleParameter[3];
                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeetingAgenda.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeetingAgenda.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_AGENDA_ID", objMeetingAgenda.AgendaID, OracleDbType.Int64, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        //public static string SaveMeetingAgenda(int orgID,int meetingID, List<ATTMeetingAgenda> lstMeetingAgenda,OracleTransaction Tran)
        public static string SaveMeetingAgenda(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
                string saveSQL = "SP_ADD_MEETING_AGENDA";
                string agendaIDs ="";

                List<OracleParameter> paramArray = new List<OracleParameter>();
                foreach (ATTMeetingAgenda objMeetingAgenda in objMeeting.LstMeetingAgenda)
                {

                    paramArray.Add(Utilities.GetOraParam(":p_ORG_ID", objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_MEETING_ID", objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_AGENDA_ID",null, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_AGENDA", objMeetingAgenda.Agenda, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objMeetingAgenda.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_ON", objMeetingAgenda.EntryOn, OracleDbType.Date, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray.ToArray());
                    agendaIDs += paramArray[2].Value.ToString() + "/";
                    paramArray.Clear();

                }

                return agendaIDs;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static DataTable GetMeetingAgendaListTable(string dateString,ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string SelectSQL = " SELECT  distinct a.org_id,a.meeting_id,a.agenda_id, a.agenda " +
                                  " From vw_meeting_events a " +
                                  " WHERE a.agenda_id IS NOT NULL";

                if (dateString.Length > 0)
                {
                    SelectSQL += " and a.meeting_date  between" + CalDateRange(dateString);
                }

                if (login != null)
                    SelectSQL += " AND org_id = " + login.OrgID ;

                //selectSQL += "UNION SELECT distinct m.org_id, m.meeting_id, m.mtype_id, m.venue_id,m.venue_type,m.venue_data, " +
                //                  " m.meeting_subject, m.meeting_date,m.IS_GRP_CALLER, m.called_by,m.CALLED_BY_P_ID, m.start_time,m.end_time,m.status,MSTATUS_COLOR " +
                //                  " FROM vw_meeting_events m ";


                //if (dateString.Length > 0)
                //{
                //    selectSQL += " WHERE a.meeting_date  between" + CalDateRange(dateString);
                //}

                //if (login != null)
                //    selectSQL += " AND org_id = " + login.OrgID + " AND CALLED_BY_P_ID = " + login.PID;
                
              
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSQL);

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
    }
}
