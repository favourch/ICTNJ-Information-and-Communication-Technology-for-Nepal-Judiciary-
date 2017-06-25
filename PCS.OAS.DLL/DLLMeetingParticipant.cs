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
    public class DLLMeetingParticipant
    {

        public static bool DeleteMeetingParticipant(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
                string deleteSQL = "SP_DEL_MEETING_PARTICIPANT";
                foreach (ATTMeetingParticipant objMeetingParticipant in objMeeting.LstMeetingParticipant)
                {


                    OracleParameter[] paramArray = new OracleParameter[3];
                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID",objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID",objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_PARTICIPANT_ID", objMeetingParticipant.ParticipantID, OracleDbType.Int64, ParameterDirection.Input);
                  
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);


                }

                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static string UpdateMeetingParticipant(List<ATTMeetingParticipant> lstMeetingParticipant, OracleTransaction Tran)
        {
            try
            {
                string updateSQL = "SP_EDIT_MEETING_PARTICIPANT";

                foreach (ATTMeetingParticipant objMeetingParticipant in lstMeetingParticipant)
                {
                   
                    if (objMeetingParticipant.Action == "A")
                    {
                        SaveMeetingParticipant(objMeetingParticipant, Tran);
                    }
                    else if (objMeetingParticipant.Action == "D")
                    {
                        DeleteMeetingParticipant(objMeetingParticipant, Tran);
                    }
                    else if (objMeetingParticipant.Action == "E")
                    {
                        OracleParameter[] paramArray = new OracleParameter[12];
                        
                        int? meetingMemPosID;
                        int? desID;

                        if (objMeetingParticipant.MeetingMemPosID == 0)
                            meetingMemPosID = null;
                        else
                            meetingMemPosID = objMeetingParticipant.MeetingMemPosID;

                        if (objMeetingParticipant.IsGrpCaller == "N")
                        {
                            desID = objMeetingParticipant.PositionID;
                            //meetingMemPosID = null;
                        }
                        else
                        {
                            desID = null;
                        }


                        paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeetingParticipant.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeetingParticipant.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_P_ID", objMeetingParticipant.ParticipantID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[3] = Utilities.GetOraParam(":P_PART_ORG_ID", objMeetingParticipant.ParticipantOrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_GROUP_ID", objMeetingParticipant.GroupID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_NOTE", objMeetingParticipant.Note, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_ENTRY_BY", objMeetingParticipant.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":P_ENTRY_ON", objMeetingParticipant.EntryOn, OracleDbType.Date, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":P_IS_GRP_PART", objMeetingParticipant.IsGrpParticipant, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam(":P_POSITION_ID", meetingMemPosID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":P_IS_PRESENT", objMeetingParticipant.IsPresent, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[11] = Utilities.GetOraParam(":P_P_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                       
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, updateSQL, paramArray);
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        

        public static bool DeleteMeetingParticipant(ATTMeetingParticipant objMeetingParticipant, OracleTransaction Tran)
        {
            try
            {
                if (objMeetingParticipant.Action == "D")
                {
                    string deleteSQL = "SP_DEL_MEETING_PARTICIPANT";

                    OracleParameter[] paramArray = new OracleParameter[3];
                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeetingParticipant.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeetingParticipant.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_PARTICIPANT_ID", objMeetingParticipant.ParticipantID, OracleDbType.Int64, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool SaveMeetingParticipant(ATTMeetingParticipant objMeetingParticipant, OracleTransaction Tran)
        {
            try
            {
                string SaveSQL = "SP_ADD_MEETING_PARTICIPANT";

                OracleParameter[] paramArray = new OracleParameter[12];
                int? meetingMemPosID;
                int? desID;

                if (objMeetingParticipant.Action == "A")
                {

                    if (objMeetingParticipant.MeetingMemPosID == -1 || objMeetingParticipant.MeetingMemPosID == 0)
                        meetingMemPosID = null;
                    else
                        meetingMemPosID = objMeetingParticipant.MeetingMemPosID;

                    if (objMeetingParticipant.IsGrpCaller == "N")
                    {
                        desID = objMeetingParticipant.PositionID;
                        //meetingMemPosID = null;
                    }
                    else
                    {
                        desID = null;
                    }

                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeetingParticipant.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeetingParticipant.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_P_ID", objMeetingParticipant.ParticipantID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[3] = Utilities.GetOraParam(":P_PART_ORG_ID", objMeetingParticipant.ParticipantOrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":P_GROUP_ID", objMeetingParticipant.GroupID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":P_NOTE", objMeetingParticipant.Note, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":P_ENTRY_BY", objMeetingParticipant.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":P_ENTRY_ON", objMeetingParticipant.EntryOn, OracleDbType.Date, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":P_IS_GRP_PART", objMeetingParticipant.IsGrpParticipant, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":P_POSITION_ID", meetingMemPosID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[10] = Utilities.GetOraParam(":P_IS_PRESENT", objMeetingParticipant.IsPresent, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[11] = Utilities.GetOraParam(":P_P_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                       

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveSQL, paramArray);

                    //objMeetingParticipant.Action = "";
                }


                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static string SaveMeetingParticipant(ATTMeeting objMeeting, OracleTransaction Tran)
        {
            try
            {
                string SaveSQL = "SP_ADD_MEETING_PARTICIPANT";
                string participantIDs = "";
                int? meetingMemPosID ;
                int? desID;

                foreach (ATTMeetingParticipant objMeetingParticipant in objMeeting.LstMeetingParticipant)
                {

                    OracleParameter[] paramArray = new OracleParameter[12];

                    if (objMeetingParticipant.Action == "A")
                    {
                        if (objMeetingParticipant.MeetingMemPosID == 0)
                            meetingMemPosID = null;
                        else
                            meetingMemPosID = objMeetingParticipant.MeetingMemPosID;

                        if (objMeetingParticipant.IsGrpCaller == "N")
                        {
                            desID = objMeetingParticipant.PositionID;
                            //meetingMemPosID = null;
                        }
                        else
                        {
                            desID = null;
                        }
                        

                        paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeeting.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeeting.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_P_ID", objMeetingParticipant.ParticipantID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[3] = Utilities.GetOraParam(":P_PART_ORG_ID", objMeetingParticipant.ParticipantOrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_GROUP_ID", objMeetingParticipant.GroupID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_NOTE", objMeetingParticipant.Note, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_ENTRY_BY", objMeetingParticipant.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":P_ENTRY_ON", objMeetingParticipant.EntryOn, OracleDbType.Date, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":P_IS_GRP_PART", objMeetingParticipant.IsGrpParticipant, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam(":P_POSITION_ID", meetingMemPosID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":P_IS_PRESENT", objMeetingParticipant.IsPresent, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[11] = Utilities.GetOraParam(":P_P_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                       

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveSQL, paramArray);
                        objMeetingParticipant.Action = "";

                        participantIDs += paramArray[2].Value.ToString() + "/";
                    }
                
                }

                return participantIDs;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static DataTable GetMeetingParticipantListTable(string dateString,ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string SelectSQL = " SELECT * FROM vw_meeting_PARTICIPANT_DETAILS P"+
                                   " WHERE p.participant_id IS NOT NULL";
                if (dateString.Length > 0)
                {
                    SelectSQL += " and p.meeting_date  between" + CalDateRange(dateString);
                }
              
                if (login != null)
                    SelectSQL += " AND org_id = " + login.OrgID ;

                //selectSQL += "UNION SELECT * FROM vw_meeting_PARTICIPANT_DETAILS P" +
                //                   " WHERE p.participant_id IS NOT NULL";


                //if (dateString.Length > 0)
                //{
                //    SelectSQL += " and p.meeting_date  between" + CalDateRange(dateString);
                //}

                //if (login != null)
                //    SelectSQL += " AND org_id = " + login.OrgID;
                

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
