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
    public class DLLAppointment
    {
        public static string SaveAppointmentEvents(ATTAppointment objAppointment)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();


            string saveSQL = "SP_ADD_APPOINTMENT";
            string eventIDs = "";
            int countAppointee = objAppointment.LstAppointee.Count;

            OracleParameter[] paramArray = new OracleParameter[11];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objAppointment.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_APPOINTMENT_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[2] = Utilities.GetOraParam(":P_APPOINTMENT_CALLED_BY", objAppointment.AppointmentCalledBy, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_APPOINTMENT_SUBJECT", objAppointment.AppointmentSubject, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":P_APPOINTMENT_DATE", objAppointment.AppointmentDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":P_START_TIME", objAppointment.StartTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":P_END_TIME", objAppointment.EndTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[7] = Utilities.GetOraParam(":P_VENUE", objAppointment.Venue, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[8] = Utilities.GetOraParam(":P_STATUS", objAppointment.Status, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objAppointment.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objAppointment.EntryOn, OracleDbType.Date, ParameterDirection.Input);
            

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray);
                objAppointment.AppointmentID = int.Parse(paramArray[1].Value.ToString());

                eventIDs += paramArray[1].Value.ToString() + "/";

                if (countAppointee > 0)
                    eventIDs += DLLAppointee.SaveAppointee(objAppointment, Tran);

                Tran.Commit();

                if (eventIDs.Length > 0)
                {
                    eventIDs = eventIDs.Substring(0, eventIDs.Length - 1);
                }

                return eventIDs;

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

        public static bool UpdateAppointmentEvents(ATTAppointment objAppointment)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            string updateSQL = "SP_EDIT_APPOINTMENT";
            int countAppointee = objAppointment.LstAppointee.Count;

            OracleParameter[] paramArray = new OracleParameter[11];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objAppointment.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_APPOINTMENT_ID",objAppointment.AppointmentID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[2] = Utilities.GetOraParam(":P_APPOINTMENT_CALLED_BY", objAppointment.AppointmentCalledBy, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":P_APPOINTMENT_SUBJECT", objAppointment.AppointmentSubject, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":P_APPOINTMENT_DATE", objAppointment.AppointmentDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":P_START_TIME", objAppointment.StartTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":P_END_TIME", objAppointment.EndTime, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[7] = Utilities.GetOraParam(":P_VENUE", objAppointment.Venue, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[8] = Utilities.GetOraParam(":P_STATUS", objAppointment.Status, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", null, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", null, OracleDbType.Date, ParameterDirection.Input);
            
            try
            {
                SqlHelper.ExecuteNonQuery(Tran,CommandType.StoredProcedure, updateSQL, paramArray);

                if (countAppointee > 0)
                    DLLAppointee.UpdateAppointee(objAppointment, Tran);

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

        public static bool DeleteAppointmentEvents(ATTAppointment objAppointment)
        {
            string deleteSQL = "SP_DEL_APPOINTMENT";
            int countAppointee = objAppointment.LstAppointee.Count;

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objAppointment.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_APPOINTMENT_ID", objAppointment.AppointmentID, OracleDbType.Int64, ParameterDirection.InputOutput);
           
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
                if (countAppointee > 0)
                    DLLAppointee.DeleteAppointee(objAppointment,null, Tran);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);
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


        public static DataTable GetAppointmentEventListTable(string dateString, ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT distinct a.ORG_ID,a.APPOINTMENT_ID,a.APPOINTMENT_CALLEDBY,a.APPOINTMENT_SUBJECT, " +
                                   " a.APPOINTMENT_DATE,a.START_TIME,a.END_TIME,a.VENUE,a.STATUS,a.STATUS_COLOR " +
                                   " FROM vw_appointment_events a ";

                if (dateString.Length > 0)
                {
                    selectSQL += " WHERE a.APPOINTMENT_DATE  between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND APPOINTMENT_CALLEDBY = " + login.PID;

                selectSQL += "UNION SELECT distinct a.ORG_ID,a.APPOINTMENT_ID,a.APPOINTMENT_CALLEDBY,a.APPOINTMENT_SUBJECT, " +
                                   " a.APPOINTMENT_DATE,a.START_TIME,a.END_TIME,a.VENUE,a.STATUS,a.STATUS_COLOR " +
                                   " FROM vw_appointment_events a ";

                if (dateString.Length > 0)
                {
                    selectSQL += " WHERE a.APPOINTMENT_DATE  between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND appointee_id  = " + login.PID;

                
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static string CalDateRange(string dateString)
        {
            try
            {
                string rqdDateRange = "";
                char[] token ={ '/' };

                int year = int.Parse(dateString.Split(token)[0]);
                int month = int.Parse(dateString.Split(token)[1]);
                int tDay = int.Parse(dateString.Split(token)[4]);

                rqdDateRange = "'" + year.ToString() + "/" + GetFormated(month.ToString()) + "/01'";
                //rqdDateRange += " AND '" + year.ToString() + "/" + GetFormated(month.ToString()) + "/" + (tDay - 1).ToString() + "'";
                rqdDateRange += " AND '" + year.ToString() + "/" + GetFormated(month.ToString()) + "/" + (tDay).ToString() + "'";

                return rqdDateRange;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public static string GetFormated(string value)
        {
            value = "00" + value;
            return value.Substring(value.Length - 2, 2);
        }
    }
}
