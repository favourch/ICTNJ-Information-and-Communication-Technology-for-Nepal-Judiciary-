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
    public class BLLMeetingVenueAlreadyBookedDetails
    {
        public static List<ATTMeetingVenueAlreadyBookedDetails> GetVenueAlreadyBookedDetails(ATTMeetingVenueBooking objVenueBok)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl = DLLMeetingVenueAlreadyBookedDetails.GetVenueAlreadyBookedDetails(objVenueBok);

                List<ATTMeetingVenueAlreadyBookedDetails> lst = new List<ATTMeetingVenueAlreadyBookedDetails>();


                foreach (DataRow row in tbl.Rows)
                {
                    ATTMeetingVenueAlreadyBookedDetails obj = new ATTMeetingVenueAlreadyBookedDetails();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.VenueID = int.Parse(row["VENUE_ID"].ToString());
                    obj.VenueName = row["VENUE_NAME"].ToString();
                    obj.BookedBy = int.Parse(row["BOOKED_BY"].ToString());
                    obj.BookerName = row["FIRST_NAME"].ToString() +
                                       (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                       (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString());
                    obj.BookingDate = row["BOOKING_DATE"].ToString();
                    obj.StartTime = row["START_TIME"].ToString();
                    obj.EndTime = row["END_TIME"].ToString();
                    obj.Purpose = row["PURPOSE"].ToString();

                    lst.Add(obj);
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
