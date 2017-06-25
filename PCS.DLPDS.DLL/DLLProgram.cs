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
    public class DLLProgram
    {

        public static DataTable GetProgramTable(int orgID,int programID)
        {
            string SelectSP = "SP_GET_PROGRAM";

            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            if (programID > 0)
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", programID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", null, OracleDbType.Int64, ParameterDirection.Input);

            paramArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[2].Value).GetDataReader();

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



        public static bool AddProgram(ATTProgram objProgram)
        {
            string InsertUpdateSP="";
            OracleTransaction Tran;

            if (objProgram.Action == "A")
                InsertUpdateSP = "SP_ADD_PROGRAM";
            else if (objProgram.Action == "E")
                InsertUpdateSP = "SP_EDIT_PROGRAM";

            int ? durationTypeID;
            if (objProgram.DurationTypeID == 0)
                durationTypeID = null;
            else
                durationTypeID = objProgram.DurationTypeID;

            OracleParameter[] paramArray = new OracleParameter[11];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objProgram.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", objProgram.ProgramID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[2] = Utilities.GetOraParam(":p_PROGRAM_NAME", objProgram.ProgramName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_PROGRAM_TYPE_ID", objProgram.ProgramTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":p_DESCRIPTION", objProgram.Description, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":p_ACTIVE", objProgram.Active, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":p_LAUNCH_DATE", objProgram.LaunchDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[7] = Utilities.GetOraParam(":p_DURATION", objProgram.Duration, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[8] = Utilities.GetOraParam(":p_DURATION_TYPE_ID", durationTypeID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[9] = Utilities.GetOraParam(":p_TO_DATE", objProgram.ToDate, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[10] = Utilities.GetOraParam(":p_LOCATION", objProgram.Location, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();

            OracleConnection DBConn = GetConn.GetDbConn(Module.DLPDS);
            Tran = DBConn.BeginTransaction();
                
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, paramArray);
                objProgram.ProgramID = int.Parse(paramArray[1].Value.ToString());

                if (objProgram.PrgCoordinatorLST != null)
                    DLLProgramCoordinator.AddProgramCoordinator(objProgram.PrgCoordinatorLST, objProgram.ProgramID, Tran);

                if (objProgram.PrgSponsorLST!= null)
                    DLLProgramSponsor.AddProgramSponsor(objProgram.PrgSponsorLST,objProgram.ProgramID,Tran);

                if (objProgram.SessionLST != null)
                    DLLSession.AddSession(objProgram.SessionLST, objProgram.ProgramID, Tran);

                if (objProgram.CourseLST != null)
                    DLLCourse.AddCourse(objProgram.CourseLST, objProgram.ProgramID, Tran);

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
                GetConn.CloseDbConn();
            }
        }
    }
}
