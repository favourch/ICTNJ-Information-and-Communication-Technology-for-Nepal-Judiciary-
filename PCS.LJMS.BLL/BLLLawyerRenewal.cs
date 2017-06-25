using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.LJMS.ATT;
using PCS.LJMS.DLL;
using PCS.COMMON.BLL;
using PCS.COMMON.ATT;
using PCS.FRAMEWORK;

namespace PCS.LJMS.BLL
{
    public class BLLLawyerRenewal
    {
        public static DataTable GetLawyerRenewalDetails(double PID)
        {
            try
            {
                return DLLLawyerRenewal.GetLawyerRenewalDetails(PID);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
