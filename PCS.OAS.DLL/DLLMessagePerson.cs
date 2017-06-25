using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.OAS.DLL
{
    public class DLLMessagePerson
    {
        public static DataTable GetMessagePersonListTable(int? orgID,int? unitID, string searchValue)
        {
            GetConnection Conn = new GetConnection();
            try
            {
                string selectSQL;

                if (orgID != null && unitID != null)
                    selectSQL = "SELECT EMP_ID,FIRST_NAME,MID_NAME,SUR_NAME FROM VW_EMP_WORK_DISTRIBUTION WHERE ORG_ID =" + orgID + " AND ORG_UNIT_ID = " + unitID;
                else if (orgID != null)
                    selectSQL = "SELECT EMP_ID,FIRST_NAME,MID_NAME,SUR_NAME FROM VW_EMP_WORK_DISTRIBUTION WHERE ORG_ID =" + orgID;
                else
                    selectSQL = "SELECT EMP_ID,FIRST_NAME,MID_NAME,SUR_NAME FROM VW_EMP_WORK_DISTRIBUTION WHERE 1 = 1 ";

                if (searchValue.Trim() != "")
                    selectSQL += " AND FIRST_NAME LIKE '" + searchValue + "%'";

                selectSQL += " ORDER BY FIRST_NAME ASC ";
                
                OracleConnection DBConn = Conn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text,selectSQL);

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
