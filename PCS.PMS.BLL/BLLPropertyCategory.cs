using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLPropertyCategory
    {

        public static ObjectValidation ValidatePropertyCategory(List<ATTPropertyCategory> lstPCC)
        {
            //(ATTPropertyCategory objPCC)
            ObjectValidation OV = new ObjectValidation();
            foreach (ATTPropertyCategory objPCC in lstPCC)
            {
                if (objPCC.PCategoryName == "")
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "Please Enter Category Name.";
                    return OV;
                }

                //if (objPCC.NoOfCols <= 0)
                //{
                //    OV.IsValid = false;
                //    OV.ErrorMessage = "Please select no. of columns.";
                //    return OV;
                //}

                if (objPCC.Type == "")
                {
                    OV.IsValid = false;
                    OV.ErrorMessage = "Please select the Type.";
                    return OV;
                }

                //if (objPCC.MasterType <= 0)
                //{
                //    OV.IsValid = false;
                //    OV.ErrorMessage = "Please select the Master Type.";
                //    return OV;
                //}


            }
            return OV;
        }


        public static List<ATTPropertyCategory> GetPropertyCateogryList(int? pCatID)
        {
            List<ATTPropertyCategory> lstPropertyCategory = new List<ATTPropertyCategory>();

            try
            {
                foreach (DataRow row in DLLPropertyCategory.GetDocCategoryListTable(pCatID).Rows)
                {
                    //ATTPropertyCategory objPropertyCategory = new ATTPropertyCategory(
                    //                                                                    int.Parse(row["PCAT_ID"].ToString()),
                    //                                                                    row["PCAT_NAME"].ToString(),
                    //                                                                    int.Parse(row["NO_OF_COLUMNS"].ToString()),
                    //                                                                    row["INCOME"].ToString(),
                    //                                                                    row["TYPE"].ToString(),
                    //                                                                    int.Parse(row["MASTERTYPE"].ToString())
                    //                                                                 );

                    ATTPropertyCategory objPropCat = new ATTPropertyCategory();
                    objPropCat.PCategoryID = int.Parse(row["PCAT_ID"].ToString());
                    objPropCat.PCategoryName = row["PCAT_NAME"].ToString();
                    objPropCat.NoOfCols = int.Parse(row["NO_OF_COLUMNS"].ToString());
                    objPropCat.Income = row["INCOME"].ToString();
                    objPropCat.Type = row["TYPE"].ToString();
                    objPropCat.MasterType = row["MASTERTYPE"].ToString();

                    lstPropertyCategory.Add(objPropCat);
                }
                return lstPropertyCategory;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool SavePropertyCategory(List<ATTPropertyCategory> lstPCC)
        {
            try
            {

                DLLPropertyCategory.SavePropertyCategory(lstPCC);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
