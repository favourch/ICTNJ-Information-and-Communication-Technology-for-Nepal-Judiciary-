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
    public class DLLEvaluationCriteriaGrade
    {
        public static DataTable GetEvaluationCriteriaGradeTable(string fromDate,string Active)
        {
            string SelectSP = "SP_GET_EVAL_CRITERIA_GRADE";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            if (fromDate != "")
                paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", fromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            else
                paramArray.Add(Utilities.GetOraParam("P_FROM_DATE", null, OracleDbType.Varchar2, ParameterDirection.Input));
            
            paramArray.Add(Utilities.GetOraParam("P_ACTIVE", Active, OracleDbType.Varchar2, ParameterDirection.Input));

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

        public static bool AddEvaluationCriteriaGrade(List<ATTEvaluationCriteriaGrade> lst, OracleTransaction Tran, int EvalCritID)
        {
            string SP = "";
            List<OracleParameter> paramArrary = new List<OracleParameter>();
            try
            {
                foreach (ATTEvaluationCriteriaGrade grade in lst)
                {
                    if (grade.Action == "A")
                        SP = "SP_ADD_EVAL_CRIT_GRADE";
                    else if (grade.Action == "E")
                        SP = "SP_EDIT_EVAL_CRIT_GRADE";

                    if (grade.Action != "N")
                    {
                        paramArrary.Add(Utilities.GetOraParam("P_EVAL_CRIT_ID", EvalCritID, OracleDbType.Int64, ParameterDirection.Input));
                        paramArrary.Add(Utilities.GetOraParam("P_FROM_DATE", grade.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArrary.Add(Utilities.GetOraParam("P_EVAL_GRADE_ID", grade.EvaluationGradeID, OracleDbType.Int64, ParameterDirection.InputOutput));
                        paramArrary.Add(Utilities.GetOraParam("P_EVAL_GRADE_NAME", grade.EvaluationGradeName, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArrary.Add(Utilities.GetOraParam("P_WEIGHT", grade.TotalWeight, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArrary.Add(Utilities.GetOraParam("P_ACTIVE", grade.Active, OracleDbType.Varchar2, ParameterDirection.Input));

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SP, paramArrary.ToArray());
                        grade.EvaluationGradeID = int.Parse(paramArrary[2].Value.ToString());
                        grade.Action = "N";

                        paramArrary.Clear();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
