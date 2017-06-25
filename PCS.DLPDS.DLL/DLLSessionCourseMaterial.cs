using System;
using System.Collections.Generic;
using System.Text;

using PCS.COREDL;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using PCS.FRAMEWORK;
using System.Data;

using PCS.DLPDS.ATT;

namespace PCS.DLPDS.DLL
{
    public class DLLSessionCourseMaterial
    {
        public static bool AddSessionCourseMaterial(List<ATTSessionCourseMaterial> SCM, OracleTransaction Tran)
        {
            List<OracleParameter> paramArray = new List<OracleParameter>();
            string SQ;
            //SP_DEL_COURSE_MATERIAL
            try
            {
                foreach (ATTSessionCourseMaterial obj in SCM)
                {
                    if (obj.Action == "A")
                    {
                        SQ = "SP_ADD_SESSION_COURSE_MATERIAL";
                        paramArray.Clear();

                        paramArray.Add(Utilities.GetOraParam("p_ORG_ID", obj.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_PROGRAM_ID", obj.ProgramID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_SESSION_ID", obj.SessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_ID", obj.CourseID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_MAT_ID", obj.MaterialID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_MAT_NAME", obj.MaterialName, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_MAT_TYPE_ID", obj.MaterialTypeID, OracleDbType.Int64, System.Data.ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, SQ, paramArray.ToArray());
                        obj.MaterialID = int.Parse(paramArray[4].Value.ToString());
                        obj.Action = "M";
                    }
                    else if (obj.Action == "D")
                    {
                        SQ = "SP_DEL_COURSE_MATERIAL";
                        paramArray.Clear();

                        paramArray.Add(Utilities.GetOraParam("p_ORG_ID", obj.OrgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_PROGRAM_ID", obj.ProgramID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_SESSION_ID", obj.SessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_ID", obj.CourseID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
                        paramArray.Add(Utilities.GetOraParam("p_COURSE_MAT_ID", obj.MaterialID, OracleDbType.Int64, System.Data.ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, SQ, paramArray.ToArray());
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static System.Data.DataTable GetSessionCourseMaretial(int orgID,int prgID,int sessionID,int CourseID, int CMID)
        {
            string SelectSP = "SP_GET_SESSION_COURSE_MATERIAL";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            
            paramArray.Add(Utilities.GetOraParam("P_ORG_ID", orgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_PRG_ID", prgID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_SESSION_ID", sessionID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_COURSE_ID", CourseID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            if (CMID <= 0)
                paramArray.Add(Utilities.GetOraParam("P_C_M_ID", 0, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam("P_C_M_ID", CMID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
            
            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, System.Data.ParameterDirection.InputOutput));


            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray.ToArray());

                if (paramArray[5].Value == System.DBNull.Value || paramArray[5].Value == null)
                    return new DataTable();
                else
                {
                    OracleDataReader reader = ((OracleRefCursor)paramArray[5].Value).GetDataReader();

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
