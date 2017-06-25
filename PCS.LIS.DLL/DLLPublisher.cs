using System;
using System.Collections.Generic;
using System.Text;
//Using section
//
using System.Data;
using PCS.FRAMEWORK;
using PCS.COREDL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types; //For OracleRefCursor
using PCS.LIS.ATT;
//


namespace PCS.LIS.DLL
{
    public class DLLPublisher
    {
        ////For populating ListBox
        public static DataTable GetPublisher()
        {
            string SelectSQL = "SP_GET_PUBLISHER";
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam("p_PUBLISHER_ID", null, OracleDbType.Int64, ParameterDirection.Input);
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

        public static bool AddPublisher(ATT.ATTPublisher objATT,Previlege pobj)
        {
            string InsertSQL;
            InsertSQL = "SP_ADD_PUBLISHER";
            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " add Publisher.");

                OracleParameter[] paramArray = new OracleParameter[4];
                paramArray[0] = Utilities.GetOraParam(":p_PUBLISHER_ID", objATT.PublisherID, OracleDbType.Int64, ParameterDirection.InputOutput);
                paramArray[1] = Utilities.GetOraParam(":P_PUBLISHER_NAME", objATT.PublisherName, OracleDbType.NVarchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam(":P_PUBLISHER_ADDRESS", objATT.PublisherAddress, OracleDbType.NVarchar2, ParameterDirection.Input);
                paramArray[3] = Utilities.GetOraParam(":p_ENTRY_BY", objATT.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

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
        //Update
        public static bool UpdatePublisherType(ATTPublisher objPT,Previlege pobj)
        {
            string UpdateSQL = "SP_EDIT_PUBLISHER";
            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " update Publisher.");

                OracleParameter[] paramArray = new OracleParameter[3];
                paramArray[0] = Utilities.GetOraParam("p_PUBLISHER_ID", objPT.PublisherID, OracleDbType.Int16, ParameterDirection.Input);
                paramArray[1] = Utilities.GetOraParam("p_PUBLISHER_NAME", objPT.PublisherName, OracleDbType.Varchar2, ParameterDirection.Input);
                paramArray[2] = Utilities.GetOraParam("p_PUBLISHER_ADDRESS", objPT.PublisherAddress, OracleDbType.Varchar2, ParameterDirection.Input);
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

        //Deleting publisher record
        public static bool DeletePublisher(ATTPublisher objPT)
        {
            string DeleteSQL = "SP_DEL_PUBLISHER";
            GetConnection GetConn = new GetConnection();
            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.LIS);
                OracleParameter[] paramArray = new OracleParameter[1];
                paramArray[0] = Utilities.GetOraParam("p_PUBLISHER_ID", objPT.PublisherID, OracleDbType.Int16, ParameterDirection.Input);
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
