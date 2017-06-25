using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
using System.Collections;

namespace PCS.OAS.BLL
{
    public class BLLEvent
    {
        public static DataTable tblMP;
        public static DataTable tblMA;
        public static List<ATTGroupMember> lstGroupMember;
        public static List<ATTEvent> GetEventList(string dateString,ATTUserLogin login)
        {
            try
            {
                List<ATTEvent> lstEvents = new List<ATTEvent>();

                DataTable tblME = new DataTable();
                tblME = BLLMeeting.GetMeetingEventListTable(dateString,login);


                tblMA = new DataTable();
                tblMA = BLLMeetingAgenda.GetMeetingAgendaListTable(dateString, login);

                tblMP = new DataTable();
                tblMP = BLLMeetingParticipant.GetMeetingParticipantListTable(dateString, login);

                lstGroupMember = BLLGroupMember.GetGroupMemberList(null);

                ATTGroupMember objGM = lstGroupMember.Find(    delegate(ATTGroupMember obj)
                                                                {
                                                                    return obj.OrgID == login.OrgID && obj.EmpID == login.PID;
                                                                }
                                                          );
             
                foreach (DataRow row in tblME.Rows)
                {

                    ATTEvent objEvent = new ATTEvent();

                    objEvent.Day = int.Parse(row["meeting_date"].ToString().Split('/')[2].ToString());

                    objEvent.OrgID = int.Parse(row["Org_ID"].ToString());
                    objEvent.EventID = int.Parse(row["MEETING_ID"].ToString());

                    //int stop;

                    //stop = objEvent.EventID;
                    /*if (objEvent.EventID == 21)
                        stop = 0;
                    */
                    //CALLED_BY_P_ID

                    int? calledByID ;

                    if(row["CALLED_BY_P_ID"].ToString() != "")
                        calledByID = int.Parse(row["CALLED_BY_P_ID"].ToString());
                    else
                        calledByID = null;

                    if (calledByID == null)
                    {


                        int calleby = int.Parse(row["called_by"].ToString());
                        string userName = row["ENTRY_BY"].ToString().Trim();

                        string entryBy = row["m_entry_by"].ToString().Trim();



                        if (login.UserName.Trim() == row["ENTRY_BY"].ToString().Trim() || login.UserName.Trim() == row["m_entry_by"].ToString().Trim())
                        {
                            if (row["meeting_subject"].ToString().Length > 15)
                                objEvent.Event = "<i><b>" + row["meeting_subject"].ToString().Substring(0, 15) + ".....</i></b>";
                            else
                                objEvent.Event = "<i><b>" + row["meeting_subject"].ToString() + "</i></b>";

                            objEvent.InOut = "IN";
                        }
                        else if(objGM != null)
                        {
                            if (objGM.GroupID == int.Parse(row["called_by"].ToString()))
                            {
                                if (row["meeting_subject"].ToString().Length > 15)
                                    objEvent.Event = "<i><b>" + row["meeting_subject"].ToString().Substring(0, 15) + ".....</i></b>";
                                else
                                    objEvent.Event = "<i><b>" + row["meeting_subject"].ToString() + "</i></b>";

                                objEvent.InOut = "IN";
                            }
                            else
                            {
                                if (row["meeting_subject"].ToString().Length > 15)
                                    objEvent.Event = "<b>" + row["meeting_subject"].ToString().Substring(0, 15) + ".....</b>";
                                else
                                    objEvent.Event = "<b>" + row["meeting_subject"].ToString() + "</b>";

                                objEvent.InOut = "OUT";
                            }
                        }
                        else
                        {
                            if (row["meeting_subject"].ToString().Length > 15)
                                objEvent.Event = "<b>" + row["meeting_subject"].ToString().Substring(0, 15) + ".....</b>";
                            else
                                objEvent.Event = "<b>" + row["meeting_subject"].ToString() + "</b>";

                            objEvent.InOut = "OUT";
                        }
                        
                    }
                    else
                    {
                        if (calledByID == login.PID || login.UserName.Trim() == row["ENTRY_BY"].ToString().Trim() || login.UserName.Trim() == row["m_entry_by"].ToString().Trim())
                        {
                            if (row["meeting_subject"].ToString().Length > 15 )
                                objEvent.Event = "<i>" + row["meeting_subject"].ToString().Substring(0, 15) + ".....</i>";
                            else
                                objEvent.Event = "<i>" + row["meeting_subject"].ToString() + "</i>";

                            objEvent.InOut = "IN";
                        }
                        else
                        {
                            if (row["meeting_subject"].ToString().Length > 15)
                                objEvent.Event = row["meeting_subject"].ToString().Substring(0, 15) + ".....";
                            else
                                objEvent.Event = row["meeting_subject"].ToString();

                            objEvent.InOut = "OUT";
                        }
                    }



                    objEvent.EventDetail = "(" +  row["start_time"].ToString() + " - " +  row["end_time"].ToString() + ") \n " + row["meeting_subject"].ToString();

                    objEvent.StatusColor = row["MSTATUS_COLOR"].ToString();

                    objEvent.LstMeeting = SetMeeting(row,dateString,login);

                    lstEvents.Add(objEvent);
                }

                return lstEvents;


            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static List<ATTMeeting> SetMeeting(DataRow row, string dateString,ATTUserLogin login)
        {

            List<ATTMeeting> lstMeetingEvents = new List<ATTMeeting>();

            int? calledByPID = null;
            int? calledBy = null;

            
            if (row["IS_GRP_CALLER"].ToString().Trim() == "N")
            {
                calledBy = null;
                calledByPID = int.Parse(row["CALLED_BY_P_ID"].ToString());
            }
            else
            {
                calledBy = int.Parse(row["called_by"].ToString());
                calledByPID = null;
            }

            ATTMeeting objME = new ATTMeeting();

            objME.OrgID = int.Parse(row["Org_id"].ToString());
            objME.MeetingID = int.Parse(row["meeting_id"].ToString());
            objME.MeetingTypeID = int.Parse(row["mtype_id"].ToString());
            objME.VenueID = int.Parse(row["venue_id"].ToString());
            objME.Subject = row["meeting_subject"].ToString();
            objME.MeetingDate = row["meeting_date"].ToString();
            objME.IsGrpCaller = row["IS_GRP_CALLER"].ToString().Trim();
            objME.CalledBy = calledBy;
            objME.CalledByPID = calledByPID;
            objME.StartTime = row["start_time"].ToString();
            objME.EndTime = row["end_time"].ToString();

            objME.Status = int.Parse(row["status"].ToString());
            objME.VenueType = row["venue_type"].ToString();

            objME.VenueData = row["venue_data"].ToString().Trim();


            if (row["venue_booking_id"].ToString().Trim() != "")
                objME.VenueBookingID = int.Parse(row["venue_booking_id"].ToString());

            


            if (tblMA.Rows.Count > 0)
            {
         
                objME.LstMeetingAgenda = SetMeetingAgenda(tblMA, int.Parse(row["Org_id"].ToString()),int.Parse(row["meeting_id"].ToString()));
        
            
            }

            if (tblMP.Rows.Count > 0)
            {
                objME.LstMeetingParticipant = SetMeetingParticipant(tblMP, int.Parse(row["Org_id"].ToString()),int.Parse(row["meeting_id"].ToString()));
       
            }

            lstMeetingEvents.Add(objME);

            return lstMeetingEvents;
        }

        public static List<ATTMeetingAgenda> SetMeetingAgenda(DataTable tblMA, int orgID, int meetingID)
      
        {
            List<ATTMeetingAgenda> lstMeetingAgenda = new List<ATTMeetingAgenda>();

            foreach (DataRow row in tblMA.Rows)
            {
                if (orgID == int.Parse(row["Org_id"].ToString()) &&
                     meetingID == int.Parse(row["meeting_id"].ToString())
                   )
                {

                    lstMeetingAgenda.Add(new ATTMeetingAgenda(
                                                                int.Parse(row["Org_id"].ToString()),
                                                                //int.Parse(row["UNIT_ID"].ToString()),
                                                                int.Parse(row["meeting_id"].ToString()),
                                                                int.Parse(row["agenda_id"].ToString()),
                                                                row["agenda"].ToString()

                                                              )
                                         );

                }
            }

            return lstMeetingAgenda;
        }

        public static List<ATTMeetingParticipant> SetMeetingParticipant(DataTable tblMP, int orgID,int meetingID)
        {
            try
            {
                List<ATTMeetingParticipant> lstMeetingParticipant = new List<ATTMeetingParticipant>();
                bool flag = false;
                bool flagChkMember = false;
                ArrayList arrVal = new ArrayList();
                ArrayList arrOtherVal = new ArrayList();

                arrVal = GetPariticipantList(orgID, meetingID);

                foreach (DataRow row in tblMP.Rows)
                {
                    if (orgID == int.Parse(row["Org_id"].ToString()) &&
                        meetingID == int.Parse(row["meeting_id"].ToString())
                       )
                    {

                        ATTMeetingParticipant objMP = new ATTMeetingParticipant();

                        int? participantOrgID = null;
                        int? groupID = null;
                        int? meetingMempositionID = null;
                        int? positionID = null;
                        int? empID = null;
                        int? participantID = null;
                        string isGrpParticipant;
                        string positionName = "";



                        if (row["group_id"].ToString() == "")
                            groupID = null;
                        else
                            groupID = int.Parse(row["group_id"].ToString());

                        if (row["emp_id"].ToString() == "")
                            empID = null;
                        else
                            empID = int.Parse(row["emp_id"].ToString());

                        if (row["PARTICIPANT_ID"].ToString() == "")
                            participantID = null;
                        else
                            participantID = int.Parse(row["PARTICIPANT_ID"].ToString());

                        isGrpParticipant = (row["IS_GRP_PARTICIPANT"].ToString()).Trim();

                       

                        if (groupID != null)
                        {
                            if (isGrpParticipant == "O")
                            {

                                if (empID == participantID)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    int l = 0;
                                    if (arrVal.Count > 0)
                                    {

                                        for (int k = 0; k < arrVal.Count; k++)
                                        {
                                            if (empID == int.Parse(arrVal[k].ToString()))
                                            {
                                                l = l + 1;
                                            }
                                        }

                                    }


                                    if (l > 0)
                                        flagChkMember = false;
                                    else
                                        flagChkMember = true;

                                    arrVal.Add(empID.ToString());

                                }
                            }
                            else if (isGrpParticipant == "OT")
                            {
                                int m = 0;
                                if (arrOtherVal.Count > 0)
                                {
                                    for (int n = 0; n < arrOtherVal.Count; n++)
                                    {
                                        if (participantID == int.Parse(arrOtherVal[n].ToString()))
                                        {
                                            m = m + 1;
                                        }
                                    }
                                }

                                if (m > 0)
                                    flag = false;
                                else
                                    flag = true;

                                arrOtherVal.Add(participantID.ToString());

                            }

                        }
                        else
                        {
                            flag = true;
                        }


                        if (flag)
                        {

                            if (row["part_org_ID"].ToString() == "")
                                participantOrgID = null;
                            else
                                participantOrgID = int.Parse(row["part_org_ID"].ToString());

                            if (row["MEETING_MEMBER_POSITIONID"].ToString() == "")
                                meetingMempositionID = 0;
                            else
                                meetingMempositionID = int.Parse(row["MEETING_MEMBER_POSITIONID"].ToString());


                            if (row["MEMBER_POSITIONID"].ToString() == "")
                                positionID = 0;
                            else
                            {
                                positionID = int.Parse(row["MEMBER_POSITIONID"].ToString());
                                positionName = row["MEMBER_POSITION_NAME"].ToString();
                            }
                            

                            if(row["des_id"].ToString() != "")
                            {
                                positionID = int.Parse(row["des_id"].ToString());
                                positionName = row["des_name"].ToString();
                            }


                            lstMeetingParticipant.Add(new ATTMeetingParticipant(
                                                                                    int.Parse(row["Org_id"].ToString()),
                                                                                    int.Parse(row["meeting_id"].ToString()),
                                                                                    int.Parse(participantID.ToString()),
                                                                                    row["FIRST_NAME"].ToString() +
                                                                                    (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                                                                    (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString()),
                                                                                    participantOrgID,
                                                                                    groupID,
                                                                                    row["NOTE"].ToString(),
                                                                                    row["IS_GRP_PARTICIPANT"].ToString(),
                                                                                    meetingMempositionID,
                                                                                    positionID,
                                                                                    positionName,
                                                                                    "N",
                                                                                    row["IS_PRESENT"].ToString()
                                                                               ));

                            flag = false;
                        }

                        if (flagChkMember)
                        {
                            ATTGroupMember objGroupMem = lstGroupMember.Find(delegate(ATTGroupMember objGM)
                                                                                    {
                                                                                        return (objGM.GroupID == groupID && objGM.EmpID == empID && (objGM.ToDate == ""));
                                                                                    }

                                                                             );

                            if (objGroupMem != null)
                            {
                                lstMeetingParticipant.Add(new ATTMeetingParticipant(
                                                                                        int.Parse(objGroupMem.OrgID.ToString()),
                                                                                        meetingID,
                                                                                        int.Parse(objGroupMem.EmpID.ToString()),
                                                                                        objGroupMem.EmpName,
                                                                                        null,
                                                                                        objGroupMem.GroupID,
                                                                                        "",
                                                                                        "",
                                                                                        -1,
                                                                                        objGroupMem.PositionID,
                                                                                        objGroupMem.PositionName,
                                                                                        "",
                                                                                        ""
                                                                                   ));
                            }

                            flagChkMember = false;
                        }


                    }
                }

                return lstMeetingParticipant;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
           
        }

        public static ArrayList GetPariticipantList(int orgID,int meetingID)
        {
            try
            {
                ArrayList arrVal = new ArrayList();
                int? empID;
                int? participantID;

                foreach (DataRow row in tblMP.Rows)
                {
                    if (orgID == int.Parse(row["Org_id"].ToString()) &&
                    meetingID == int.Parse(row["meeting_id"].ToString()))
                   {
                        if (row["emp_id"].ToString() == "")
                            empID = null;
                        else
                            empID = int.Parse(row["emp_id"].ToString());

                        if (row["PARTICIPANT_ID"].ToString() == "")
                            participantID = null;
                        else
                            participantID = int.Parse(row["PARTICIPANT_ID"].ToString());

                        if (empID == participantID)
                        {
                            arrVal.Add(participantID.ToString());
                        }
                    }
                }

                return arrVal;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static bool DeleteEvent(List<ATTEvent> lstEvent)
        {
            try
            {
                foreach(ATTEvent objEvent in lstEvent)
                {
                    foreach (ATTMeeting objMeeting in objEvent.LstMeeting)
                    {
                        BLLMeeting.DeleteMeetingEvent(objMeeting);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }


    }
}
