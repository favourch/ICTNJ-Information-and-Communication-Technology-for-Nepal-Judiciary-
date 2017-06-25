using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTAnnualHoliday
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int _FY;

        public int FY
        {
            get { return _FY; }
            set { _FY = value; }
        }
  
        private string _FromDate;

        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string  _ToDate;

        public string  ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
	
        private string _DateType;

        public string DateType
        {
            get { return _DateType; }
            set { _DateType = value; }
        }

        private string _HolidayDescription;

        public string HolidayDescription
        {
            get { return _HolidayDescription; }
            set { _HolidayDescription = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private string _Holidays;

        public string Holidays
        {
            get { return _Holidays; }
            set { _Holidays = value; }
        }
	
	

        public  ATTAnnualHoliday()
        {

        }

        public  ATTAnnualHoliday(int orgId,int fy,string fromDate,string toDate, string dateType, string holidayDesc, string entryBy,string action)
        {
            this.OrgID = orgId;
            this.FY = fy;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.DateType = dateType;
            this.HolidayDescription = holidayDesc;
            this.EntryBy = entryBy;
            this.Action = action;
        }

        public ATTAnnualHoliday(string holidays)
        {
            this.Holidays = holidays;
        }
    }
}
