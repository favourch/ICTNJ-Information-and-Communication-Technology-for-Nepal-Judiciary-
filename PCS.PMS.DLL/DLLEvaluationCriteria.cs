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
    public class DLLEvaluationCriteria
    {
        public static DataTable GetEvaluationCriteriaTable(int? grpID,string Active)
        {
            string SelectSP = "SP_GET_EVAL_CRITERIA";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            if (grpID != null)
                paramArray.Add(Utilities.GetOraParam("P_EVAL_GRP_ID", grpID, OracleDbType.Int64, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam("P_EVAL_GRP_ID", null, OracleDbType.Int64, ParameterDirection.Input));
            
            paramArray.Add(Utilities.GetOraParam("P_active", Active, OracleDbType.Varchar2, ParameterDirection.Input));

            paramArray.Add(Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEvaluationCriteria(ATTEvaluationCriteria obj)
        {
            string SP = "";
            if (obj.Action == "A")
                SP = "SP_ADD_EVALUATION_CRITERIA";
            else if (obj.Action == "E")
                SP = "SP_EDIT_EVALUATION_CRITERIA";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            GetConnection getConn = new GetConnection();
            OracleTransaction Tran = getConn.GetDbConn(Module.PMS).BeginTransaction();

            if (obj.Action != "N")
            {
                paramArray.Add(Utilities.GetOraParam("P_EVAL_CRIT_ID", obj.EvaluationCriteriaID, OracleDbType.Int64, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_EVAL_GROUP_ID", obj.GroupID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_EVAL_CRIT_NAME", obj.EvaluationCriteriaName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_TO_DATE", obj.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam("P_ACTIVE", obj.Active, OracleDbType.Char, ParameterDirection.Input));
            }

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArray.ToArray());

                int CriteriaID = int.Parse(paramArray[0].Value.ToString());
                obj.EvaluationCriteriaID = CriteriaID;
                obj.Action = "N";

                DLLEvaluationCriteriaGrade.AddEvaluationCriteriaGrade(obj.LstEvaluationCriteriaGrade, Tran, CriteriaID);

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
