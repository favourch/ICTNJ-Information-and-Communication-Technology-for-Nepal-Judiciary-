using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;
using System.Collections;

namespace PCS.OAS.BLL
{
    public class BLLInvSrchDakhila
    {
        public static List<ATTInvDakhila> SrchDirectEntry(ATTInvSrchDakhila objSrchDak)
        {
            try
            {
                List<ATTInvDakhila> lst = new List<ATTInvDakhila>();

                DataTable tbl = new DataTable();

                tbl = DLLInvSrchDakhila.SrchDirectEntry(objSrchDak);
 
                foreach (DataRow row in tbl.Rows)
                {
                    ATTInvDakhila obj = new ATTInvDakhila();

                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                  
                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.DirectEntrySeq = int.Parse(row["SEQ_NO"].ToString());
                    obj.DirectEntryDate = row["DIR_ENTRY_DATE"].ToString();
                    obj.DirectEntryType = row["DIR_ENTRY_TYPE"].ToString();
                    obj.DonationOrg = row["DON_ORGANIZATION"].ToString();
                    obj.UnitPrice = double.Parse(row["ITEMS_UNIT_PRICE"].ToString());
                    obj.Quantity = int.Parse(row["TOTAL_QUANTITY"].ToString());


                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
