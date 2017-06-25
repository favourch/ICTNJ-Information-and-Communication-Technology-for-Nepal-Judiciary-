using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLPropertyIncome
    {
        public static bool SavePropertyIncome(List<ATTPropertyIncome> lstPInc, OracleTransaction Tran)
        {
            try
            {
                string SaveSQL = "SP_ADD_PROPERTYINCOME";
                foreach (ATTPropertyIncome objPInc in lstPInc)
                {

                    OracleParameter[] paramArray = new OracleParameter[6];
                    paramArray[0] = Utilities.GetOraParam(":p_EMP_ID",objPInc.EmpID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_PCAT_ID",objPInc.PCatID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_SUB_DATE",objPInc.SubDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":P_PINC_ID",null, OracleDbType.Int64, ParameterDirection.InputOutput);
                    paramArray[4] = Utilities.GetOraParam(":p_YEAR",objPInc.Year, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_AMOUNT",objPInc.Amount, OracleDbType.Int64, ParameterDirection.Input);
                  
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveSQL, paramArray);
                    //P_PINC_ID
                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
