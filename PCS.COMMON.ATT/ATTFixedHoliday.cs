using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTFixedHoliday
    {
        private string _Year;

        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
	

        private string _FromMonth;

        public string FromMonth
        {
            get { return _FromMonth; }
            set { _FromMonth = value; }
        }

        private string _ToMonth;

        public string ToMonth
        {
            get { return _ToMonth; }
            set { _ToMonth = value; }
        }

        private string _FromDay;

        public string FromDay
        {
            get { return _FromDay; }
            set { _FromDay = value; }
        }

        private string _ToDay;

        public string ToDay
        {
            get { return _ToDay; }
            set { _ToDay = value; }
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

        public ATTFixedHoliday()
        {

        }

        public ATTFixedHoliday(string year,string fromMonth,string toMonth,string fromDay,string toDay,string dateType,string holidayDesc,string entryBy,string action)
        {
            this.Year = year;
            this.FromMonth = fromMonth;
            this.ToMonth = toMonth;
            this.FromDay = fromDay;
            this.ToDay = toDay;
            this.DateType = dateType;
            this.HolidayDescription = holidayDesc;
            this.EntryBy = entryBy;
            this.Action = action;
        }
    }
}
