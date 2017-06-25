using System;
using System.Collections.Generic;
using System.Text;
//using section
using System.Data;
using PCS.FRAMEWORK;
using PCS.COREDL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types; //For OracleRefCursor
using PCS.LIS.ATT;



namespace PCS.LIS.DLL
{
    public class DLLLookupLanguage
    {
        ////For populating ListBox
        public static DataTable GetLanguage()
        {
            string SelectSQL = "SP_GET_LANGUAGE";
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam("p_LANG_ID", null, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam("P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);


            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[1].Value).GetDataReader();
                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);
                return tbl;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
        //Adding new language.
        public static bool AddLanguage(ATT.ATTLookupLanguage objATT,Previlege pobj)
        {
            string InsertSQL;
            InsertSQL = "SP_ADD_LANGUAGE";
            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " add Language.");

                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam(":p_LANG_ID", objATT.LookupLanguageID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":P_LANG_NAME", objATT.LookupLanguageName, OracleDbType.NVarchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_ENTRY_BY", objATT.LookupLanguageEntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertSQL, paramArray);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        //Editing existing record
        public static bool UpdateLanguageType(ATTLookupLanguage objLT,Previlege pobj)
        {
            string UpdateSQL = "SP_EDIT_LANGUAGE";
            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " update Language.");

                OracleParameter[] paramArray = new OracleParameter[2];
                paramArray[0] = Utilities.GetOraParam("p_LANG_ID", objLT.LookupLanguageID, OracleDbType.Int16, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam("p_LANG_ID", objLT.LookupLanguageName, OracleDbType.Varchar2, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, UpdateSQL, paramArray);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        //Deleting record
        public static bool DeleteLanguage(ATTLookupLanguage objLT)
        {
            string DeleteSQL = "SP_DEL_LANGUAGE";
            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                OracleParameter[] paramArray = new OracleParameter[1];
                paramArray[0] = Utilities.GetOraParam("p_LANG_ID", objLT.LookupLanguageID, OracleDbType.Int16, ParameterDirection.Input);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, DeleteSQL, paramArray);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }
    }
}
