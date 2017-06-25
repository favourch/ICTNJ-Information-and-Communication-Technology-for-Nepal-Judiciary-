using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;

namespace PCS.OAS.BLL
{
    public class BLLInvOrgItems
    {
        public static bool SaveOrgItems(List<ATTInvOrgItems> items)
        {
            try
            {
                return DLLInvOrgItems.SaveOrgItems(items);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<ATTInvOrgItems> GetOrgInvItems(int orgID, string active)
        {
            List<ATTInvOrgItems> lstitems = new List<ATTInvOrgItems>();
            try
            {
                foreach (DataRow row in DLLInvOrgItems.GetOrgInvItems(orgID, active).Rows)
                {
                    ATTInvOrgItems objitems = new ATTInvOrgItems();

                    objitems.OrgID = int.Parse(row["ORG_ID"].ToString());
                    objitems.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    objitems.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    objitems.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    objitems.Quantity = int.Parse(row["QUANTITY"].ToString());
                    objitems.PanNo = row["JI_KHA_PA_NO"].ToString();
                    objitems.Active = row["ACTIVE"].ToString();
                    //objitems.EntryBy = row["ENTRY_BY"].ToString();



                    lstitems.Add(objitems);
                }
                return lstitems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CheckExistsOrgItems(ATTInvOrgItems objInvOItems)
        {
            try
            {
                return DLLInvOrgItems.CheckExistsOrgItems(objInvOItems);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        
    }
}
