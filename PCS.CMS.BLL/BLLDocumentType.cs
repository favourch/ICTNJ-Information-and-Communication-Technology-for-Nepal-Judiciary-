using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLDocumentType
    {
        public static bool SaveDocumentType(ATTDocumentType objDocumentType)
        {
            try
            {
                return DLLDocumentType.SaveDocumentType(objDocumentType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTDocumentType> GetDocumentType(int? DocumentType, string active, int defaultFlag)
        {
            List<ATTDocumentType> DocumentTypeList = new List<ATTDocumentType>();
            try
            {
                foreach (DataRow row in DLLDocumentType.GetDocumentType(DocumentType, active).Rows)
                {
                    ATTDocumentType Reglst = new ATTDocumentType(
                        int.Parse(row["DOCUMENT_TYPE_ID"].ToString()),
                        row["DOCUMENT_TYPE_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    DocumentTypeList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    DocumentTypeList.Insert(0, new ATTDocumentType(0, "छान्नुहोस", ""));
                return DocumentTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
