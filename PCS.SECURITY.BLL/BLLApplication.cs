using System;
using System.Collections.Generic;
using System.Text;

using PCS.FRAMEWORK;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;
using System.Data;

namespace PCS.SECURITY.BLL
{
    public class BLLApplication
    {
        /// <summary>
        /// Flag value 0 for Default value
        /// </summary>
        /// <param name="FlagForDefault"></param>
        /// <returns></returns>
        /// 
        public static List<ATTApplication> GetApplicationList(int FlagForDefault)
        {
            try
            {
                List<ATTApplication> LstAppl = new List<ATTApplication>();
                
                foreach (DataRow row in DLLApplication.GetApplicationTable().Rows)
                {
                    ATTApplication obj = new ATTApplication
                                                            (
                                                                int.Parse(row["Appl_ID"].ToString()),
                                                                (string)row["Appl_Short_Name"],
                                                                (string)row["Appl_Full_Name"],
                                                                row["Description"].ToString(),
                                                                ""
                                                            );

                    LstAppl.Add(obj);                                                                 
                }

                if (FlagForDefault == 0)
                    LstAppl.Insert(0, new ATTApplication(0, "", "-------- Select Application --------", "", ""));

                return LstAppl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTApplication> GetUserApplicationList(string username)
        {
            List<ATTApplication> lst = new List<ATTApplication>();
            try
            {
                foreach (DataRow row in DLLApplication.GetUserApplicationTable(username).Rows)
                {
                    ATTApplication obj = new ATTApplication();
                    obj.ApplicationID = int.Parse(row["appl_id"].ToString());
                    obj.ApplicationShortName = row["appl_short_name"].ToString();
                    obj.ApplicationDescription = row["description"].ToString();

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTApplication> GetApplicationListWithFormNMenuNRolesNRoleMenus()
        {
            try
            {
                List<ATTApplication> lstApp = BLLApplication.GetApplicationList(0);
                List<ATTMenu> lstMenus = BLLMenu.GetMenuList(-1, -1, -1);
                List<ATTRoles> lstRoles = BLLRoles.GetRolesAndMenus(-1, -1);


                foreach (ATTApplication app in lstApp)
                {
                    app.LstMenus = lstMenus.FindAll(delegate(ATTMenu menus) { return menus.ApplicationID == app.ApplicationID; });
                    app.LstRoles = lstRoles.FindAll(delegate(ATTRoles roles) { return roles.ApplicationID == app.ApplicationID; });
                }

                return lstApp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTApplication> GetApplicationListWithFormNMenu()
        {
            try
            {
                List<ATTApplication> lstApp = BLLApplication.GetApplicationList(0);
                List<ATTApplicationForm> lstForm = BLLApplicationForm.GetApplicationFormListWithMenu(-1, -1);
                
                foreach (ATTApplication app in lstApp)
                {
                    app.LstApplicationForm = lstForm.FindAll(delegate(ATTApplicationForm frm) { return frm.ApplicationID == app.ApplicationID; });
                }
                
                return lstApp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ObjectValidation Validate(ATTApplication appObj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (appObj.ApplicationShortName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Application short name cannot be blank.";
                return OV;
            }

            if (appObj.ApplicationFullName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Application full name cannot be blank.";
                return OV;
            }

            return OV;
        }

        public static bool AddApplication(ATTApplication Applicationobj)
        {
            try
            {
                DLLApplication.AddApplication(Applicationobj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
