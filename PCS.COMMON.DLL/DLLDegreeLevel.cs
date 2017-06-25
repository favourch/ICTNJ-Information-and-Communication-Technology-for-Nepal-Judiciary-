using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
   public class DLLDegreeLevel
    {
       public static DataTable GetDegreeLevel(int? degreeLevelId,string active)
       {
           try
           {
               string SelectDegreeLevelSql = "SP_GET_DEGREE_LEVEL";

               OracleParameter[] ParamArray = new OracleParameter[3];
               ParamArray[0] = Utilities.GetOraParam(":p_DEGREE_LEVEL_ID", degreeLevelId, OracleDbType.Int64, ParameterDirection.Input);
               ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

               DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectDegreeLevelSql,  ParamArray);
               return (DataTable)ds.Tables[0];
           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public static bool SaveDegreeLevel(ATTDegreeLevel ObjAtt)
       {
           GetConnection Conn = new GetConnection();
           OracleConnection DBConn;
           OracleTransaction Tran;
           string InsertUpdateDegreeLevel = "";
           try
           {
               DBConn = Conn.GetDbConn();
               Tran=DBConn.BeginTransaction();

               if (ObjAtt.DegreeLevelID == 0)
                   InsertUpdateDegreeLevel = "SP_ADD_DEGREE_LEVEL";
               else
                   InsertUpdateDegreeLevel = "SP_EDIT_DEGREE_LEVEL";

               OracleParameter[] ParamArray = new OracleParameter[4];

               ParamArray[0] = Utilities.GetOraParam(":p_DEGREE_LEVEL_ID", ObjAtt.DegreeLevelID, OracleDbType.Int64, ParameterDirection.InputOutput);
               ParamArray[1] = Utilities.GetOraParam(":p_DEGREE_LEVEL_NAME", ObjAtt.DegreeLevelName, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[2] = Utilities.GetOraParam(":p_ACTIVE", ObjAtt.Active, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[3] = Utilities.GetOraParam(":p_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

               
               SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDegreeLevel, ParamArray);

             
               int DegreeLevelID = int.Parse(ParamArray[0].Value.ToString());

             //if (ObjAtt.DegreeLevelID == 0)
                   ObjAtt.DegreeLevelID = DegreeLevelID;

               DLLDegree.SaveDegree(ObjAtt.LstDegree, DegreeLevelID,Tran);
              
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


       public static bool DeleteDegreeLevel(int DegreeLevelID)
       {
           GetConnection Conn = new GetConnection();
           OracleConnection DBConn;
           OracleTransaction Tran;
           string DeleteDegreeLevelSql = "SP_DEL_DEGREE_LEVEL";
         
           try
           {
               DBConn = Conn.GetDbConn(Module.Security);
               Tran = DBConn.BeginTransaction();
                            
               OracleParameter[] ParamArray = new OracleParameter[1];

               ParamArray[0] = Utilities.GetOraParam(":p_DEGREE_LEVEL_ID", DegreeLevelID, OracleDbType.Int64, ParameterDirection.Input);

               SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeleteDegreeLevelSql, ParamArray);
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
