using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLInvItemType
    {
        public static List<ATTInvItemType> GetItemType(int? itemtypeid, string active)
        {
            List<ATTInvItemType> lst = new List<ATTInvItemType>();
            try
            {
                foreach (DataRow row in DLLInvItemType.GetItemType(itemtypeid, active).Rows)
                {
                    ATTInvItemType objItemType = new ATTInvItemType(
                                     int.Parse(row["ITEMS_TYPE_ID"].ToString()),
                                     row["ITEMS_TYPE_NAME"].ToString(),
                                     row["active"].ToString());
                    lst.Add(objItemType);
                }
                return lst;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
