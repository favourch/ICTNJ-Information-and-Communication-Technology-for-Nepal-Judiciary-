using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;

namespace PCS.OAS.DLL
{
    public class DLLMeetingType
    {
        public static bool AddMeetingType(ATTMeetingType obj)
        {
            string SP = "";

            if (obj.Action == "A")
                SP = "SP_ADD_MEETING_TYPE";
            else if (obj.Action == "E")
                SP = "SP_EDIT_MEETING_TYPE";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_mtype_id", obj.MeetingTypeID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("p_mtype_name", obj.MeetingTypeName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_desc", obj.MeetingTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);

                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                obj.MeetingTypeID = int.Parse(paramArray[0].Value.ToString());

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

        public static DataTable GetMeetingTypeListTable()
        {
            string SelectSQL = "SP_GET_MEETING_TYPE";

            OracleParameter[] paramArray = new OracleParameter[1];
            //paramArray[0] = Utilities.GetOraParam(":p_MEETING_TYPE_ID", meetingTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[0] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[0].Value).GetDataReader();

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
