using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.COMMON.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.COMMON.DLL
{
   public class DLLInstitution
    {
       public static DataTable GetInstitution(int? institutionID,string active)
       {
       //    GetConnection Conn = new GetConnection();
       //    OracleConnection DBConn = Conn.GetDbConn(Module.PMS);
       //    OracleTransaction Tran = DBConn.BeginTransaction();
           
           string SelectInstitutionSql = "SP_GET_INSTITUTIONS";

           try
           {
               OracleParameter[] ParamArray = new OracleParameter[3];
               ParamArray[0] = Utilities.GetOraParam(":p_INSTITUTION_ID", institutionID, OracleDbType.Long, ParameterDirection.Input);
               ParamArray[1] = Utilities.GetOraParam(":p_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[2] = Utilities.GetOraParam(":P_RC",null, OracleDbType.RefCursor, ParameterDirection.Output);

              DataSet ds= SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectInstitutionSql,  ParamArray);
              return (DataTable)ds.Tables[0];
              
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

       public static int SaveInstitution(ATTInstitution ObjAtt)
       {
           GetConnection Conn = new GetConnection();
           OracleConnection DBConn = Conn.GetDbConn();
           OracleTransaction Tran = DBConn.BeginTransaction();

           string InsertUpdateInstitutionSql = "";

           if (ObjAtt.InstitutionID == 0)
               InsertUpdateInstitutionSql = "SP_ADD_INSTITUTIONS";
           else
               InsertUpdateInstitutionSql = "SP_EDIT_INSTITUTIONS";

           try
           {
               OracleParameter[] ParamArray = new OracleParameter[8];
               ParamArray[0] = Utilities.GetOraParam(":p_INSTITUTION_ID", ObjAtt.InstitutionID, OracleDbType.Int64, ParameterDirection.InputOutput);
               ParamArray[1] = Utilities.GetOraParam(":p_INSTITUTION_NAME", ObjAtt.InstitutionName, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[2] = Utilities.GetOraParam(":p_BOARD_NAME", ObjAtt.BoardName, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[3] = Utilities.GetOraParam(":p_LOCATION", ObjAtt.Location, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[4] = Utilities.GetOraParam(":p_COUNTRY_ID", ObjAtt.CountryID, OracleDbType.Int64, ParameterDirection.Input);
               ParamArray[5] = Utilities.GetOraParam(":p_ACTIVE", ObjAtt.Active, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[6] = Utilities.GetOraParam(":p_INSTITUTION_TYPE", ObjAtt.InstitutionType, OracleDbType.Varchar2, ParameterDirection.Input);
               ParamArray[7] = Utilities.GetOraParam(":p_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);


               SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure,InsertUpdateInstitutionSql, ParamArray);

               int NewInstitutionID = int.Parse(ParamArray[0].Value.ToString());

               Tran.Commit();

               return NewInstitutionID;

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

       public static bool DeleteInstitution(int InstitutionID)
       {
           GetConnection Conn = new GetConnection();
           OracleConnection DBConn = Conn.GetDbConn();
           OracleTransaction Tran = DBConn.BeginTransaction();

           string DeleteInstitutionSql = "SP_DEL_INSTITUTIONS";
           try
           {
               OracleParameter[] ParamArray = new OracleParameter[1];
               ParamArray[0] = Utilities.GetOraParam(":p_INSTITUTION_ID", InstitutionID, OracleDbType.Int64, ParameterDirection.Input);

               SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, DeleteInstitutionSql, ParamArray);
               
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
