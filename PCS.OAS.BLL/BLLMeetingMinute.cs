using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.OAS.BLL
{
    public class BLLMeetingMinute
    {
        public static ObjectValidation Validate(ATTMeetingMinute minute)
        {
            ObjectValidation result = new ObjectValidation();

            if (minute.Minute == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Minute cannot be blank.";
                return result;
            }

            if (minute.Minute.Length > 390)
            {
                result.IsValid = false;
                result.ErrorMessage = "Minute text length cannot be greater then 390.";
                return result;
            }

            return result;
        }

        public static List<ATTMeetingMinute> CreateDeepCopy(List<ATTMeetingMinute> lst)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, lst);
            m.Position = 0;
            List<ATTMeetingMinute> DeepCopyLst = (List<ATTMeetingMinute>)b.Deserialize(m);
            m.Close();
            m.Dispose();
            return DeepCopyLst;
        }

        public static List<ATTMeetingMinute> GetMeetingMinuteList(int orgID, int meetingID, int? minuteID)
        {
            List<ATTMeetingMinute> lst = new List<ATTMeetingMinute>();
            try
            {
                foreach (DataRow row in DLLMeetingMinute.GetMeetingMinuteTable(orgID, meetingID, minuteID).Rows)
                {
                    ATTMeetingMinute minute = new ATTMeetingMinute();

                    minute.OrgID = int.Parse(row["org_id"].ToString());
                    minute.MeetingID = int.Parse(row["meeting_id"].ToString());
                    minute.MinuteID = int.Parse(row["minute_id"].ToString());
                    minute.Minute = row["minute"].ToString();
                    minute.EntryBy = row["entry_by"].ToString();
                    minute.Action = "N";
                    lst.Add(minute);
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
