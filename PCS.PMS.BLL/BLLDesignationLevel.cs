using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.PMS.ATT;
using PCS.PMS.DLL;

namespace PCS.PMS.BLL
{
    public class BLLDesignationLevel
    {

        public static ObjectValidation Validate(ATTDesignationLevel att_des_obj)
        {
            ObjectValidation OV = new ObjectValidation();
            if (att_des_obj.LevelName=="")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Level Name Cannot be Empty";
                return (OV);
            }
            return (OV);
        }

        public static List<ATTDesignationLevel> GetDesignationLevelList()
        {
            List<ATTDesignationLevel> lstdl = new List<ATTDesignationLevel>();
            try
            {
                foreach(DataRow row in DLLDesignationLevel.GetDesignationLevelTable().Rows)
                {
                    ATTDesignationLevel att_desl_obj=new ATTDesignationLevel(
                                                                                int.Parse(row["Level_ID"].ToString()),
                                                                                row["Level_Name"].ToString()
                                                                            );
                    lstdl.Add(att_desl_obj);
                }
                return lstdl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                                                                                
        }

        public static bool SaveDesignationLevel(ATTDesignationLevel att_des_obj)
        {
            try
            {
                return DLLDesignationLevel.SaveDesignationLevel(att_des_obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
