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
    public class BLLAppointee
    {
        public static DataTable GetAppointeeListTable(string dateString, ATTUserLogin login)
        {
            try
            {
                return DLLAppointee.GetAppointeeListTable(dateString, login);

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
