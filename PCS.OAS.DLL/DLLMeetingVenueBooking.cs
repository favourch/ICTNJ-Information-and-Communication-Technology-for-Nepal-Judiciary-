using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLMeetingVenueBooking
    {
        public static bool UpdateMeetingVenueBooking(ATTMeetingVenueBooking objVenueBok)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                int venueAlreadyExistCount = CheckVenueIfVenueAlreadyBooked(objVenueBok, Tran);

                if (venueAlreadyExistCount > 0)
                {
                    //Tran.Commit();
                    //return false;
                    //return 0;
                }


                string sp = "SP_EDIT_MEETING_VENUE_BOOKING";
                int countBookedResources = objVenueBok.LstBookedResources.Count;

                OracleParameter[] paramArray = new OracleParameter[11];

                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objVenueBok.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_VENUE_ID", objVenueBok.VenueID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_BOOKING_ID", objVenueBok.BookingID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":P_BOOKED_BY", objVenueBok.BookedBy, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":P_PURPOSE", objVenueBok.Purpose, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":P_BOOKING_DATE", objVenueBok.BookingDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":P_START_TIME", objVenueBok.StartTime, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":P_END_TIME", objVenueBok.EndTime, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":P_ACTIVE", objVenueBok.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objVenueBok.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objVenueBok.EntryOn, OracleDbType.Date, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                objVenueBok.BookingID = int.Parse(paramArray[2].Value.ToString());


                if (countBookedResources > 0)
                {
                    DLLMeetingVenueResources.UpdateBookedResources(objVenueBok, Tran);
                }

                Tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static int SaveMeetingVenueBooking(ATTMeetingVenueBooking objVenueBok)
        {

            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                int venueAlreadyExistCount = CheckVenueIfVenueAlreadyBooked(objVenueBok, Tran);

                if (venueAlreadyExistCount > 0)
                {
                    Tran.Commit();
                    //return false;
                    return 0;
                }


                string sp = "SP_ADD_MEETING_VENUE_BOOKING";
                int countBookedResources = objVenueBok.LstBookedResources.Count;

                OracleParameter[] paramArray = new OracleParameter[11];

                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID",objVenueBok.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_VENUE_ID",objVenueBok.VenueID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_BOOKING_ID",objVenueBok.BookingID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":P_BOOKED_BY",objVenueBok.BookedBy, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":P_PURPOSE",objVenueBok.Purpose, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":P_BOOKING_DATE", objVenueBok.BookingDate, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":P_START_TIME",objVenueBok.StartTime, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[7] = Utilities.GetOraParam(":P_END_TIME",objVenueBok.EndTime, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":P_ACTIVE", objVenueBok.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY",objVenueBok.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objVenueBok.EntryOn, OracleDbType.Date, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray);

                objVenueBok.BookingID = int.Parse(paramArray[2].Value.ToString());


                if (countBookedResources > 0)
                {
                    DLLMeetingVenueResources.SaveBookedResources(objVenueBok,Tran);
                }

                Tran.Commit();

                return objVenueBok.BookingID;
                //return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static bool DeleteMeetingVenueBooking(int bookingID)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                string sp = "SP_DEL_MEETING_VENUE_BOOKING";
                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":bookingID", bookingID, OracleDbType.Int32, ParameterDirection.Input));

                if(DLLMeetingVenueResources.DeleteBookedResources(bookingID,Tran))
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, sp, paramArray.ToArray());

                Tran.Commit();

                return true;
                          
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
        
        public static DataTable GetBookedVenueDetailsTable(ATTMeetingVenueBooking objVBooked)
        {
            try
            {
                string SQL = " SELECT distinct ORG_ID,VENUE_ID,BOOKING_ID,ORG_NAME,VENUE_NAME,BOOKED_BY,FIRST_NAME,MID_NAME,SUR_NAME, "+
                             " BOOKING_DATE,START_TIME,END_TIME,PURPOSE,ACTIVE "+
                             " FROM   vw_meeting_venue_details WHERE 1=1 ";

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

                    if (objVBooked.BookedBy >0)
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

                return SqlHelper.ExecuteDataset(CommandType.Text,SQL,Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static int CheckVenueIfVenueAlreadyBooked(ATTMeetingVenueBooking objVBooked, OracleTransaction Tran)
        {
            try
            {
                string SQL = "SELECT  CHECK_IF_VENUE_ALREADY_BOOKED(" + objVBooked.OrgID + ","
                                                                      + objVBooked.VenueID + ",'"
                                                                      + objVBooked.BookingDate + "','"
                                                                      + objVBooked.StartTime + "','"
                                                                      + objVBooked.EndTime + "')" +
                             "FROM DUAL";


                DataSet ds = SqlHelper.ExecuteDataset(Tran,CommandType.Text,SQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                int bookedVenueCount = int.Parse(tbl.Rows[0][0].ToString());

                return bookedVenueCount;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static DataTable CheckVenueIfVenueAlreadyBooked(ATTMeetingVenueBooking objVBooked)
        {
            try
            {
                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                OracleTransaction Tran = DBConn.BeginTransaction();

                string SQL =  " SELECT * FROM vw_meeting_booking " +
                              " WHERE ORG_ID = " + objVBooked.OrgID +
                              " AND VENUE_ID = " + objVBooked .VenueID+
                              " AND BOOKING_DATE = '"+ objVBooked.BookingDate + "'"+
                              " AND ACTIVE = 'Y'"+
                              " AND ((START_TIME BETWEEN '" + objVBooked.StartTime + "' AND '"+ objVBooked.EndTime + "') " +
                              " OR (END_TIME BETWEEN '" + objVBooked.StartTime + "' AND '" + objVBooked.EndTime + "') " +
                              " OR (START_TIME < '" + objVBooked.StartTime + "' AND END_TIME > '" + objVBooked.EndTime + "' ) )";
                                        


                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text, SQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                //int bookedVenueCount = int.Parse(tbl.Rows[0][0].ToString());

                return tbl;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static int CheckBookingIDInUse(int bookingID)
        {
            try
            {
                GetConnection GetConn = new GetConnection();
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                OracleTransaction Tran = DBConn.BeginTransaction();

                string SQL = "SELECT Check_BookingID_InUse(" + bookingID + ")" +
                             "FROM DUAL";


                DataSet ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text, SQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                int count = int.Parse(tbl.Rows[0][0].ToString());

                Tran.Commit();

                return count;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

    
    }
}
