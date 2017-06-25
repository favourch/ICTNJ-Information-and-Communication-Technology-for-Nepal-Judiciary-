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
    public class BLLInvPurchaseOrder
    {

        public static int SavePurchaseOrder(ATTInvPurchaseOrder objPo)
        {
            try
            {
                return DLLInvPurchaseOrder.SavePurchaseOrder(objPo);
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        public static int RecomendApprovePurchaseOrder(ATTInvPurchaseOrder objPo)
        {
            try
            {
                return DLLInvPurchaseOrder.RecomendApprovePurchaseOrder(objPo);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


    }
}
