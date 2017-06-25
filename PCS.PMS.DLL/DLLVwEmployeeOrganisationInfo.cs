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
    public class DLLVwEmployeeOrganisationInfo
    {
        public static DataTable GetEmployeeOrganisationInfoListTable(int? empID)
        {
            GetConnection Conn = new GetConnection();
            try
            {
                string SelectSQL;

                if (empID != null)
                    //SelectSQL = "SELECT * FROM vw_employee_organisation_info WHERE EMP_ID =" + empID;
                    //SelectSQL = "SELECT * FROM VW_EMP_POSTING WHERE EMP_ID =" + 86;
                    SelectSQL = "SELECT * FROM VW_EMP_POSTING WHERE EMP_ID =" + empID;
                else
                    SelectSQL = "SELECT * FROM VW_EMP_POSTING";
                
                
                //OracleConnection DBConn = Conn.GetDbConn("PMS_ADMIN", "PMS_ADMIN");
                OracleConnection DBConn = Conn.GetDbConn(Module.PMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSQL);

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
                Conn.CloseDbConn();
            }

        }
    }
}
