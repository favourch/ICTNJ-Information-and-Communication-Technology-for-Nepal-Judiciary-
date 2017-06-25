using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTTarekhCourtBato
    {
        private int _CourtID;
        public int CourtID
        {
            get { return _CourtID; }
            set { _CourtID = value; }
        }
        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        private string _ToDate;
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        private int _TotalDays;
        public int TotalDays
        {
            get { return _TotalDays; }
            set { _TotalDays = value; }
        }
        private int _BatoKoMayad;
        public int BatoKoMayad
        {
            get { return _BatoKoMayad; }
            set { _BatoKoMayad = value; }
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
	
        public ATTTarekhCourtBato()
        {
        }

        public ATTTarekhCourtBato(int courtID,string fromDate,int totDays,int batoMyaad)
        {
            this.CourtID = courtID;
            this.FromDate = fromDate;
            this.TotalDays = totDays;
            this.BatoKoMayad = batoMyaad;
        }
    }
}
