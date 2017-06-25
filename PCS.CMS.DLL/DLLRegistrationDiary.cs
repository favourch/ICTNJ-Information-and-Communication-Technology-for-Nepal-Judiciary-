using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COREDL;
using PCS.FRAMEWORK;
using PCS.CMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public class DLLRegistrationDiary
    {
        public static DataTable GetRegistrationDiary(int orgID,int caseTypeID, int? regDiaryID, string active)
        {
            try
            {
                string SelectRegistrationDiarySql = "SP_GET_REGISTRATION_DIARY";

                OracleParameter[] ParamArray = new OracleParameter[5];
                ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_REG_DIARY_ID", regDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectRegistrationDiarySql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteRegistrationDiary(List<ATTRegistrationDiary> registrationDiaryLST)
        {
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {
                string InsertUpdateDeleteRegistrationDiary = "";

                foreach (ATTRegistrationDiary rDiary in registrationDiaryLST)
                {
                    if (rDiary.Action == "A")
                        InsertUpdateDeleteRegistrationDiary = "SP_ADD_REGISTRATION_DIARY";
                    else if (rDiary.Action == "E")
                        InsertUpdateDeleteRegistrationDiary = "SP_EDIT_REGISTRATION_DIARY";
                    else if (rDiary.Action == "D")
                        InsertUpdateDeleteRegistrationDiary = "SP_DEL_REGISTRATION_DIARY";
                    OracleParameter[] ParamArray;

                    if (rDiary.Action == "A" || rDiary.Action == "E")
                    {
                        ParamArray = new OracleParameter[7];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", rDiary.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", rDiary.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_ID", rDiary.RegistrationDiaryID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_NAME", rDiary.RegistrationDiaryName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_CODE", rDiary.RegistrationDiaryCode, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", rDiary.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", rDiary.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteRegistrationDiary, ParamArray);

                        int regDiaryID = int.Parse(ParamArray[2].Value.ToString());
                        if (rDiary.RegistrationDiarySubjectLIST.Count > 0)
                        {
                            foreach (ATTRegistrationDiarySubject regDiarySubject in rDiary.RegistrationDiarySubjectLIST)
                            {
                                regDiarySubject.CaseTypeID = rDiary.CaseTypeID;
                                regDiarySubject.RegistrationDiaryID = regDiaryID;
                            }
                            DLLRegistrationDiarySubject.AddEditDeleteRegistrationDiarySubject(rDiary.RegistrationDiarySubjectLIST, Tran);
                        }
                    }
                    if (rDiary.Action == "D")
                    {
                        ParamArray = new OracleParameter[3];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", rDiary.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", rDiary.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_ID", rDiary.RegistrationDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                        if (rDiary.RegistrationDiarySubjectLIST.Count > 0)
                        {
                            foreach (ATTRegistrationDiarySubject regDiarySubject in rDiary.RegistrationDiarySubjectLIST)
                            {
                                regDiarySubject.Action = "D";
                            }
                            DLLRegistrationDiarySubject.AddEditDeleteRegistrationDiarySubject(rDiary.RegistrationDiarySubjectLIST, Tran);
                        }
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteRegistrationDiary, ParamArray);
                    }
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
