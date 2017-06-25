using System;
using System.Collections.Generic;
using System.Text;

using PCS.PMS.ATT;
using PCS.PMS.DLL;
using PCS.FRAMEWORK;

namespace PCS.PMS.BLL
{
    public class BLLPropertyDetails
    {
        public static bool SavePropertyDetails(List<ATTPropertyDetails> lstPropertyDetails)
        {
            try
            {
                return DLLPropertyDetails.SavePropertyDetails(lstPropertyDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool SavePropertyDetails(ATTPropertyDetails objPD)
        {
            try
            {
                return DLLPropertyDetails.SavePropertyDetails(objPD);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
