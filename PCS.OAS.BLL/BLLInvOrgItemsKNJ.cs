using System;
using System.Collections.Generic;
using System.Text;

using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.FRAMEWORK;
using System.Data;


namespace PCS.OAS.BLL
{
    public class BLLInvOrgItemsKNJ
    {
        public static List<ATTInvOrgItemsKNJ> SearchItemsKNJ(ATTInvOrgItemsKNJ itms)
        {
            try
            {
                List<ATTInvOrgItemsKNJ> LSTItemsKNJ = new List<ATTInvOrgItemsKNJ>();
                foreach (DataRow row in DLLInvOrgItemsKNJ.SearchItemsKNJ(itms).Rows)
                {
                    ATTInvOrgItemsKNJ obj = new ATTInvOrgItemsKNJ();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.KNJSeq = int.Parse(row["SEQ_NO"].ToString());
                    obj.ItemsAttrib=row["ITEMS_ATTRIBUTES"].ToString();
                    obj.VehRegNo=row["VEHICLE_REG_NO"].ToString();
                    obj.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                    obj.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                    obj.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                    obj.ItemsUnitName = row["ITEMS_UNIT_NAME"].ToString();
                    obj.JI_KHA_PA_NO = row["JI_KHA_PA_NO"].ToString();
                    LSTItemsKNJ.Add(obj);
                }
                return LSTItemsKNJ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTInvOrgItemsKNJ> SearchItemsKNJ(int? itmCatID, int? itmSubCatID)
        {
            try
            {
                List<ATTInvOrgItemsKNJ> LSTItemsKNJ = new List<ATTInvOrgItemsKNJ>();
                foreach (DataRow row in DLLInvOrgItemsKNJ.SearchItemsKNJ(itmCatID, itmSubCatID).Rows)
                {
                    ATTInvOrgItemsKNJ obj = new ATTInvOrgItemsKNJ();
                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrgName = row["ORG_NAME"].ToString();
                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.KNJSeq = int.Parse(row["SEQ_NO"].ToString());
                    obj.ItemsAttrib = row["ITEMS_ATTRIBUTES"].ToString();
                    obj.VehRegNo = row["VEHICLE_REG_NO"].ToString();
                    obj.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                    obj.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                    obj.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                    obj.ItemsUnitName = row["ITEMS_UNIT_NAME"].ToString();
                    obj.JI_KHA_PA_NO = row["JI_KHA_PA_NO"].ToString();
                    LSTItemsKNJ.Add(obj);
                }
                return LSTItemsKNJ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
