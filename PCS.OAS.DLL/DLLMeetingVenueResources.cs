using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLMeetingVenueResources
    {

        public static bool UpdateBookedResources(ATTMeetingVenueBooking objVenueBok, OracleTransaction Tran)
        {
            try
            {
                string sp = "";
                List<OracleParameter> paramArray = new List<OracleParameter>();

                foreach (ATTMeetingVenueResources objRes in objVenueBok.LstBookedResources)
                {
                    objRes.OrgID = objVenueBok.OrgID;
                    objRes.VenueID = objVenueBok.VenueID;
                    objRes.BookingID = objVenueBok.BookingID;

                    paramArray.Add(Utilities.GetOraParam(":p_ORG_ID", objRes.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_VENUE_ID", objRes.VenueID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_BOOKING_ID", objRes.BookingID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_RESOURCE_BOOK_ID", objRes.ResourceBookID, OracleDbType.Int64, ParameterDirection.Input));

                    int resID = objRes.ResourceID;

                    if (objRes.Action.Trim() == "A" || objRes.Action.Trim() == "E")
                    {
                        if (objRes.Action == "A")
                            sp = "SP_ADD_MEETING_VENUE_RESOURCES";
                        else if (objRes.Action == "E")
                            sp = "SP_EDIT_MEETING_VENUE_RES";

                        paramArray.Add(Utilities.GetOraParam(":P_RESOURCE_ID", objRes.ResourceID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_RESOURCE_QTY", objRes.ResourceQty, OracleDbType.Int64, ParameterDirection.Input));

                        

                    }
                    else if (objRes.Action.Trim() == "D")
                    {
                        sp = "SP_DEL_MEETING_VENUE_RESOURCES";
                    }

                    if (sp != "")
                    {
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());
                        paramArray.Clear();
                        sp = "";
                    }

                    
                }
                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static bool DeleteBookedResources(int bookingID,OracleTransaction Tran)
        {
           
            try
            {
                string sp = "SP_DEL_MEETING_VENUE_RESOURCES";
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":bookingID", bookingID, OracleDbType.Int32, ParameterDirection.Input));

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());

                return true;

            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }

        }



        //public static bool DeleteBookedResources(ATTMeetingParticipant objMeetingParticipant, OracleTransaction Tran)
        //{
        //    try
        //    {
        //        if (objMeetingParticipant.Action == "D")
        //        {
        //            string deleteSQL = "SP_DEL_MEETING_PARTICIPANT";

        //            OracleParameter[] paramArray = new OracleParameter[3];
        //            paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objMeetingParticipant.OrgID, OracleDbType.Int64, ParameterDirection.Input);
        //            paramArray[1] = Utilities.GetOraParam(":P_MEETING_ID", objMeetingParticipant.MeetingID, OracleDbType.Int64, ParameterDirection.Input);
        //            paramArray[2] = Utilities.GetOraParam(":P_PARTICIPANT_ID", objMeetingParticipant.ParticipantID, OracleDbType.Int64, ParameterDirection.Input);

        //            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw (ex);
        //    }
        //}

        public static bool SaveBookedResources(ATTMeetingVenueBooking objVenueBok, OracleTransaction Tran)
        {
            try
            {
                string sp = "SP_ADD_MEETING_VENUE_RESOURCES";
               
                List<OracleParameter> paramArray = new List<OracleParameter>();
                foreach (ATTMeetingVenueResources objRes in objVenueBok.LstBookedResources)
                {
                    objRes.OrgID = objVenueBok.OrgID;
                    objRes.VenueID = objVenueBok.VenueID;
                    objRes.BookingID = objVenueBok.BookingID;

                    paramArray.Add(Utilities.GetOraParam(":p_ORG_ID",objRes.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_VENUE_ID",objRes.VenueID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_BOOKING_ID",objRes.BookingID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_RESOURCE_BOOK_ID", objRes.ResourceBookID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_RESOURCE_ID", objRes.ResourceID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_RESOURCE_QTY", objRes.ResourceQty, OracleDbType.Int64, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());
                    paramArray.Clear();
                }

                return true;


            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static DataTable GetBookedResourceDetailsTable(ATTMeetingVenueBooking objVBooked)
        {
            try
            {
                string SQL = " SELECT distinct ORG_ID,VENUE_ID,BOOKING_ID,RESOURCE_BOOK_ID,RESOURCE_ID,RESOURCE_NAME,RESOURCE_QTY " +
                             " FROM   vw_meeting_venue_details WHERE 1=1 AND RESOURCE_BOOK_ID IS NOT NULL ";

                List<OracleParameter> paramArray = new List<OracleParameter>();

                if (objVBooked != null)
                {

                    if (objVBooked.OrgID > 0)
                    {
                        SQL = SQL + " AND ORG_ID=:org_id ";
                        paramArray.Add(Utilities.GetOraParam(":org_id", objVBooked.OrgID, OracleDbType.Int32, ParameterDirection.Input));
                    }

                    if (objVBooked.VenueID > 0)
                    {
                        SQL = SQL + " AND VENUE_ID=:venue_id";
                        paramArray.Add(Utilities.GetOraParam(":venue_id", objVBooked.VenueID, OracleDbType.Int32, ParameterDirection.Input));
                    }

                    if (objVBooked.BookedBy > 0)
                    {
                        SQL = SQL + " AND BOOKED_BY = :bookedBy";
                        paramArray.Add(Utilities.GetOraParam(":bookedBy", objVBooked.BookedBy, OracleDbType.Int32, ParameterDirection.Input));
                    }


                    if (objVBooked.BookingID > 0)
                    {
                        SQL = SQL + " AND BOOKING_ID = :bookedID";
                        paramArray.Add(Utilities.GetOraParam(":bookedID", objVBooked.BookingID, OracleDbType.Int32, ParameterDirection.Input));
                    }

                    if (objVBooked.BookingDate != "")
                    {
                        SQL = SQL + " AND booking_date= :bookingDate";
                        paramArray.Add(Utilities.GetOraParam(":bookingDate", objVBooked.BookingDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }
                }

                SQL = SQL + " order by BOOKING_ID DESC";

                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
