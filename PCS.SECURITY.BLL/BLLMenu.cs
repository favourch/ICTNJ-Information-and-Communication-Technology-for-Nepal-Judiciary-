using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;
using System.Data;

namespace PCS.SECURITY.BLL
{
    public class BLLMenu
    {
        public static ObjectValidation Validate(ATTMenu obj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (obj.MenuName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Menu name cannot be blank.";
                return OV;
            }

            return OV;
        }

        public static List<ATTMenu> GetMenuList(int appID, int formID, int menuID)
        {
            try
            {
                List<ATTMenu> lst = new List<ATTMenu>();
                foreach (DataRow row in DLLMenu.GetMenuTable(appID, formID, menuID).Rows)
                {
                    ATTMenu menu = new ATTMenu
                                                (
                                                    int.Parse(row["Appl_ID"].ToString()),
                                                    int.Parse(row["Form_ID"].ToString()),
                                                    int.Parse(row["Menu_ID"].ToString()),
                                                    (string)row["Menu_Name"],
                                                    row["Menu_Description"].ToString(),
                                                    row["P_SELECT"].ToString(),
                                                    row["P_ADD"].ToString(),
                                                    row["P_EDIT"].ToString(),
                                                    row["P_DELETE"].ToString(),
                                                    "M"
                                                );
                    lst.Add(menu);
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
