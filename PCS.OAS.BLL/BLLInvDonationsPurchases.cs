using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.OAS.ATT;
using PCS.OAS.DLL;

namespace PCS.OAS.BLL
{
    public class BLLInvDonationsPurchases
    {
        public static bool saveDonationPurchases(ATTInvDonationsPurchases obj)
        {
            try
            {
                return DLLInvDonationsPurchases.saveDonationPurchases(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}
