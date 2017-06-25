using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;

namespace PCS.OAS.DLL
{
    public class DLLDocument
    {
        //public static int QueryID;
        public static DataTable GetDocumentNameListTable(int? docID,int? unitID, int? orgID)
        {
            string SelectSQL = "SP_GET_DOCUMENT";

            OracleParameter[] paramArray = new OracleParameter[4];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID", unitID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", docID, OracleDbType.Int16, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_RC", null, OracleDbType.RefCursor, ParameterDirection.Output);

            GetConnection GetConn = new GetConnection();

            try
            {
                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSQL, paramArray);
                OracleDataReader reader = ((OracleRefCursor)paramArray[3].Value).GetDataReader();

                DataTable tbl = new DataTable();
                tbl.Load(reader, LoadOption.OverwriteChanges);

                return tbl;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }
        }

        public static bool UpdateDocument(ATTDocument objDoc)
        {
            string UpdateSQL = "SP_EDIT_Document";
            int CountDocAttachment = objDoc.LstDocAttachment.Count;
            int CountDocProcess = objDoc.LstDocProcess.Count;

            OracleParameter[] paramArray = new OracleParameter[7];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objDoc.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID", objDoc.UnitID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", objDoc.DocID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[3] = Utilities.GetOraParam(":p_DOCUMENT_NAME", objDoc.DocumentName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":p_DOCUMENT_DESC", objDoc.DocDescription, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":p_FILE_CAT_ID", objDoc.DocCategory, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":p_DOCUMENT_FLOW_ID", objDoc.DocFlowType, OracleDbType.Int64, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {

                SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, UpdateSQL, paramArray);
              
                if (CountDocProcess > 0)
                    DLLDocumentProcess.UpateDocProcess(objDoc.LstDocProcess, Tran);

                if (CountDocAttachment > 0)
                    DLLDocumentAttachment.UpateDocAttachment(objDoc.LstDocAttachment, Tran);


                Tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw (ex);
            }

        }

        public static bool SaveDocument(ATTDocument objDoc)
        {
            string SaveSQL = "SP_ADD_Document";
            int CountDocAttachment = objDoc.LstDocAttachment.Count;
            int CountDocProcess = objDoc.LstDocProcess.Count;
            int DocSeq = 0;

            OracleParameter[] paramArray = new OracleParameter[7];
            paramArray[0] = Utilities.GetOraParam(":p_ORG_ID",objDoc.OrgID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID",objDoc.UnitID, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", null, OracleDbType.Int64, ParameterDirection.Output);
            paramArray[3] = Utilities.GetOraParam(":p_DOCUMENT_NAME", objDoc.DocumentName, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[4] = Utilities.GetOraParam(":p_DOCUMENT_DESC", objDoc.DocDescription, OracleDbType.Varchar2, ParameterDirection.Input);
            paramArray[5] = Utilities.GetOraParam(":p_FILE_CAT_ID",objDoc.DocCategory, OracleDbType.Int64, ParameterDirection.Input);
            paramArray[6] = Utilities.GetOraParam(":p_DOCUMENT_FLOW_ID",objDoc.DocFlowType, OracleDbType.Int64, ParameterDirection.Input);

            GetConnection GetConn = new GetConnection();
            OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();

            try
            {
         
                //SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure,SaveSQL, paramArray);
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveSQL, paramArray);
                objDoc.DocID = int.Parse(paramArray[2].Value.ToString());

                if(CountDocProcess > 0)
                    DocSeq = DLLDocumentProcess.SaveDocProcess(objDoc.OrgID, objDoc.UnitID, objDoc.DocID, objDoc.LstDocProcess, Tran);

                if (CountDocAttachment > 0)
                    DLLDocumentAttachment.SaveDocAttachment(objDoc.OrgID, objDoc.UnitID, objDoc.DocID, objDoc.LstDocAttachment,DocSeq,Tran);

                Tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Tran.Rollback();
                throw(ex);
            }
        }


        //public static DataTable SearchDocumentListTable(int? orgID, int? unitID, int? docID, string docName,string status,int queryID)
        public static DataTable SearchDocumentListTable(int? orgID, int? unitID, int? docID, string docName,string status)
        {
            GetConnection GetConn = new GetConnection();

            try
            {

                //QueryID = queryID;
                string SearchSQL;
                SearchSQL = QueryBuilder(orgID, unitID, docID, docName,status);

                OracleConnection DBConn = GetConn.GetDbConn(Module.OAS);
                DataSet ds = SqlHelper.ExecuteDataset(DBConn, CommandType.Text, SearchSQL);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                return tbl;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                GetConn.CloseDbConn();
            }

        }

        public static string QueryBuilder(int? orgID, int? unitID, int? docID, string docName,string status)
        {
            string GeneralSQL ="";
            string ConditionSQL = "";

            //GeneralSQL = "SELECT * FROM  oas_owner.vw_document ";

            //if(QueryID == 0)
                GeneralSQL = "SELECT DISTINCT Org_id,UNIT_ID,DOC_ID,DOC_NAME,DESCRIPTION,FLOW_ID,DOC_FLOW_NAME,CAT_ID,CATEGORY_NAME   FROM oas_owner.vw_document ";

            //else if(QueryID == 1)
            //    GeneralSQL = "SELECT  ORG_ID,UNIT_ID,DOC_ID,ATTACH_SEQ,ATTACH_ID,ATTACH_FILEBYTE,ATTACH_FILENAME,ATTACH_DESCRIPTION FROM oas_owner.vw_document";

            //else if(QueryID == 2)
            //    GeneralSQL = "SELECT DISTINCT ORG_ID,UNIT_ID,DOC_ID,PROCESS_SEQ,SEND_TO,SEND_TYPE,STATUS,HAS_RECEIVED,NOTE FROM oas_owner.vw_document ";

            if ((orgID != null) && (unitID != null) && (docID != null))
            {
                ConditionSQL = " WHERE org_id = " + orgID + " AND unit_id = " + unitID + " AND doc_id = " + docID + " AND doc_Name LIKE '" + docName.Trim() + "' ";
            }
            else if ((orgID != null) && (unitID != null) && (docID == null))
            {
                ConditionSQL = " WHERE org_id = " + orgID + " AND unit_id = " + unitID;
            }
            else if ((orgID != null) && (unitID == null) && (docID != null))
            {
                ConditionSQL = " WHERE org_id = " + orgID + " AND doc_id = " + docID + " AND doc_Name LIKE '" + docName.Trim() + "' ";
            }
            else if ((orgID == null) && (unitID != null) && (docID != null))
            {
                ConditionSQL = " WHERE  unit_id = " + unitID + " AND doc_id = " + docID + " AND doc_Name LIKE '" + docName.Trim() + "' ";
            }
            else if ((orgID != null) && (unitID == null) && (docID == null))
            {
                ConditionSQL = " WHERE org_id = " + orgID;

            }
            else if ((orgID == null) && (unitID == null) && (docID != null))
            {
                ConditionSQL = " WHERE  doc_id = " + docID + " AND doc_Name LIKE '" + docName.Trim() + "' ";
            }
            else if ((orgID == null) && (unitID != null) && (docID == null))
            {
                ConditionSQL = " WHERE  unit_id = " + unitID;
            }

            if (status != "")
            {
                if(ConditionSQL == "")
                    ConditionSQL = "WHERE  status = '" + status +"'";
                else
                    ConditionSQL = ConditionSQL + " AND  status = '" + status + "'";
            }

            //if (QueryID == 1)
            //{
            //    if (ConditionSQL == "")
            //        ConditionSQL = "WHERE  ATTACH_ID > 0 ORDER BY ATTACH_ID ";
            //    else
            //        ConditionSQL = ConditionSQL + " AND  ATTACH_ID > 0 ORDER BY ATTACH_ID ";
            //}

            //if (QueryID == 2)
            //{
            //    if (ConditionSQL == "")
            //        ConditionSQL = "WHERE  PROCESS_SEQ > 0";
            //    else
            //        ConditionSQL = ConditionSQL + " AND  PROCESS_SEQ > 0";
            //}


            return (GeneralSQL + " " + ConditionSQL);
        }
    }
}
