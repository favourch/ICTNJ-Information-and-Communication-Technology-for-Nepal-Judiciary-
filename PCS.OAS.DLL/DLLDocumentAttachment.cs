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
    public class DLLDocumentAttachment
    {
        public static bool UpateDocAttachment(List<ATTDocumentAttachment> lstDocAttach, OracleTransaction Tran)
        {
            try
            {
                //string UpdateAttachDocSQL = "SP_EDIT_DOCUMENT_PROCESS";

                string UpdateAttachDocSQL = "SP_EDIT_DOCUMENT_ATTACHMENT";
                foreach (ATTDocumentAttachment objDocAttach in lstDocAttach)
                {

                    OracleParameter[] paramArray = new OracleParameter[8];
                    paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", objDocAttach.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID", objDocAttach.UnitID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", objDocAttach.DocID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":p_DOC_SEQ", objDocAttach.DocSequence, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_ATTACHMENT_ID", objDocAttach.AttachmentID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_FILE_BYTES", objDocAttach.ContentFile, OracleDbType.Blob, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":p_FILE_NAME", objDocAttach.FileName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":p_DESCRIPTION", objDocAttach.FileDescription, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, UpdateAttachDocSQL, paramArray);


                }

                return true;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public static bool SaveDocAttachment(int orgID,int unitID,int docID, List<ATTDocumentAttachment> lstDocAttach,int docSeq,OracleTransaction Tran)
        {
            try
            {
                string SaveAttachDocSQL = "SP_ADD_DOCUMENT_ATTACHMENT";
                foreach (ATTDocumentAttachment objDocAttach in lstDocAttach)
                {

                    OracleParameter[] paramArray = new OracleParameter[8];
                    paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID", unitID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", docID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3] = Utilities.GetOraParam(":p_DOC_SEQ", docSeq, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_ATTACHMENT_ID",null, OracleDbType.Int64, ParameterDirection.Output);
                    paramArray[5] = Utilities.GetOraParam(":p_FILE_BYTES", objDocAttach.ContentFile, OracleDbType.Blob, ParameterDirection.Input);
                    paramArray[6] = Utilities.GetOraParam(":p_FILE_NAME", objDocAttach.FileName, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7] = Utilities.GetOraParam(":p_DESCRIPTION", objDocAttach.FileDescription, OracleDbType.Varchar2, ParameterDirection.Input);
                 
                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveAttachDocSQL, paramArray);

                    
                }

                return true;
            }
            catch (Exception ex)
            {                
                throw(ex);
            }

        }

        public static DataTable SearchDocumentListTable(int? orgID, int? unitID, int? docID, string docName, string status)
        {
            GetConnection GetConn = new GetConnection();

            try
            {

                //QueryID = queryID;
                string SearchSQL;
                SearchSQL = QueryBuilder(orgID, unitID, docID, docName, status);

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


        public static string QueryBuilder(int? orgID, int? unitID, int? docID, string docName, string status)
        {
            string GeneralSQL = "";
            string ConditionSQL = "";

            //GeneralSQL = "SELECT * FROM  oas_owner.vw_document ";

            //if (QueryID == 0)
            //    GeneralSQL = "SELECT DISTINCT Org_id,UNIT_ID,DOC_ID,DOC_NAME,DESCRIPTION,FLOW_ID,DOC_FLOW_NAME,CAT_ID,CATEGORY_NAME   FROM oas_owner.vw_document ";

            //else if (QueryID == 1)
                GeneralSQL = "SELECT  ORG_ID,UNIT_ID,DOC_ID,ATTACH_SEQ,ATTACH_ID,ATTACH_FILEBYTE,ATTACH_FILENAME,ATTACH_DESCRIPTION FROM oas_owner.vw_document";

            //else if (QueryID == 2)
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
                if (ConditionSQL == "")
                    ConditionSQL = "WHERE  status = '" + status + "'";
                else
                    ConditionSQL = ConditionSQL + " AND  status = '" + status + "'";
            }

            //if (QueryID == 1)
            //{
                if (ConditionSQL == "")
                    ConditionSQL = "WHERE  ATTACH_ID > 0 ORDER BY ATTACH_ID ";
                else
                    ConditionSQL = ConditionSQL + " AND  ATTACH_ID > 0 ORDER BY ATTACH_ID ";
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
