using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLDocumentCategory
    {
        public static List<ATTDocumentCategory> GetDocCategoryList(int? fileCatID)
        {
            List<ATTDocumentCategory> lstDocCategory = new List<ATTDocumentCategory>();

            try
            {
                foreach (DataRow row in DLLDocumentCategory.GetDocCategoryListTable(fileCatID).Rows)
                {
                    ATTDocumentCategory ObjDocCategory = new ATTDocumentCategory(
                                                                                    int.Parse(row["FILE_CAT_ID"].ToString()),
                                                                                    row["CATEGORY_NAME"].ToString()
                                                                                   
                                                                                 );

                    lstDocCategory.Add(ObjDocCategory);
                }
                return lstDocCategory;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
