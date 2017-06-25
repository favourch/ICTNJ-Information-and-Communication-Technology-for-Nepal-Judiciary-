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
    public class DLLInvItemUnit
    {
        public static DataTable GetItemTable(int? ItemID, string active)
        {
            string SelectSP;
            SelectSP = "SP_INV_GET_ITEMS_UNIT";
            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_items_unit_id", ItemID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_active", active, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

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
                getConn.CloseDbConn();
            }
            //try
            //{
            //    OracleParameter[] paramArray = new OracleParameter[3];
            //    paramArray[0] = Utilities.GetOraParam(":p_items_unit_id", ItemID, OracleDbType.Int64, ParameterDirection.Input);
            //    paramArray[1] = Utilities.GetOraParam(":p_active ", active, OracleDbType.Varchar2, ParameterDirection.Input);
            //    paramArray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);

            //    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.OAS, paramArray);
            //    if (ds.Tables.Count == 0)
            //        return new DataTable();
            //    else
            //        return ds.Tables[0];
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        /// <summary>
        /// Add ItemUnit object to database
        /// </summary>
        /// <param name="obj">ATTInvItemUnit object</param>
        /// <returns>return bool</returns>
        public static bool SaveItemUnit(ATTInvItemUnit obj)
        {
            string InsertSP;

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":p_items_unit_id", obj.ItemUnitID, OracleDbType.Int64, ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":p_items_unit_name", obj.ItemUnitName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_active", obj.Active , OracleDbType.Varchar2, ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

            GetConnection getConn = new GetConnection();
            try
            {
                OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
                if (obj.Action == "A") //New Add
                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_add_items_unit", paramArray.ToArray());
                else if (obj.Action == "E") //Update
                    SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_edit_items_unit", paramArray.ToArray());
                obj.ItemUnitID = int.Parse(paramArray[0].Value.ToString());
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
