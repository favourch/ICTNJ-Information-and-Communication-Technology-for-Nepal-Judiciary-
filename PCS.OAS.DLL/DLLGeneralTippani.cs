using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;

namespace PCS.OAS.DLL
{
    public class DLLGeneralTippani
    {
        public static object GetConnection()
        {
            try
            {
                return new GetConnection().GetDbConn(Module.OAS) as object;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CloseConnection(object conn)
        {
            (conn as OracleConnection).Close();
            (conn as OracleConnection).Dispose();
            return true;
        }

        public static object BeginTransaction(object conn)
        {
            try
            {
                return (conn as OracleConnection).BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CommitTransaction(object tran)
        {
            try
            {
                (tran as OracleTransaction).Commit();
                (tran as OracleTransaction).Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool RollbackTransaction(object tran)
        {
            try
            {
                (tran as OracleTransaction).Rollback();
                (tran as OracleTransaction).Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTippaniDetail(int orgID, int tippaniID)
        {
            string SP = "sp_get_tippani_detail";
            
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_org_id", orgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_tippani_id", tippaniID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                DataTable tbl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.OAS, paramArray.ToArray()).Tables[0];
                return tbl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetDateDifference(string NepaliToDate, string NepaliFromDate)
        {
            GetConnection DBConn = new GetConnection();
            string SQL = "select get_date_diff('" + NepaliToDate + "','" + NepaliFromDate + "') from dual";
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);

                object o = SqlHelper.ExecuteScalar(Conn, CommandType.Text, SQL);

                return int.Parse(o.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static bool AddGeneralTippani(ATTGeneralTippani tippani, object tran)
        {
            string SP = "";

            if (tippani.Action == "A")
                SP = "SP_ADD_TIPPANI";
            else if (tippani.Action == "E")
                SP = "SP_EDIT_TIPPANI";
            else if (tippani.Action == "D")
                SP = "";

            List<OracleParameter> paramArray=new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", tippani.OrgID, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ID", tippani.TippaniID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_SUBJECT_ID", tippani.TippaniSubjectID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_BY", tippani.TippaniBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_ON", tippani.TippaniOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_TIPPANI_TEXT", tippani.TippaniText, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_FILE_NO", tippani.FileNo, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_PRIORITY_ID", tippani.PriorityID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_CREATED_BY", tippani.CreatedBy, OracleDbType.Double, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_msg_org_id", tippani.MsgOrgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_msg_id", tippani.MsgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_dar_org_id", tippani.DarOrgID, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_dar_org_id", tippani.DarRegDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_dar_reg_no", tippani.DarRegNo, OracleDbType.Int16, ParameterDirection.Input));

            try
            {
                SqlHelper.ExecuteNonQuery(tran as OracleTransaction, CommandType.StoredProcedure, SP, paramArray.ToArray());
                tippani.TippaniID = int.Parse(paramArray[1].Value.ToString());

                paramArray.Clear();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetGeneralTippaniInfo(ATTGeneralTippaniRequestInfo info, int sIndex, int eIndex, ref decimal totalRecord)
        {
            string TempSP = "select * from VW_TIPPANI_INFO where 1 = 1 ";
            string CountSP = "select count(*) from VW_TIPPANI_INFO where 1 = 1 ";
            string SP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (info.OrgID > 0)
                SP = SP + " and emp_org_id = " + info.OrgID;

            if (info.TippaniSubjectID > 0)
                SP = SP + " and tippani_subject_id = " + info.TippaniSubjectID.ToString();

            if (info.FromDate != "")
            {
                SP = SP + " and tippani_on >= :fromdate";
                paramArray.Add(Utilities.GetOraParam(":fromdate", info.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (info.ToDate != "")
            {
                SP = SP + " and tippani_on <= :todate";
                paramArray.Add(Utilities.GetOraParam(":todate", info.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
            }

            if (info.TippaniStatusID > 0)
                SP = SP + " and Tippani_status_id = " + info.TippaniStatusID.ToString();

            if (info.ProcessBy != "")
            {
                SP = SP + " AND upper(p_name) LIKE :FName||'%'";
                paramArray.Add(Utilities.GetOraParam(":FName", info.ProcessBy.ToUpper(), OracleDbType.Varchar2, ParameterDirection.Input));
            }

            SP = SP + " order by org_id, tippani_id desc,tippani_on";

            OracleParameter[] param;
            if (paramArray.Count > 0)
                param = paramArray.ToArray();
            else
                param = null;

            GetConnection DBConn = new GetConnection();

            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.OAS);
                if (totalRecord > 0)
                {
                    totalRecord = (decimal)SqlHelper.ExecuteScalar(Conn, CommandType.Text, CountSP + SP, param);
                }
                return SqlHelper.ExecuteDataset(Conn, CommandType.Text, TempSP + SP, sIndex, eIndex, param).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }

        public static DataTable GetUnreadTippani(double empID, int subjectID)
        {
            string SQL = "select * from vw_unread_tippani where emp_id = " + empID.ToString();
            if (subjectID > 0)
            {
                //SQL = SQL + " and \"number\"";
            }
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SQL, Module.OAS, null).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
