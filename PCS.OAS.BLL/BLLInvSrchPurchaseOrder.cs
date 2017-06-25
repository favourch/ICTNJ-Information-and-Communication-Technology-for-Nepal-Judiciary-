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
    public class BLLInvSrchPurchaseOrder
    {
        public static List<ATTInvPurchaseOrder> SrchPurchaseOrder(ATTInvSrchPurchaseOrder objSrchPo,int type)
        {
            try
            {
                List<ATTInvPurchaseOrder> lst = new List<ATTInvPurchaseOrder>();

                foreach (DataRow row in DLLInvSrchPurchaseOrder.SrchPurchaseOrder(objSrchPo,type).Rows)
                {
                    ATTInvPurchaseOrder obj = new ATTInvPurchaseOrder();

                    int? recby = null;
                    int? appby = null;

                    if(row["REC_BY"].ToString() != "")
                        recby = int.Parse(row["REC_BY"].ToString());

                    if(row["APP_BY"].ToString() != "")
                        appby = int.Parse(row["APP_BY"].ToString());

                    obj.OrgID = int.Parse(row["ORG_ID"].ToString());
                    obj.SupplierID = int.Parse(row["SUPPLIERS_ID"].ToString());
                    obj.SupplierName = row["SUPPLIERS_NAME"].ToString();
                    obj.OrderDate = row["ORDER_DATE"].ToString();
                    obj.OrderNo = row["ORDER_NO"].ToString();
                    obj.RecBy = recby;
                    obj.RecDate = row["REC_DATE"].ToString();
                    obj.RecYesNo = row["REC_YES_NO"].ToString();
                    obj.AppBy = appby;
                    obj.AppDate = row["APP_DATE"].ToString();
                    obj.AppYesNo = row["APP_YES_NO"].ToString(); 
                    
                  
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
