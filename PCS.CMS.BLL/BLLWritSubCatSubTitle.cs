using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLWritSubCatSubTitle
    {
        public static List<ATTWritCategorySubTitle> GetWritSubjCatSubTitleDetailsLST(int? writSubjectID, int? writSubCatID, int? writSubCatTitleID,int ? writSubCatSubTitleID, string active, bool WritSubCatSubTitleDV)
        {
            List<ATTWritCategorySubTitle> WritSubCatSubTitleLST = new List<ATTWritCategorySubTitle>();
            try
            {
                foreach (DataRow row in DLLWritSubCatSubTitle.GetWritSubCatSubTitle(writSubjectID, writSubCatID, writSubCatTitleID,writSubCatSubTitleID, active).Rows)
                {
                    ATTWritCategorySubTitle WritSubCatSubTitleOBJ = new ATTWritCategorySubTitle();
                    WritSubCatSubTitleOBJ.WritSubjectID = int.Parse(row["WRIT_SUB_ID"].ToString());
                    WritSubCatSubTitleOBJ.WritSubjectCatID = int.Parse(row["WRIT_SUB_CAT_ID"].ToString());
                    WritSubCatSubTitleOBJ.WritSubjectCatTitleID = int.Parse(row["WRIT_SUB_CAT_TITLE_ID"].ToString());
                    WritSubCatSubTitleOBJ.WritSubjectCatSubTitleID= int.Parse(row["WRIT_SUB_CAT_SUBTITLE_ID"].ToString());
                    WritSubCatSubTitleOBJ.WritSubjectCatSubTitleName = row["WRIT_SUB_CAT_SUBTITLE_NAME"].ToString();
                    WritSubCatSubTitleOBJ.Active= row["ACTIVE"].ToString();
                    WritSubCatSubTitleOBJ.Action = "";

                    WritSubCatSubTitleLST.Add(WritSubCatSubTitleOBJ);



                }

                if (WritSubCatSubTitleDV ==true)
                {
                    ATTWritCategorySubTitle obj = new ATTWritCategorySubTitle();
                    obj.WritSubjectCatSubTitleID = 0;
                    obj.WritSubjectCatSubTitleName = "छान्नुहोस";
                    WritSubCatSubTitleLST.Insert(0, obj);

                }
                   
                return WritSubCatSubTitleLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
