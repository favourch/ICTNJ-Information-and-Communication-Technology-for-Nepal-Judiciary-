using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLDocument
    {
          
        public static ObjectValidation ValidateDocument(ATTDocument objDoc)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objDoc.OrgID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Organization.";
                return OV;
            }

            if (objDoc.UnitID <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Unit.";
                return OV;
            }

            if (objDoc.DocFlowType <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Document Flow Type.";
                return OV;
            }

            if (objDoc.DocumentName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please Enter Document Name.";
                return OV;
            }

            if (objDoc.DocCategory <= 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Please select Document Category.";
                return OV;
            }

            return OV;
        }

        public static bool SaveDocument(ATTDocument objDoc)
        {
            try
            {
                DLLDocument.SaveDocument(objDoc);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateDocument(ATTDocument objDoc)
        {
            try
            {
                DLLDocument.UpdateDocument(objDoc);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTDocument> GetDocumentNameList(int? docID, int? unitID, int? orgID)
        {
            List<ATTDocument> LstDocumentName = new List<ATTDocument>();

            foreach (DataRow row in DLLDocument.GetDocumentNameListTable(docID, unitID, orgID).Rows)
            {
                ATTDocument objDocName = new ATTDocument(
                                                            int.Parse(row["UNIT_ID"].ToString()),
                                                            int.Parse(row["DOC_ID"].ToString()),
                                                            row["DOC_NAME"].ToString()
                                                        );

                LstDocumentName.Add(objDocName);
            }

            return LstDocumentName;
        }

        public static List<ATTDocument> SearchDocumentList(int? orgID, int? unitID, int? docID, string docName,string status)
        {
            List<ATTDocument> LstDocSearch = new List<ATTDocument>();
          
            DataTable tblDoc = new DataTable();
            //tblDoc = DLLDocument.SearchDocumentListTable(orgID, unitID, docID, docName, status, 0);
            tblDoc = DLLDocument.SearchDocumentListTable(orgID, unitID, docID, docName, status);

            DataTable tblDocAttach = new DataTable();
            //tblDocAttach = DLLDocument.SearchDocumentListTable(orgID, unitID, docID, docName, status, 1);
            tblDocAttach = BLLDocumentAttachment.SearchDocumentListTable(orgID, unitID, docID, docName, status);

            DataTable tblDocProcess = new DataTable();
            //tblDocProcess = DLLDocument.SearchDocumentListTable(orgID, unitID, docID, docName, status, 2);
            tblDocProcess = BLLDocumentProcess.SearchDocumentListTable(orgID, unitID, docID, docName, status);

            foreach (DataRow row in tblDoc.Rows)
            {
                ATTDocument objDocName = new ATTDocument(   int.Parse(row["Org_id"].ToString()),
                                                            int.Parse(row["UNIT_ID"].ToString()),
                                                            int.Parse(row["DOC_ID"].ToString()),
                                                            row["DOC_NAME"].ToString(),
                                                            row["DESCRIPTION"].ToString(),
                                                            int.Parse(row["FLOW_ID"].ToString()),
                                                            row["DOC_FLOW_NAME"].ToString(),
                                                            int.Parse(row["CAT_ID"].ToString()),
                                                            row["CATEGORY_NAME"].ToString()
                                                        );

                if (tblDocAttach.Rows.Count > 0)
                {
                    objDocName.LstDocAttachment = SetDocAttachment(tblDocAttach, int.Parse(row["Org_id"].ToString()), int.Parse(row["UNIT_ID"].ToString())
                                                                   , int.Parse(row["DOC_ID"].ToString()));
                }

                if (tblDocProcess.Rows.Count > 0)
                {
                    objDocName.LstDocProcess = SetDocProcess(tblDocProcess, int.Parse(row["Org_id"].ToString()), int.Parse(row["UNIT_ID"].ToString())
                                                            ,int.Parse(row["DOC_ID"].ToString()));
                }

                LstDocSearch.Add(objDocName);
            }
            return LstDocSearch;
        }

        public static List<ATTDocumentAttachment> SetDocAttachment(DataTable tblDocAttach, int orgID, int unitID, int docID)
        {
            int val = docID;
            int currentVal = 0;
            int beforeVal = 0;
            List<ATTDocumentAttachment> LstDocSearchAttach = new List<ATTDocumentAttachment>();

            foreach (DataRow rowAttach in tblDocAttach.Rows)
            {
                if ( orgID  == int.Parse(rowAttach["Org_id"].ToString()) &&
                     unitID == int.Parse(rowAttach["UNIT_ID"].ToString()) &&
                     docID  == int.Parse(rowAttach["DOC_ID"].ToString())
                   )
                {
                    currentVal = int.Parse(rowAttach["ATTACH_ID"].ToString());

                    if (currentVal != beforeVal)
                    {
                        LstDocSearchAttach.Add(new ATTDocumentAttachment(
                                                                            int.Parse(rowAttach["Org_id"].ToString()),
                                                                            int.Parse(rowAttach["UNIT_ID"].ToString()),
                                                                            int.Parse(rowAttach["DOC_ID"].ToString()),
                                                                            double.Parse(rowAttach["ATTACH_SEQ"].ToString()),
                                                                            int.Parse(rowAttach["ATTACH_ID"].ToString()),
                                                                            (byte[])(rowAttach["ATTACH_FILEBYTE"]),
                                                                            rowAttach["ATTACH_FILENAME"].ToString(),
                                                                            rowAttach["ATTACH_DESCRIPTION"].ToString()

                                                                        )
                                               );

                        beforeVal = currentVal;
                    }

                }
            }

            return LstDocSearchAttach;
        }

        public static List<ATTDocumentProcess> SetDocProcess(DataTable tblDocProcess,int orgID,int unitID,int docID)
        {

            List<ATTDocumentProcess> LstDocSearchProcess = new List<ATTDocumentProcess>();
            
            foreach (DataRow rowProcess in tblDocProcess.Rows)
            {
                if ( orgID  == int.Parse(rowProcess["Org_id"].ToString()) &&
                     unitID == int.Parse(rowProcess["UNIT_ID"].ToString()) &&
                     docID  == int.Parse(rowProcess["DOC_ID"].ToString())
                   )
                {



                    LstDocSearchProcess.Add(new ATTDocumentProcess(
                                                                        int.Parse(rowProcess["Org_id"].ToString()),
                                                                        int.Parse(rowProcess["UNIT_ID"].ToString()),
                                                                        int.Parse(rowProcess["DOC_ID"].ToString()),
                                                                        double.Parse(rowProcess["PROCESS_SEQ"].ToString()),
                                                                        "",
                                                                        rowProcess["SEND_TO"].ToString(),
                                                                        rowProcess["SEND_TYPE"].ToString(),
                                                                        rowProcess["STATUS"].ToString(),
                                                                        rowProcess["HAS_RECEIVED"].ToString(),
                                                                        rowProcess["NOTE"].ToString()
                                                                   )
                                             );


                  
                }

            }
            return LstDocSearchProcess;

        }

               
    }
}
