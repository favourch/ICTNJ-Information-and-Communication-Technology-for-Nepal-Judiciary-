using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLMeetingType
    {
        public static ObjectValidation Validate(ATTMeetingType obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.MeetingTypeName=="")
            {
                result.IsValid = false;
                result.ErrorMessage = "Meeting type name cannot be blank.";
                return result;
            }

            return result;
        }

        public static bool AddMeetingType(ATTMeetingType obj)
        {
            try
            {
                return DLLMeetingType.AddMeetingType(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTMeetingType> GetMeetingTypeList()
        {
            List<ATTMeetingType> lstMeetingType = new List<ATTMeetingType>();

            try
            {
                foreach(DataRow row in DLLMeetingType.GetMeetingTypeListTable().Rows)
                {
                    ATTMeetingType objMeetingType = new ATTMeetingType(

                                                                         int.Parse(row["MTYPE_ID"].ToString()),
                                                                         row["MTYPE_NAME"].ToString(),
                                                                         row["DESCRIPTION"].ToString()
                        
                                                                        );

                    objMeetingType.Action = "E";

                    lstMeetingType.Add(objMeetingType);
                }

                return lstMeetingType;

            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
    }
}
