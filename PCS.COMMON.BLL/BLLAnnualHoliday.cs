using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;
using PCS.COMMON.DLL;
using System.Data;


namespace PCS.COMMON.BLL
{
    public class BLLAnnualHoliday
    {
        public static List<ATTAnnualHoliday> GetAnnHoliday(string year)
        {
            List<ATTAnnualHoliday> LSTAnnHolidays = new List<ATTAnnualHoliday>();
            try
            {
                foreach (DataRow row in DLLAnnualHoliday.GetAnnHoliday(year).Rows)
                {
                    ATTAnnualHoliday obj = new ATTAnnualHoliday();
                    obj.OrgID=int.Parse(row["ORG_ID"].ToString());
                    obj.FY = int.Parse(row["FY"].ToString());
                    obj.FromDate = row["FROM_DATE"].ToString();
                    obj.ToDate = row["TO_DATE"].ToString();
                    //obj.DateType = row["DATE_TYPE"].ToString();
                    obj.HolidayDescription = row["HOLIDAY_DESC"].ToString();
                    obj.Action = "";
                    LSTAnnHolidays.Add(obj);
                }
                return LSTAnnHolidays;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetMonthlyHoliday(string fromDate, string toDate)
        {
            List<ATTAnnualHoliday> lstMonthlyHolidays = new List<ATTAnnualHoliday>();
            string monthlyHoliday= DLLAnnualHoliday.GetMonthlyHolidays(fromDate, toDate);
            //foreach (DataRow row in DLLAnnualHoliday.GetMonthlyHolidays(fromDate, toDate).Rows)          
            //{
            //    ATTAnnualHoliday obj = new ATTAnnualHoliday();
            //    obj.Holidays = row["P_OUT_MSG"].ToString();
            //    lstMonthlyHolidays.Add(obj);
            //}
            //return lstMonthlyHolidays;\
            return monthlyHoliday; //new List<ATTAnnualHoliday>();


        }

        public static List<ATTAnnualHoliday> GetAnnHolidayPrev()
        {
            List<ATTAnnualHoliday> LSTAnnHolidayPrev = new List<ATTAnnualHoliday>();
            foreach (DataRow rw in DLLAnnualHoliday.GetAnnHolidayPrev().Rows)
            {
                ATTAnnualHoliday obj = new ATTAnnualHoliday();
                //obj.FY = int.Parse(rw["FY"].ToString());
                obj.FromDate = rw["FROM_DATE"].ToString();
                obj.ToDate = rw["TO_DATE"].ToString();
                //obj.DateType = rw["DATE_TYPE"].ToString();
                obj.HolidayDescription = rw["HOLIDAY_DESC"].ToString();
                obj.Action = "";
                LSTAnnHolidayPrev.Add(obj);
            }
            return LSTAnnHolidayPrev;
        }

        public static bool SaveAnnualHoliday(List<ATTAnnualHoliday> LSTAnn)
        {
            try
            {
                return DLLAnnualHoliday.SaveAnnualHoliday(LSTAnn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
