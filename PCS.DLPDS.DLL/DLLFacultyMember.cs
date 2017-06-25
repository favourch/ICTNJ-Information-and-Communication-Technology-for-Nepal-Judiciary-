using System;
using System.Collections.Generic;
using System.Text;
//Using section.
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.DLPDS.ATT;
using PCS.COMMON.DLL;
namespace PCS.DLPDS.DLL
{
    public class DLLFacultyMember
    {
        public static bool SaveFacultyMember(ATTFacultyMember objFacultyMember)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.DLPDS).BeginTransaction();
            double personID;
            string InsertUpdatePostSql = "";
            try
            {
                personID = DLLPerson.AddPersonnelDetails(objFacultyMember.ObjPerson, Tran);

                if (objFacultyMember.LstParticipantPost.Count > 0)
                    DLLParticipantPost.SaveParticipantPost(objFacultyMember.LstParticipantPost, Tran, personID);

                OracleParameter[] ParamArray = new OracleParameter[5];
                ParamArray[0] = Utilities.GetOraParam(":p_ORG_ID", objFacultyMember.OrgID, OracleDbType.Int32, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":p_FACULTY_ID", objFacultyMember.FacultyID, OracleDbType.Int32, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":p_P_ID", personID, OracleDbType.Double, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":p_FROM_DATE", objFacultyMember.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":p_TO_DATE", objFacultyMember.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
                if (objFacultyMember.PID == 0)
                    InsertUpdatePostSql = "SP_ADD_FACULTY_MEMBER";
                else if (objFacultyMember.PID > 0)
                    InsertUpdatePostSql = "SP_EDIT_FACULTY_MEMBER";
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdatePostSql, ParamArray);
                objFacultyMember.PID = personID;
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

        public static DataTable GetFacultyMember(int? orgID, int? facultyID)
        {
            string SelectFacultyMemberSQL = "SP_GET_FACULTY_MEMBER";
            try
            {
                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":P_FACULTY_ID", facultyID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectFacultyMemberSQL, Module.DLPDS, paramArray);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
