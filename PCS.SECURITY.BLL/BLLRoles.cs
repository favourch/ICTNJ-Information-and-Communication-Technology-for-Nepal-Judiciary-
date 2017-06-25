using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;
using PCS.FRAMEWORK;

namespace PCS.SECURITY.BLL
{
    public class BLLRoles
    {
        private static List<ATTRoles> GetRolesList(int applID, int roleID)
        {
            List<ATTRoles> lstRoles = new List<ATTRoles>();

            foreach (DataRow row in DLLRoles.GetApplicationRoleTable(null,null).Rows)
            {
                ATTRoles RolesObj = new ATTRoles(int.Parse(row["ROLE_ID"].ToString()),
                    int.Parse(row["APPL_ID"].ToString()), (string)row["ROLE_NAME"],
                    (string)row["ROLE_DESCRIPTION"],"");
                lstRoles.Add(RolesObj);

                return lstRoles;
            }

            return lstRoles;
        }

        public bool SaveRoles(ATTRoles objRoles)
        {
            try
            {
                PCS.SECURITY.DLL.DLLRoles.AddRoles(objRoles);
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTRoles> GetRolesAndMenus(int applID,int roleID)
        {
            List<ATTRoles> lstRoles = new List<ATTRoles>();
            List<ATTRoleMenus> lstRolesMenus = BLLRoleMenus.GetRoleMenus(-1,-1,-1,-1);

            foreach (DataRow row in DLLRoles.GetApplicationRoleTable(null,null).Rows)
            {
                ATTRoles obj = new ATTRoles(int.Parse(row["ROLE_ID"].ToString()),
                    int.Parse(row["APPL_ID"].ToString()), (string)row["ROLE_NAME"],
                    (string)row["ROLE_DESCRIPTION"], "");

                obj.LstRoleMenus = lstRolesMenus.FindAll(delegate(ATTRoleMenus rolemnu) { return rolemnu.ApplicationID == obj.ApplicationID && rolemnu.RoleID == obj.RoleID; });

                lstRoles.Add(obj);
            }

            return lstRoles;
        }

        public static ObjectValidation Validate(ATTRoles roleObj)
        {
            ObjectValidation OV = new ObjectValidation();

            if (roleObj.ApplicationID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Application cannot be blank. Select any one application. asdas dasdasdasd asdasd";
                return OV;
            }

            if (roleObj.RoleName == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Role name cannot be blank.";
                return OV;
            }

            if (roleObj.RoleDescription == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Role description cannot be blank.";
                return OV;
            }

            return OV;
        }

        public static int AddRolesAndRoleMenus(List<ATTRoles> lstRoles)
        {
            try
            {
                return DLLRoles.AddRolesAndRoleMenus(lstRoles);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ATTRoles> GetApplicationRoles(int ApplID)
        {
            try
            {
                List<ATTRoles> LstAppl = new List<ATTRoles>();

                foreach (DataRow row in DLLRoles.GetApplicationRoleTable(ApplID,null).Rows)
                {
                    ATTRoles objRoles = new ATTRoles
                                                            (
                                                                int.Parse(row["ROLE_ID"].ToString()),
                                                                int.Parse(row["Appl_ID"].ToString()),
                                                                (string)row["ROLE_Name"].ToString(),
                                                                (string)row["ROLE_Description"].ToString(),
                                                                "E"
                                                            );

                    LstAppl.Add(objRoles);
                }



                return LstAppl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
