using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.DLPDS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;


namespace PCS.DLPDS.DLL
{
    public class DLLCourse
    {
        public static DataTable GetCourseTable(int orgID,int programID,int courseID)
        {
            string SelectSP = "SP_GET_COURSE";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", programID, OracleDbType.Int64, ParameterDirection.Input);

            if (courseID > 0)
                paramArray[2] = Utilities.GetOraParam(":p_COURSE_ID",courseID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[2] = Utilities.GetOraParam(":p_COURSE_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[3] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

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


        public static bool AddCourse(List<ATTCourse> LSTCourse,int programID, OracleTransaction Tran)
        {
            string InsertUpdateSP = "";

            foreach (ATTCourse objCourse in LSTCourse)
            {
                if (objCourse.Action == "A")
                    InsertUpdateSP = "SP_ADD_COURSE";
                else if (objCourse.Action == "E")
                    InsertUpdateSP = "SP_EDIT_COURSE";


                OracleParameter[] paramArray = new OracleParameter[6];
                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objCourse.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", (objCourse.ProgramID==0)?programID:objCourse.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_COURSE_ID", objCourse.CourseID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":p_COURSE_TITLE", objCourse.CourseTitle, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_DESCRIPTION", objCourse.Description, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[5] = Utilities.GetOraParam(":p_ACTIVE", objCourse.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                

                try
                {
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, paramArray);
                    if (objCourse.Action == "A")
                    {
                        objCourse.CourseID = int.Parse(paramArray[2].Value.ToString());
                        objCourse.ProgramID = programID;
                    }

                    objCourse.Action = "";

                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return true;
        }
    }
}
