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
    public class DLLPratiuttarDocLit
    {
        public static bool SavePratiuttarDocLit(List<ATTPratiuttarDocLit> lstPratiuttarDocLit, int pratiuttarID,int documentID, OracleTransaction Tran)
        {
            try
            {
                List<OracleParameter> paramArray = new List<OracleParameter>();
                foreach (ATTPratiuttarDocLit lst in lstPratiuttarDocLit)
                {
                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", lst.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_PRATIUTTAR_ID", pratiuttarID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_LITIGANT_ID", lst.LitigantID, OracleDbType.Int32, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_DOCUMENT_ID", documentID, OracleDbType.Int32, ParameterDirection.Input));
                    if (lst.Action == "D")
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_DEL_CASE_PRA_DOC_LIT", paramArray.ToArray());
                    else
                    {
                        paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", lst.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                        if (lst.Action == "A")
                            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_CASE_PRA_DOC_LIT", paramArray.ToArray());
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
