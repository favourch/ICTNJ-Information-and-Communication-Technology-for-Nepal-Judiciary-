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
    public class DLLProgramCoordinator
    {
        public static DataTable GetProgramCoordinatorTable(int orgID, int programID, int programCoordinatorID)
        {
            string SelectSP = "SP_GET_PROGRAM_COORDINATOR";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", programID, OracleDbType.Int64, ParameterDirection.Input);

            if (programCoordinatorID > 0)
                paramArray[2] = Utilities.GetOraParam(":p_PROGRAM_COORDINATOR_ID", programCoordinatorID, OracleDbType.Int64, ParameterDirection.Input);
            else
                paramArray[2] = Utilities.GetOraParam(":p_PROGRAM_COORDINATOR_ID", null, OracleDbType.Int64, ParameterDirection.Input);

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


        public static bool AddProgramCoordinator(List<ATTProgramCoordinator> LSTPrgCoordinator, int programID, OracleTransaction Tran)
        {
            string InsertUpdateSP = "";

            foreach (ATTProgramCoordinator objProgramCoordinator in LSTPrgCoordinator)
            {
                if (objProgramCoordinator.Action == "A")
                    InsertUpdateSP = "SP_ADD_PROGRAM_COORDINATOR";
                else if (objProgramCoordinator.Action == "E")
                    InsertUpdateSP = "SP_EDIT_PROGRAM_COORDINATOR";
                else if (objProgramCoordinator.Action == "D")
                    InsertUpdateSP = "SP_DELETE_PROGRAM_COORDINATOR";


                OracleParameter[] paramArray = new OracleParameter[5];
                paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objProgramCoordinator.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_PROGRAM_ID", (objProgramCoordinator.ProgramID == 0) ? programID : objProgramCoordinator.ProgramID, OracleDbType.Int64, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_PRG_COORDINATOR_ID", objProgramCoordinator.ProgramCoordinatorID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[3] = Utilities.GetOraParam(":p_PID", objProgramCoordinator.PID, OracleDbType.Double, ParameterDirection.Input);
                paramArray[4] = Utilities.GetOraParam(":p_COORDINATOR_TYPE_ID", objProgramCoordinator.CoordinatorTypeID, OracleDbType.Int64, ParameterDirection.Input);
                

                try
                {
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, paramArray);
                    if (objProgramCoordinator.Action == "A")
                    {
                        objProgramCoordinator.ProgramCoordinatorID= int.Parse(paramArray[2].Value.ToString());
                        objProgramCoordinator.ProgramID = programID;
                    }

                    if(objProgramCoordinator.Action!="D")
                        objProgramCoordinator.Action = "";


                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            //foreach (ATTProgramCoordinator objProgramCoordinator in LSTPrgCoordinator)
            LSTPrgCoordinator.RemoveAll (delegate(ATTProgramCoordinator obj)
                                        {
                                            return obj.Action == "D";
                                        });
            return true;
        }
    }
}
