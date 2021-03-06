using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
using System.Collections;

namespace PCS.OAS.BLL
{
    public class BLLAppointmentEvent
    {
        public static DataTable tblAppointee;
        public static List<ATTAppointmentEvent> GetEventList(string dateString, ATTUserLogin login)
        {
            try
            {
                List<ATTAppointmentEvent> lstAppointmentEvents = new List<ATTAppointmentEvent>();

                DataTable tblAppointment = new DataTable();
                tblAppointment = BLLAppointment.GetAppointmentEventListTable(dateString, login);

                tblAppointee = new DataTable();
                tblAppointee = BLLAppointee.GetAppointeeListTable(dateString, login);

                if (tblAppointment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblAppointment.Rows)
                    {
                        ATTAppointmentEvent objEvent = new ATTAppointmentEvent();

                        objEvent.Day = int.Parse(row["APPOINTMENT_DATE"].ToString().Split('/')[2].ToString());

                        objEvent.OrgID = int.Parse(row["ORG_ID"].ToString());
                        objEvent.EventID = int.Parse(row["APPOINTMENT_ID"].ToString());

                        if (login != null)
                        {
                            if (int.Parse(row["APPOINTMENT_CALLEDBY"].ToString()) == login.PID)
                            {
                                //if (row["APPOINTMENT_SUBJECT"].ToString().Length > 15)
                                //    objEvent.Event = "<i><b>" + row["APPOINTMENT_SUBJECT"].ToString().Substring(0, 15) + ".....</i></b>";
                                //else
                                //    objEvent.Event = "<i><b>" + row["APPOINTMENT_SUBJECT"].ToString() + "</i></b>";

                                if (row["APPOINTMENT_SUBJECT"].ToString().Length > 15)
                                    objEvent.Event = "<i>" + row["APPOINTMENT_SUBJECT"].ToString().Substring(0, 15) + ".....</i>";
                                else
                                    objEvent.Event = "<i>" + row["APPOINTMENT_SUBJECT"].ToString() + "</i>";

                                objEvent.InOut = "IN";
                            }
                            else
                            {
                                if (row["APPOINTMENT_SUBJECT"].ToString().Length > 15)
                                    objEvent.Event = row["APPOINTMENT_SUBJECT"].ToString().Substring(0, 15) + ".....";
                                else
                                    objEvent.Event = row["APPOINTMENT_SUBJECT"].ToString();

                                objEvent.InOut = "OUT";
                            }
                        }
                        else
                        {
                            objEvent.Event = "Error";
                            objEvent.InOut = "IN";
                        }


                        objEvent.EventDetail = "(" + row["start_time"].ToString() + " - " + row["end_time"].ToString() + ") \n " + row["APPOINTMENT_SUBJECT"].ToString();
                        objEvent.StatusColor = row["STATUS_COLOR"].ToString();
                        lstAppointmentEvents.Add(objEvent);

                        objEvent.LstAppointment = SetAppointment(row, dateString, login);
                    }
                }


                return lstAppointmentEvents;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ATTAppointment> SetAppointment(DataRow row, string dateString, ATTUserLogin login)
        {
            try
            {
                List<ATTAppointment> lstAppointmentEvents = new List<ATTAppointment>();

                ATTAppointment objAppointment = new ATTAppointment(
                                                                       int.Parse(row["ORG_ID"].ToString()),
                                                                       int.Parse(row["APPOINTMENT_ID"].ToString()),
                                                                       int.Parse(row["APPOINTMENT_CALLEDBY"].ToString()),
                                                                       row["APPOINTMENT_SUBJECT"].ToString(),
                                                                       row["APPOINTMENT_DATE"].ToString(),
                                                                       row["START_TIME"].ToString(),
                                                                       row["END_TIME"].ToString(),
                                                                       int.Parse(row["STATUS"].ToString()),
                                                                       row["VENUE"].ToString()
                                                                  );

                lstAppointmentEvents.Add(objAppointment);

                if (tblAppointee.Rows.Count > 0)
                {
                    objAppointment.LstAppointee = SetAppointee(row);
                }

                return lstAppointmentEvents;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public static List<ATTAppointee> SetAppointee(DataRow appRow)
        {
            try
            {
                List<ATTAppointee> lstAppointee = new List<ATTAppointee>();
                foreach (DataRow row in tblAppointee.Rows)
                {
                    if (int.Parse(appRow["ORG_ID"].ToString()) == int.Parse(row["ORG_ID"].ToString()) &&
                        int.Parse(appRow["APPOINTMENT_ID"].ToString()) == int.Parse(row["APPOINTMENT_ID"].ToString())
                       )
                    {
                       
                        int? appointeeID ;
                        string appointee = "";
                        string outdoorAppointeeOrgName ;

                        if (row["APPOINTEE_ID"].ToString() != "")
                        {
                            appointeeID = int.Parse(row["APPOINTEE_ID"].ToString());
                            appointee = row["FIRST_NAME"].ToString() +
                                       (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                       (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString());

                            outdoorAppointeeOrgName = "";
                        }
                        else
                        {
                            appointeeID = null;
                            appointee = row["OUTDOOR_APPOINTEE_NAME"].ToString();
                            outdoorAppointeeOrgName = row["OUTDOOR_APPOINTEE_ORG_NAME"].ToString();
                        }

                        ATTAppointee objAppointee = new ATTAppointee();
                        objAppointee.OrgID = int.Parse(row["ORG_ID"].ToString());
                        objAppointee.AppointmentID = int.Parse(row["APPOINTMENT_ID"].ToString());
                        objAppointee.ApID = int.Parse(row["AP_ID"].ToString());
                        objAppointee.AppointeeID = appointeeID;
                        objAppointee.Appointee = appointee;  
                        objAppointee.IsIndoorAppointee = row["IS_INDOOR_APPOINTEE"].ToString();
                        objAppointee.Action = "N";
                        objAppointee.OutdoorOrgName = outdoorAppointeeOrgName;
                        objAppointee.EntryOn = DateTime.Parse(row["ENTRY_ON"].ToString());
                        objAppointee.Flag = row["flag"].ToString();
                        objAppointee.Remark = row["remark"].ToString();
                       
                        lstAppointee.Add(objAppointee);
                    }
                 }
                return lstAppointee;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    }
}
