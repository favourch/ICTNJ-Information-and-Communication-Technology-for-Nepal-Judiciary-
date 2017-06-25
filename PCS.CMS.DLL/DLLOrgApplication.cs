using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;

using PCS.CMS.ATT;
using PCS.FRAMEWORK;
using PCS.COREDL;

namespace PCS.CMS.DLL
{
    public class DLLOrgApplication
    {
        public static bool SaveOrgApplication(List< ATTOrgApplication> OrgLST,int applicationID,OracleTransaction Tran)
        {
            string InsertUpdateSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                foreach (ATTOrgApplication objOrgAppl in OrgLST)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", objOrgAppl.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_APPLICATION_ID", applicationID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objOrgAppl.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objOrgAppl.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (objOrgAppl.Action == "A")
                        InsertUpdateSQL = "SP_ADD_ORG_APPLICATION";
                    else if (objOrgAppl.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_ORG_APPLICATION";

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    objOrgAppl.Action = "";
                    paramArray.Clear();
                }
                return true;
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

           

        }

        public static DataTable GetOrgApplication(int? applicationID, int ? orgID, string active)
        {

            string SelectSql = "SP_GET_ORG_APPLICATION";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_APPLICATION_ID", applicationID, OracleDbType.Int64, ParameterDirection.Input));
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
