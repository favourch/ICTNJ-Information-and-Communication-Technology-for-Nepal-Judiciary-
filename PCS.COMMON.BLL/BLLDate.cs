
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.COMMON.DLL;

namespace PCS.COMMON.BLL
{
    public class BLLDate
    {
        public static DataTable GetMaxMinYear()
        {
            try
            {
                return DLLDate.GetMaxMinYear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetDateString(int Year, int Month, string LP)
        {
            try
            {
                return DLLDate.GetDateString(Year, Month, LP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getNepDate()
        {
            return DLLDate.getNepDate();
        }

        public static string getEngDate()
        {
            return DLLDate.getEngDate();
        }
    }
}
