using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;

namespace PCS.OAS.BLL
{
    public class BLLInvOrgItemsPrice
    {
        public static bool SaveOrgItemsPrice(List<ATTInvOrgItemsPrice> itemsPrice)
        {
            try
            {
                return DLLInvOrgItemsPrice.SaveOrgItemsPrice(itemsPrice);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<ATTInvOrgItemsPrice> GetOrgInvItemsPrice(int orgID, int? itemCatID, int? itemSubCatID, Boolean flag)
        {
            List<ATTInvOrgItemsPrice> lstItemsPrice = new List<ATTInvOrgItemsPrice>();
            try
            {
                foreach (DataRow row in DLLInvOrgItemsPrice.GetOrgInvItemsPrice(orgID, itemCatID, itemSubCatID).Rows)
                {
                    ATTInvOrgItemsPrice objItemsPrice = new ATTInvOrgItemsPrice();

                    objItemsPrice.OrgID = int.Parse(row["ORG_ID"].ToString());

                    objItemsPrice.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    objItemsPrice.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();

                    objItemsPrice.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    objItemsPrice.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();

                    objItemsPrice.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    objItemsPrice.ItemCD = row["ITEMS_CD"].ToString();
                    objItemsPrice.ItemName = row["ITEMS_NAME"].ToString();


                    objItemsPrice.FromDate = row["FROM_DATE"].ToString();

                    objItemsPrice.UnitPrice = (row["UNIT_PRICE"].ToString() == "") ? 0.0 : double.Parse(row["UNIT_PRICE"].ToString());

                    lstItemsPrice.Add(objItemsPrice);
                }
                if (flag)
                {
                    ATTInvOrgItemsPrice ob = new ATTInvOrgItemsPrice();
                    ob.ItemsID = -2;
                    ob.ItemName = "--छान्नुहोस्";

                    lstItemsPrice.Insert(0, ob);
                }


                return lstItemsPrice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTInvOrgItemsPrice> GetOrgInvItemsPrice(int orgID, int? itemCatID, int? itemSubCatID)
        {
            List<ATTInvOrgItemsPrice> lstItemsPrice = new List<ATTInvOrgItemsPrice>();
            try
            {
                foreach (DataRow row in DLLInvOrgItemsPrice.GetOrgInvItemsPrice(orgID, itemCatID, itemSubCatID).Rows)
                {
                    ATTInvOrgItemsPrice objItemsPrice = new ATTInvOrgItemsPrice();

                    objItemsPrice.OrgID = int.Parse(row["ORG_ID"].ToString());

                    objItemsPrice.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    objItemsPrice.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();

                    objItemsPrice.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    objItemsPrice.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();

                    objItemsPrice.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    objItemsPrice.ItemCD = row["ITEMS_CD"].ToString();
                    objItemsPrice.ItemName = row["ITEMS_NAME"].ToString();


                    objItemsPrice.FromDate = row["FROM_DATE"].ToString();

                    objItemsPrice.UnitPrice = (row["UNIT_PRICE"].ToString() == "") ? 0.0 : double.Parse(row["UNIT_PRICE"].ToString());


                    objItemsPrice.ItemShortName = row["ITEMS_SHORT_NAME"].ToString();
                    objItemsPrice.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                    objItemsPrice.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                    objItemsPrice.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                    objItemsPrice.ItemsUnitName = row["ITEMS_UNIT_NAME"].ToString();
                    //objItemsPrice.Specifications = row["ITEMS_SPECIFICATIONS"].ToString()!= "" ?row["ITEMS_SPECIFICATIONS"].ToString():"" ;
                    //objItemsPrice.IssuedTo = row["ISSUED_TO"].ToString() != "" ?row["ISSUED_TO"].ToString() : "" ;
                    //objItemsPrice.JiKhaPaNo = row["JI_KHA_PA_NO"].ToString();
                    objItemsPrice.Quantity = int.Parse(row["QUANTITY"].ToString());

                    lstItemsPrice.Add(objItemsPrice);
                }
                return lstItemsPrice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTInvOrgItemsPrice> GetOrgInvItemsPrice(ATTInvOrgItemsPrice obj)
        {
            List<ATTInvOrgItemsPrice> lstItemsPrice = new List<ATTInvOrgItemsPrice>();
            try
            {
                foreach (DataRow row in DLLInvOrgItemsPrice.GetOrgInvItemsPrice(obj).Rows)
                {
                    ATTInvOrgItemsPrice objItemsPrice = new ATTInvOrgItemsPrice();

                    objItemsPrice.OrgID = int.Parse(row["ORG_ID"].ToString());

                    objItemsPrice.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    objItemsPrice.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();

                    objItemsPrice.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    objItemsPrice.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();

                    objItemsPrice.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    objItemsPrice.ItemCD = row["ITEMS_CD"].ToString();
                    objItemsPrice.ItemName = row["ITEMS_NAME"].ToString();


                    objItemsPrice.FromDate = row["FROM_DATE"].ToString();

                    objItemsPrice.UnitPrice = (row["UNIT_PRICE"].ToString() == "") ? 0.0 : double.Parse(row["UNIT_PRICE"].ToString());


                    objItemsPrice.ItemShortName = row["ITEMS_SHORT_NAME"].ToString();
                    objItemsPrice.ItemsTypeID = int.Parse(row["ITEMS_TYPE_ID"].ToString());
                    objItemsPrice.ItemsTypeName = row["ITEMS_TYPE_NAME"].ToString();
                    objItemsPrice.ItemsUnitID = int.Parse(row["ITEMS_UNIT_ID"].ToString());
                    objItemsPrice.ItemsUnitName = row["ITEMS_UNIT_NAME"].ToString();
                    //objItemsPrice.Specifications = row["SPECIFICATIONS"].ToString();
                    //objItemsPrice.IssuedTo = row["ISSUED_TO"].ToString();
                    objItemsPrice.JiKhaPaNo = row["JI_KHA_PA_NO"].ToString();
                    objItemsPrice.Quantity = int.Parse(row["QUANTITY"].ToString());

                    lstItemsPrice.Add(objItemsPrice);
                }
                return lstItemsPrice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
