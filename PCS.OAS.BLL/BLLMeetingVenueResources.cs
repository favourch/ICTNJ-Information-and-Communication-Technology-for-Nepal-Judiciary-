using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
using System.Collections;

namespace PCS.OAS.BLL
{
    public class BLLMeetingVenueResources
    {
        public static DataTable GetBookedResourceDetailsTable(ATTMeetingVenueBooking objVBooked)
        {
            try
            {
                return DLLMeetingVenueResources.GetBookedResourceDetailsTable(objVBooked);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    }
}
