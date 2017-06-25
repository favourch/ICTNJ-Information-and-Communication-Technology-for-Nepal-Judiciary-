using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTPersonAddress
    {
        private double _PId;
        public double PId
        {
            get { return this._PId; }
            set { this._PId = value; }
        }

        public string _AdTypeId;
        public string AdTypeId
        {
            get { return this._AdTypeId; }
            set { this._AdTypeId = value; }
        }

        public string _AddressType;
        public string AddressType
        {
            get { return this._AddressType; }
            set { this._AddressType = value; }
        }

        private string _NepDistrictName;
        public string NepDistrictName
        {
            get { return this._NepDistrictName; }
            set { this._NepDistrictName = value; }
        }

        private string _NepVDCName;
        public string NepVDCName
        {
            get { return this._NepVDCName; }
            set { this._NepVDCName = value; }
        }

        private int? _Ward;
        public int? Ward
        {
            get { return this._Ward; }
            set { this._Ward = value; }
        }

        private string _Tole;
        public string Tole
        {
            get { return this._Tole; }
            set { this._Tole = value; }
        }

        private int? _District;
        public int? District
        {
            get { return this._District; }
            set { this._District = value; }
        }

        private int? _VDC;
        public int? VDC
        {
            get { return this._VDC; }
            set { this._VDC = value; }
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
        
        private int _AdSNo;
        public int AdSNo
        {
            get { return this._AdSNo; }
            set { this._AdSNo = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value.Trim(); }
        }

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return this._EntryDate; }
            set { this._EntryDate = value; }
        }

        public ATTPersonAddress()
        {
        }

        public ATTPersonAddress(double pId, string adTypeId, int adSNo, int? district, int? vdc, int? ward, string tole, string active, string entryBy, DateTime entryDate)
        {
            this.PId = pId;
            this.AdTypeId = adTypeId;
            this.AdSNo = adSNo;
            this.District = district;
            this.VDC = vdc;
            this.Ward = ward;
            this.Tole = tole;
            this.Active = active;
            this.EntryBy = entryBy;
            this.EntryDate = entryDate;
        }

        public ATTPersonAddress(double pId, string adTypeId, int adSNo)
        {
            this.PId = pId;
            this.AdTypeId = adTypeId;
            this.AdSNo = adSNo;
        }

    }
}
