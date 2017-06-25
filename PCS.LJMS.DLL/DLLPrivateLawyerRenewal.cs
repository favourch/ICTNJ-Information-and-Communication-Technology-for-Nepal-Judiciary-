using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.LJMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.LJMS.DLL
{
    public class DLLPrivateLawyerRenewal
    {
        public static bool AddPrivateLawyerReenwalList(List<ATTPrivateLawyerRenewal> lst, OracleTransaction Tran, double PID)
        {
            string SP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTPrivateLawyerRenewal renewal in lst)
                {
                    if (renewal.Action == "A")
                        SP = "SP_ADD_P_LAWYER_RENEWAL";
                    else if (renewal.Action == "E")
                        SP = "SP_EDIT_P_LAWYER_RENEWAL";
                    else if (renewal.Action == "D")
                        SP = "";

                    paramArray.Add(Utilities.GetOraParam("P_P_ID", PID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LAWYER_TYPE_ID", renewal.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LICENSE_NO", renewal.Lisence, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_UNIT_ID", renewal.UnitID, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", renewal.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_Renewal_DATE", renewal.RenewalDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_Renewal_upto", renewal.RenewalUpto, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", renewal.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (SP != "")
                    {
                       SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                       SP = "";
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

        public static DataTable GetPrivateLawyerRenewal(double PID)
        {
            string SP = "SP_GET_PRIVATE_LAWYER_renewal";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_p_id", PID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.LJMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPrivateLawyerRenewalDetailsTable(double PID)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT DISTINCT P_ID,LAWYER_TYPE_ID,LICENSE_NO,UNIT_ID,unit_name,P_RENEWAL_DATE,P_RENEWAL_UPTO,P_FROM_DATE FROM vw_lawyer_info_details " +
                                   " WHERE P_FROM_DATE IS NOT NULL AND UNIT_ID IS NOT NULL and P_RENEWAL_DATE IS NOT NULL AND P_RENEWAL_UPTO IS NOT NULL ";

                if (PID > 0)
                {
                    selectSQL += " AND P_ID = " + PID;
                }

                OracleConnection DBConn = GetConn.GetDbConn(Module.LJMS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, selectSQL);

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
                GetConn.CloseDbConn();
            }
        }
    }
}
