using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using PCS.FRAMEWORK;

namespace PCS.COMMON.BLL
{
    public class BLLDocumentsType
    {
        public static ObjectValidation Validate(ATTDocumentsType objDocType)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objDocType.DocTypeName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Document Type cannot be Blank.";
                return OV;
            }
            return OV;
        }

        public static List<ATTDocumentsType> GetDocumentsType(int? docTypeID)
        {
            List<ATTDocumentsType> lstDocumentsType = new List<ATTDocumentsType>();

            foreach (DataRow row in DLLDocumentsType.GetDocumentsType(docTypeID).Rows)
            {
                ATTDocumentsType obj = new ATTDocumentsType(int.Parse(row["DOC_TYPE_ID"].ToString()),
                    ((row["DOC_TYPE_NAME"] == System.DBNull.Value) ? "" : (string)row["DOC_TYPE_NAME"]));
                lstDocumentsType.Add(obj);
            }
            return lstDocumentsType;
        }

        public static List<ATTDocumentsType> GetDocumentsType(int? docTypeID, bool DTDV)
        {
            List<ATTDocumentsType> lstDocumentsType = new List<ATTDocumentsType>();

            foreach (DataRow row in DLLDocumentsType.GetDocumentsType(docTypeID).Rows)
            {
                ATTDocumentsType obj = new ATTDocumentsType(int.Parse(row["DOC_TYPE_ID"].ToString()),
                    ((row["DOC_TYPE_NAME"] == System.DBNull.Value) ? "" : (string)row["DOC_TYPE_NAME"]));
                lstDocumentsType.Add(obj);
            }
            if (DTDV == true)
            {
                lstDocumentsType.Insert(0, new ATTDocumentsType(0, "--- छान्नहोस ---"));
            }
            return lstDocumentsType;
        }

        public static bool SaveDocumentsType(ATTDocumentsType objDocType)
        {
            try
            {
                return DLLDocumentsType.SaveDocumentTypes(objDocType);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
