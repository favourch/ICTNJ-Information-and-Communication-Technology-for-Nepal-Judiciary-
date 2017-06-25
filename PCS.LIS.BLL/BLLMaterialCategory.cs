using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.LIS.ATT;
using PCS.FRAMEWORK;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLMaterialCategory
    {
        public static ObjectValidation Validate(ATTMaterialCategory objMC)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objMC.CategoryName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Category Name Cannot be blank.";
                return OV;
            }

            return OV;
        }

        public static bool AddMaterialCategory(ATTMaterialCategory objMC,Previlege pobj)
        {
            try
            {
                DLLMaterialCategory.AddMaterialCategory(objMC,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateMaterialCategory(ATTMaterialCategory objMC,Previlege pobj)
        {
            try
            {
                DLLMaterialCategory.UpdateMaterialCategory(objMC,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTMaterialCategory> GetMaterialCategory()
        {
            List<ATTMaterialCategory> MaterialCategoryLST = new List<ATTMaterialCategory>();

            foreach (DataRow row in DLLMaterialCategory.GetMaterialCategoryTable().Rows)
            {
                ATTMaterialCategory MC = new ATTMaterialCategory(int.Parse(row["CATEGORY_id"].ToString()),
                                                         row["CATEGORY_name"].ToString(),
                                                         "empty",
                                                         row["DESCRIPTION"].ToString()
                                                         );
                MaterialCategoryLST.Add(MC);
            }

            return MaterialCategoryLST;
        }
    }
}
