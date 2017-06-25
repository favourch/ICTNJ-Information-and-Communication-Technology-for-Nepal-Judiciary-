using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PCS.COMMON.DLL
{
    public class DLLFixedHoliday
    {
        public static DataTable GetYear()
        {
            string selectCmd = "SP_GET_YEAR";
            OracleParameter[] paramArray = new OracleParameter[1];

            paramArray[0] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectCmd, Module.PMS, paramArray).Tables[0];
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetFixedHolidays()
        {
            string selectCmd = "SP_GET_FIXED_HOLIDAY";
            OracleParameter[] paramArray = new OracleParameter[1];

            paramArray[0] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectCmd, Module.PMS, paramArray).Tables[0];
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveFixedHoliday(List<ATTFixedHoliday> LSTFix)
        {
           GetConnection conn = new GetConnection();
           OracleConnection dbconn;
           string InsertSQL = "";
           try
           {
               dbconn = conn.GetDbConn(Module.PMS);
               foreach (ATTFixedHoliday var in LSTFix)
               {
                   if (var.Action == "A")
                   {
                       InsertSQL = "SP_ADD_FIXED_HOLIDAY";
                   }
                   else if (var.Action == "D")
                   {
                       InsertSQL = "SP_DEL_FIXED_HOLIDAY";
                   }
                   if (var.Action == "A" || var.Action == "D")
                   {
                       OracleParameter[] paramArray = new OracleParameter[7];
                       paramArray[0] = Utilities.GetOraParam(":P_HOLIDAY_DESC", var.HolidayDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                       paramArray[1] = Utilities.GetOraParam(":P_FROM_MONTH", var.FromMonth, OracleDbType.Varchar2, ParameterDirection.Input);
                       paramArray[2] = Utilities.GetOraParam(": P_FROM_DAY", var.FromDay, OracleDbType.Varchar2, ParameterDirection.Input);
                       paramArray[3] = Utilities.GetOraParam(":P_TO_MONTH", var.ToMonth, OracleDbType.Varchar2, ParameterDirection.Input);
                       paramArray[4] = Utilities.GetOraParam(":P_TO_DAY ", var.ToDay, OracleDbType.Varchar2, ParameterDirection.Input);
                       paramArray[5] = Utilities.GetOraParam(":P_DATE_TYPE", var.DateType, OracleDbType.Varchar2, ParameterDirection.Input);
                       paramArray[6] = Utilities.GetOraParam(": P_ENTRY_BY", var.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
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
