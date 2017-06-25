using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.LIS.ATT;
using PCS.LIS.DLL;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LIS.DLL
{
    public class DLLMaterialCategory
    {

        public static DataTable GetMaterialCategoryTable()
        {
            string SelectSQL = "SP_GET_MATERIAL_CATEGORY";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_MATERIAL_CATEGORY_ID", null, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

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
                throw ex;
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static bool AddMaterialCategory(ATTMaterialCategory objMC,Previlege pobj)
        {
            string InsertSQL = "";
            InsertSQL = "SP_ADD_MATERIAL_CATEGORY";
            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " add Material Category.");
               
                OracleParameter[] paramArray = new OracleParameter[4];
                paramArray[0] = Utilities.GetOraParam(":p_CATEGORY_ID",0, OracleDbType.Int16, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_CATEGORY_NAME", objMC.CategoryName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_CATEGORY_DESCRIPTION", objMC.CategoryDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_CATEGORY_ENTRYBY", objMC.CategoryEntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(DBConn,CommandType.StoredProcedure, InsertSQL, paramArray);
                return true;
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

        public static bool UpdateMaterialCategory(ATTMaterialCategory objMC,Previlege pobj)
        {
            string UpdateSQL;
            UpdateSQL = "SP_EDIT_MATERIAL_CATEGORY";
            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " update Material Category.");

                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam(":p_CATEGORY_ID", objMC.CategoryID, OracleDbType.Int16, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam(":p_CATEGORY_NAME", objMC.CategoryName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":p_CATEGORY_DESCRIPTION", objMC.CategoryDescription, OracleDbType.Varchar2, ParameterDirection.Input);
               
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, UpdateSQL, paramArray);

                return true;
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
       
    }
}
