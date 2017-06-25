using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;


namespace PCS.CMS.BLL
{
    public class BLLCaseDocumentLit
    {
        public static List<ATTCaseDocumentsLit> GetCaseDocuments(double? caseID, double? litigantID, int? documentID)
        {
            List<ATTCaseDocumentsLit> CaseDocumentLitList = new List<ATTCaseDocumentsLit>();
            try
            {
                foreach (DataRow row in DLLCaseDocumentLit.GetCaseDocuments(caseID, litigantID, documentID).Rows)
                {
                    ATTCaseDocumentsLit objCaseDocLit = new ATTCaseDocumentsLit();
                    objCaseDocLit.CaseID = double.Parse(row["CASE_ID"].ToString());
                    objCaseDocLit.LitType = row["LITIGANT_TYPE"].ToString();
                    objCaseDocLit.LitigantID = double.Parse(row["LITIGANT_ID"].ToString());
                    objCaseDocLit.LitigantName = row["LITIGANTNAME"].ToString();
                    objCaseDocLit.DocumentID= int.Parse(row["DOCUMENT_ID"].ToString());
                    objCaseDocLit.FileName = row["DOCUMENT_FILE_NAME"].ToString();
                    objCaseDocLit.Action= "";
                    CaseDocumentLitList.Add(objCaseDocLit);
                }


                return CaseDocumentLitList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
