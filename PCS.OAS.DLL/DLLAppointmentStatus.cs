using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using System.Data;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.OAS.DLL
{
    public class DLLAppointmentStatus
    {
        public static DataTable GetAppointmentStatusList(int? statusId)
        {
           
                string SP = "SP_GET_APPOINTMENT_STATUS";
                OracleParameter[] paramArray = new OracleParameter[2];
                paramArray[0] = Utilities.GetOraParam("P_STATUS_ID", statusId, OracleDbType.Int16, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);
                try
                {
               return  SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS,paramArray).Tables[0];
                }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAppointmentStatusTable(int? id)
        {
            string SP = "SP_GET_APPOINTMENT_STATUS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_appointment_id", id, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool AddAppointmentStatus(ATTAppointmentStatus objAppntStatus)
        {
            string SPInsertUpdate = "";
           
                if (objAppntStatus.Action == "A")
                    SPInsertUpdate = "SP_ADD_APPOINTMENT_STATUS";
                else if (objAppntStatus.Action == "E")
                    SPInsertUpdate = "SP_EDIT_APPOINTMENT_STATUS";

                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam("P_STATUS_ID", objAppntStatus.AppointmentStatusID, OracleDbType.Int16, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam("P_STATUS_NAME", objAppntStatus.AppointmentStatusName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam("P_STATUS_COLOR", objAppntStatus.AppointmentStatusColor, OracleDbType.Varchar2, ParameterDirection.Input);
              
                GetConnection DBConn=new GetConnection();
                OracleConnection Conn=DBConn.GetDbConn(Module.OAS);
                try
                {
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SPInsertUpdate, paramArray);
                objAppntStatus.AppointmentStatusID = int.Parse(paramArray[0].Value.ToString());
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

    }
}
