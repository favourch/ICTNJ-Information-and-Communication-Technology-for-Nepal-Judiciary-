using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.PMS.DLL
{
    public class DLLJudgeWorkInspection
    {
        public static DataTable GetJudgeWorkInspection(int? empID, string fiscalYear)
        {
            try
            {
                string SelectJudgeWorkInspectionDetailsSql = "SP_GET_JUDGE_WORK_INSPECTION";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":P_EMP_ID", empID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_FISCAL_YEAR", fiscalYear, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectJudgeWorkInspectionDetailsSql, Module.PMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool SaveJudgeWorkInspection(ATTJudgeWorkInspection objAtt)
        {
            string InsertUpdateSP = "";
            OracleTransaction Tran;

            if (objAtt.Action == "A")
                InsertUpdateSP = "SP_ADD_JUDGE_WORK_INSPECTION";
            else if (objAtt.Action == "E")
                InsertUpdateSP = "SP_EDIT_JUDGE_WORK_INSPECTION";
            
            OracleParameter[] ParamArray = new OracleParameter[5];

            ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_EMP_ID", objAtt.EmployeeID, OracleDbType.Int64, ParameterDirection.Input);
            ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_FISCAL_YEAR", objAtt.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input);
            ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_INSP_EMP_ID", objAtt.InspEmpID, OracleDbType.Int64, ParameterDirection.Input);
            ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_INSP_DATE", objAtt.InspectionDate, OracleDbType.Date, ParameterDirection.Input);
            ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", objAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();

            OracleConnection DBConn = GetConn.GetDbConn(Module.PMS);
            Tran = DBConn.BeginTransaction();

            try
            {
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSP, ParamArray);              
               
                DLLJudgeWorkInspectionDetails.SaveJudgeWorkInspectionDetails(objAtt.Details,Tran);

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
