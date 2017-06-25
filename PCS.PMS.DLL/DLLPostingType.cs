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
    public class DLLPostingType
    {
        public static DataTable GetPostingType(int? PostingTypeId, string active)
        {
            try
            {
                string SelectPostingTypeSql = "SP_GET_POSTING_TYPES";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_POSTING_TYPE_ID", PostingTypeId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectPostingTypeSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool SavePostingType(ATTPostingType ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string InsertUpdatePostingType = "";
            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();

                if (ObjAtt.PostingTypeID == 0)
                    InsertUpdatePostingType = "SP_ADD_POSTING_TYPES";
                else
                    InsertUpdatePostingType = "SP_EDIT_POSTING_TYPES";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_POSTING_TYPE_ID", ObjAtt.PostingTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_POSTING_TYPE_NAME", ObjAtt.PostingTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_ACTIVE", ObjAtt.Active, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostingType, ParamArray);
                int PostingTypeID = int.Parse(ParamArray[0].Value.ToString());
                ObjAtt.PostingTypeID = PostingTypeID;
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


        public static bool DeletePostingType(int PostingTypeID)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string DeletePostingTypeSql = "SP_DEL_POSTING_TYPES";

            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);
                Tran = DBConn.BeginTransaction();

                OracleParameter[] ParamArray = new OracleParameter[1];
                ParamArray[0] = Utilities.GetOraParam(":p_POSTING_TYPE_ID", PostingTypeID, OracleDbType.Int64, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeletePostingTypeSql, ParamArray);
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
    }
}