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
   public class DLLSectionClerkCase
    {
        public static bool SaveSectionClerkCase(List<ATTSectionClerkCase> lstSectionClerkCase)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            string InsertUpdateSQL = "";
            try
            {
                foreach (ATTSectionClerkCase objSectionClerkCase in lstSectionClerkCase)
                {
                    if (objSectionClerkCase.Action == "A")
                        InsertUpdateSQL = "SP_ADD_SEC_CLERK_CASE";
                    else if (objSectionClerkCase.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_SEC_CLERK_CASE";
                    List<OracleParameter> paramArray = new List<OracleParameter>();
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objSectionClerkCase.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_UNIT_ID", objSectionClerkCase.UnitID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", objSectionClerkCase.CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_FROM_DATE", objSectionClerkCase.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", objSectionClerkCase.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_SEC_CLRK_ID", objSectionClerkCase.SectionClerkID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_SEC_CLRK_FROM_DATE", objSectionClerkCase.SectionClerkFromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objSectionClerkCase.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

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

       public static DataTable GetSectionClerkCase(double caseID)
       {
           string SelectSQL = "SP_GET_SEC_CLRK_CASE";

           List<OracleParameter> paramArray = new List<OracleParameter>();
           paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", caseID, OracleDbType.Double, ParameterDirection.Input));
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
