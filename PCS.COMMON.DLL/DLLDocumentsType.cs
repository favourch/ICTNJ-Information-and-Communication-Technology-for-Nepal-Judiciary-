using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;
using Oracle.DataAccess.Client;

namespace PCS.COMMON.DLL
{
    public class DLLDocumentsType
    {
        public static DataTable GetDocumentsType(int? docTypeId)
        {
            GetConnection GetCon = new GetConnection();
            OracleConnection DBConn;
            OracleCommand Cmd;

            try
            {
                DBConn = GetCon.GetDbConn();
                Cmd = new OracleCommand();
                string SelectSql = "SP_GET_DOCUMENTS_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[2];
                ParamArray[0] = Utilities.GetOraParam(":p_DOC_TYPE_ID", docTypeId, OracleDbType.Int64, ParameterDirection.Input);
                ParamArray[1] = Utilities.GetOraParam(":P_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSql, ParamArray);
                return (DataTable)ds.Tables[0];

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

        public static bool SaveDocumentTypes(ATTDocumentsType objDocType)
        {
            GetConnection GetConn = new GetConnection();
            OracleTransaction Tran = GetConn.GetDbConn().BeginTransaction();
            int DocumentTypeID = 0;
            try
            {
                string InsertUpdateSQL = "";

                if (objDocType.DocTypeID <= 0)
                    InsertUpdateSQL = "SP_ADD_DOCUMENTS_TYPE";
                else
                    InsertUpdateSQL = "SP_EDIT_DOCUMENTS_TYPE";

                OracleParameter[] ParamArray = new OracleParameter[2];

                ParamArray[0] = Utilities.GetOraParam(":p_DOC_TYPE_ID", objDocType.DocTypeID, OracleDbType.Int64, ParameterDirection.InputOutput);
                ParamArray[1] = Utilities.GetOraParam(":p_DOC_TYPE_NAME", objDocType.DocTypeName, OracleDbType.Varchar2, ParameterDirection.Input);

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, InsertUpdateSQL, ParamArray[0], ParamArray);
                DocumentTypeID = int.Parse(ParamArray[0].Value.ToString());
                objDocType.DocTypeID = DocumentTypeID;
                Tran.Commit();
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
