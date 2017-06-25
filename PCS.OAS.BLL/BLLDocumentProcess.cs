using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLDocumentProcess
    {
        public static ObjectValidation ValidateDocumentProcess(List<ATTDocumentProcess> lstDocProcess)
        {
            ObjectValidation OV = new ObjectValidation();

            foreach (ATTDocumentProcess objDocProcess in lstDocProcess)
            {
                if (objDocProcess.SentTo == "")
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "Please Enter Sent To.";
                    return OV;
                }

                if (objDocProcess.SentType == "")
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "Please select Sent Type.";
                    return OV;
                }

                if (objDocProcess.Status == "")
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "Please select Status.";
                    return OV;
                }

            }

            return OV;
        }

        public static DataTable SearchDocumentListTable(int? orgID, int? unitID, int? docID, string docName, string status)
        {
            try
            {
                return DLLDocumentProcess.SearchDocumentListTable(orgID, unitID, docID, docName, status);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    }
}
