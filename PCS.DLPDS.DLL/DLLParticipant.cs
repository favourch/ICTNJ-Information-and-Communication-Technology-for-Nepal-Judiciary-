using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using PCS.COMMON.DLL;

using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.DLPDS.DLL
{
   public class DLLParticipant
    {
       public static bool SaveParticipant(ATTParticipant ObjParticipant)
       {
         GetConnection GetConn = new GetConnection();
         OracleTransaction Tran = GetConn.GetDbConn(Module.DLPDS).BeginTransaction();
         double personID;
         string InsertUpdatePostSql = "";
         try
         {
             personID = DLLPerson.AddPersonnelDetails(ObjParticipant.ObjPerson, Tran);

             if (ObjParticipant.LstParticipantPost.Count > 0)
                 DLLParticipantPost.SaveParticipantPost(ObjParticipant.LstParticipantPost, Tran, personID);

             OracleParameter[] ParamArray = new OracleParameter[4];
             ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", ObjParticipant.OrgID, OracleDbType.Int64, ParameterDirection.Input);
             ParamArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", ObjParticipant.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
             ParamArray[2] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
             ParamArray[3] = Utilities.GetOraParam(":p_JOINING_DATE", ObjParticipant.JoiningDate, OracleDbType.Varchar2, ParameterDirection.Input);
             if (ObjParticipant.PID == 0)
                 InsertUpdatePostSql = "SP_ADD_PARTICIPANT";
             else if (ObjParticipant.PID > 0)
                 InsertUpdatePostSql = "SP_EDIT_PARTICIPANT";
             SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostSql, ParamArray);
             ObjParticipant.PID = personID;
             Tran.Commit();
             return true;
         }

         catch (OracleException oex)
         {
             PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
             throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
         }
         catch (Exception ex)
         {
             Tran.Rollback();
             throw ex;
         }
         finally
         {
             GetConn.CloseDbConn();
         }
     }

       public static bool SaveParticipant(List<ATTParticipant> lstParticipant)
       {
           GetConnection GetConn = new GetConnection();
           OracleTransaction Tran = GetConn.GetDbConn(Module.DLPDS).BeginTransaction();

           string InsertUpdateParticipantSql = "SP_ADD_PARTICIPANT";

           try
           {
               foreach (ATTParticipant  attP in lstParticipant)
               {
                   OracleParameter[] ParamArray = new OracleParameter[4];
                   ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", attP.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[1] = Utilities.GetOraParam(":P_PROGRAM_ID", attP.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[2] = Utilities.GetOraParam(":P_P_ID", attP.PID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[3] = Utilities.GetOraParam(":P_JOINING_DATE", attP.JoiningDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateParticipantSql, ParamArray);
               }
               Tran.Commit();
               return true;
           }
           catch (OracleException oex)
           {
               PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
               throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
           }
           catch (Exception ex)
           {
               Tran.Rollback();
               throw ex;
           }
           finally
           {
               GetConn.CloseDbConn();
           }
       }


       public static DataTable GetParticipant(int OrgID,int ProgramID)
       {
           GetConnection Conn = new GetConnection();
           OracleTransaction Tran = Conn.GetDbConn().BeginTransaction();

           string SelectParticipantSql = "SP_GET_PARTICIPANT";
           try
           {

               OracleParameter[] ParamArray = new OracleParameter[3];
               ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", OrgID, OracleDbType.Int32, ParameterDirection.Input);
               ParamArray[1] = Utilities.GetOraParam(":P_PROGRAM_ID", ProgramID, OracleDbType.Int32, ParameterDirection.Input);
               ParamArray[2] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

               DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectParticipantSql, Module.DLPDS, ParamArray);
               return (DataTable)ds.Tables[0];
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
    }
}
