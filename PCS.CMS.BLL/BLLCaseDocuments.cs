using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
    public class BLLCaseDocuments
    {
        public static List<ATTCaseDocuments> GetCaseDocuments(double? caseID, int? documentID)
        {
            List<ATTCaseDocuments> CaseDocumentList = new List<ATTCaseDocuments>();
            try
            {
                foreach (DataRow row in DLLCaseDocuments.GetCaseDocuments(caseID, documentID).Rows)
                {
                    ATTCaseDocuments objCaseDoc = new ATTCaseDocuments();
                    objCaseDoc.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objCaseDoc.DocumentID = int.Parse(row["DOCUMENT_ID"].ToString());
                    objCaseDoc.DocumentFileName= row["DOCUMENT_FILE_NAME"].ToString();
                    objCaseDoc.DocumentContent = (byte[])row["DOCUMENT_CONTENT"];
                    CaseDocumentList.Add(objCaseDoc);
                }


                return CaseDocumentList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
