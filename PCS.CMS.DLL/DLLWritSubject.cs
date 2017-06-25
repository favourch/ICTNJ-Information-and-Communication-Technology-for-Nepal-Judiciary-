using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PCS.CMS.DLL
{
    public class DLLWritSubject
    {
        public static bool SaveWritSubject(ATTWritSubject objWritSubject)
        {
            string InsertUpdateSQL = "";

            if (objWritSubject.Action == "A")
                InsertUpdateSQL = "SP_ADD_WRIT_SUBJECT";
            else if (objWritSubject.Action == "E")
                InsertUpdateSQL = "SP_EDIT_WRIT_SUBJECT";


            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", objWritSubject.WritSubjectID, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_NAME", objWritSubject.WritSubjectName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ACTIVE", objWritSubject.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objWritSubject.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                objWritSubject.WritSubjectID = int.Parse(paramArray[0].Value.ToString());
                objWritSubject.Action = "";

                if (objWritSubject.WritCategoryLST != null)
                {
                    DLLWritCategory.AddWritCategory(objWritSubject.WritCategoryLST, Tran, objWritSubject.WritSubjectID);
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

        public static DataTable GetWritSubject(int? writSubID, string active)
        {

            string SelectSql = "SP_GET_WRIT_SUBJECT";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_WRIT_SUB_ID", writSubID, OracleDbType.Int64, ParameterDirection.Input));
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
