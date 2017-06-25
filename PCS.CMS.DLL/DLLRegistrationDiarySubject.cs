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
    public class DLLRegistrationDiarySubject
    {
        public static DataTable GetRegistrationDiarySubject(int orgID,int caseTypeID,int regDiaryID,int? SubjectID, string active)
        {
            try
            {
                string SelectRegistrationDiarySubjectSql = "SP_GET_REG_DIARY_SUBJECT";

                OracleParameter[] ParamArray = new OracleParameter[6];
                ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_REG_DIARY_ID", regDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_SUBJECT_ID", SubjectID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[5] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectRegistrationDiarySubjectSql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteRegistrationDiarySubject(List<ATTRegistrationDiarySubject> registrationDiarySubjectLST, OracleTransaction Tran)
        {
            string InsertUpdateDeleteRegistrationDiarySubject = "";

            try
            {                              
                foreach (ATTRegistrationDiarySubject rDiarySubject in registrationDiarySubjectLST)
                {
                    if (rDiarySubject.Action == "A")
                        InsertUpdateDeleteRegistrationDiarySubject = "SP_ADD_REG_DIARY_SUBJECT";
                    else if (rDiarySubject.Action == "E")
                        InsertUpdateDeleteRegistrationDiarySubject = "SP_EDIT_REG_DIARY_SUBJECT";
                    else if (rDiarySubject.Action == "D")
                        InsertUpdateDeleteRegistrationDiarySubject = "SP_DEL_REG_DIARY_SUBJECT";
                    OracleParameter[] ParamArray;

                    if (rDiarySubject.Action == "A" || rDiarySubject.Action == "E")
                    {
                        ParamArray = new OracleParameter[7];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", rDiarySubject.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", rDiarySubject.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_ID", rDiarySubject.RegistrationDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_SUBJECT_ID ", rDiarySubject.SubjectID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_SUBJECT_NAME", rDiarySubject.SubjectName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", rDiarySubject.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", rDiarySubject.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteRegistrationDiarySubject, ParamArray);

                        int rdSubjectID = int.Parse(ParamArray[3].Value.ToString());
                        if (rDiarySubject.RegistrationDiaryNameLIST.Count > 0)
                        {
                            foreach (ATTRegistrationDiaryName regDiaryName in rDiarySubject.RegistrationDiaryNameLIST)
                            {
                                regDiaryName.CaseTypeID = rDiarySubject.CaseTypeID;
                                regDiaryName.RegistrationDiaryID = rDiarySubject.RegistrationDiaryID;
                                regDiaryName.RegistrationSubjectID = rdSubjectID;
                            }
                            DLLRegistrationDiaryName.AddEditDeleteRegistrationDiaryName(rDiarySubject.RegistrationDiaryNameLIST, Tran);
                        }
                    }
                    else if (rDiarySubject.Action == "D")
                    {
                        ParamArray = new OracleParameter[4];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", rDiarySubject.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", rDiarySubject.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_ID", rDiarySubject.RegistrationDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_SUBJECT_ID", rDiarySubject.SubjectID, OracleDbType.Int64, ParameterDirection.Input);
                        if (rDiarySubject.RegistrationDiaryNameLIST.Count > 0)
                        {
                            foreach (ATTRegistrationDiaryName regDiaryName in rDiarySubject.RegistrationDiaryNameLIST)
                            {
                                regDiaryName.Action = "D";
                            }

                            DLLRegistrationDiaryName.AddEditDeleteRegistrationDiaryName(rDiarySubject.RegistrationDiaryNameLIST, Tran);
                        }
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteRegistrationDiarySubject, ParamArray);
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
         }
    }
}
