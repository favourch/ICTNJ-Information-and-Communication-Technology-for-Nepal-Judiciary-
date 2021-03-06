using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLWritSubject
    {
        public static bool SaveWritSubject(ATTWritSubject objWritSubject)
        {
            try
            {
                return DLLWritSubject.SaveWritSubject(objWritSubject);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<ATTWritSubject> GetWritSubjectDetailsLST(int? writSubjectID,
                                                                    string active, 
                                                                    bool writSubDV,
                                                                    bool writCatDV,
                                                                    bool writTitleDV,
                                                                    bool writSubTitleDV)
        {
            List<ATTWritSubject> WritSubjectLST = new List<ATTWritSubject>();
            try
            {
                foreach (DataRow row in DLLWritSubject.GetWritSubject(writSubjectID, active).Rows)
                {
                    ATTWritSubject WritSubOBJ = new ATTWritSubject();
                    WritSubOBJ.WritSubjectID=int.Parse(row["WRIT_SUB_ID"].ToString());
                    WritSubOBJ.WritSubjectName = row["WRIT_SUB_NAME"].ToString();
                    WritSubOBJ.Active = row["ACTIVE"].ToString();
                    WritSubOBJ.Action = "";
                    WritSubOBJ.WritCategoryLST = BLLWritSubjectCategory.GetWritSubjCategoryDetailsLST(int.Parse(row["WRIT_SUB_ID"].ToString()), null, null,writCatDV,writTitleDV,writSubTitleDV);

                    WritSubjectLST.Add(WritSubOBJ);

                    

                }

                if (writSubDV== true)
                {
                    ATTWritSubject obj = new ATTWritSubject();
                    obj.WritSubjectID = 0;
                    obj.WritSubjectName = "छान्नुहोस";
                    WritSubjectLST.Insert(0, obj);

                }
                return WritSubjectLST;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
