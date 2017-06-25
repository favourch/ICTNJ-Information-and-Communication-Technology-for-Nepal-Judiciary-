using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.OAS.ATT;

namespace PCS.OAS.DLL
{
    public class DLLInvItemType
    {
        public static DataTable GetItemType(int? itemtypeid, string active)
        {            
            List<OracleParameter> param = new List<OracleParameter>();
            param.Add(Utilities.GetOraParam(":p_items_type_id", itemtypeid, OracleDbType.Int64, ParameterDirection.Input));
            param.Add(Utilities.GetOraParam(":p_active", active, OracleDbType.Varchar2, ParameterDirection.Input));
            param.Add(Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));
            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_get_items_type", param.ToArray());
                OracleDataReader reader = ((OracleRefCursor)param[2].Value).GetDataReader();
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
    }
}
