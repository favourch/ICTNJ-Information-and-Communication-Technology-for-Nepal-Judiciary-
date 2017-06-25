using System;
using System.Collections.Generic;
using System.Text;

using PCS.OAS.ATT;
using PCS.OAS.DLL;
using System.Data;
using PCS.FRAMEWORK;

namespace PCS.OAS.BLL
{
    public class BLLAuctionMaster
    {
        public static bool SaveAuctionMaster(ATTAuctionMaster objItemsMaster)
        {
            try
            {
                return DLLAuctionMaster.SaveAuctionMaster(objItemsMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
