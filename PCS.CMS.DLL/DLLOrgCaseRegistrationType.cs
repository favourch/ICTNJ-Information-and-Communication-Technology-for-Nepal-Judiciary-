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
   public class DLLOrgCaseRegistrationType
    {

       public static bool SaveOrgCaseRegType(List<ATTOrgCaseRegistrationType> lstOrgCaseRegType)
       {
           string InsertUpdateSQL = "";
           GetConnection GetConn = new GetConnection();
           OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
           try
           {
               foreach (ATTOrgCaseRegistrationType objOrgCaseRegType in lstOrgCaseRegType)
               {
                   if(objOrgCaseRegType.Action=="A")
                       InsertUpdateSQL = "SP_ADD_ORG_CASE_REG_TYPE";
                   else if(objOrgCaseRegType.Action=="E")
                       InsertUpdateSQL = "SP_EDIT_ORG_CASE_REG_TYPE";
                   List<OracleParameter> paramArray = new List<OracleParameter>();
                   paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objOrgCaseRegType.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                   paramArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", objOrgCaseRegType.CaseTypeID, OracleDbType.Varchar2, ParameterDirection.Input));
                   paramArray.Add(Utilities.GetOraParam(":P_REG_TYPE_ID", objOrgCaseRegType.RegTypeID, OracleDbType.Varchar2, ParameterDirection.Input));
                   paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objOrgCaseRegType.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                   paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objOrgCaseRegType.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                   
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


       public static DataTable GetOrgCaseRegType(int orgID, int CaseTypeID,int? regTypeID, string active)
       {

           string SelectSql = "SP_GET_ORG_CASE_REG_TYPE";

           List<OracleParameter> ParamArray = new List<OracleParameter>();
           ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
           ParamArray.Add(Utilities.GetOraParam(":P_CASE_TYPE_ID", CaseTypeID, OracleDbType.Int64, ParameterDirection.Input));
           ParamArray.Add(Utilities.GetOraParam(":P_REG_TYPE_ID", regTypeID, OracleDbType.Int64, ParameterDirection.Input));
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
