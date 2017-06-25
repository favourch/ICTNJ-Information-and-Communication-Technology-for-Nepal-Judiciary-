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
    public class BLLMeetingVenueBooking
    {
        public static DataTable tblVenue;
        public static DataTable tblRes;
        public static int SaveMeetingVenueBooking(ATTMeetingVenueBooking objVenueBok)
        {
            try
            {
                int bookingID = 0;

                bookingID =  DLLMeetingVenueBooking.SaveMeetingVenueBooking(objVenueBok);

                if (bookingID == 0)
                {
                    string bookedDetails = "";
                    //bookedDetails = GetVenueAlreadyBookedDetails(objVenueBok);
                    return 0;
                }
                else
                    return bookingID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTMeetingVenueBooking> GetBookedVenueDetails(ATTMeetingVenueBooking objVBooked)
        {
            List<ATTMeetingVenueBooking> lst = new List<ATTMeetingVenueBooking>();

            try
            {
                tblVenue = new DataTable();
                tblRes = new DataTable();

                tblVenue = DLLMeetingVenueBooking.GetBookedVenueDetailsTable(objVBooked);
                tblRes = BLLMeetingVenueResources.GetBookedResourceDetailsTable(objVBooked);


                foreach (DataRow row in tblVenue.Rows)
                {

                    ATTMeetingVenueBooking obj = new ATTMeetingVenueBooking();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.VenueID = int.Parse(row["VENUE_ID"].ToString());
                    obj.BookingID = int.Parse(row["BOOKING_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.VenueName = row["VENUE_NAME"].ToString();
                    obj.BookedBy = int.Parse(row["BOOKED_BY"].ToString());
                    obj.BookedByName = row["FIRST_NAME"].ToString() +
                                       (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                       (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString());
                    obj.BookingDate = row["BOOKING_DATE"].ToString();
                    obj.StartTime = row["START_TIME"].ToString();
                    obj.EndTime = row["END_TIME"].ToString();
                    obj.Purpose = row["PURPOSE"].ToString();
                    obj.Active = row["ACTIVE"].ToString();

                    //obj.LstBookedResources = SetVenueResources(obj.OrgID, obj.VenueID, obj.BookingID);
                    obj.LstBookedResources = SetVenueResources(obj.BookingID);

                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

//        public static List<ATTMeetingVenueResources> SetVenueResources(int orgID, int venueID, int bookingID)
        public static List<ATTMeetingVenueResources> SetVenueResources(int bookingID)
        {
            try
            {
                List<ATTMeetingVenueResources> lst = new List<ATTMeetingVenueResources>();

                foreach (DataRow row in tblRes.Rows)
                {
                   /* if(orgID == int.Parse(row["ORG_ID"].ToString()) &&
                       venueID == int.Parse(row["VENUE_ID"].ToString()) &&
                       bookingID == int.Parse(row["BOOKING_ID"].ToString()))*/

                    if (bookingID == int.Parse(row["BOOKING_ID"].ToString()))
                    {
                        ATTMeetingVenueResources objRes = new ATTMeetingVenueResources();
                        objRes.OrgID = int.Parse(row["ORG_ID"].ToString());
                        objRes.VenueID = int.Parse(row["VENUE_ID"].ToString());
                        objRes.BookingID = int.Parse(row["BOOKING_ID"].ToString());
                        objRes.ResourceID = int.Parse(row["RESOURCE_ID"].ToString());
                        objRes.ResourceBookID = int.Parse(row["RESOURCE_BOOK_ID"].ToString());
                        objRes.ResourceQty = int.Parse(row["RESOURCE_QTY"].ToString());
                        objRes.Action = "N";

                        lst.Add(objRes);
                    }

                    //string SQL = " SELECT distinct ORG_ID,VENUE_ID,BOOKING_ID,RESOURCE_BOOK_ID,RESOURCE_ID,RESOURCE_NAME,RESOURCE_QTY " +
                    //        " FROM   vw_meeting_venue_details WHERE 1=1 ";
                }

                return lst;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static bool UpdateMeetingVenueBooking(ATTMeetingVenueBooking objVenueBok)
        {
            try
            {
                return DLLMeetingVenueBooking.UpdateMeetingVenueBooking(objVenueBok);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteMeetingVenueBooking(int bookingID)
        {
            try
            {
                return DLLMeetingVenueBooking.DeleteMeetingVenueBooking(bookingID);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static int CheckBookingIDInUse(int bookingID)
        {
            try
            {
                return DLLMeetingVenueBooking.CheckBookingIDInUse(bookingID);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static List<ATTMeetingVenueBooking> CheckVenueIfVenueAlreadyBooked(ATTMeetingVenueBooking objVBooked)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl = DLLMeetingVenueBooking.CheckVenueIfVenueAlreadyBooked(objVBooked);

                List<ATTMeetingVenueBooking> lst = new List<ATTMeetingVenueBooking>();
                foreach (DataRow row in tbl.Rows)
                {
                    ATTMeetingVenueBooking obj = new ATTMeetingVenueBooking();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.BookingID = int.Parse(row["BOOKING_ID"].ToString());

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
