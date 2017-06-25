using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLMeetingInfo
    {
        public static List<ATTMeetingInfo> GetMeetingInfoList(ATTMeetingInfo infox)
        {
            List<ATTMeetingInfo> lst = new List<ATTMeetingInfo>();
            try
            {
                foreach (DataRow row in DLLMeetingInfo.GetMeetingInfoTable(infox).Rows)
                {
                    ATTMeetingInfo info = new ATTMeetingInfo();

                    info.OrgID = int.Parse(row["org_id"].ToString());
                    info.MeetingID = int.Parse(row["meeting_id"].ToString());
                    info.Subject = row["meeting_subject"].ToString();
                    info.MeetingTypeName = row["mtype_name"].ToString();
                    info.Venue = row["venue_name"].ToString();
                    info.MeetingDate = row["meeting_date"].ToString();
                    info.CalledBy = row["group_name"].ToString();
                    info.StartTime = row["start_time"].ToString();
                    info.EndTime = row["end_time"].ToString();
                    info.Status = row["mstatus_name"].ToString();
                    info.CalledPID = row["p_name"].ToString();

                    lst.Add(info);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddMeetingMinute(List<ATTMeetingMinute> lst)
        {
            try
            {
                return DLLMeetingMinute.AddMeetingMinute(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
