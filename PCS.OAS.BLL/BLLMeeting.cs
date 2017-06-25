using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;

namespace PCS.OAS.BLL
{
    public class BLLMeeting
    {
        public static ObjectValidation ValidateMeetingEntry(ATTMeeting objMeeting)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objMeeting.OrgID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Organization.";
                return OV;
            }

            if (objMeeting.Status <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Status.";
                return OV;
            }

            //if (objMeeting.StartTime == 0.0)
            if (objMeeting.StartTime == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter  Start Time.";
                return OV;
            }


            //if (objMeeting.EndTime == 0.0)
            if (objMeeting.EndTime == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter  End Time.";
                return OV;
            }

            if (objMeeting.MeetingTypeID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Meeting Type.";
                return OV;
            }

            //if (objMeeting.VenueID <= 0)
            //{
            //    OV.IsValid = false;
            //    OV.ErrorMessage = "Please select Venue.";
            //    return OV;
            //}

            if (objMeeting.CalledBy <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Called By.";
                return OV;
            }

           
           

            if (objMeeting.Subject == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter  Subject.";
                return OV;
            }


          
            return OV;
        }

        public static string SaveMeetingEvents(ATTMeeting objMeeting)
        {
            try
            {
                return DLLMeeting.SaveMeetingEvents(objMeeting);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string UpdateMeetingEvents(ATTMeeting objMeeting)
        {
            try
            {
               return DLLMeeting.UpdateMeetingEvents(objMeeting);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetMeetingEventListTable(string dateString,ATTUserLogin login)
        {
            try
            {
                return DLLMeeting.GetMeetingEventListTable(dateString,login);

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool DeleteMeetingEvent(ATTMeeting objMeeting)
        {
            try
            {
                DLLMeeting.DeleteMeetingEvents(objMeeting);
                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool CheckMeetingEvents(ATTUserLogin login, string date, string startTime, string endTime)
        {
            try
            {
                //DataTable tbl = new DataTable();

                //tbl = DLLMeeting.CheckMeetingEvents(login, date, startTime, endTime);
                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

    }
}
