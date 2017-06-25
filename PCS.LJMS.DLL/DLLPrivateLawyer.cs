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
    public class DLLPrivateLawyer
    {
        public static bool AddPrivateLawyerInfoList(List<ATTPrivateLawyer> lst, OracleTransaction Tran, double PID)
        {
            string SP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTPrivateLawyer lawyer in lst)
                {
                    if (lawyer.Action == "A")
                        SP = "SP_ADD_P_LAWYER_INFO";
                    else if (lawyer.Action == "E")
                        SP = "SP_EDIT_P_LAWYER_INFO";
                    else if (lawyer.Action == "D")
                        SP = "";

                    
                    if (SP != "")
                    {
                        paramArray.Add(Utilities.GetOraParam("P_P_ID", PID, OracleDbType.Double, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_LAWYER_TYPE_ID", lawyer.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_LICENSE_NO", lawyer.Lisence, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_UNIT_ID", lawyer.UnitID, OracleDbType.Int16, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", lawyer.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_TO_DATE", lawyer.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", lawyer.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                        SP = "";
                    }
                    paramArray.Clear();

                    if (lawyer.LstRenewal.Count > 0)
                    {
                        if (DLLPrivateLawyerRenewal.AddPrivateLawyerReenwalList(lawyer.LstRenewal, Tran, PID) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddPrivateLawyerInfoList(List<ATTPrivateLawyer> lst)
        {
            string SP = "";

            double PID = 213;

            GetConnection DBConn = new GetConnection();
            OracleConnection Conn = DBConn.GetDbConn(Module.LJMS);
            OracleTransaction Tran = Conn.BeginTransaction();

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTPrivateLawyer lawyer in lst)
                {
                    if (lawyer.Action == "A")
                        SP = "SP_ADD_P_LAWYER_INFO";
                    else if (lawyer.Action == "E")
                        SP = "SP_EDIT_P_LAWYER_INFO";
                    else if (lawyer.Action == "D")
                        SP = "";

                    paramArray.Add(Utilities.GetOraParam("P_P_ID", PID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LAWYER_TYPE_ID", lawyer.LawyerTypeID, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_LICENSE_NO", lawyer.Lisence, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_UNIT_ID", lawyer.UnitID, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", lawyer.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_TO_DATE", lawyer.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam("P_ENTRY_BY", lawyer.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());
                    paramArray.Clear();

                    DLLPrivateLawyerRenewal.AddPrivateLawyerReenwalList(lawyer.LstRenewal, Tran, PID);
                }
                Tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static DataTable GetPrivateLawyerInfo(double PID)
        {
            string SP = "SP_GET_PRIVATE_LAWYER_INFO";

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

        public static DataTable GetPrivateLawyerDetailsTable(double PID)
        {
            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT DISTINCT P_ID,LAWYER_TYPE_ID,lawyer_type_description,LICENSE_NO,P_FROM_DATE,UNIT_ID,unit_name FROM vw_lawyer_info_details " +
                                   " WHERE P_FROM_DATE IS NOT NULL AND UNIT_ID IS NOT NULL ";
               
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
