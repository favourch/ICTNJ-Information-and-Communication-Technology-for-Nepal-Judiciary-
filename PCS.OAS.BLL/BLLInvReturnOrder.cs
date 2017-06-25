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
    public class BLLInvReturnOrder
    {
        public static bool SaveUpdateReturnOrder(ATTInvReturnOrder objRo)
        {
            try
            {
                //DLLInvDeliveryOrder.SaveUpdateReturnOrder(objDo);
                DLLInvReturnOrder.SaveUpdateReturnOrder(objRo);
          

                return true;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
