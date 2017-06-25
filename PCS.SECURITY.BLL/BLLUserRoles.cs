using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;

namespace PCS.SECURITY.BLL
{
     public class BLLUserRoles
    {

        public List<ATTUserRoles> GetUserRoles(string  Username)
        {
            return (GetUserRoleList(PCS.SECURITY.DLL.DLLUserRoles.GetUserRoleTable(Username)));
        }


        public static List<ATTUserRoles> GetUserRoleList(DataTable tbl)
        {
            List<ATTUserRoles> UserRoleLST = new List<ATTUserRoles>();
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTUserRoles UserObj = new ATTUserRoles
                                                            (
                                                                (string)row["USER_NAME"],
                                                                int.Parse (row["ROLE_ID"].ToString() ),
                                                                (string ) row["FROM_DATE"].ToString(),
                                                                "",
                                                                int.Parse(row["APPL_ID"].ToString()),
                                                                "E"
                                                            );

                    UserObj.ObjRoles = new ATTRoles
                                                    (
                                                        int.Parse(row["ROLE_ID"].ToString()),
                                                        int.Parse(row["APPL_ID"].ToString()),
                                                        (string)row["ROLE_NAME"],
                                                        (string)row["ROLE_DESCRIPTION"],
                                                        "E"
                                                    );
                    UserObj.ObjApplications =new ATTApplication
                                                                (
                                                                    int.Parse(row["APPL_ID"].ToString()),
                                                                    (string)row["APPL_SHORT_NAME"].ToString(),
                                                                    (string)row["APPL_FULL_NAME"].ToString(),
                                                                    (string)row["DESCRIPTION"].ToString(),
                                                                    "E"

                                                                );
                                                   
                    UserRoleLST.Add(UserObj);
                }
                return UserRoleLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


         public static List<ATTUserRoles> GetLSTUserRoles(DataTable tbl)
         {
             List<ATTUserRoles> UserRoleLST = new List<ATTUserRoles>();
             try
             {
                 foreach (DataRow row in tbl.Rows)
                 {
                     ATTUserRoles UserObj = new ATTUserRoles
                                                             (
                                                                 row["Username"].ToString(),   
                                                                 int.Parse(row["RoleID"].ToString ()),
                                                                 row["FromDate"].ToString(),
                                                                 row["ToDate"].ToString(),
                                                                 int.Parse(row["ApplID"].ToString()),
                                                                 row["Action"].ToString()
                                                             );
                     UserRoleLST.Add(UserObj);
                 }
                 return UserRoleLST;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
    }
}
