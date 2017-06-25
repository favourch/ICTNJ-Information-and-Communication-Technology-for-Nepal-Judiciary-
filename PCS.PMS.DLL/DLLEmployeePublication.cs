using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.COMMON.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using System.Data;

namespace PCS.PMS.DLL
{
    public class DLLEmployeePublication
    {
        public static bool AddEmployeePublication(List<ATTEmployeePublication> lst, OracleTransaction Tran, double EmpID)
        {
            string SP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTEmployeePublication pub in lst)
                {
                    if (pub.Action == "A")
                        SP = "SP_ADD_EMP_PUBLICATION";
                    else if (pub.Action == "E")
                        SP = "SP_EDIT_EMP_PUBLICATION";
                    else if (pub.Action == "D")
                        SP = "SP_DEL_EMP_PUBLICATION";

                    if (pub.Action == "A" || pub.Action == "E")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUB_ID", pub.PublicationID, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("P_PUBLICATION", pub.PublicationName, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUBLISHER_ORG", pub.Publisher, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUB_DATE", pub.PublicationDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUB_TYPE_ID", pub.PubTypeID, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("P_REMARKS", pub.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", pub.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    }       

                    if (pub.Action == "D")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_EMP_ID", EmpID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_PUB_ID", pub.PublicationID, OracleDbType.Int64, ParameterDirection.InputOutput));
                    }

                    if (pub.Action != "N")
                    {
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                    } 
                    paramArray.Clear();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmployeePublication(double empId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_EMP_PUBLICATION";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
