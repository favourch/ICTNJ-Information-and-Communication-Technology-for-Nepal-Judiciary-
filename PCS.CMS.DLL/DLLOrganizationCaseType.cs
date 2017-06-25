using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLOrganizationCaseType
    {
        public static bool SaveOrgCaseType(List<ATTOrganizationCaseType> lstOrgCaseType, int caseTypeID, OracleTransaction Tran)
        {
            string InsertUpdateSQL = "SP_SAVE_ORG_CASE_TYPE";
            try
            {
                foreach (ATTOrganizationCaseType objOrgCaseType in lstOrgCaseType)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objOrgCaseType.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objOrgCaseType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objOrgCaseType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                }
                return true;
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                Tran.Rollback();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                Tran.Rollback();
                throw ex;
            }
        }
        public static DataTable GetOrgCaseType(int? orgID,int? CaseTypeID, string active)
        {

            string SelectSql = "SP_GET_ORG_CASE_TYPE";

            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //public static DataTable GetOrgByCaseType(int CaseTypeID, string active)
        //{

        //    string SelectSql = "SP_GET_ORG_CASE_TYPE";

        //    List<OracleParameter> ParamArray = new List<OracleParameter>();
        //    ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", null, OracleDbType.Int64, ParameterDirection.Input));
        //    ParamArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
        //    ParamArray.Add(Utilities.GetOraParam(":P_ACTIVE", active, OracleDbType.Varchar2, ParameterDirection.Input));
        //    ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
        //    try
        //    {
        //        DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
        //        return (DataTable)ds.Tables[0];

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}
    }
}
