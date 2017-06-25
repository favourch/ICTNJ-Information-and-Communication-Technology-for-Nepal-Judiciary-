using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
    public class DLLAnnualHoliday
    {
        public static DataTable GetAnnHoliday(string year)
        {
            string selectCmd = "SP_GET_CUR_ANNUAL_HOLIDAYS";
            OracleParameter[] paramArray = new OracleParameter[2];

            paramArray[0] = Utilities.GetOraParam("P_FY", year, OracleDbType.Int32, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectCmd, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAnnHolidayPrev()
        {
            string selectCmd = "SP_GET_OT_ANNUAL_HOLIDAYS";
            OracleParameter[] paramArray = new OracleParameter[1];
            paramArray[0] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectCmd, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetMonthlyHolidays(string fromdate,string todate)
        {
            string selectCmd = "SP_GET_MONTHLY_HOLIDAYS";
            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0]=Utilities.GetOraParam("P_FROM_DATE",fromdate,OracleDbType.Varchar2,ParameterDirection.Input);
            paramArray[1]=Utilities.GetOraParam("P_TO_DATE",todate,OracleDbType.Varchar2,ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam("P_OUT_MSG", null, OracleDbType.Varchar2, ParameterDirection.Output);
            paramArray[2].Size = 100;
            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(); 
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, selectCmd, paramArray);
                return paramArray[2].Value.ToString();
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectCmd,Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static bool SaveAnnualHoliday(List<ATTAnnualHoliday> LSTAnn)
        {
            GetConnection conn = new GetConnection();
            OracleConnection dbconn;
            string InsertSQL = "";
            try
            {
                dbconn = conn.GetDbConn(Module.PMS);
                foreach (ATTAnnualHoliday var in LSTAnn)
                {
                    if (var.Action == "A")
                    {
                        InsertSQL = "SP_ADD_ANNUAL_HOLIDAYS";
                    }
                    else if (var.Action == "D")
                    {
                        InsertSQL = "SP_DEL_ANNUAL_HOLIDAYS";
                    }
                    if (var.Action == "A" || var.Action == "D")
                    {
                        OracleParameter[] paramArray = new OracleParameter[7];
                        paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", var.OrgID, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_FY", var.FY, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_HOLIDAY_DESC", var.HolidayDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":P_FROM_DATE ", var.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_TO_DATE ", var.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_DATE_TYPE", var.DateType, OracleDbType.Varchar2, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(dbconn, CommandType.StoredProcedure, InsertSQL, paramArray);
                        var.Action = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return true;
        }
    }
}
