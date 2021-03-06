using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLGroup
    {
        public static ObjectValidation Validate(ATTGroup obj)
        {
            ObjectValidation result = new ObjectValidation();

            if (obj.GroupName.Trim() == "")
            {
                result.IsValid = false;
                result.ErrorMessage = "Group name cannot be blank";
                return result;
            }

            return result;
        }

        public static bool AddGroup(ATTGroup obj)
        {
            try
            {
                DLLGroup.AddGroup(obj);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTGroup> GetGroupList(int? orgID, bool ContainDefault,char type)
        {
            try
            {
                List<ATTGroup> lstGroup = new List<ATTGroup>();

                DataTable tbl = DLLGroup.GetGroupListTable(orgID,type);
                
                foreach (DataRow row in tbl.Rows)
                {
                    ATTGroup objGroup = new ATTGroup(int.Parse(row["ORG_ID"].ToString()),
                                                     int.Parse(row["GROUP_ID"].ToString()),
                                                     row["GROUP_NAME"].ToString(),
                                                     row["DESCRIPTION"].ToString(),
                                                     row["ACTIVE"].ToString()
                                                    );
                   
                    lstGroup.Add(objGroup);
                }

                if (ContainDefault == true && lstGroup.Count > 0)
                {
                    lstGroup.Insert(0, new ATTGroup(0, 0, "------ Select Group ------", "", ""));
                }

                return lstGroup;

            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static List<ATTGroup> GetGroupListWithMember(int? orgID, bool ContainDefault,char type)
        {
            try
            {
                List<ATTGroupMember> lstGM = BLLGroupMember.GetGroupMemberList(null);

                List<ATTGroup> lstGroup = new List<ATTGroup>();

                foreach (DataRow row in DLLGroup.GetGroupListTable(orgID,type).Rows)
                {
                    ATTGroup objGroup = new ATTGroup(int.Parse(row["ORG_ID"].ToString()),
                                                     int.Parse(row["GROUP_ID"].ToString()),
                                                     row["GROUP_NAME"].ToString(),
                                                     row["DESCRIPTION"].ToString(),
                                                     row["ACTIVE"].ToString()
                                                    );

                    objGroup.LstGroupMember = lstGM.FindAll
                                                        (
                                                            delegate(ATTGroupMember m)
                                                            {
                                                                return
                                                                    m.OrgID == objGroup.OrgID &&
                                                                    m.GroupID == objGroup.GroupID;
                                                            }
                                                        );

                    lstGroup.Add(objGroup);
                }

                if (ContainDefault == true && lstGroup.Count > 0)
                {
                    lstGroup.Insert(0, new ATTGroup(0, 0, "छान्नुहोस्", "", ""));
                }

                return lstGroup;

            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        
    }
}
