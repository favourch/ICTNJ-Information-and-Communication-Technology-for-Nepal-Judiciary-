
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.DLL;

namespace PCS.COMMON.BLL
{
    public class BLLTime
    {
        public static string GetCurrentTime()
        {
            try
            {
                //return DLLDate.GetDateString(Year, Month, LP);

                return DLLTime.GetCurrentTime();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
