using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.DLL;
using PCS.CMS.ATT;

namespace PCS.CMS.BLL
{
    public class BLLWritSubCatTitle
    {
        public static List<ATTWritCategoryTitle> GetWritSubjCatTitleDetailsLST(int? writSubjectID, int? writSubCatID,int? writSubCatTitleID, string active, bool writSubCatTitleDV,bool writSubTitleDV)
        {
            List<ATTWritCategoryTitle> WritSubCatTitleLST = new List<ATTWritCategoryTitle>();
            try
            {
                foreach (DataRow row in DLLWritSubCatTitle.GetWritSubCatTitle(writSubjectID, writSubCatID, writSubCatTitleID, active).Rows)
                {
                    ATTWritCategoryTitle WritSubCatTitleOBJ = new ATTWritCategoryTitle();
                    WritSubCatTitleOBJ.WritSubjectID = int.Parse(row["WRIT_SUB_ID"].ToString());
                    WritSubCatTitleOBJ.WritSubjectCatID = int.Parse(row["WRIT_SUB_CAT_ID"].ToString());
                    WritSubCatTitleOBJ.WritSubjectCatTitleID= int.Parse(row["WRIT_SUB_CAT_TITLE_ID"].ToString());
                    WritSubCatTitleOBJ.WritSubjectCatTitleName= row["WRIT_SUB_CAT_TITLE_NAME"].ToString();
                    WritSubCatTitleOBJ.Active = row["ACTIVE"].ToString();
                    WritSubCatTitleOBJ.Action = "";

                    WritSubCatTitleOBJ.WritCategorySubTitleLST= BLLWritSubCatSubTitle.GetWritSubjCatSubTitleDetailsLST(
                                                                                            int.Parse(row["WRIT_SUB_ID"].ToString()),
                                                                                            int.Parse(row["WRIT_SUB_CAT_ID"].ToString()),
                                                                                            int.Parse(row["WRIT_SUB_CAT_TITLE_ID"].ToString()),
                                                                                            null, null, writSubTitleDV);

                    WritSubCatTitleLST.Add(WritSubCatTitleOBJ);



                }

                if (writSubCatTitleDV ==true)
                {
                    ATTWritCategoryTitle obj = new ATTWritCategoryTitle();
                    obj.WritSubjectCatTitleID = 0;
                    obj.WritSubjectCatTitleName = "छान्नुहोस";
                    WritSubCatTitleLST.Insert(0, obj);
                }
                return WritSubCatTitleLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
