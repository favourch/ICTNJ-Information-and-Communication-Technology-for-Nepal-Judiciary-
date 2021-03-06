using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;


namespace PCS.OAS.BLL
{
    public class BLLMeetingStatus
    {
        public static ObjectValidation Validate(ATTMeetingStatus obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.MeetingStatusName == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Meeting status name cannot be blank.";
                return result;
            }

            return result;
        }

        public static List<ATTMeetingStatus> GetMeetingStatusList(int? msID, bool containDefault)
        {
            List<ATTMeetingStatus> lst = new List<ATTMeetingStatus>();
            try
            {
                foreach (DataRow row in DLLMeetingStatus.GetMeetingStatusTable(msID).Rows)
                {
                    ATTMeetingStatus obj = new ATTMeetingStatus();

                    obj.MeetingStatusID = int.Parse(row["ms_id"].ToString());
                    obj.MeetingStatusName = row["mstatus_name"].ToString();
                    obj.MeetingStatusColor = row["mstatus_color"].ToString();
                    obj.Action = "E";

                    lst.Add(obj);
                }
                if (lst.Count > 0 && containDefault == true)
                {
                    ATTMeetingStatus def = new ATTMeetingStatus();
                    def.MeetingStatusID = -1;
                    def.MeetingStatusName = "छान्नुहोस्";
                    lst.Insert(0, def);
                }
                
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddMeetingStatus(ATTMeetingStatus status)
        {
            try
            {
                return DLLMeetingStatus.AddMeetingStatus(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
