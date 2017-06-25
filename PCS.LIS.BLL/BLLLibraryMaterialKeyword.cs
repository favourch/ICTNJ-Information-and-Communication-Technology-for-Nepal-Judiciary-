using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using PCS.FRAMEWORK;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLLibraryMaterialKeyword
    {
        public static List<ATTLibraryMaterialKeyword> GetLibraryMaterialKeywordList(int orgID, int libraryID, decimal lMaterialID)
        {
            try
            {
                List<ATTLibraryMaterialKeyword> lst = new List<ATTLibraryMaterialKeyword>();
                foreach (DataRow row in DLLLibraryMaterialKeyword.GetLibraryMaterialKeywordTable(orgID,libraryID,lMaterialID).Rows)
                {
                    ATTLibraryMaterialKeyword key = new ATTLibraryMaterialKeyword();

                    key.OrgID = int.Parse(row["Org_ID"].ToString());
                    key.LibraryID = int.Parse(row["Library_ID"].ToString());
                    key.LMaterialID = long.Parse(row["L_Material_ID"].ToString());
                    key.Action = "M";

                    key.Keyword.KeywordID = int.Parse(row["Keyword_ID"].ToString());
                    key.Keyword.KeywordName = row["Keyword_Name"].ToString();

                    lst.Add(key);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
