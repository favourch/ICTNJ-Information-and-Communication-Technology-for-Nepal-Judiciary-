using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;

namespace PCS.SECURITY.BLL
{
   public class BLLRoleMenus
    {
       public static List<ATTRoleMenus> GetRoleMenus(int ApplID,int RoleID,int FormID,int MenuID)
        {
            List<ATTRoleMenus> lstRoleMenus = new List<ATTRoleMenus>();

            foreach (DataRow row in DLLRoleMenus.GetRoleMenusTable(ApplID,RoleID,FormID,MenuID).Rows)
            {
                ATTRoleMenus RoleMenusObj = new ATTRoleMenus(int.Parse(row["ROLE_ID"].ToString()),
                    int.Parse(row["MENU_ID"].ToString()), int.Parse(row["APPL_ID"].ToString()),
                    int.Parse(row["FORM_ID"].ToString()),row["P_SELECT"].ToString(),
                    row["P_ADD"].ToString(),row["P_EDIT"].ToString(),row["P_DELETE"].ToString());
                //RoleMenusObj.MenuName = (string)(row["MENU_NAME"]);

                lstRoleMenus.Add(RoleMenusObj);
            }

            return lstRoleMenus;
        }
   }
}
