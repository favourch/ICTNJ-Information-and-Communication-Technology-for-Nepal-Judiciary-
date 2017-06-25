using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;

namespace PCS.COMMON.DLL
{
    public class DLLTime
    {
        public static string GetCurrentTime()
        {
            GetConnection GetConn = new GetConnection();
            string time = "";
            string sql = "";
            char[] token ={ '/' };

            try
            {
                sql = "select to_char(sysdate,'hh24:mi:ss ') from dual";
                OracleConnection DBConn = GetConn.GetDbConn();
                //.Replace(":", "/")
                time = SqlHelper.ExecuteScalar(DBConn, CommandType.Text, sql).ToString().Replace(":","/");
                
                return time;
            }
            catch (System.Exception ex)
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
