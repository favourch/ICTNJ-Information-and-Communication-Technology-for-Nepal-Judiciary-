using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.LIS.ATT;
using PCS.LIS.DLL;

namespace PCS.LIS.DLL
{
    /// <summary>
    /// This class implements data logic for Author
    /// </summary>
    public class DLLAuthor
    {
        /// <summary>
        /// Get list of author
        /// </summary>
        /// <param name="authorID">Author ID for filter criteria</param>
        /// <returns>Datatable</returns>
        public static DataTable GetAuthorTable(int? authorID)
        {
            string SelectSP;
            SelectSP = "SP_GET_AUTHOR";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_AUTHOR_ID", authorID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.LIS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

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
                getConn.CloseDbConn();
            }
        }

        /// <summary>
        /// Add author object to database
        /// </summary>
        /// <param name="obj">ATTAuthor object</param>
        /// <returns>return bool</returns>
        public static bool AddAuthor(ATTAuthor obj, Previlege pobj)
        {
            string InsertSP;
            InsertSP = "SP_ADD_Author";

            //Preparing oracle parameter with value
            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_AUTHOR_ID", obj.AuthorID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":p_AUTHOR_NAME", obj.AuthorName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);
            
            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " add Author.");

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertSP, paramArray);
                obj.AuthorID = int.Parse(paramArray[0].Value.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }

        /// <summary>
        /// Edit author object to database
        /// </summary>
        /// <param name="obj">ATTAuthor object</param>
        /// <returns>return bool</returns>
        public static bool EditAuthor(ATTAuthor obj,Previlege pobj)
        {
            string EditSP;
            EditSP = "SP_EDIT_AUTHOR";

            //Preparing oracle parameter with value
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_AUTHOR_ID", obj.AuthorID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":p_AUTHOR_NAME", obj.AuthorName, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " update Author.");

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, EditSP, paramArray);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                getConn.CloseDbConn();
            }
        }
    }
}
