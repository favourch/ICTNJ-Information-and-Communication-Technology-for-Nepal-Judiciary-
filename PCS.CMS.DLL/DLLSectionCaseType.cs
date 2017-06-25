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
    public class DLLSectionCaseType
    {
        public static bool SaveSectionCaseType(List<ATTSectionCaseType> lstSectionCaseType)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            string InsertUpdateSQL = "";
            try
            {
                foreach (ATTSectionCaseType objSectionCaseType in lstSectionCaseType)
                {
                    if (objSectionCaseType.Action == "A")
                        InsertUpdateSQL = "SP_ADD_SEC_CASE_TYPE";
                    else if (objSectionCaseType.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_SEC_CASE_TYPE";
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objSectionCaseType.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objSectionCaseType.UnitID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", objSectionCaseType.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", objSectionCaseType.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_TO_DATE", objSectionCaseType.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objSectionCaseType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                }
                Tran.Commit();
                return true;
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
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

        public static DataTable GetSectionCasetype(int orgID,int unitID,int? caseTypeID,string fromDate)
        {
            string SelectSQL = "SP_GET_SEC_CASE_TYPE";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", unitID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", fromDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_RC",null, OracleDbType.RefCursor, ParameterDirection.Output));
           
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(System.Data.CommandType.StoredProcedure, SelectSQL,Module.CMS, paramArray.ToArray());
                 return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static DataTable GetSecCaseType(int orgID,int caseTypeID)
        {
            string SelectSQL = "SP_GET_CASE_TYPE_SECTIONS";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", caseTypeID, OracleDbType.Int64, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));

            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(System.Data.CommandType.StoredProcedure, SelectSQL, Module.CMS, paramArray.ToArray());
                return (DataTable)ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
