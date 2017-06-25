using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.PMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
   public class DLLJudgeWorkList
    {
       public static DataTable GetJudgeWorkList(int? JwcId)
        {
          
            try
            {
                string SelectWorkListSql = "SP_GET_ALL_JUDGE_WORK_LIST";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":P_JWC_ID", JwcId, OracleDbType.Int64, ParameterDirection.Input);

                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectWorkListSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool SaveWork(ATTJudgeWorkList ObjAtt)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn;
            string InsertUpdateWorkCheck = "";
            OracleParameter[] ParamArray = new OracleParameter[0];
            try
            {
                DBConn = Conn.GetDbConn(Module.PMS);

                if (ObjAtt.Action == "A")
                {
                    InsertUpdateWorkCheck = "SP_ADD_JUDGE_WORK_LIST";
                    ParamArray = new OracleParameter[4];

                    ParamArray[0] = Utilities.GetOraParam(":P_JWC_ID", ObjAtt.JwcID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[1] = Utilities.GetOraParam(":P_JWC_NAME", ObjAtt.JwcName, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":P_ACTIVE", (ObjAtt.Active == true) ? "Y" : "N", OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[3] = Utilities.GetOraParam(":P_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                }
                else if(ObjAtt.Action=="E")
                {
                    InsertUpdateWorkCheck = "SP_EDIT_JUDGE_WORK_LIST";
                     ParamArray = new OracleParameter[3];

                    ParamArray[0] = Utilities.GetOraParam(":P_JWC_ID", ObjAtt.JwcID, OracleDbType.Int64, ParameterDirection.InputOutput);
                    ParamArray[1] = Utilities.GetOraParam(":P_JWC_NAME", ObjAtt.JwcName, OracleDbType.Varchar2, ParameterDirection.Input);
                    ParamArray[2] = Utilities.GetOraParam(":P_ACTIVE", (ObjAtt.Active == true) ? "Y" : "N", OracleDbType.Varchar2, ParameterDirection.Input);
                    
                }

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertUpdateWorkCheck, ParamArray);

                int JWCID = int.Parse(ParamArray[0].Value.ToString());

                ObjAtt.JwcID = JWCID;

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

       public static DataTable GetCurrentJudgesList(int orgID)
       {
           try
           {
               string SelectWorkListSql = "SP_GET_JUDGES";

               OracleParameter[] ParamArray = new OracleParameter[3]; 
               
               ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int32, ParameterDirection.Input);
               ParamArray[1] = Utilities.GetOraParam(":P_DES_TYPE", "J", OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

               DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectWorkListSql, Module.PMS, ParamArray);
               return (DataTable)ds.Tables[0];
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
    }
}
