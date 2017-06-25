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
   public class DLLPostLevel
    {
        public static DataTable GetPostLevel(int? PostId)
        {
            try
            {
                string SelectPostLevelSql = "SP_GET_PLEVEL";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":p_POST_ID", PostId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_LEVEL_ID", null, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectPostLevelSql, Module.DLPDS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool SavePostLevel(List<ATTPostLevel> LstAtt,OracleTransaction Tran,int PostID)
        {
            if (LstAtt.Count==0)
                return true;

            string InsertUpdatePostLevelSql = "";
            try
            {
                foreach (ATTPostLevel attPl in LstAtt)
                {

                    if (attPl.Flag == "D")
                    {
                        string DeletePostLevelSql = "SP_DEL_pLEVEL";
                        OracleParameter[] ParamArray = new OracleParameter[1];

                        ParamArray[0] = Utilities.GetOraParam(":P_LEVEL_ID", PostID, OracleDbType.Int64, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeletePostLevelSql, ParamArray);

                    }
                    else
                    {
                        if (attPl.Flag == "A")
                            InsertUpdatePostLevelSql = "SP_ADD_pLEVEL";
                        else if (attPl.Flag == "E")
                            InsertUpdatePostLevelSql = "SP_EDIT_pLEVEL";

                        OracleParameter[] ParamArray = new OracleParameter[3];
                        ParamArray[0] = Utilities.GetOraParam(":p_POST_ID", PostID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":P_LEVEL_ID", attPl.PostLevelID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[2] = Utilities.GetOraParam(":p_LEVEL_NAME", attPl.PostLevelName, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostLevelSql, ParamArray);


                        int PostLevelID = int.Parse(ParamArray[1].Value.ToString());

                        attPl.PostID = PostID;
                        attPl.PostLevelID = PostLevelID;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }


       
    }
}
