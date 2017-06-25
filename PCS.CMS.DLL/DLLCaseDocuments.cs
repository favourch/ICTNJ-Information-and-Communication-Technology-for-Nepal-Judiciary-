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
    public class DLLCaseDocuments
    {

        public static List<ATTCaseDocuments> SaveCaseDocument(List<ATTCaseDocuments> CaseDocumentLST, OracleTransaction Tran)
        {
            string InsertUpdateSQL = "";
            List<OracleParameter> paramArray;
            //GetConnection GetConn = new GetConnection();
            //OracleTransaction Tran = GetConn.GetDbConn(Module.CMS).BeginTransaction();

            try
            {

                foreach (ATTCaseDocuments objCaseDocument in CaseDocumentLST)
                {
                    paramArray = new List<OracleParameter>();

                    paramArray.Add(Utilities.GetOraParam(":P_CASE_ID", objCaseDocument.CaseID, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_DOCUMENT_ID", objCaseDocument.DocumentID, OracleDbType.Int16, ParameterDirection.InputOutput));
                    paramArray.Add(Utilities.GetOraParam(":P_DOCUMENT_FILE_NAME", objCaseDocument.DocumentFileName, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_DOCUMENT_CONTENT", objCaseDocument.DocumentContent, OracleDbType.Blob, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":P_ENTRY_BY", objCaseDocument.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));
                    if (objCaseDocument.Action == "A")
                        InsertUpdateSQL = "SP_ADD_CASE_DOCUMENTS";
                    else if (objCaseDocument.Action == "E")
                        InsertUpdateSQL = "SP_EDIT_CASE_DOCUMENTS";

                    SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, InsertUpdateSQL, paramArray.ToArray());
                    objCaseDocument.DocumentID = int.Parse(paramArray[1].Value.ToString());
                }


                return CaseDocumentLST;
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


        public static DataTable GetCaseDocuments(double? CaseID, int? documentID)
        {

            string SelectSql = "SP_GET_CASE_DOCUMENTS";
            List<OracleParameter> ParamArray = new List<OracleParameter>();
            ParamArray.Add(Utilities.GetOraParam(":P_CASE_ID", CaseID, OracleDbType.Double, ParameterDirection.Input));
            ParamArray.Add(Utilities.GetOraParam(":P_DOCUMENT_ID", documentID, OracleDbType.Int64, ParameterDirection.Input));
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
