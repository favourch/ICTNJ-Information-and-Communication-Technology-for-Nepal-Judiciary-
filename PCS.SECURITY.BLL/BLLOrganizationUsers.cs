using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.SECURITY.ATT;
using PCS.FRAMEWORK;
using PCS.SECURITY.DLL;

namespace PCS.SECURITY.BLL
{
    public class BLLOrganizationUsers
    {
        public static ObjectValidation Validate(ATTOrganizationUsers objOrgUsers)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objOrgUsers.OrgID == 0)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Organization Not Selected. Please Select One...";
                return OV;
            }

            if (objOrgUsers.Username == "")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Username cannot be Blank.";
                return OV;
            }

            

            return OV;
        }

        public List<ATTOrganizationUsers> GetOrgUsers(int orgID)
        {
            return (GetOrgUserList(PCS.SECURITY.DLL.DLLOrganizationUSers.GetOrgUsersTable(orgID)));
        }


        public static List<ATTOrganizationUsers> GetOrgUserList(DataTable tbl)
        {
            List<ATTOrganizationUsers> OrgUserLST = new List<ATTOrganizationUsers>();
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTOrganizationUsers OrgUserObj = new ATTOrganizationUsers
                                                                         (
                                                        int.Parse (row["ORG_ID"].ToString()),
                                                        (string)row["USER_NAME"].ToString(),
                                                        (string)row["FROM_DATE"].ToString(),
                                                        (string)row["TO_DATE"].ToString(),
                                                        "E"
                                                        
                                                   );
                    
                    OrgUserObj.LSTUserRoles = new BLLUserRoles().GetUserRoles((string)row["USER_NAME"].ToString());
                    
                    OrgUserObj.ObjUsers = new ATTUsers
                                                    (
                                                       (string)row["USER_NAME"].ToString(),
                                                       (string)row["PASSWORD"].ToString(),
                                                       "",
                                                       (string)row["CREATEDBY"].ToString(),
                                                       (DateTime)row["CREATED_DATE"],
                                                       (DateTime)row["VALID_UPTO"],
                                                       (string)row["ACTIVE"].ToString(),
                                                       "E",
                                                       (row["P_ID"] == System.DBNull.Value) ? 0 : double.Parse(row["P_ID"].ToString())
                                                       );
                  
                    OrgUserLST.Add(OrgUserObj);
                }
                return OrgUserLST;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddOrgUser(ATTOrganizationUsers obj)
        {
            try
            {
                DLLOrganizationUSers.AddOrgUsers(obj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
