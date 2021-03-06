using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLWritSubjectCategory
    {
        public static List<ATTWritCategory> GetWritSubjCategoryDetailsLST(int? writSubjectID,int? writSubCatID, string active, bool writCatDV,bool writTitleDV, bool writSubTitleDV)
        {
            List<ATTWritCategory> WritSubCategoryLST = new List<ATTWritCategory>();
            try
            {
                foreach (DataRow row in DLLWritCategory.GetWritSubCat(writSubjectID, writSubCatID, active).Rows)
                {
                    ATTWritCategory WritSubCatOBJ = new ATTWritCategory();
                    WritSubCatOBJ.WritSubjectID = int.Parse(row["WRIT_SUB_ID"].ToString());
                    WritSubCatOBJ.WritSubjectCatID= int.Parse(row["WRIT_SUB_CAT_ID"].ToString());
                    WritSubCatOBJ.WritSubjectCatName = row["WRIT_SUB_CAT_NAME"].ToString();
                    WritSubCatOBJ.Active = row["ACTIVE"].ToString();
                    WritSubCatOBJ.Action = "";

                    WritSubCatOBJ.WritCategoryTitleLST = BLLWritSubCatTitle.GetWritSubjCatTitleDetailsLST(int.Parse(row["WRIT_SUB_ID"].ToString()), int.Parse(row["WRIT_SUB_CAT_ID"].ToString()), null, null, writTitleDV,writSubTitleDV);

                    WritSubCategoryLST.Add(WritSubCatOBJ);



                }

                if (writCatDV ==true)
                {
                    ATTWritCategory obj = new ATTWritCategory();
                    obj.WritSubjectCatID = 0;
                    obj.WritSubjectCatName = "छान्नुहोस";
                    WritSubCategoryLST.Insert(0, obj);

                }
                return WritSubCategoryLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
