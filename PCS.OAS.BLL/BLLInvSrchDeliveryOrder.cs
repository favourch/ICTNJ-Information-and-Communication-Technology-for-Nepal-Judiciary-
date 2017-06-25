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
    public class BLLInvSrchDeliveryOrder
    {
        public static List<ATTInvDeliveryOrderDetail> SrchDeliveryOrder(ATTInvSrchDeliveryOrder objSrchDo)
        {
            try
            {
                List<ATTInvDeliveryOrderDetail> lst = new List<ATTInvDeliveryOrderDetail>();

                foreach (DataRow row in DLLInvSrchDeliveryOrder.SrchDeliveryOrder(objSrchDo).Rows)
                {
                    ATTInvDeliveryOrderDetail obj = new ATTInvDeliveryOrderDetail();

                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrderNo = row["ORDER_NO"].ToString();

                    obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                    obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                    obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                    obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                    obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                    obj.ItemsName = row["ITEMS_NAME"].ToString();
                    obj.RequiredQty = int.Parse(row["TOTAL_QUANTITY"].ToString());
                    obj.DeliveredQty = row["TOTAL_DELIVERED"].ToString() == "" ? 0 : int.Parse(row["TOTAL_DELIVERED"].ToString());
                    obj.ApproveDate = row["app_date"].ToString();
                    obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
                                      
                   
                    lst.Add(obj);
                }

                return lst;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


        public static List<ATTInvDeliveryOrder> SrchDeliveredOrder(ATTInvSrchDeliveryOrder objSrchDo)
        {
            try
            {
                List<ATTInvDeliveryOrder> lst = new List<ATTInvDeliveryOrder>();

                DataTable tbl = new DataTable();

                tbl = DLLInvSrchDeliveryOrder.SrchDeliveredOrder(objSrchDo);

                foreach (DataRow row in tbl.Rows)
                {
                    ATTInvDeliveryOrder obj = new ATTInvDeliveryOrder();

                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.OrderNo = row["ORDER_NO"].ToString();
                    obj.DeliverySeq = int.Parse(row["DELIVERY_SEQ"].ToString());
                    obj.DeliveryPerson = row["DELIVERY_PERSON"].ToString();
                    obj.DeliveryDate = row["DELIVERY_DATE"].ToString();
                    obj.ReceiverID = int.Parse(row["RCVD_BY"].ToString());
                    obj.ReceiverName = row["FIRST_NAME"].ToString() +
                                        (row["MID_NAME"].ToString() == "" ? "" : " " + row["MID_NAME"].ToString()) +
                                        (row["SUR_NAME"].ToString() == "" ? "" : " " + row["SUR_NAME"].ToString());
                                                                             
                    obj.ReceivedDate = row["RCVD_DATE"].ToString();
                    obj.InvoiceNo = row["INVOICE_NO"].ToString();

                    lst.Add(obj);
                }
                

                return lst;
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }

        public static List<ATTInvDeliveryOrderDetail> DeliveredOrderDetail(ATTInvDeliveryOrder objDo)
        {
            try
            {
                List<ATTInvDeliveryOrderDetail> lst = new List<ATTInvDeliveryOrderDetail>();

                DataTable tbl = new DataTable();

                tbl = DLLInvSrchDeliveryOrder.DeliveredOrderDetail(objDo);

                  foreach (DataRow row in tbl.Rows)
                  {
                      ATTInvDeliveryOrderDetail obj = new ATTInvDeliveryOrderDetail();

                      obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                      //obj.UnitID = int.Parse(row["UNIT_ID"].ToString());
                      obj.OrderNo = row["ORDER_NO"].ToString();
                      obj.DeliverySeq = int.Parse(row["DELIVERY_SEQ"].ToString());
                      obj.ItemsCategoryID = int.Parse(row["ITEMS_CATEGORY_ID"].ToString());
                      obj.ItemsCategoryName = row["ITEMS_CATEGORY_NAME"].ToString();
                      obj.ItemsSubCategoryID = int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString());
                      obj.ItemsSubCategoryName = row["ITEMS_SUB_CATEGORY_NAME"].ToString();
                      obj.ItemsID = int.Parse(row["ITEMS_ID"].ToString());
                      obj.ItemsName = row["ITEMS_NAME"].ToString();
                      obj.DeliveredQty = row["total_delivered"].ToString() == "" ? 0 : int.Parse(row["total_delivered"].ToString());
                      obj.ReturnedQty = row["total_returned"].ToString() == "" ? 0 : int.Parse(row["total_returned"].ToString());

                      obj.SeqNo = int.Parse(row["SEQ_NO"].ToString());
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
