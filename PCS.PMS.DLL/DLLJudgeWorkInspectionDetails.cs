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
    public class DLLJudgeWorkInspectionDetails
    {
        public static bool SaveJudgeWorkInspectionDetails(List<ATTJudgeWorkInspectionDetails> WorkInspectionDetailsList, OracleTransaction tran)
        {
            GetConnection Conn = new GetConnection();
            OracleConnection DBConn = Conn.GetDbConn(Module.PMS);

            string InsertUpdateJudgeWorkInspectionDetailsSql = "";

            try
            {
                foreach (ATTJudgeWorkInspectionDetails ObjAtt in WorkInspectionDetailsList)
                {
                    if (ObjAtt.Action == "A")
                        InsertUpdateJudgeWorkInspectionDetailsSql = "SP_ADD_JUDGE_WORK_INSP_DET";
                    else if (ObjAtt.Action == "E" || ObjAtt.Action == "D")
                        InsertUpdateJudgeWorkInspectionDetailsSql = "SP_EDIT_JUDGE_WORK_INSP_DET";
                    

                    if (ObjAtt.Action != "" && ObjAtt.Action != null && ObjAtt.Action != "D")
                    {
                        OracleParameter[] ParamArray = new OracleParameter[10];

                        ParamArray[0] = Utilities.GetOraParam(":P_EMP_ID", ObjAtt.EmployeeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":P_FISCAL_YEAR", ObjAtt.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[2] = Utilities.GetOraParam(":P_JWC_ID", ObjAtt.JwcID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":P_WORKDONE", (ObjAtt.WorkDone) ? "Y" : "N", OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[4] = Utilities.GetOraParam(":P_NOOFCASE", ObjAtt.NoOfCase, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[5] = Utilities.GetOraParam(":P_INSP_CASENO", ObjAtt.InspectionCaseNo, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[6] = Utilities.GetOraParam(":P_NODONE_REASON", ObjAtt.NoDoneReason, OracleDbType.Varchar2, ParameterDirection.Input);
                        string valid = "";
                        if (ObjAtt.IsReasonValid != null)
                        {
                            valid=((bool)ObjAtt.IsReasonValid) ? "Y" : "N";
                        }
                        ParamArray[7] = Utilities.GetOraParam(":P_ISREASONVAILID", valid, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[8] = Utilities.GetOraParam(":P_REMARKS", ObjAtt.Remarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", ObjAtt.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertUpdateJudgeWorkInspectionDetailsSql, ParamArray);
                    }
                    else if (ObjAtt.Action != "" && ObjAtt.Action != null && ObjAtt.Action == "D")
                    {
                        OracleParameter[] ParamArray = new OracleParameter[10];

                        ParamArray[0] = Utilities.GetOraParam(":P_EMP_ID", ObjAtt.EmployeeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = Utilities.GetOraParam(":P_FISCAL_YEAR", ObjAtt.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[2] = Utilities.GetOraParam(":P_JWC_ID", ObjAtt.JwcID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = Utilities.GetOraParam(":P_WORKDONE", "N", OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[4] = Utilities.GetOraParam(":P_NOOFCASE",null , OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[5] = Utilities.GetOraParam(":P_INSP_CASENO", null, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[6] = Utilities.GetOraParam(":P_NODONE_REASON", "", OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[7] = Utilities.GetOraParam(":P_ISREASONVAILID", "", OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[8] = Utilities.GetOraParam(":P_REMARKS", "", OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[9] = Utilities.GetOraParam(":P_ENTRY_BY", "", OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, InsertUpdateJudgeWorkInspectionDetailsSql, ParamArray);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conn.CloseDbConn();
            }

        }

        public static DataTable GetJudgeWorkInspectionDetails(int? empID, string fiscalYear)
        {
            try
            {
                string SelectJudgeWorkInspectionDetailsSql = "SP_GET_JUDGE_WORK_INSP_DET";

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
    }
}
