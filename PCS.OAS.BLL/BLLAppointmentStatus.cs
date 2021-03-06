using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLAppointmentStatus
    {

        public static ObjectValidation Validate(ATTAppointmentStatus obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.AppointmentStatusName == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Appointment  status name cannot be blank.";
                return result;
            }

            return result;
        }
        //public static List<ATTAppointmentStatus> GetAppointmentStatusList(int? statusId)
        //{
        //    List<ATTAppointmentStatus> appntList = new List<ATTAppointmentStatus>();
        //    try
        //    {
        //        DataTable dt =DLLAppointmentStatus.GetAppointmentStatusList(statusId);
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            ATTAppointmentStatus obj = new ATTAppointmentStatus();
        //            obj.AppointmentStatusID = int.Parse(row["STATUS_ID"].ToString());
        //            obj.AppointmentStatusName = row["STATUS_NAME"].ToString();
        //            obj.AppointmentStatusColor = row["STATUS_COLOR"].ToString();
        //            appntList.Add(obj);

        //        }
        //        return appntList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public static List<ATTAppointmentStatus> GetMeetingStatusList(int? id, bool containDefault)
        {
            List<ATTAppointmentStatus> lst = new List<ATTAppointmentStatus>();
            try
            {
                foreach (DataRow row in DLLAppointmentStatus.GetAppointmentStatusTable(id).Rows)
                {
                    ATTAppointmentStatus obj = new ATTAppointmentStatus();

                    obj.AppointmentStatusID = int.Parse(row["STATUS_ID"].ToString());
                    obj.AppointmentStatusName = row["STATUS_NAME"].ToString();
                    obj.AppointmentStatusColor = row["STATUS_COLOR"].ToString();

                    lst.Add(obj);
                }

                if (lst.Count > 0 && containDefault == true)
                {
                    ATTAppointmentStatus def = new ATTAppointmentStatus();
                    def.AppointmentStatusID = -1;
                    def.AppointmentStatusName = "छान्नुहोस्";
                    lst.Insert(0, def);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddAppointmentStatus(ATTAppointmentStatus obj)
        {
            try
            {
                return DLLAppointmentStatus.AddAppointmentStatus(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
