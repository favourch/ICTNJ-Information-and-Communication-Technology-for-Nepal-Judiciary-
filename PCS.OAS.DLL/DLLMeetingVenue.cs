using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;


namespace PCS.OAS.DLL
{
    public class DLLMeetingVenue
    {
        public static bool AddMeetingVenue(ATTMeetingVenue obj)
        {
            string SP = "";
            if (obj.Action == "A")
                SP = "SP_ADD_VENUE";
            else
                SP = "SP_EDIT_VENUE";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("p_org_id", obj.OrgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_venue_id", obj.VenueID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("p_venue_name", obj.VenueName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_v_location", obj.VenueLocation, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();

            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                obj.VenueID = int.Parse(paramArray[1].Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static DataTable GetMeetingVenueListTable(int? orgID)
        {

            string SelectSQL = "SP_GET_VENUE";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[1].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
