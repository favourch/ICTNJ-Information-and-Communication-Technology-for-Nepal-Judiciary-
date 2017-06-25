using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.LIS.ATT;
using PCS.LIS.DLL;

namespace PCS.LIS.BLL
{
    public class BLLMaterialType
    {
        public static ObjectValidation Validate(ATTMaterialType objMT)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objMT.MaterialTypeName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Material Type cannot be blank.";
                return OV;
            }

            return OV;

        }

        public static bool AddMaterialType(ATTMaterialType objMT,Previlege pobj)
        {
            try
            {
                DLLMaterialType.AddMaterialType(objMT,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateMaterialType(ATTMaterialType objMT, Previlege pobj)
        {
            try
            {
                DLLMaterialType.UpdateMaterialType(objMT,pobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTMaterialType> GetMaterialType()
        {
            List<ATTMaterialType> MaterialTypeLST = new List<ATTMaterialType>();

            foreach (DataRow row in DLLMaterialType.GetMaterialTypeTable().Rows)
            {
                ATTMaterialType MT = new ATTMaterialType(int.Parse(row["MT_ID"].ToString()),
                                                         row["MT_NAME"].ToString(),
                                                         "empty",
                                                         row["DESCRIPTION"].ToString()
                                                         );
                MaterialTypeLST.Add(MT);
            }

            return MaterialTypeLST;
        }

     }
}
