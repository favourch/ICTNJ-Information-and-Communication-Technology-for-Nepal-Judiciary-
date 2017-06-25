using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.COREDL;
using Oracle.DataAccess.Client;

namespace PCS.PMS.DLL
{
    public class DLLVwEmpRelativeBeneficiary
    {
        public static DataTable GetEmpRelativeBeneficiary(double empID,object obj)
        {
            string strSelectSQL = "SELECT * FROM VW_EMP_RELATIVE_BENEFICIARY WHERE P_ID=" + empID;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.Text, strSelectSQL);
                return (DataTable)ds.Tables[0];
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
