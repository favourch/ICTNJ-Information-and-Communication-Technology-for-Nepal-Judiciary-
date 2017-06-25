using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLPropertyCategoryColumns
    {
        public static List<ATTPropertyCategoryColumns> GetPropertyCateogryColList(int? pCatID)
        {
            List<ATTPropertyCategoryColumns> lstPropertyCategoryCols = new List<ATTPropertyCategoryColumns>();

            try
            {
                foreach (DataRow row in DLLPropertyCategoryCols.GetPropertyCateogryColListTable(pCatID).Rows)
                {
                    ATTPropertyCategoryColumns objPropertyCategoryCols = new ATTPropertyCategoryColumns(
                                                                                                int.Parse(row["PCAT_ID"].ToString()),
                                                                                                int.Parse(row["COL_NO"].ToString()),
                                                                                                row["COL_NAME"].ToString(),
                                                                                                row["COL_DATA_TYPE"].ToString(),
                                                                                                row["ACTIVE"].ToString()
                                                                                            );

                    lstPropertyCategoryCols.Add(objPropertyCategoryCols);
                }
                return lstPropertyCategoryCols;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool SavePropertyCategoryCols(List<ATTPropertyCategoryColumns> lstPCCols)
        {
            try
            {

                DLLPropertyCategoryCols.SavePropertyCategoryCols(lstPCCols);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
