using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.DLPDS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.DLPDS.DLL
{
   public class DLLSessionCourse
    {
       public static bool SaveSessionCourse(List<ATTSessionCourse> LstSC)
       {
           GetConnection Conn = new GetConnection();
           OracleTransaction Tran = Conn.GetDbConn(Module.DLPDS).BeginTransaction();
           string InsertUpdateSessionCourseSql = "";
           

           try
           {
               foreach (ATTSessionCourse Att in LstSC)
               {
                   if (Att.Action == "A")
                       InsertUpdateSessionCourseSql = "SP_ADD_SESSION_COURSE";
                   else if (Att.Action == "E")
                       InsertUpdateSessionCourseSql = "SP_EDIT_SESSION_COURSE";
                   else if (Att.Action == "D")
                       return true;

                   OracleParameter[] ParamArray = new OracleParameter[7];
                   ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", Att.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", Att.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[2] = Utilities.GetOraParam(":p_SESSION_ID", Att.SessionID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[3] = Utilities.GetOraParam(":p_COURSE_ID", Att.CourseID, OracleDbType.Int64, ParameterDirection.Input);
                   ParamArray[4] = Utilities.GetOraParam(":p_FROM_DATE", Att.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   ParamArray[5] = Utilities.GetOraParam(": p_TO_DATE", Att.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                   ParamArray[6] = Utilities.GetOraParam(": p_SYLLABUS_PATH", Att.SyllbusDocPath, OracleDbType.Varchar2, ParameterDirection.Input);

                   SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSessionCourseSql, ParamArray);

               }
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


       public static DataTable GetSessionCourseTable(int orgID, int programID, int sessionID,int CourseID)
       {
           string SelectSP = "SP_GET_SESSION_COURSE";

           OracleParameter[] paramArray = new OracleParameter[5];
           paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
           paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", programID, OracleDbType.Int64, ParameterDirection.Input);
           paramArray[2] = Utilities.GetOraParam(":p_SESSION_ID", sessionID, OracleDbType.Int64, ParameterDirection.Input);
           if (CourseID > 0)
               paramArray[3] = Utilities.GetOraParam(":p_COURSE_ID", CourseID, OracleDbType.Int64, ParameterDirection.Input);
           else
               paramArray[3] = Utilities.GetOraParam(":p_COURSE_ID", null, OracleDbType.Int64, ParameterDirection.Input);

           paramArray[4] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

           GetConnection GetConn = new GetConnection();

           try
           {
               OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

               SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

               OracleDataReader reader = ((OracleRefCursor)paramArray[4].Value).GetDataReader();

               DataTable tbl = new DataTable();
               tbl.Load(reader, LoadOption.OverwriteChanges);

               return tbl;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               GetConn.CloseDbConn();
           }
       }

       public static bool AddSessionCourseMaterialNMember(ATTSessionCourse SC)
       {
           GetConnection getConn = new GetConnection();
           try
           {
               OracleTransaction Tran = getConn.GetDbConn(Module.DLPDS).BeginTransaction();
               try
               {
                   DLLSessionCourseMaterial.AddSessionCourseMaterial(SC.LstSessionCourseMaterial, Tran);
                   DLLSessionCourseMember.AddSessionCourseMember(SC.LstSessionCourseMember, Tran);

                   Tran.Commit();

                   return true;
               }
               catch (Exception ex)
               {
                   Tran.Rollback();
                   throw ex;
               }
               finally
               {
                   getConn.CloseDbConn();
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
           }
       }
    }
}
