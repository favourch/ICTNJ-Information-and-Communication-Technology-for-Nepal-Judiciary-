using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.LIS.ATT;
using PCS.FRAMEWORK;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLLibraryMaterialAuthor
    {
        public static List<ATTLibraryMaterialAuthor> GetLibraryMaterialAuthorList(int orgID, int libraryID, decimal lMaterialID)
        {
            try
            {
                List<ATTLibraryMaterialAuthor> lst = new List<ATTLibraryMaterialAuthor>();
                foreach (DataRow row in DLLLibraryMaterialAuthor.GetLibraryMaterialAuthorTable(orgID, libraryID, lMaterialID).Rows)
                {
                    ATTLibraryMaterialAuthor author = new ATTLibraryMaterialAuthor();

                    author.OrgID = int.Parse(row["Org_ID"].ToString());
                    author.LibraryID = int.Parse(row["Library_ID"].ToString());
                    author.LMaterialID = long.Parse(row["L_Material_ID"].ToString());
                    author.Action = "M";

                    author.Author.AuthorID = int.Parse(row["Author_ID"].ToString());
                    author.Author.AuthorName = row["Author_Name"].ToString();

                    lst.Add(author);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<ATTLibraryMaterialAuthor> SearchMaterial(int langID, int[] checkedAuthors, int[] checkedKeywords)
        {

            List<ATTLibraryMaterialAuthor> LibraryMaterialLst = new List<ATTLibraryMaterialAuthor>();
            foreach (DataRow row in DLLLibraryMaterialAuthor.SearchMaterialTable(langID, checkedAuthors, checkedKeywords).Rows)
            {
                ATTLibraryMaterialAuthor LMA = new ATTLibraryMaterialAuthor(int.Parse(row["org_id"].ToString()),
                                                                            int.Parse(row["library_id"].ToString()),
                                                                            int.Parse(row["l_material_id"].ToString()),
                                                                            row["category_name"].ToString(),
                                                                            row["m_cat_desc"].ToString(),
                                                                            row["lang_name"].ToString(),
                                                                            row["call_no"].ToString(),
                                                                            row["corporate_body"].ToString(),
                                                                            row["publisher_name"].ToString()
                                                                           );

                LibraryMaterialLst.Add(LMA);

            }
            return LibraryMaterialLst;
        }
    }
}
