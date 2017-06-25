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
    public class DllApplication
    {
        public static bool SaveApplication(ATTApplication objApplication)
        {
            string InsertUpdateSQL = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                paramArray.Add(Utilities.GetOraParam(":P_APPLICATION_ID", objApplication.ApplicationID, OracleDbType.Int64, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam(":P_APPLICATION_NAME", objApplication.ApplicationName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_APPLICATION_TYPE", objApplication.ApplicationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objApplication.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objApplication.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                if (objApplication.Action == "A")
                    InsertUpdateSQL = "SP_ADD_APPLICATION";
                else if (objApplication.Action == "E")
                    InsertUpdateSQL = "SP_EDIT_APPLICATION";

                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                objApplication.ApplicationID = int.Parse(paramArray[0].Value.ToString());
                objApplication.Action = "";

                if (objApplication.OrgApplicationLST != null)
                {
                    DLLOrgApplication.SaveOrgApplication(objApplication.OrgApplicationLST, objApplication.ApplicationID, Tran);
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

        public static DataTable GetApplication(int? ApplicationID,string ApplicationType,  string active)
        {

            string SelectSql = "SP_GET_APPLICATION";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_APPLICATION_ID", ApplicationID, OracleDbType.Int64, ParameterDirection.Input));
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
