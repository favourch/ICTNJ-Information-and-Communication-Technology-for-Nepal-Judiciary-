using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTCountry
    {
        private int _CountryId;
        public int CountryId
        {
            get { return this._CountryId; }
            set { this._CountryId = value; }
        }

        private string _CountryNepName;
        public string CountryNepName
        {
            get { return this._CountryNepName; }
            set { this._CountryNepName = value; }
        }

        private string _CountryEngName;
        public string CountryEngName
        {
            get { return this._CountryEngName; }
            set { this._CountryEngName = value; }
        }

        private string _CountryCode;
        public string CountryCode
        {
            get { return this._CountryCode; }
            set { this._CountryCode = value; }
        }

        public ATTCountry()
        {
        }

        public ATTCountry(int countryId, string countryNepName, string countryEngName, string countryCode)
        {
            this.CountryId = countryId;
            this.CountryNepName = countryNepName;
            this.CountryEngName = countryEngName;
            this.CountryCode = countryCode;
        }
    }
}
