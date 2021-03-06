using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
namespace PCS.OAS.BLL
{
    public class BLLMeetingResources
    {
        public static List<ATTMeetingResources> GetResourcesList(int? rID)
        {
            List<ATTMeetingResources> lst = new List<ATTMeetingResources>();
            try
            {
                foreach (DataRow row in DLLMeetingResources.GetResourcesListTable(rID).Rows)
                {
                    ATTMeetingResources obj = new ATTMeetingResources();

                    obj.ResourceID = int.Parse(row["RESOURCE_ID"].ToString());
                    obj.ResourceName = row["RESOURCE_NAME"].ToString();
                    obj.ResourceDescription = row["RESOURCE_DESCRIPTION"].ToString();
                    //obj.Action = "E";

                    lst.Add(obj);
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
