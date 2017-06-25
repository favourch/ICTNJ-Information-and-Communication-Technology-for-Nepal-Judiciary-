using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace PCS.PMS.DLL
{
    public class DLLPost
    {
        public static bool SavePosts(List<ATTPost> lstPost, string CreatedDate, OracleTransaction Tran)
        {
            string InsertUpdateDeleteSql = "";

            try
            {
                foreach (ATTPost lst in lstPost)
                {
                    if (lst.Action != "D")
                    {
                        OracleParameter[] ParamArray = new OracleParameter[7];
                        ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", lst.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":p_DES_ID", lst.DesID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = Utilities.GetOraParam(":p_CREATED_DATE", CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":p_POST_ID", lst.PostID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[4] = Utilities.GetOraParam(":p_POST_NAME", lst.PostName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[5] = Utilities.GetOraParam(":p_OCCUPIED", lst.Occupied, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = Utilities.GetOraParam(":p_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                        if (lst.Action == "A")
                            InsertUpdateDeleteSql = "SP_ADD_ORG_POSTS";
                        else if (lst.Action == "E")
                            InsertUpdateDeleteSql = "SP_EDIT_ORG_POSTS";
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSql, ParamArray);
                    }
                    else
                    {
                        InsertUpdateDeleteSql = "SP_DEL_ORG_POSTS";
                        OracleParameter[] DeleteParamArray = new OracleParameter[4];
                        DeleteParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", lst.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        DeleteParamArray[1] = Utilities.GetOraParam(":p_DES_ID", lst.DesID, OracleDbType.Int64, ParameterDirection.Input);
                        DeleteParamArray[2] = Utilities.GetOraParam(":p_CREATED_DATE", lst.CreatedDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        DeleteParamArray[3] = Utilities.GetOraParam(":p_POST_ID", lst.PostID, OracleDbType.Int64, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSql, DeleteParamArray);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetOrganizationPosts(int? orgID, int? desID, string createdDate)
        {
            string SelectSql = "SP_GET_ORG_POSTS";
            try
            {
                OracleParameter[] ParamArray = new OracleParameter[4];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_CREATED_DATE", createdDate, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetOrgAvailableDesgPost(int? orgID, int? desID, string availablePost, string desType)
        {
            string SelectSql = "SP_GET_ORG_AVAILABLE_POSTS";
            try
            {
                OracleParameter[] ParamArray = new OracleParameter[5];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_OCCUPIED", availablePost, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_DES_TYPE", desType, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetAllDesgPost(int? orgID, int? desID, string created_date)
        {
            string SelectSql = "SP_GET_ORG_POSTS";
            try
            {
                OracleParameter[] ParamArray = new OracleParameter[4];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_CREATED_DATE", created_date, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
