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
    public class DLLOrganizationDesignation
    {
        public static bool SaveOrganizationDesignation(ATTOrganizationDesignation ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn = Conn.GetDbConn(Module.PMS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            string InsertUpdateSql = "";

            if (ObjAtt.Action == "A")
                InsertUpdateSql = "SP_ADD_ORG_DESIGNATIONS";
            else if (ObjAtt.Action=="E")
                InsertUpdateSql = "SP_EDIT_ORG_DESIGNATIONS";

            try
            {
                OracleParameter[] ParamArray = new OracleParameter[11];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", ObjAtt.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_DES_ID", ObjAtt.DesID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_CREATED_DATE", ObjAtt.CreatedDate, OracleDbType.Varchar2, ParameterDirection.InputOutput);
                ParamArray[3] = Utilities.GetOraParam(":p_PARENT_ORG", ObjAtt.ParentOrg, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":p_PARENT_DES", ObjAtt.ParentDes, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[5] = Utilities.GetOraParam(":p_TOT_SEATS", ObjAtt.TotalSeats, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[6] = Utilities.GetOraParam(":p_SEWA_ID", ObjAtt.SewaID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[7] = Utilities.GetOraParam(":p_SAMUHA_ID", ObjAtt.SamuhaID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[8] = Utilities.GetOraParam(":p_UPASAMUHA_ID", ObjAtt.UpaSamuhaID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[9] = Utilities.GetOraParam(":p_DESG_LEVEL_ID", ObjAtt.DesgLevelID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[10] = Utilities.GetOraParam(":p_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2].Size = 25;
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSql, ParamArray);
                ObjAtt.CreatedDate = ParamArray[2].Value.ToString();
                DLLPost.SavePosts(ObjAtt.LstPosts,ObjAtt.CreatedDate,Tran);
                Tran.Commit();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }
        }

        public static DataTable GetOrganizationDesignation(int? orgID, int? desID,string desType)
        {
            string SelectSql = "SP_GET_ORG_DESIGNATIONS";
            try
            {
                OracleParameter[] ParamArray = new OracleParameter[4];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_DES_ID", desID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_DES_TYPE", desType, OracleDbType.Varchar2, ParameterDirection.Input);
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
