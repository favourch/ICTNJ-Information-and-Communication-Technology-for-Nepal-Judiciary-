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
    public class BLLInvPurchaseOrderDetail
    {
        public static List<ATTInvPurchaseOrderDetail> GetPurchaseOrderDetail(string orderNo)
        {
            try
            {
              
                List<ATTInvPurchaseOrderDetail> lst = new List<ATTInvPurchaseOrderDetail>();

                DataTable tbl = new DataTable();
                tbl = DLLInvPurchaseOrderDetail.GetPurchaseOrderDetail(orderNo);

                foreach (DataRow row in tbl.Rows)
                {
                    ATTInvPurchaseOrderDetail obj = new ATTInvPurchaseOrderDetail();
                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                    obj.ManuCompany = row["manu_company"].ToString();
                    obj.ManuDate = row["manu_date"].ToString();
                    obj.Brand = row["brand"].ToString();
                    obj.UnitPrice = double.Parse(row["UNIT_PRICE"].ToString());
                    obj.TotalQty = int.Parse(row["TOTAL_QUANTITY"].ToString());
                    obj.Specification = "";
                   
                    obj.Action = "N";


                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public static bool SavePurchaseOrderDetail(List<ATTInvPurchaseOrderDetail> lst)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
