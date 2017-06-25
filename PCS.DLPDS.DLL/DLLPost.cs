using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.DLPDS.ATT;

namespace PCS.DLPDS.DLL
{
   public class DLLPost
    {
        public static DataTable GetPost(int? PostId)
        {
            try
            {
                string SelectPostSql = "SP_GET_POST";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_POST_ID", PostId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectPostSql, Module.DLPDS, ParamArray);
                
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool SavePost(ATTPost ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string InsertUpdatePostSql = "";
            try
            {
                DBConn = Conn.GetDbConn(Module.DLPDS);
                Tran = DBConn.BeginTransaction();

                if (ObjAtt.PostID == 0)
                    InsertUpdatePostSql = "SP_ADD_POST";
                else
                    InsertUpdatePostSql = "SP_EDIT_POST";

                OracleParameter[] ParamArray = new OracleParameter[2];

                ParamArray[0] = Utilities.GetOraParam(":p_POST_ID", ObjAtt.PostID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_POST_NAME", ObjAtt.PostName, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostSql, ParamArray);


                int PostID = int.Parse(ParamArray[0].Value.ToString());

                ObjAtt.PostID = PostID;
                
                DLLPostLevel.SavePostLevel(ObjAtt.LstPostLevel, Tran, PostID);

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


        public static bool DeletePost(int PostID)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            OracleTransaction Tran;
            string DeletePostSql = "SP_DEL_POST ";

            try
            {
                DBConn = Conn.GetDbConn(Module.DLPDS);
                Tran = DBConn.BeginTransaction();

                OracleParameter[] ParamArray = new OracleParameter[1];

                ParamArray[0] = Utilities.GetOraParam(":p_POST_ID", PostID, OracleDbType.Int64, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeletePostSql, ParamArray);
                Tran.Commit();

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
