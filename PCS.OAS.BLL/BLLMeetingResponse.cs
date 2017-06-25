using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLMeetingResponse
    {

        public static ObjectValidation ValidateMeetingResponse(ATTMeetingResponse objResponse)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objResponse.Response == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter Comment.";
                return OV;
            }

            return OV;
        }

        public static bool SaveMeetingResponse(ATTMeetingResponse objMResponse)
        {
            try
            {
                return DLLMeetingResponse.SaveMeetingResponse(objMResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTMeetingResponse> GetMeetingResponseListTable(ATTMeetingResponse objMResponse)
        {
            try
            {
                //return DLLMeetingResponse.GetMeetingResponseTable(objMResponse);

                List<ATTMeetingResponse> lstMResponse = new List<ATTMeetingResponse>();
               
                DataTable tblMR = new DataTable();
                tblMR = DLLMeetingResponse.GetMeetingResponseTable(objMResponse);

                foreach (DataRow row in tblMR.Rows)
                {
                    ATTMeetingResponse objMR = new ATTMeetingResponse();
                    objMR.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objMR.MeetingID = int.Parse(row["MEETING_ID"].ToString());
                    objMR.ParticipantID = int.Parse(row["PARTICIPANT_ID"].ToString());
                    objMR.Response = row["NOTE"].ToString();
                    objMR.IsAgree = row["IS_AGREE_ON_MINUTE"].ToString();
                    objMR.ResponseBy = row["P_NAME"].ToString();
                    objMR.NoteOn = DateTime.Parse(row["note_on"].ToString());

                    lstMResponse.Add(objMR);
                }

                return lstMResponse;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
