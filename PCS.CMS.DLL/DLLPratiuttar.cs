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
    public class DLLPratiuttar
    {
        public static bool SavePratiuttar(ATTPratiuttar objPratiuttar)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();
            double pratiuttarID = 0;
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", objPratiuttar.CaseID, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_PRATIUTTAR_ID", pratiuttarID, OracleDbType.Int32, ParameterDirection.InputOutput));
                paramArray.Add(Utilities.GetOraParam(":P_PRATIUTTAR_DATE", objPratiuttar.PratiuttarDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ACCOUNT_FORWARD", objPratiuttar.AccountForward, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_SUBMITTED_BY", objPratiuttar.SubmittedBy, OracleDbType.Double, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_PRATIUTTAR_SUMMARY", objPratiuttar.PratiuttarSummary, OracleDbType.Varchar2, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objPratiuttar.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                if (objPratiuttar.PratiuttarID == 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_ADD_CASE_PRATIUTTAR", paramArray.ToArray());
                else if (objPratiuttar.PratiuttarID > 0)
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "SP_EDIT_CASE_PRATIUTTAR", paramArray.ToArray());

                objPratiuttar.PratiuttarID = int.Parse(paramArray[1].Value.ToString());
                if (objPratiuttar.LstPratiuttarLitigants.Count > 0) DLLPratiuttarLitigants.SavePratiuttarLitigants(objPratiuttar.LstPratiuttarLitigants, objPratiuttar.PratiuttarID, Tran);
                if (objPratiuttar.LstPratiuttarEvidence.Count > 0) DLLPratiuttarEvidence.SavePratiuttarEvidence(objPratiuttar.LstPratiuttarEvidence, objPratiuttar.PratiuttarID, Tran);
                if (objPratiuttar.LstPratiuttarDocuments.Count > 0) DLLPratiuttarDocuments.SavePratiuttarDocuments(objPratiuttar.LstPratiuttarDocuments, objPratiuttar.PratiuttarID, Tran);

                Tran.Commit();
                paramArray.Clear();
                return true;
            }

            catch (OracleException oex)
            {
                PCS.COREDL.OracleError oe = new PCS.COREDL.OracleError();
                throw new ArgumentException(oe.GetOraError(oex.Number, oex.Message));
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
