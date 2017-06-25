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
    public class DLLMeetingVenueAlreadyBookedDetails
    {
        public static DataTable GetVenueAlreadyBookedDetails(ATTMeetingVenueBooking objVBooked)
        {
            try
            {
                string SQL = " SELECT * FROM vw_venue_booker_detail WHERE 1=1 ";

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

                    if (objVBooked.BookingDate != "")
                    {
                        SQL = SQL + " AND booking_date= :bookingDate";
                        paramArray.Add(Utilities.GetOraParam(":bookingDate", objVBooked.BookingDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    }

                    if (objVBooked.StartTime != "" && objVBooked.EndTime != "")
                    {
                        SQL = SQL + " AND ((start_time BETWEEN :start_time AND :end_time) OR (end_time BETWEEN :start_time AND :end_time) OR (start_time < :start_time AND  end_time > :end_time))";

                        paramArray.Add(Utilities.GetOraParam(":START_TIME", objVBooked.StartTime, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":END_TIME", objVBooked.EndTime, OracleDbType.Varchar2, ParameterDirection.Input));

                    }

                    SQL += " ORDER BY  start_time";
                }


                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
