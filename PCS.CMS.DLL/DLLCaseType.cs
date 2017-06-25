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
    public class DLLCaseType
    {

        public static DataTable GetCaseType(int? caseTypeID, string active)
        {
            try
            {
                string SelectCaseTypeSql = "SP_GET_CASE_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[3];
                ParamArray[0] = Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectCaseTypeSql, Module.CMS, ParamArray);
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddEditDeleteCaseType(ATTCaseType cType)
        {
            string InsertUpdateDeleteCaseType = "";
            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.CMS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {
                if (cType.CaseTypeID == 0)
                    InsertUpdateDeleteCaseType = "SP_ADD_CASE_TYPE";
                else
                    InsertUpdateDeleteCaseType = "SP_EDIT_CASE_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[6];

                ParamArray[0] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_ID", cType.CaseTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = FRAMEWORK.Utilities.GetOraParam(":P_CASE_TYPE_NAME", cType.CaseTypeName, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[2] = FRAMEWORK.Utilities.GetOraParam(":P_APPELLANT", cType.Appellant, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[3] = FRAMEWORK.Utilities.GetOraParam(":P_RESPONDENT", cType.Respondant, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[4] = FRAMEWORK.Utilities.GetOraParam(":P_ACTIVE", cType.Active, OracleDbType.Varchar2, ParameterDirection.Input);
                ParamArray[5] = FRAMEWORK.Utilities.GetOraParam(":P_ENTRY_BY", cType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateDeleteCaseType, ParamArray);
                cType.CaseTypeID = int.Parse(ParamArray[0].Value.ToString()); 
                int ctID = int.Parse(ParamArray[0].Value.ToString());
                
                DLLOrganizationCaseType.SaveOrgCaseType(cType.OrganisationCaseTypesLIST, ctID, Tran);

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
