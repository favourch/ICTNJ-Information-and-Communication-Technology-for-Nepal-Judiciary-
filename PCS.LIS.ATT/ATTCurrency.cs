using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTCurrency
    {
        private int _CurrencyID;
        public int CurrencyID
        {
            get { return this._CurrencyID; }
            set { this._CurrencyID = value; }
        }

        private string _CurrencyName;
        public string CurrencyName
        {
            get { return this._CurrencyName.Trim(); }
            set { this._CurrencyName = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        public ATTCurrency()
        {
        }

        public ATTCurrency(int curencyID, string currencyName)
        {
            this.CurrencyID = curencyID;
            this.CurrencyName = currencyName;
        }

        public ATTCurrency(int curencyID, string currencyName, string entryBy, DateTime entryOn)
        {
            this.CurrencyID = curencyID;
            this.CurrencyName = currencyName;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
        }
    }
}
