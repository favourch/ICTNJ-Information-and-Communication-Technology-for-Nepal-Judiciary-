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
    public class DLLSamuha
    {
        public static DataTable GetSamuhaTable(int? sewaID, int? samuhaID)
        {
            string SelectSP = "sp_get_samuha";
            OracleParameter[] paramArray = new OracleParameter[3];
            paramArray[0] = Utilities.GetOraParam(":p_sewa_id", sewaID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_samuha_id", samuhaID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_rc", sewaID, OracleDbType.RefCursor, ParameterDirection.InputOutput);

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.PMS, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddSamuha(List<ATTSamuha> lstSamuha, int sewaID, OracleTransaction Tran)
        {
            string InsertSP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTSamuha samuha in lstSamuha)
                {
                    if (samuha.Action == "A")
                        InsertSP = "sp_add_samuha";
                    else if (samuha.Action == "M")
                        InsertSP = "SP_EDIT_SAMUHA";

                    paramArray.Add(Utilities.GetOraParam(":p_sewa_id", sewaID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_samuha_id", samuha.SamuhaID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":p_samuha_name", samuha.SamuhaName, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_by", samuha.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_on", samuha.EntryOn, OracleDbType.Date, System.Data.ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
                    samuha.SewaID = sewaID;
                    samuha.SamuhaID = int.Parse(paramArray[1].Value.ToString());
                    samuha.Action = "M";

                    DLLUpaSamuha.AddUpaSamuha(samuha.LstUpaSamuha, samuha.SewaID, samuha.SamuhaID, Tran);

                    paramArray.Clear();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
