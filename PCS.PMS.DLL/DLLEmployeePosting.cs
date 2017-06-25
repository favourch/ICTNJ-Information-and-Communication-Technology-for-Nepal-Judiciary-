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
    public class DLLEmployeePosting
    {
        public static bool SaveEmployeePosting(List<ATTEmployeePosting> lstEmployeePosting, OracleTransaction Tran, double empID)
        {
            try
            {
                foreach (ATTEmployeePosting lst in lstEmployeePosting)
                {
                    OracleParameter[] paramArray = new OracleParameter[18];
                    paramArray[0] = Utilities.GetOraParam(":p_EMP_ID", empID, OracleDbType.Double, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_ORG_ID", lst.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_DES_ID", lst.DesID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":p_CREATED_DATE", lst.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_POST_ID", lst.PostID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_FROM_DATE", lst.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":p_TO_DATE", lst.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":p_JOINING_DATE", lst.JoiningDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[8] = Utilities.GetOraParam(":p_DECISION_DATE", lst.DecisionDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":p_LEAVE_DATE", lst.LeaveDate, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[10] = Utilities.GetOraParam(":p_POSTING_TYPE_ID", lst.PostingTypeID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[11] = Utilities.GetOraParam(":p_EMP_POSTING_SALARY", lst.EmpSalary, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[12] = Utilities.GetOraParam(":p_EMP_POSTING_ALLOWANCE", lst.EmpAllowance, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[13] = Utilities.GetOraParam(":p_EMP_POSTING_KITAAB_DARTA_NO", lst.EmpKitaabDartaNo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[14] = Utilities.GetOraParam(":p_EMP_POSTING_REMARKS", lst.EmpPostingRemarks, OracleDbType.Varchar2, ParameterDirection.Input);
                    if (lst.PostingAttachmentDocs != null && lst.PostingAttachmentDocs.Length>0)
                        paramArray[15] = Utilities.GetOraParam(":p_ATTACHMENT", lst.PostingAttachmentDocs, OracleDbType.Blob, ParameterDirection.Input);
                    else
                        paramArray[15] = Utilities.GetOraParam(":p_ATTACHMENT", null, OracleDbType.Blob, ParameterDirection.Input);
                    
                    paramArray[16] = Utilities.GetOraParam(":p_ATTACHMENT_FILE_NAME", lst.PostingAttachmentContent, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[17] = Utilities.GetOraParam(":p_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                    if (lst.Action == "A")
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_EMP_POSTINGS", paramArray);
                    else if (lst.Action == "E")
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_EMP_POSTINGS", paramArray);
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

        public static DataTable GetEmployeePosting(double empId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_EMP_POSTINGS";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetEmployeeAllPosting(double empId, object obj)
        {
            try
            {
                string SelectSql = "SP_GET_EMP_POSTINGS";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
                ParamArray[2] = Utilities.GetOraParam(":DEFAULT_VALUE", 1, OracleDbType.Int64, ParameterDirection.Input);

                //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDesignationSql, Module.PMS, ParamArray);
                DataSet ds = SqlHelper.ExecuteDataset((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string GetEmployeeCurrentPosting(double empId)
        {
            try
            {
                GetConnection Conn = new GetConnection();
                OracleConnection DBConn;
                DBConn = Conn.GetDbConn(Module.PMS);
                object obj = DBConn;

                string SelectSql = "SP_GET_EMP_CURRENT_POST";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_DES_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[2] = Utilities.GetOraParam(":P_DES_NAME", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[2].Size = 100;


                SqlHelper.ExecuteNonQuery((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);

                int DesgID = int.Parse(ParamArray[1].Value.ToString());
                string DesName = ParamArray[2].Value.ToString();

                return DesgID.ToString() + " " + DesName;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetEmployeeWithPostingListTable(int? orgID)
        {

            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT ORG_ID,P_ID,FIRST_NAME,MID_NAME,SUR_NAME,DES_ID,DES_NAME " +
                                   " FROM vw_employee_with_posting";


                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
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

        public static DataTable GetEmployeePostingHistory(int empID, int? orgID)
        {

            GetConnection GetConn = new GetConnection();

            try
            {
                string selectSQL = " SELECT EMP_ID,ORG_ID,ORG_NAME,DES_ID,DES_NAME,POSTING_TYPE_ID,POSTING_TYPE_NAME,FROM_DATE,CREATED_DATE,POST_ID " +
                                   " FROM VW_EMP_POSTING_HISTORY WHERE EMP_ID=" + empID;
                if (orgID != null)
                {
                    selectSQL = selectSQL + " AND ORG_ID=" + orgID;
                }

                OracleConnection DBConn = GetConn.GetDbConn(Module.PMS);
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

        public static string GetEmployeeCurrentPostingAllInfo(double empId)
        {
            //GetEmployeeCurrentPostingAllInfo added by shanjeev sah
            try
            {
                GetConnection Conn = new GetConnection();
                OracleConnection DBConn;
                DBConn = Conn.GetDbConn(Module.PMS);
                object obj = DBConn;


                string SelectSql = "sp_get_emp_current_post_info";

                OracleParameter[] ParamArray = new OracleParameter[9];
                ParamArray[0] = Utilities.GetOraParam(":p_EMP_ID", empId, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_org_id", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1].Size = 3;
                ParamArray[2] = Utilities.GetOraParam(":p_org_name", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[2].Size = 100;
                ParamArray[3] = Utilities.GetOraParam(":P_DES_ID", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[3].Size = 3;
                ParamArray[4] = Utilities.GetOraParam(":p_des_name", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[4].Size = 30;
                ParamArray[5] = Utilities.GetOraParam(":p_created_date", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[5].Size = 10;
                ParamArray[6] = Utilities.GetOraParam(":p_post_id", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[6].Size = 3;
                ParamArray[7] = Utilities.GetOraParam(":p_post_name", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[7].Size = 30;
                ParamArray[8] = Utilities.GetOraParam(":p_from_date", null, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[8].Size = 10;

                SqlHelper.ExecuteNonQuery((OracleConnection)obj, CommandType.StoredProcedure, SelectSql, ParamArray);

                int orgID = 0;
                int desgID = 0;
                int postID = 0;
                string orgName = "";
                string desName = "";
                string postName = "";
                if (ParamArray[1].Value.ToString() != "null")
                {
                    orgID = int.Parse(ParamArray[1].Value.ToString());
                    orgName = ParamArray[2].Value.ToString();
                }

                if (ParamArray[3].Value.ToString() != "null")
                {
                    desgID = int.Parse(ParamArray[3].Value.ToString());
                    desName = ParamArray[4].Value.ToString();
                }

                string createdDate = ParamArray[5].Value.ToString();
                if (ParamArray[4].Value.ToString() != "null")
                {
                    postID = int.Parse(ParamArray[6].Value.ToString());
                    postName = ParamArray[7].Value.ToString();
                }

                string fromDate = ParamArray[8].Value.ToString();

                return orgID.ToString() + "#" + orgName + "#" + desgID.ToString() + "#" + desName + "#" + createdDate + "#" + postID.ToString() + "#" + postName + "#" + fromDate;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }   
}