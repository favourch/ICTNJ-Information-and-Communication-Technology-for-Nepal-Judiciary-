using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;

namespace PCS.OAS.BLL
{
    public  class BLLInvDakhila
    {
        public static bool SaveDakhila(List<ATTInvDakhila> lst)
        {
            try
            {
                return DLLInvDakhila.SaveDakhila(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ApproveDakhila(ATTInvDakhila objDak)
        {
            try
            {
                return DLLInvDakhila.ApproveDakhila(objDak); 
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
    }
}
