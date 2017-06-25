using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTLibraryMaterialCopy
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _LibraryID;
        public int LibraryID
        {
            get { return this._LibraryID; }
            set { this._LibraryID = value; }
        }

        private long _LMaterialID;
        public long LMaterialID
        {
            get { return this._LMaterialID; }
            set { this._LMaterialID = value; }
        }

        private long _AccessionID;
        public long AccessionID
        {
            get { return this._AccessionID; }
            set { this._AccessionID = value; }
        }

        private string _Edition = "";
        public string Edition
        {
            get { return this._Edition.Trim(); }
            set { this._Edition = value; }
        }

        private string _PublicationDate = "";
        public string PublicationDate
        {
            get { return this._PublicationDate.Trim(); }
            set { this._PublicationDate = value; }
        }

        private DateTime _RegistrationDate = DateTime.Now.Date;
        public DateTime RegistrationDate
        {
            get { return this._RegistrationDate; }
            set { this._RegistrationDate = value; }
        }

        private string _IsbnIssnNo = "";
        public string IsbnIssnNo
        {
            get { return this._IsbnIssnNo.Trim(); }
            set { this._IsbnIssnNo = value; }
        }

        private double _Price;
        public double Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }

        private int _CurrencyID;
        public int CurrencyID
        {
            get { return this._CurrencyID; }
            set { this._CurrencyID = value; }
        }

        private string _Location = "";
        public string Location
        {
            get { return this._Location.Trim(); }
            set { this._Location = value; }
        }

        private string _EntryBy = "";
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

        private string _Action = "";
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private bool _HasChecked = false;
        public bool HasChecked
        {
            get { return this._HasChecked; }
            set { this._HasChecked = value; }
        }

        public ATTLibraryMaterialCopy()
        {
        }
    }
}
