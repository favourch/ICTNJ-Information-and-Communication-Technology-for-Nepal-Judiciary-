using System;
using System.Collections.Generic;
using System.Text;


using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLMeetingVenue
    {
        public static ObjectValidation Validate(ATTMeetingVenue obj)
        {
            ObjectValidation result=new ObjectValidation();

            if (obj.VenueName=="")
            {
                result.IsValid = false;
                result.ErrorMessage = "Venue name cannot be blank.";
                return result;
            }

            return result;
        }

        public static bool AddMeetingVenue(ATTMeetingVenue obj)
        {
            try
            {
                DLLMeetingVenue.AddMeetingVenue(obj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTMeetingVenue> GetMeetingVenueList(int? orgID)
        {
            List<ATTMeetingVenue> lstMeetingVenue = new List<ATTMeetingVenue>();

            try
            {
                foreach(DataRow row in DLLMeetingVenue.GetMeetingVenueListTable(orgID).Rows)
                {
                    ATTMeetingVenue objMeetingVenue = new ATTMeetingVenue(

                                                                             int.Parse(row["ORG_ID"].ToString()),
                                                                             int.Parse(row["VENUE_ID"].ToString()),
                                                                             row["VENUE_NAME"].ToString(),
                                                                             row["VENUE_LOCATION"].ToString()

                                                                         );
                   
                    lstMeetingVenue.Add(objMeetingVenue);
                }

                if (lstMeetingVenue.Count > 0)
                {
                    ATTMeetingVenue objDefault = new ATTMeetingVenue();
                    objDefault.OrgID = -1;
                    objDefault.VenueID = -1;
                    objDefault.VenueName = "छान्नुहोस्";

                    lstMeetingVenue.Insert(0, objDefault);
                }

                return lstMeetingVenue;

            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
     
    }
}
