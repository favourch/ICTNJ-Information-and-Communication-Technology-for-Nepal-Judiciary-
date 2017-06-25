using System;
using System.Collections.Generic;
using System.Text;

using PCS.COREDL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using System.Data;

using PCS.DLPDS.ATT;

namespace PCS.DLPDS.DLL
{
    public class DLLSessionCourseMember
    {
        public static bool AddSessionCourseMember(List<ATTSessionCourseMember> lst, OracleTransaction Tran)
        {
            string SP = "";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTSessionCourseMember  mem in lst)
                {
                    if (mem.Action == "A")
                    {
                        SP = "SP_ADD_COURSE_ASSIGNMENT";

                        paramArray.Clear();

                        paramArray.Add(Utilities.GetOraParam("p_ORG_ID", mem.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_PROGRAM_ID", mem.ProgramID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_SESSION_ID", mem.SessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_ID", mem.CourseID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_FACULTY_ID", mem.FacultyID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_PID", mem.PID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_FROM_DATE", mem.FromDate, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_ASSIGNMENT_DAT", mem.AssignmentDate, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_TO_DATE", mem.ToDate, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, SP, paramArray.ToArray());
                    }
                    else if (mem.Action == "D")
                    {
                        SP = "SP_DEL_COURSE_MEMBER";

                        paramArray.Clear();

                        paramArray.Add(Utilities.GetOraParam("p_ORG_ID", mem.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_PROGRAM_ID", mem.ProgramID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_SESSION_ID", mem.SessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_ID", mem.CourseID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_FACULTY_ID", mem.FacultyID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_PID", mem.PID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_FROM_DATE", mem.FromDate, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_ASSIGNMENT_DAT", mem.AssignmentDate, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, SP, paramArray.ToArray());
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static bool UpdateResourcePersonMarks(List<ATTSessionCourseMember> lst)
        {
            string UpdateSP = "";

            foreach (ATTSessionCourseMember obj in lst)
            {
                UpdateSP = "SP_UPDATE_RP_MARKS";
                

                OracleParameter[] paramArray = new OracleParameter[7];
                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", obj.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_SESSION_ID", obj.SessionID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_COURSE_ID", obj.CourseID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_FACULTY_ID", obj.FacultyID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_PID", obj.PID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[6] = Utilities.GetOraParam(":p_MARKS_OBTAINED", obj.MarksObtained, OracleDbType.Int64, ParameterDirection.Input);

                GetConnection GetConn = new GetConnection();

                try
                {
                    OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, UpdateSP, paramArray);
                    
                    


                }
                catch (Exception ex)
                {
                    throw ex;

                }

               
            }

            return true;
        }


        public static System.Data.DataTable GetSessionCourseMember(int orgID, int prgID, int sessionID, int ? CourseID)
        {
            string SelectSP = "SP_GET_COURSE_ASSIGNED_MEMBER";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", orgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_PRG_ID", prgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_SESSION_ID", sessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_COURSE_ID", CourseID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, System.Data.ParameterDirection.InputOutput));


            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray.ToArray());

                if (paramArray[4].Value == System.DBNull.Value || paramArray[4].Value == null)
                    return new DataTable();
                else
                {
                    OracleDataReader reader = ((OracleRefCursor)paramArray[4].Value).GetDataReader();

                    DataTable tbl = new DataTable();
                    tbl.Load(reader, LoadOption.OverwriteChanges);

                    return tbl;
                }
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


        public static System.Data.DataTable GetSessionCourseMemberForMarks(int orgID, int prgID, int sessionID, int? CourseID)
        {
            string SelectSP = "SP_GET_CA_MEM_FOR_MARKS";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", orgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_PRG_ID", prgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_SESSION_ID", sessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_COURSE_ID", CourseID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, System.Data.ParameterDirection.InputOutput));


            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray.ToArray());

                if (paramArray[4].Value == System.DBNull.Value || paramArray[4].Value == null)
                    return new DataTable();
                else
                {
                    OracleDataReader reader = ((OracleRefCursor)paramArray[4].Value).GetDataReader();

                    DataTable tbl = new DataTable();
                    tbl.Load(reader, LoadOption.OverwriteChanges);

                    return tbl;
                }
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
    }
}
