using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.LIS.DLL
{
    public class DLLLibrary
    {
        public static DataTable GetLibraryTable(int orgID,int? libraryID)
        {
            string SelectSQL = "SP_GET_LIBRARY";

            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_LIBRARY_ID", libraryID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);

                OracleDataReader reader = ((OracleRefCursor)paramArray[2].Value).GetDataReader();

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

        public static bool AddLibrary(ATTLibrary obj,Previlege pobj)
        {
            string SQL;

            SQL = "SP_ADD_LIBRARY";

            OracleParameter[] paramArray = new OracleParameter[5];
            paramArray[0] = Utilities.GetOraParam(":p_LIBRARY_ID", obj.LibraryID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_LIBRARY_NAME", obj.LibraryName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_LOCATION", obj.Location, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " add Libaray.");

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SQL, paramArray);
                obj.LibraryID = int.Parse(paramArray[0].Value.ToString());

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

        public static bool EditLibrary(ATTLibrary obj,Previlege pobj)
        {
            string SQL;

            SQL = "SP_EDIT_LIBRARY";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_LIBRARY_ID", obj.LibraryID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":p_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_LIBRARY_NAME", obj.LibraryName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_LOCATION", obj.Location, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " update Library.");

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SQL, paramArray);

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

        public static DataTable GetLibraryNameListTable()
        {
            GetConnection GetConn = new GetConnection();
            try
            {
                //string SelectSQL = "select * from library";

                string SelectSQL = "select distinct Library_ID,Library_Name,org_id from vw_library_info order by library_Name ASC";

                //OracleConnection DBConn = GetConn.GetDbConn("LIS_ADMIN", "LIS_ADMIN");
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SelectSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];

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
    }
}
