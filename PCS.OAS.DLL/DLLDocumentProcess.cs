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
    public class DLLDocumentProcess
    {
       // public static int QueryID;
        public static bool UpateDocProcess(List<ATTDocumentProcess> lstDocProcess, OracleTransaction Tran)
        {
            try
            {
                string UpdateProcessDocSQL = "SP_EDIT_DOCUMENT_PROCESS";

                foreach (ATTDocumentProcess objDocProcess in lstDocProcess)
                {

                    OracleParameter[] paramArray = new OracleParameter[11];
                    paramArray[0]  = Utilities.GetOraParam(":p_ORG_ID", objDocProcess.OrgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1]  = Utilities.GetOraParam(":p_UNIT_ID", objDocProcess.UnitID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2]  = Utilities.GetOraParam(":p_DOC_ID", objDocProcess.DocID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[3]  = Utilities.GetOraParam(":p_DOC_SEQ", objDocProcess.DocSequence, OracleDbType.Double, ParameterDirection.InputOutput);
                    paramArray[4]  = Utilities.GetOraParam(":p_CREATED_BY", objDocProcess.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5]  = Utilities.GetOraParam(":p_CREATED_ON", DateTime.Now, OracleDbType.Date, ParameterDirection.Input);
                    paramArray[6]  = Utilities.GetOraParam(":p_SEND_TO", objDocProcess.SentTo, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[7]  = Utilities.GetOraParam(":p_SEND_TYPE", objDocProcess.SentType, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[8]  = Utilities.GetOraParam(":p_STATUS", objDocProcess.Status, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[9]  = Utilities.GetOraParam(":p_HAS_REC", objDocProcess.HasReceived, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[10] = Utilities.GetOraParam(":p_NOTE", objDocProcess.Note, OracleDbType.Varchar2, ParameterDirection.Input);

                    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, UpdateProcessDocSQL, paramArray);

                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveDocProcess(int orgID, int unitID, int docID, List<ATTDocumentProcess> lstDocProcess, OracleTransaction Tran)
        {
            try
            {
                string SaveAttachDocSQL = "SP_ADD_DOCUMENT_PROCESS";
                int i = 0;
                int DocSeq =0;
              
                double InputDocSequence = 0;

                foreach (ATTDocumentProcess objDocProcess in lstDocProcess)
                {

                    OracleParameter[] paramArray = new OracleParameter[11];
                    paramArray[0] = Utilities.GetOraParam(":p_ORG_ID", orgID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[1] = Utilities.GetOraParam(":p_UNIT_ID", unitID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[2] = Utilities.GetOraParam(":p_DOC_ID", docID, OracleDbType.Int64, ParameterDirection.Input);
                    paramArray[4] = Utilities.GetOraParam(":p_CREATED_BY", objDocProcess.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input);
                    paramArray[5] = Utilities.GetOraParam(":p_CREATED_ON", DateTime.Now, OracleDbType.Date, ParameterDirection.Input);
                    paramArray[9] = Utilities.GetOraParam(":p_HAS_REC", objDocProcess.HasReceived, OracleDbType.Varchar2, ParameterDirection.Input);
                 
                    // NB: Initial case
                    if (i == 0)
                    {
                        if (objDocProcess.DocSequence == 0)
                           paramArray[3] = Utilities.GetOraParam(":p_DOC_SEQ", null, OracleDbType.Int64, ParameterDirection.InputOutput);
                            
                       else
                            paramArray[3] = Utilities.GetOraParam(":p_DOC_SEQ", objDocProcess.DocSequence, OracleDbType.Int64, ParameterDirection.InputOutput);
                                            
                        paramArray[6] = Utilities.GetOraParam(":p_SEND_TO", "Er.Razu", OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7] = Utilities.GetOraParam(":p_SEND_TYPE", "F", OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8] = Utilities.GetOraParam(":p_STATUS", "A", OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":p_NOTE", "", OracleDbType.Varchar2, ParameterDirection.Input);
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveAttachDocSQL, paramArray);

                        DocSeq = int.Parse(paramArray[3].Value.ToString());
                        
                        i = i + 1;
                    }


                    if(i >= 1)
                    {   
                       
                        InputDocSequence = Convert.ToDouble(DocSeq.ToString() + ".00" + i.ToString());
                                             
                        paramArray[3]  = Utilities.GetOraParam(":p_DOC_SEQ", InputDocSequence, OracleDbType.Double, ParameterDirection.Input);
                        paramArray[6]  = Utilities.GetOraParam(":p_SEND_TO", objDocProcess.SentTo, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[7]  = Utilities.GetOraParam(":p_SEND_TYPE", objDocProcess.SentType, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[8]  = Utilities.GetOraParam(":p_STATUS", objDocProcess.Status, OracleDbType.Varchar2, ParameterDirection.Input);
                        paramArray[10] = Utilities.GetOraParam(":p_NOTE", objDocProcess.Note, OracleDbType.Varchar2, ParameterDirection.Input);
                        
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, SaveAttachDocSQL, paramArray);

                        i = i + 1;
                    }

                }

                return DocSeq;

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

               // QueryID = queryID;
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
            //    GeneralSQL = "SELECT  ORG_ID,UNIT_ID,DOC_ID,ATTACH_SEQ,ATTACH_ID,ATTACH_FILEBYTE,ATTACH_FILENAME,ATTACH_DESCRIPTION FROM oas_owner.vw_document";

            //else if (QueryID == 2)
            GeneralSQL = "SELECT DISTINCT ORG_ID,UNIT_ID,DOC_ID,PROCESS_SEQ,SEND_TO,SEND_TYPE,STATUS,HAS_RECEIVED,NOTE FROM oas_owner.vw_document ";

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
            //    if (ConditionSQL == "")
            //        ConditionSQL = "WHERE  ATTACH_ID > 0 ORDER BY ATTACH_ID ";
            //    else
            //        ConditionSQL = ConditionSQL + " AND  ATTACH_ID > 0 ORDER BY ATTACH_ID ";
            //}

            //if (QueryID == 2)
            //{
                if (ConditionSQL == "")
                    ConditionSQL = "WHERE  PROCESS_SEQ > 0";
                else
                    ConditionSQL = ConditionSQL + " AND  PROCESS_SEQ > 0";
            //}


            return (GeneralSQL + " " + ConditionSQL);
        }
    }
}
