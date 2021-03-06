using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLMessageGroup
    {
        public static List<ATTMessageGroup> GetGroupList(int? orgID,string type, string searchValue, bool ContainDefault)
        {
            try
            {
                List<ATTMessageGroup> lstReceiverGroup = new List<ATTMessageGroup>();

                DataTable tbl = DLLMessageGroup.GetGroupListTable(orgID,type,searchValue);

                foreach (DataRow row in tbl.Rows)
                {
                    ATTMessageGroup objGroup = new ATTMessageGroup(int.Parse(row["ORG_ID"].ToString()),
                                                                    int.Parse(row["GROUP_ID"].ToString()),
                                                                    row["GROUP_NAME"].ToString(),
                                                                    row["DESCRIPTION"].ToString(),
                                                                    row["ACTIVE"].ToString()
                                                                  );

                    objGroup.GroupType = row["TYPE"].ToString();

                    //objGroup.Grouptype
                    lstReceiverGroup.Add(objGroup);
                }

                if (ContainDefault == true && lstReceiverGroup.Count > 0)
                {
                    lstReceiverGroup.Insert(0, new ATTMessageGroup(0, 0, "छान्नुहोस्", "", ""));
                }

                return lstReceiverGroup;

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

    }
}
