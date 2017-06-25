using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using PCS.COMMON.DLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public class DLLCaseBenchAssignment
    {
        public static bool AddEditDeleteCaseBenchAssignment(List<ATTCaseBenchAssignment> objLST)
        {
            string InsertUpdateDeleteSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {
                foreach (ATTCaseBenchAssignment Obj in objLST)
                {
                    if (Obj.Action == "A")
                        InsertUpdateDeleteSQL = "SP_ADD_CASE_BENCH_ASSIGNMENT";
                    else if (Obj.Action == "E")
                        InsertUpdateDeleteSQL = "SP_EDIT_CASE_BENCH_ASSIGNMENT";
                    else if (Obj.Action == "D")
                        InsertUpdateDeleteSQL = "SP_DEL_CASE_BENCH_ASSIGNMENT";

                    OracleParameter[] ParamArray;
                    if (Obj.Action == "A" || Obj.Action == "E")
                    {                        
                        ParamArray = new OracleParameter[9];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", Obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_BENCH_TYPE_ID", Obj.BenchTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_BENCH_NO", Obj.BenchNo, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_FROM_DATE", Obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_SEQ_NO", Obj.SeqNo, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", Obj.CaseID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":P_ASSIGNMENT_DATE", Obj.AssignmentDate, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[7] = FRAMEWORK.Utilities.GetOraParam(":P_PRIORITY", Obj.Priority, OracleDbType.Int64, ParameterDirection.Input);
                        //ParamArray[8] = FRAMEWORK.Utilities.GetOraParam(":P_BEN_STATUS_ID", Obj.BenStatusID, OracleDbType.Int64, ParameterDirection.Input);
                        //ParamArray[9] = FRAMEWORK.Utilities.GetOraParam(":P_BEN_REMARKS", Obj.BenRemarks, OracleDbType.Varchar2, ParameterDirection.Input);
                        
                        ParamArray[8] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", Obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);
                        
                    }
                    //if (Obj.Action == "D")
                    //{
                    //    ParamArray = new OracleParameter[4];
                    //    ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_ID", Obj.CaseID, OracleDbType.Int64, ParameterDirection.Input);
                    //    ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_LITIGANT_ID", Obj.LitigantID, OracleDbType.Int64, ParameterDirection.Input);
                    //    ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_PERSON_ID", Obj.PersonID, OracleDbType.Int64, ParameterDirection.Input);
                    //    //ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_ATTORNEY_ID", Obj.AttorneyID, OracleDbType.Int64, ParameterDirection.Input);
                    //    ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_FROM_DATE", Obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input);


                    //    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteSQL, ParamArray);

                    //}
                }

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
