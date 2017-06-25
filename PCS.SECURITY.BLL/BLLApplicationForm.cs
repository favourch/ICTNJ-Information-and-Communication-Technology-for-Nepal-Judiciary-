using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;

namespace PCS.SECURITY.BLL
{
    public class BLLApplicationForm
    {
        public static ObjectValidation Validate(ATTApplicationForm appFormObj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (appFormObj.FormName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Form name cannot be blank.";
                return OV;
            }

            return OV;
        }

        public static List<ATTApplicationForm> GetApplicationFormListWithMenu(int appID, int formID)
        {
            try
            {
                List<ATTApplicationForm> lstForm = new List<ATTApplicationForm>();
                List<ATTMenu> lstMenu = BLLMenu.GetMenuList(-1, -1, -1);

                foreach (DataRow row in DLLApplicationForm.GetApplicationFormTable(appID, formID).Rows)
                {
                    ATTApplicationForm obj = new ATTApplicationForm(
                                                                    int.Parse(row["APPL_ID"].ToString()),
                                                                    int.Parse(row["FORM_ID"].ToString()),
                                                                    (string)row["FORM_NAME"],
                                                                    row["FORM_DESCRIPTION"].ToString(),
                                                                    "M"
                                                                );

                    obj.LstMenu = lstMenu.FindAll(delegate(ATTMenu mnu) { return mnu.ApplicationID == obj.ApplicationID && mnu.FormID == obj.FormID; });

                    lstForm.Add(obj);
                }

                return lstForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddApplicationFormWithMenu(List<ATTApplication> lstApp)
        {
            try
            {
                return DLLApplicationForm.AddApplicationFormWithMenu(lstApp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
