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
    public class DLLRegistrationDiaryName
    {
        public static DataTable GetRegistrationDiaryName(int orgID,int caseTypeID,int regDiaryID,int SubjectID, int? regDiaryNameID, string active)
        {
            try
            {
                string SelectRegistrationDiaryNameSql = "SP_GET_REG_DIARY_NAME";

                OracleParameter[] ParamArray = new OracleParameter[7];
                ParamArray[0] = Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_REG_DIARY_ID", regDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[3] = Utilities.GetOraParam(":P_REG_SUBJECT_ID", SubjectID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[4] = Utilities.GetOraParam(":P_REG_DIARY_NAME_ID",regDiaryNameID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[5] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[6] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectRegistrationDiaryNameSql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteRegistrationDiaryName(List<ATTRegistrationDiaryName> registrationDiaryNameLST, OracleTransaction Tran)
        {
            string InsertUpdateDeleteRegistrationDiaryName = "";

            try
            {                
                foreach (ATTRegistrationDiaryName rDiaryName in registrationDiaryNameLST)
                {
                    if (rDiaryName.Action == "A")
                        InsertUpdateDeleteRegistrationDiaryName = "SP_ADD_REG_DIARY_NAME";
                    else if (rDiaryName.Action == "E")
                        InsertUpdateDeleteRegistrationDiaryName = "SP_EDIT_REG_DIARY_NAME";
                    else if (rDiaryName.Action == "D")
                        InsertUpdateDeleteRegistrationDiaryName = "SP_DEL_REG_DIARY_NAME";
                    OracleParameter[] ParamArray;

                    if (rDiaryName.Action == "A" || rDiaryName.Action == "E")
                    {
                        ParamArray = new OracleParameter[9];

                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", rDiaryName.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", rDiaryName.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_ID", rDiaryName.RegistrationDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_REG_SUBJECT_ID ", rDiaryName.RegistrationSubjectID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_NAME_ID", rDiaryName.RegistrationDiaryNameID, OracleDbType.Int64, ParameterDirection.InputOutput);
                        ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_NAME", rDiaryName.RegistrationDiaryName, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[6] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_NAME_DESC", rDiaryName.RegistrationDiaryNameDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[7] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", rDiaryName.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                        ParamArray[8] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", rDiaryName.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteRegistrationDiaryName, ParamArray);
                        string st = ParamArray[4].Value.ToString();
                        rDiaryName.RegistrationDiaryNameID = int.Parse(ParamArray[3].Value.ToString());

                    }
                    else if (rDiaryName.Action == "D")
                    {
                        ParamArray = new OracleParameter[4];
                        ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_ORG_ID", rDiaryName.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", rDiaryName.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_ID", rDiaryName.RegistrationDiaryID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_REG_SUBJECT_ID", rDiaryName.RegistrationSubjectID, OracleDbType.Int64, ParameterDirection.Input);
                        ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_REG_DIARY_NAME_ID ", rDiaryName.RegistrationDiaryNameID, OracleDbType.Int64, ParameterDirection.Input);
                       
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteRegistrationDiaryName, ParamArray);
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
