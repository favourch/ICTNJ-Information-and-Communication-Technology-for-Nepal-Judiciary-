using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace PCS.PMS.DLL
{
    public class DLLSewa
    {
        public static DataTable GetSewaTable(int? sewaID)
        {
            string SelectSP = "sp_get_sewa";
            OracleParameter[] paramArray = new OracleParameter[2];
            paramArray[0] = Utilities.GetOraParam(":p_sewa_id", sewaID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_rc", sewaID, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddSewa(ATTSewa sewa)
        {
            string InsertSP;

            if (sewa.Action == "A")
                InsertSP = "SP_ADD_SEWA";
            else
                InsertSP = "SP_EDIT_SEWA";

            List<OracleParameter> paramArray = new List<OracleParameter>();
            paramArray.Add(Utilities.GetOraParam(":p_sewa_id", sewa.SewaID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
            paramArray.Add(Utilities.GetOraParam(":p_sewa_name", sewa.SewaName, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_entry_by", sewa.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
            paramArray.Add(Utilities.GetOraParam(":p_entry_on", sewa.EntryOn, OracleDbType.Date, System.Data.ParameterDirection.Input));

            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.PMS).BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
                sewa.SewaID = int.Parse(paramArray[0].Value.ToString());
                sewa.Action = "M";
                DLLSamuha.AddSamuha(sewa.LstSamuha, sewa.SewaID, Tran);

                Tran.Commit();
                return true;
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
    }
}
