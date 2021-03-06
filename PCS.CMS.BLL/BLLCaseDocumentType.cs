using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;
using System.Data;

namespace PCS.CMS.BLL
{
   public class BLLCaseDocumentType
    {
        public static bool SaveCaseDocumentType(ATTCaseDocumentType objCaseDocumentType)
        {
            try
            {
                return DLLCaseDocumentType.SaveCaseDocumentType(objCaseDocumentType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTCaseDocumentType> GetCaseDocumentType(int? CaseDocumentType, string active, int defaultFlag)
        {
            List<ATTCaseDocumentType> CaseDocumentTypeList = new List<ATTCaseDocumentType>();
            try
            {
                foreach (DataRow row in DLLCaseDocumentType.GetCaseDocumentType(CaseDocumentType, active).Rows)
                {
                    ATTCaseDocumentType Reglst = new ATTCaseDocumentType(
                        int.Parse(row["CASE_TYPE_ID"].ToString()),
                        row["CASE_TYPE_NAME"].ToString(),
                        row["ACTIVE"].ToString());
                    CaseDocumentTypeList.Add(Reglst);
                }

                if (defaultFlag > 0)
                    CaseDocumentTypeList.Insert(0, new ATTCaseDocumentType(0, "छान्नुहोस", ""));
                return CaseDocumentTypeList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
