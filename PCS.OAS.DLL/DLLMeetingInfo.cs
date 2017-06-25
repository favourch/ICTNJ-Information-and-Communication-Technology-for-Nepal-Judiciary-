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
    public class DLLMeetingInfo
    {
        public static DataTable GetMeetingInfoTable(ATTMeetingInfo info)
        {
            string SP = "select vw.org_id, vw.meeting_id,vw.mtype_name, vw.venue_name, vw.meeting_subject, vw.meeting_date, vw.group_name, vw.start_time, vw.end_time, vw.mstatus_name,vw.p_name from vw_meeting_info vw where 1=1 " + DLLMeetingInfo.GetFilterString(info);

            try
            {
                return SqlHelper.ExecuteDataset( CommandType.Text, SP, Module.OAS,new OracleParameter[0]).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetFilterString(ATTMeetingInfo info)
        {
            string filter = "";

            if (info.OrgID > 0)
                filter += " and vw.org_id=" + info.OrgID.ToString();

            if (info.FromDate != "")
                filter += " and vw.meeting_date>='" + info.FromDate + "'";

            if (info.ToDate != "")
                filter += " and vw.meeting_date<='" + info.ToDate + "'";

            if (int.Parse(info.CalledBy) > 0)
                filter += " and vw.Called_by=" + info.CalledBy;

            if (int.Parse(info.Venue) > 0)
                filter += " and vw.venue_id=" + info.Venue;

            if (int.Parse(info.Status) > 0)
                filter += " and vw.status=" + info.Status;

            if (int.Parse(info.MeetingTypeName) > 0)
                filter += " and vw.mtype_id=" + info.MeetingTypeName;

            return filter;
        }
    }
}
