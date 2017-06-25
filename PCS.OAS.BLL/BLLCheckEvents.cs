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
    public class BLLCheckEvents
    {
        public static List<ATTCheckEvents> CheckEvents(ATTUserLogin login, string date, string startTime, string endTime)
        {
            try
            {
                List<ATTCheckEvents> lst = new List<ATTCheckEvents>();

                DataTable tblMeeting = new DataTable();
                DataTable tblAppointment = new DataTable();

                tblMeeting = DLLCheckEvents.CheckMeetingEvents(login, date, startTime, endTime);

                tblAppointment = DLLCheckEvents.CheckAppointmentEvents(login, date, startTime, endTime);

                foreach (DataRow row in tblMeeting.Rows)
                {
                    ATTCheckEvents objChkE = new ATTCheckEvents();
                    objChkE.OrgID = int.Parse(row["org_id"].ToString());
                    objChkE.ID = int.Parse(row["meeting_id"].ToString());
                    objChkE.Subject = row["meeting_subject"].ToString();
                    objChkE.Date = row["meeting_date"].ToString();
                    objChkE.StartTime = row["start_time"].ToString();
                    objChkE.EndTime = row["end_time"].ToString();
                    objChkE.Type = "M";


                    lst.Add(objChkE);
                }

                foreach (DataRow row in tblAppointment.Rows)
                {
                    ATTCheckEvents objChkE = new ATTCheckEvents();
                    objChkE.OrgID = int.Parse(row["org_id"].ToString());
                    objChkE.ID = int.Parse(row["appointment_id"].ToString());
                    objChkE.Subject = row["appointment_subject"].ToString();
                    objChkE.Date = row["appointment_date"].ToString();
                    objChkE.StartTime = row["start_time"].ToString();
                    objChkE.EndTime = row["end_time"].ToString();
                    objChkE.Type = "A";


                    lst.Add(objChkE);
                }


                return lst;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
