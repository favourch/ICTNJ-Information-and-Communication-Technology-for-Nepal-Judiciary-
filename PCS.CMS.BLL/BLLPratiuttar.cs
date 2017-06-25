using System;
using System.Collections.Generic;
using System.Text;

using PCS.CMS.ATT;
using PCS.CMS.DLL;

namespace PCS.CMS.BLL
{
    public class BLLPratiuttar
    {
        public static bool SavePratiuttar(ATTPratiuttar objPratiuttar)
        {
            try
            {
                return DLLPratiuttar.SavePratiuttar(objPratiuttar);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
