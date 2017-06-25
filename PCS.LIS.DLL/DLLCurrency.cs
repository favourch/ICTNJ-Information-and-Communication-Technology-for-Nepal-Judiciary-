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
    public class DLLCurrency
    {
        public static DataTable GetCurrencyTable(int? currencyID)
        {
            string SelectSP;
            SelectSP = "SP_GET_CURRENCY";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_CURRENCY_ID", currencyID, OracleDbType.Int64, ParameterDirection.Input);
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

        public static bool AddCurrency(ATTCurrency obj, Previlege pobj)
        {
            string InsertSP;
            InsertSP = "SP_ADD_CURRENCY";

            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_CURRENCY_ID", obj.CurrencyID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":p_CURRENCY_NAME", obj.CurrencyName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_ENTRY_BY", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " add Currency.");

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, InsertSP, paramArray);
                obj.CurrencyID = int.Parse(paramArray[0].Value.ToString());

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

        public static bool EditCurrency(ATTCurrency obj, Previlege pobj)
        {
            string EditSP;
            EditSP = "SP_EDIT_CURRENCY";

            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_CURRENCY_ID", obj.CurrencyID, OracleDbType.Int64, ParameterDirection.InputOutput);
            paramArray[1] = Utilities.GetOraParam(":p_CURRENCY_NAME", obj.CurrencyName, OracleDbType.Varchar2, ParameterDirection.Input);

            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.LIS);

                if (Previlege.HasPrevilege(pobj, DBConn) == false)
                    throw new ArgumentException(Utilities.PreviledgeMsg + " update Currency.");

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
