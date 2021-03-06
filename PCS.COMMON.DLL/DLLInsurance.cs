using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
    public class DLLInsurance
    {
        public static bool SaveEmpInsurance(List<ATTInsurance> LSTInsurance,OracleTransaction Tran,double empid)
        {
            //GetConnection conn = new GetConnection();
            //OracleConnection dbconn = conn.GetDbConn(Module.PMS);
            string InsertSQL = "SP_ADD_EMP_INSURANCE";
            try
            {
                foreach (ATTInsurance obj in LSTInsurance)
                {
                    OracleParameter[] paramArray = new OracleParameter[7];
                    paramArray[0] = Utilities.GetOraParam("P_EMP_ID", empid, OracleDbType.Int32, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam("P_SEQ_NO", obj.SeqNo, OracleDbType.Int32, ParameterDirection.InputOutput);
                    paramArray[2] = Utilities.GetOraParam("P_COMPANY_NAME", obj.CompanyName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam("P_INSURANCE_NO", obj.InsuranceNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam("P_FROM_DATE", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam("P_MATURITY_DATE", obj.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam("P_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertSQL, paramArray);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static DataTable GetEmpInsurance(double empId)
        {
            string SelectSQL="SP_GET_EMP_INSURANCE";

            OracleParameter[] paramArray=new OracleParameter[2];

            paramArray[0] = Utilities.GetOraParam("P_EMP_ID", empId, OracleDbType.Int32, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSQL, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
