using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLDocumentAttachment
    {
        public static ObjectValidation ValidateDocumentAttachment(List<ATTDocumentAttachment> lstDocAttach)
        {
            ObjectValidation OV = new ObjectValidation();

            foreach (ATTDocumentAttachment objDocAttach in lstDocAttach)
            {
                if (objDocAttach.ContentFile == null)
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "Please Browse File to Attach.";
                    return OV;
                }
            }

            return OV;
        }

        public static DataTable SearchDocumentListTable(int? orgID, int? unitID, int? docID, string docName, string status)
        {
            try
            {
                return DLLDocumentAttachment.SearchDocumentListTable(orgID, unitID, docID, docName, status);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }


    }
}
