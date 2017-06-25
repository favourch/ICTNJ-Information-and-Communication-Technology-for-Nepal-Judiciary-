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
    public class DLLCheckEvents
    {
        public static DataTable CheckMeetingEvents(ATTUserLogin login, string date, string startTime, string endTime)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = "SELECT DISTINCT m.org_id, m.meeting_id, m.called_by,m.called_by_p_id,m.meeting_subject, " +
                                   " m.meeting_date, m.start_time, m.end_time, entry_by, m_entry_by " +
                                   " FROM vw_meeting_events m WHERE 1=1 ";

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND participant_id = " + login.PID;

                if (date != "" && startTime != "" && endTime != "")
                {
                    selectSQL += " AND m.meeting_date = '" + date + "'";
                    selectSQL += " AND ((START_TIME BETWEEN '" + startTime + "' AND '" + endTime + "') OR (END_TIME BETWEEN '" + startTime + "' AND '" + endTime + "')";
                    selectSQL += " OR (START_TIME < '" + startTime + "' AND END_TIME > '" + endTime + "'))";
           
                }

                selectSQL += " UNION SELECT DISTINCT m.org_id, m.meeting_id, m.called_by,m.called_by_p_id,m.meeting_subject, " +
                                     " m.meeting_date, m.start_time, m.end_time, entry_by, m_entry_by " +
                                     " FROM vw_meeting_events m WHERE 1=1 ";

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND called_by_p_id = " + login.PID;

                if (date != "" && startTime != "" && endTime != "")
                {
                    selectSQL += " AND m.meeting_date = '" + date + "'";
                    selectSQL += " AND ((START_TIME BETWEEN '" + startTime + "' AND '" + endTime + "') OR (END_TIME BETWEEN '" + startTime + "' AND '" + endTime + "')";
                    selectSQL += " OR (START_TIME < '" + startTime + "' AND END_TIME > '" + endTime + "'))";
           
              
                }


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


        public static DataTable CheckAppointmentEvents(ATTUserLogin login, string date, string startTime, string endTime)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = "SELECT DISTINCT a.org_id, a.appointment_id, a.appointment_calledby, " +
                                    "a.appointment_subject, a.appointment_date, a.start_time, " +
                                    "a.end_time, a.venue " +
                                    "FROM vw_appointment_events a WHERE 1=1 ";

                if (login != null)
                    selectSQL += " AND a.org_id = " + login.OrgID + " AND a.appointment_calledby = " + login.PID;

                if (date != "" && startTime != "" && endTime != "")
                {
                    selectSQL += " AND a.appointment_date = '" + date + "'";
                    selectSQL += " AND ((a.START_TIME BETWEEN '" + startTime + "' AND '" + endTime + "') OR (a.END_TIME BETWEEN '" + startTime + "' AND '" + endTime + "')";
                    selectSQL += " OR (a.START_TIME < '" + startTime + "' AND a.END_TIME > '" + endTime + "'))";
                }

                selectSQL += " UNION SELECT DISTINCT a.org_id, a.appointment_id, a.appointment_calledby, " +
                            "  a.appointment_subject, a.appointment_date, a.start_time, " +
                            "  a.end_time, a.venue " +
                            "  FROM vw_appointment_events a WHERE 1=1 ";


                if (login != null)
                    selectSQL += " AND a.org_id = " + login.OrgID + " AND a.appointee_id = " + login.PID;

                if (date != "" && startTime != "" && endTime != "")
                {
                    selectSQL += " AND a.appointment_date = '" + date + "'";
                    selectSQL += " AND ((a.START_TIME BETWEEN '" + startTime + "' AND '" + endTime + "') OR (a.END_TIME BETWEEN '" + startTime + "' AND '" + endTime + "')";
                    selectSQL += " OR (a.START_TIME < '" + startTime + "' AND a.END_TIME > '" + endTime + "'))";
                }

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
    }
}
