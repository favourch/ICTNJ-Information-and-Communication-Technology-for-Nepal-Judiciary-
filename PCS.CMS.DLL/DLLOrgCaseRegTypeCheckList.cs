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
    public class DLLOrgCaseRegTypeCheckList
    {
        public static bool SaveOrgCaseRegTypeCheckList(List<ATTOrgCaseRegTypeCheckList> lstOrgCaseRegTypeCheckList)
        {
            string InsertUpdateSQL = "";
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                foreach (ATTOrgCaseRegTypeCheckList objOrgCaseRegTypeCheckList in lstOrgCaseRegTypeCheckList)
                {
                    if (objOrgCaseRegTypeCheckList.Action == "A")
                        InsertUpdateSQL = "SP_ADD_ORGCASEREGTYPE_CHKLST";
                    else if (objOrgCaseRegTypeCheckList.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_ORGCASEREGTYPE_CHKLST";
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objOrgCaseRegTypeCheckList.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", objOrgCaseRegTypeCheckList.CaseTypeID, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_REG_TYPE_ID", objOrgCaseRegTypeCheckList.RegTypeID, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_CHECK_LIST_ID", objOrgCaseRegTypeCheckList.CheckListID, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objOrgCaseRegTypeCheckList.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objOrgCaseRegTypeCheckList.EntryBY, OracleDbType.Varchar2, ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                }

                Tran.Commit();
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
            finally
            {
                GetConn.CloseDbConn();
            }

        }


        public static DataTable GetOrgCaseRegTypeCheckList(int orgID, int CaseTypeID, int regTypeID,int? checkListID, string active)
        {

            string SelectSql = "SP_GET_ORGCASEREG_CHECKLIST";

            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_REG_TYPE_ID", regTypeID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_CHECK_LIST_ID", checkListID, OracleDbType.Int64, ParameterDirection.Input));
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

    }
}
