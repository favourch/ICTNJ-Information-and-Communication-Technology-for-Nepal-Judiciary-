using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.PMS.DLL
{
    public class DLLEmployeeVisits
    {
        public static DataTable GetEmployeeVisit(double empId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_EMP_VISITS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj,CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static bool AddEmployeeVisits(List<ATTEmployeeVisits> lstEmployeeVisits, OracleTransaction Tran, double empID)
        {
            try
            {
                foreach (ATTEmployeeVisits lst in lstEmployeeVisits)
                {
                    if (lst.Action == "D")
                    {
                        OracleParameter[] deleteparamArray = new OracleParameter[2];
                        deleteparamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empID, OracleDbType.Double, ParameterDirection.Input);
                        deleteparamArray[1] = Utilities.GetOraParam(":p_SEQ_NO", lst.SeqNo, OracleDbType.Int64, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_EMP_VISITS", deleteparamArray);
                    }
                    else
                    {
                        OracleParameter[] paramArray = new OracleParameter[10];
                        paramArray[0] = Utilities.GetOraParam(":P_EMP_ID", empID, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[1] = Utilities.GetOraParam(":P_SEQ_NO", lst.SeqNo, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[2] = Utilities.GetOraParam(":P_PURPOSE", lst.Purpose, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[3] = Utilities.GetOraParam(":P_LOCATION", lst.Location, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[4] = Utilities.GetOraParam(":P_COUNTRY", lst.Country, OracleDbType.Int64, ParameterDirection.Input);
                        paramArray[5] = Utilities.GetOraParam(":P_FROM_DATE", lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[6] = Utilities.GetOraParam(":P_TO_DATE", lst.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":P_REMARKS", lst.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":P_VEHICLE", lst.Vehicle, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);


                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_EMP_VISITS", paramArray);
                        else if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_EMP_VISITS", paramArray);
                    }
                }
                return true;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
