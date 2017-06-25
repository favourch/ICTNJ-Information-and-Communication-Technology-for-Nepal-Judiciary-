using System;
using System.Collections.Generic;
using System.Text;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.PMS.DLL
{
    public class DLLEvaluationGroup
    {
        public static DataTable GetEvaluationGroupTable()
        {
            string SelectSP = "SP_GET_EVAL_GRP";
            OracleParameter[] paramArray = new OracleParameter[1];
            paramArray[0] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool SaveEvaluationGroup(ATTEvaluationGroup obj)
        {
            string SP = "";
            if (obj.Action == "A")
                SP = "SP_ADD_EVALUATION_GROUPS";
            else if (obj.Action == "E")
                SP = "SP_EDIT_EVALUATION_GROUPS";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            GetConnection getConn = new GetConnection();
            OracleTransaction Tran = getConn.GetDbConn(Module.PMS).BeginTransaction();
            paramArray.Add(Utilities.GetOraParam("P_EVAL_GROUP_ID", obj.GroupID, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_EVAL_GROUP_NAME", obj.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());

                int groupID = int.Parse(paramArray[0].Value.ToString());
                obj.GroupID = groupID;
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
    }
}
