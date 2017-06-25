using System;
using System.Collections.Generic;
using System.Text;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;

namespace PCS.OAS.BLL
{
    public class BLLMaagFaaramDetail
    {
        public static List<ATTMaagFaaramDetail> GetMaagFaaramDetail(ATTMaagFaaramDetail objMaagFaaramDetail)
        {
            List<ATTMaagFaaramDetail> lstMaagFaaramDetail = new List<ATTMaagFaaramDetail>();

            foreach (DataRow row in DLLMaagFaaramDetail.GetMaagFaaramDetail(objMaagFaaramDetail).Rows)
            {
                ATTMaagFaaramDetail obj = new ATTMaagFaaramDetail
                (
                ((row["ORG_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["ORG_ID"].ToString())),
                ((row["UNIT_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["UNIT_ID"].ToString())),
                ((row["REQ_NO"] == System.DBNull.Value) ? (double?)null : double.Parse(row["REQ_NO"].ToString())),
                ((row["ITEMS_CATEGORY_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["ITEMS_CATEGORY_ID"].ToString())),
                ((row["ITEMS_SUB_CATEGORY_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["ITEMS_SUB_CATEGORY_ID"].ToString())),
                ((row["ITEMS_ID"] == System.DBNull.Value) ? (int?)null : int.Parse(row["ITEMS_ID"].ToString())),
                ((row["REQ_QTY"] == System.DBNull.Value) ? (int?)null : int.Parse(row["REQ_QTY"].ToString()))
                );

                obj.Remarks = ((row["REMARKS"] == System.DBNull.Value) ? "" : (row["REMARKS"].ToString()));
                obj.AppQty = ((row["APP_QTY"] == System.DBNull.Value) ? (int?)null : int.Parse(row["APP_QTY"].ToString()));
                obj.DeliveredQty = ((row["DELIVERED_QTY"] == System.DBNull.Value) ? 0 : int.Parse(row["DELIVERED_QTY"].ToString()));
                //obj.Specifications = ((row["ITEMS_SPECIFICATIONS"] == System.DBNull.Value) ? "" : (row["ITEMS_SPECIFICATIONS"].ToString()));
                
                obj.JiKhaPaNo = ((row["JI_KHA_PA_NO"] == System.DBNull.Value) ? "" : (row["JI_KHA_PA_NO"].ToString()));
                obj.ItemsCategoryName = ((row["ITEMS_CATEGORY_NAME"] == System.DBNull.Value) ? "" : (row["ITEMS_CATEGORY_NAME"].ToString()));
                obj.ItemsSubCategoryName = ((row["ITEMS_SUB_CATEGORY_NAME"] == System.DBNull.Value) ? "" : (row["ITEMS_SUB_CATEGORY_NAME"].ToString()));
                obj.ItemsName = ((row["ITEMS_NAME"] == System.DBNull.Value) ? "" : (row["ITEMS_NAME"].ToString()));
                obj.ItemsUnitName = ((row["ITEMS_UNIT_NAME"] == System.DBNull.Value) ? "" : (row["ITEMS_UNIT_NAME"].ToString()));


                lstMaagFaaramDetail.Add(obj);
            }
            return lstMaagFaaramDetail;
        }
    }
}
