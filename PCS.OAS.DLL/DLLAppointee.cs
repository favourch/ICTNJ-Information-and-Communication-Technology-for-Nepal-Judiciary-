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
    public class DLLAppointee
    {
        public static string SaveAppointee(ATTAppointment objAppointment, OracleTransaction Tran)
        {
            try
            {
                string saveSQL = "SP_ADD_APPOINTEE";
                //string appointeeIDs = "";
                string outdoorAppointeeName;
                string outdoorAppointeeOrgName;
                

                foreach (ATTAppointee objAppointee in objAppointment.LstAppointee)
                {
                    OracleParameter[] paramArray = new OracleParameter[11];

                    objAppointee.OrgID = objAppointment.OrgID;
                    objAppointee.AppointmentID = objAppointment.AppointmentID;

                  

                    if (objAppointee.IsIndoorAppointee == "N")
                    {
                        outdoorAppointeeName = objAppointee.Appointee;
                        outdoorAppointeeOrgName = objAppointee.OutdoorOrgName;
                    }
                    else
                    {
                        outdoorAppointeeName = "";
                        outdoorAppointeeOrgName = "";
                    }

                    paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objAppointee.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":P_APPOINTMENT_ID", objAppointee.AppointmentID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":P_AP_ID",null, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[3] = Utilities.GetOraParam(":P_APPOINTEE_ID", objAppointee.AppointeeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[4] = Utilities.GetOraParam(":P_IS_INDOOR_APPOINTEE", objAppointee.IsIndoorAppointee, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":P_OUTDOOR_APPOINTEE_NAME", outdoorAppointeeName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":P_OUTDOOR_APPOINTEE_ORG_NAME", outdoorAppointeeOrgName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":P_FLAG", objAppointee.Flag, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":P_REMARK", objAppointee.Remark, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objAppointee.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objAppointee.EntryOn, OracleDbType.Date, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray);

                }

                return "";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static bool SaveAppointee(ATTAppointee objAppointee, OracleTransaction Tran)
        {
            try
            {
                string saveSQL = "SP_ADD_APPOINTEE";
                //string appointeeIDs = "";
                string outdoorAppointeeName;
                string outdoorAppointeeOrgName;

                if (objAppointee.IsIndoorAppointee == "N")
                {
                    outdoorAppointeeName = objAppointee.Appointee;
                    outdoorAppointeeOrgName = objAppointee.OutdoorOrgName;
                }
                else
                {                    
                    outdoorAppointeeName = "";
                    outdoorAppointeeOrgName = "";
                }

                OracleParameter[] paramArray = new OracleParameter[11];

                //if (objAppointee.Action == "A")
                //{

                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objAppointee.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_APPOINTMENT_ID", objAppointee.AppointmentID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_AP_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":P_APPOINTEE_ID", objAppointee.AppointeeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[4] = Utilities.GetOraParam(":P_IS_INDOOR_APPOINTEE", objAppointee.IsIndoorAppointee, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":P_OUTDOOR_APPOINTEE_NAME",outdoorAppointeeName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":P_OUTDOOR_APPOINTEE_ORG_NAME",outdoorAppointeeOrgName, OracleDbType.Varchar2, ParameterDirection.Input);

                paramArray[7] = Utilities.GetOraParam(":P_FLAG", objAppointee.Flag, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[8] = Utilities.GetOraParam(":P_REMARK", objAppointee.Remark, OracleDbType.Varchar2, ParameterDirection.Input);
                
                paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objAppointee.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objAppointee.EntryOn, OracleDbType.Date, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, saveSQL, paramArray);

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static bool UpdateAppointee(ATTAppointment objAppointment, OracleTransaction Tran)
        {
            try
            {
                foreach (ATTAppointee objAppointee in objAppointment.LstAppointee)
                {
                    objAppointee.OrgID = objAppointment.OrgID;
                    objAppointee.AppointmentID = objAppointment.AppointmentID;

                    if (objAppointee.Action == "A")
                    {
                        SaveAppointee(objAppointee,Tran);
                    }
                    else if (objAppointee.Action == "D")
                    {
                        DeleteAppointee(null,objAppointee,Tran);
                    }
                    else if (objAppointee.Action == "E")
                    {
                        string updateSQL = "SP_EDIT_APPOINTEE";
                        string outdoorAppointeeName;
                        string outdoorAppointeeOrgName;

                        if (objAppointee.IsIndoorAppointee == "N")
                        {
                            outdoorAppointeeName = objAppointee.Appointee;
                            outdoorAppointeeOrgName = objAppointee.OutdoorOrgName;
                        }
                        else
                        {
                            outdoorAppointeeName = "";
                            outdoorAppointeeOrgName = "";
                        }

                      
                        OracleParameter[] paramArray = new OracleParameter[11];

                        paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", objAppointee.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_APPOINTMENT_ID", objAppointee.AppointmentID, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_AP_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[3] = Utilities.GetOraParam(":P_APPOINTEE_ID", objAppointee.AppointeeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        paramArray[4] = Utilities.GetOraParam(":P_IS_INDOOR_APPOINTEE", objAppointee.IsIndoorAppointee, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_OUTDOOR_APPOINTEE_NAME", outdoorAppointeeName, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_OUTDOOR_APPOINTEE_ORG_NAME", outdoorAppointeeOrgName, OracleDbType.Varchar2, ParameterDirection.Input);

                        paramArray[7] = Utilities.GetOraParam(":P_FLAG", objAppointee.Flag, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":P_REMARK", objAppointee.Remark, OracleDbType.Varchar2, ParameterDirection.Input);

                        paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", objAppointee.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":P_ENTRY_ON", objAppointee.EntryOn, OracleDbType.Date, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, updateSQL, paramArray);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
          
        }

        public static bool DeleteAppointee(ATTAppointment objAppointment,ATTAppointee objAppointee, OracleTransaction Tran)
        {
            try
            {
              
                string deleteSQL = "SP_DEL_APPOINTEE";
                int? orgID;
                int? appointmentID;
                //int? appointeeID ;
                int? apID;


                if (objAppointment != null)
                {
                    orgID = objAppointment.OrgID;
                    appointmentID = objAppointment.AppointmentID;
                    //appointeeID = null;
                    apID = null;
                }
                else
                {
                    orgID = objAppointee.OrgID;
                    appointmentID = objAppointee.AppointmentID;
                    //appointeeID = objAppointee.AppointeeID;
                    apID = objAppointee.ApID;

                }

                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_APPOINTMENT_ID", appointmentID, OracleDbType.Int64, ParameterDirection.Input);
                //paramArray[2] = Utilities.GetOraParam(":P_APPOINTEE_ID", appointeeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[2] = Utilities.GetOraParam(":P_AP_ID", apID, OracleDbType.Int64, ParameterDirection.Input);
                 
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, deleteSQL, paramArray);

                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static DataTable GetAppointeeListTable(string dateString, ATTUserLogin login)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = "SELECT distinct t.ORG_ID,t.APPOINTMENT_ID,t.AP_ID,t.IS_INDOOR_APPOINTEE,t.APPOINTEE_ID, " +
                                   " t.FIRST_NAME, t.MID_NAME,t.SUR_NAME,t.OUTDOOR_APPOINTEE_NAME,t.OUTDOOR_APPOINTEE_ORG_NAME,t.ENTRY_ON,t.flag,t.remark  " +
                                   " FROM vw_appointment_events t " +
                                   " WHERE t.AP_ID IS NOT NULL ";

                if (dateString.Length > 0)
                {
                    selectSQL += " AND  t.APPOINTMENT_DATE between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID ;


               /* selectSQL += " UNION SELECT distinct t.ORG_ID,t.APPOINTMENT_ID,t.AP_ID,t.IS_INDOOR_APPOINTEE,t.APPOINTEE_ID, " +
                             " t.FIRST_NAME, t.MID_NAME,t.SUR_NAME,t.OUTDOOR_APPOINTEE_NAME,t.OUTDOOR_APPOINTEE_ORG_NAME,t.ENTRY_ON  " +
                             " FROM vw_appointment_events t " +
                              " WHERE t.AP_ID IS NOT NULL ";

                if (dateString.Length > 0)
                {
                    selectSQL += " AND  t.APPOINTMENT_DATE between" + CalDateRange(dateString);
                }

                if (login != null)
                    selectSQL += " AND org_id = " + login.OrgID + " AND appointee_id  = " + login.PID;*/


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
