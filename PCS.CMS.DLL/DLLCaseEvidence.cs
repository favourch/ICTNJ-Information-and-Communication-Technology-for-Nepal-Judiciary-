using System;
using System.Collections.Generic;
using System.Text;


using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using PCS.CMS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;


namespace PCS.CMS.DLL
{
    public class DLLCaseEvidence
    {
        public static bool SaveCaseEvidence(List<ATTCaseEvidence> CaseEvidenceLST,OracleTransaction Tran)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray;
            //GetConnection GetConn = new GetConnection();
            //OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            try
            {

                foreach (ATTCaseEvidence objCaseEvidence in CaseEvidenceLST)
                {
                    paramArray = new List<OracleParameter>();

                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", objCaseEvidence.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_EVIDENCE_ID", objCaseEvidence.EvidenceID, OracleDbType.Int16, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_EVIDENCE", objCaseEvidence.Evidence, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objCaseEvidence.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    if (objCaseEvidence.Action == "A")
                        InsertUpdateSQL = "SP_ADD_CASE_EVIDENCE";
                    else if (objCaseEvidence.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_CASE_EVIDENCE";

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());

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
                Tran.Rollback();
                throw ex;
            }
           

        }


        public static DataTable GetCaseEvidence(double? CaseID)
        {

            string SelectSql = "SP_GET_CASE_EVIDENCE";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", CaseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output));
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, Module.CMS, ParamArray.ToArray());
                return (DataTable)ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
