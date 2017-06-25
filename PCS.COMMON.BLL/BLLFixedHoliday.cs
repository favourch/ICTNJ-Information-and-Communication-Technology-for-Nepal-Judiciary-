using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;

using System.Data;

namespace PCS.COMMON.BLL
{
    public class BLLFixedHoliday
    {
        public static List<ATTFixedHoliday> GetYear()
        {
            List<ATTFixedHoliday> LSTYear = new List<ATTFixedHoliday>();
            try
            {
                foreach (DataRow rw in DLLFixedHoliday.GetYear().Rows)
                {
                    ATTFixedHoliday obj = new ATTFixedHoliday();
                    obj.Year = rw["NYEAR"].ToString();
                    LSTYear.Add(obj);
                }
                return LSTYear;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ATTFixedHoliday> GetFixedHolidays()
        {
            List<ATTFixedHoliday> LSTFxHolidays = new List<ATTFixedHoliday>();
            try
            {
                foreach (DataRow row in DLLFixedHoliday.GetFixedHolidays().Rows)
                {
                    ATTFixedHoliday obj = new ATTFixedHoliday();
                    obj.FromMonth = row["FROM_MONTH"].ToString();
                    obj.ToMonth = row["TO_MONTH"].ToString();
                    obj.FromDay = row["FROM_DAY"].ToString();
                    obj.ToDay = row["TO_DAY"].ToString();
                    obj.DateType = row["DATE_TYPE"].ToString();
                    obj.HolidayDescription = row["HOLIDAY_DESC"].ToString();
                    obj.Action = "";
                    LSTFxHolidays.Add(obj);
                }
                return LSTFxHolidays;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveFixedHoliday(List<ATTFixedHoliday> LSTFx)
        {
            try
            {
                return DLLFixedHoliday.SaveFixedHoliday(LSTFx);
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            
        }
    }
}
