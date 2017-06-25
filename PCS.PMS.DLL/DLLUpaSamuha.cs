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
    public class DLLUpaSamuha
    {
        public static DataTable GetUpaSamuhaTable(int? sewaID, int? samuhaID, int? upaSamuhaID)
        {
            string SelectSP = "select * from vw_get_upa_samuha where 1=1 ";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            if (sewaID != null)
            {
                SelectSP = SelectSP + " and sewa_id=:sewaID ";
                paramArray.Add(Utilities.GetOraParam(":sewaID", sewaID, OracleDbType.Int64, ParameterDirection.Input));
            }

            if (samuhaID != null)
            {
                SelectSP = SelectSP + " and samuha_id=:samuhaID ";
                paramArray.Add(Utilities.GetOraParam(":samuhaID", samuhaID, OracleDbType.Int64, ParameterDirection.Input));
            }

            if (upaSamuhaID != null)
            {
                SelectSP = SelectSP + " and upa_samuha_id=:upsamuhaID ";
                paramArray.Add(Utilities.GetOraParam(":upsamuhaID", upaSamuhaID, OracleDbType.Int64, ParameterDirection.Input));
            }

            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, SelectSP, Module.PMS, paramArray.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddUpaSamuha(List<ATTUpaSamuha> lstUpaSamuha, int sewaID,int samuhaID, OracleTransaction Tran)
        {
            string InsertSP = "";

            List<OracleParameter> paramArray = new List<OracleParameter>();

            try
            {
                foreach (ATTUpaSamuha Upasamuha in lstUpaSamuha)
                {
                    if (Upasamuha.Action == "A")
                        InsertSP = "sp_add_upa_samuha1";
                    else if (Upasamuha.Action == "M")
                        InsertSP = "SP_EDIT_UPA_SAMUHA1";

                    paramArray.Add(Utilities.GetOraParam(":P_SEWA_ID", sewaID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_SAMUHA_ID", samuhaID, OracleDbType.Int64, System.Data.ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_UPA_SAMUHA_ID", Upasamuha.UpaSamuhaID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_UPA_SAMUHA_NAME", Upasamuha.UpaSamuhaName, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", Upasamuha.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
                    //paramArray.Add(Utilities.GetOraParam(":P_ENTRY_ON", Upasamuha.EntryOn, OracleDbType.Date, System.Data.ParameterDirection.Input));

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertSP, paramArray.ToArray());
                    Upasamuha.SewaID = sewaID;
                    Upasamuha.SamuhaID = samuhaID;
                    Upasamuha.SamuhaID = int.Parse(paramArray[2].Value.ToString());
                    Upasamuha.Action = "M";

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
