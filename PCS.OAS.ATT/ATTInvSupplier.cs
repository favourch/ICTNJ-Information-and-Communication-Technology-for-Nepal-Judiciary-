using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.OAS.ATT
{
    [Serializable]
    public class ATTInvSupplier
    {
        //In the paramater ENTRY_DATE sys date is entered 

        private int _SupplierID;
        public int SupplierID
        {
            get { return this._SupplierID; }
            set { this._SupplierID = value; }
        }
        private string _SupplierName;
        public string SupplierName
        {
            get { return this._SupplierName.Trim(); }
            set { this._SupplierName = value; }
        }
        private string _SupplierAddress;
        public string SupplierAddress
        {
            get { return this._SupplierAddress.Trim(); }
            set { this._SupplierAddress = value; }
        }
        private string _PanNo;
        public string PanNo
        {
            get { return this._PanNo.Trim(); }
            set { this._PanNo = value; }
        }
        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }
        private string _Action;

        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private List<ATTInvSupplierContact> _LstSupplierContact = new List<ATTInvSupplierContact>();
        public List<ATTInvSupplierContact> LstSupplierContact
        {
            get { return this._LstSupplierContact; }
            set { this._LstSupplierContact = value; }
        }

        //private List<ATTInvSupplier> _LstSupplier = new List<ATTInvSupplier>();
        //public List<ATTInvSupplier> LstSupplier
        //    {
        //        get { return this._LstSupplier; }
        //        set { this._LstSupplier = value; }
        //    }
        //private DateTime _EntryOn;
        //public DateTime EntryOn
        //{
        //    get { return this._EntryOn.Date; }
        //    set { this._EntryOn = value; }
        //}
        public ATTInvSupplier()
        {

        }
        public ATTInvSupplier CreateDeepCopy()
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, this);
            m.Position = 0;
            ATTInvSupplier obj = (ATTInvSupplier)b.Deserialize(m);
            m.Close();
            m.Dispose();
            return obj;
        }
        public ATTInvSupplier(int supplierID, string supplierName, string supplierAddress, string panNo, string active, string entryBy, string action)
        {
            this.SupplierID = supplierID;
            this.SupplierName = supplierName;
            this.SupplierAddress = supplierAddress;
            this.PanNo = panNo;
            this.Active = active;
            this.EntryBy = entryBy;
            this.Action = action;
        }
    }

  }

