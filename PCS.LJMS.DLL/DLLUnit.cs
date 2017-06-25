using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.LJMS.ATT;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.LJMS.DLL
{
    public class DLLUnit
    {
        public static DataTable GetUnitTable(string status)
        {
            string SP = "SP_GET_UNITS";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("p_unit_id", null, OracleDbType.Int16, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_active", status, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput));

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SP, Module.LJMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddUnit(ATTUnit unit)
        {
            string SP = "";
            
            if (unit.Action == "A")
                SP = "sp_add_units";
            else if (unit.Action == "E")
                SP = "sp_edit_units";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam("P_UNIT_ID", unit.UnitID, OracleDbType.Int16, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam("P_UNIT_NAME", unit.UnitName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_UNIT_ADDRESS", unit.UnitAddress, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_UNIT_PHONE", unit.UnitPhone, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam("P_ACTIVE", unit.Active, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection DBConn = new GetConnection();
            try
            {
                OracleConnection Conn = DBConn.GetDbConn(Module.LJMS);
                SqlHelper.ExecuteNonQuery(Conn, CommandType.StoredProcedure, SP, paramArray.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConn.CloseDbConn();
            }
        }
    }
}
