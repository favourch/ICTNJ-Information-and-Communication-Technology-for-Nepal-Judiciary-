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
    public class BLLAppointment
    {
        public static ObjectValidation ValidateAppointmentEntry(ATTAppointment objAppointment)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objAppointment.Status <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Status.";
                return OV;
            }

            if (objAppointment.StartTime == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter  Start Time.";
                return OV;
            }

            if(objAppointment.AppointmentSubject == "")
            {   
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter  Subject.";
                return OV;
            }

            if (objAppointment.AppointmentDate == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter Appointment Date.";
                return OV;
            }

            if (objAppointment.Venue == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter  Venue.";
                return OV;
            }


            return OV;
        }

        public static string SaveAppointmentEvents(ATTAppointment objAppointment)
        {
            try
            {
                
                return DLLAppointment.SaveAppointmentEvents(objAppointment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAppointmentEventListTable(string dateString, ATTUserLogin login)
        {
            try
            {
                return DLLAppointment.GetAppointmentEventListTable(dateString, login);

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool UpdateAppointmentEvents(ATTAppointment objAppointment)
        {
            try
            {
                if (DLLAppointment.UpdateAppointmentEvents(objAppointment))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteAppointmentEvents(ATTAppointment objAppointment)
        {
            try
            {
                DLLAppointment.DeleteAppointmentEvents(objAppointment);
                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
