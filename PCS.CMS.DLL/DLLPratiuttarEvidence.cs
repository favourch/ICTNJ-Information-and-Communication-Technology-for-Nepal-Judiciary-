using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.COREDL;
using PCS.CMS.ATT;
using PCS.FRAMEWORK;

namespace PCS.CMS.DLL
{
    public class DLLPratiuttarEvidence
    {
        public static bool SavePratiuttarEvidence(List<ATTPratiuttarEvidence> lstPratiEvidence, int pratiuttarID, OracleTransaction Tran)
        {
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                foreach (ATTPratiuttarEvidence lst in lstPratiEvidence)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", lst.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_PRATIUTTAR_ID", pratiuttarID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_EVIDENCE_ID", lst.EvidenceID, OracleDbType.Int32, ParameterDirection.InputOutput));
                    if (lst.Action == "D")
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_CASE_PRA_EVIDENCE", paramArray.ToArray());
                    else
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_EVIDENCE", lst.Evidence, OracleDbType.Varchar2, ParameterDirection.Input));
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_CASE_PRA_EVIDENCE", paramArray.ToArray());
                        if (lst.Action == "E")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_CASE_PRA_EVIDENCE", paramArray.ToArray());
                    }
                    paramArray.Clear();
                }
                return true;
            }
            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
