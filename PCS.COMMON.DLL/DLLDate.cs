using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using Oracle.DataAccess.Client;
using PCS.COMMON.ATT;

namespace PCS.COMMON.DLL
{
    public class DLLDate
    {

        public static DataTable GetMaxMinYear()
        {
            string SPSelect = "SP_GET_MIN_MAX_YEAR";

            try
            {
                OracleParameter[] paramArray = new OracleParameter[1];
                paramArray[0] = PCS.FRAMEWORK.Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SPSelect, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetDateString(int Year, int Month, string LP)
        {
            string SToReturn = "";
            char[] token ={ '/' };

            if (LP == "_N")
            {
                GetConnection GetConn = new GetConnection();

                try
                {
                    SToReturn = Year.ToString() + "/" + Month.ToString() + "/" + "1/";
                    if (Year == 0 && Month == 0)
                    {
                        OracleConnection DBConn = GetConn.GetDbConn();

                        SToReturn = SqlHelper.ExecuteScalar(DBConn, CommandType.Text, "SELECT LIB_ETON(SYSDATE) FROM DUAL").ToString().Replace(".", "/") + "/";
                        Year = int.Parse(SToReturn.Split(token)[0]);
                        Month = int.Parse(SToReturn.Split(token)[1]);
                    }

                    DataTable tbl = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM SYS_NDATE WHERE NYEAR=" + Year.ToString()).Tables[0];
                    int Totaldays = 0;

                    for (int i = 1; i <= Month - 1; i++)
                        Totaldays += int.Parse(tbl.Rows[0]["M" + i.ToString()].ToString());

                    DateTime CurrentDateUSM = DateTime.Parse(tbl.Rows[0]["ST_DATE"].ToString()).AddDays(Totaldays);
                    int StartIndex = 0;

                    switch (CurrentDateUSM.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            StartIndex = 1;
                            break;
                        case "Monday":
                            StartIndex = 2;
                            break;
                        case "Tuesday":
                            StartIndex = 3;
                            break;
                        case "Wednesday":
                            StartIndex = 4;
                            break;
                        case "Thursday":
                            StartIndex = 5;
                            break;
                        case "Friday":
                            StartIndex = 6;
                            break;
                        case "Saturday":
                            StartIndex = 7;
                            break;
                    }

                    return SToReturn + StartIndex.ToString() + "/" + tbl.Rows[0]["M" + Month.ToString()].ToString();

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

            return "";
            //else
            //{
            //}
        }

        public static string getNepDate()
        {
            PCS.COREDL.GetConnection GetCon = new PCS.COREDL.GetConnection();
            OracleConnection DBConn;

            string SPSelect = "SP_GET_NEP_DATE";

            try
            {
                DBConn = GetCon.GetDbConn();

                OracleParameter[] paramArray = new OracleParameter[2];
                //OracleDbType
                paramArray[0] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_e_date", null, OracleDbType.Date, ParameterDirection.Input);
                paramArray[1] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_n_date", null, OracleDbType.Varchar2, ParameterDirection.Output);
                paramArray[1].Size = 100;
                PCS.COREDL.SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SPSelect, paramArray);
                return paramArray[1].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetCon.CloseDbConn();
            }
        }

        public static string getEngDate()
        {
            PCS.COREDL.GetConnection GetCon = new PCS.COREDL.GetConnection();
            OracleConnection DBConn;

            string SPSelect = "SP_GET_ENG_DATE";

            try
            {
                DBConn = GetCon.GetDbConn();

                OracleParameter[] paramArray = new OracleParameter[2];
                //OracleDbType
                paramArray[0] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_n_date", null, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[1] = PCS.FRAMEWORK.Utilities.GetOraParam(":p_E_date", null, OracleDbType.Date, ParameterDirection.Output);
                paramArray[0].Size = 10;
                PCS.COREDL.SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SPSelect, paramArray);
                return paramArray[1].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetCon.CloseDbConn();
            }
        }

    }
}
