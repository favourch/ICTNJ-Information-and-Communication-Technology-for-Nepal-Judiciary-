using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvPurchaseOrder
    {

        private int? _OrgID;
        public int? OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int? _UnitID;
        public int? UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName; }
            set { this._UnitName = value; }
        }

        private int? _SectionID;
        public int? SectionID
        {
            get { return this._SectionID; }
            set { this._SectionID = value; }
        }

        private string _SectionName;
        public string SectionName
        {
            get { return this._SectionName; }
            set { this._SectionName = value; }
        }


        private string _OrderNo;
        public string OrderNo
        {
            get { return this._OrderNo; }
            set { this._OrderNo = value; }
        }

        private string _OrderDate;
        public string OrderDate
        {
            get { return this._OrderDate; }
            set { this._OrderDate = value; }
        }

        private int? _SupplierID;
        public int? SupplierID
        {
            get { return this._SupplierID; }
            set { this._SupplierID = value; }
        }

        private string _SupplierName;
        public string SupplierName
        {
            get { return this._SupplierName; }
            set { this._SupplierName = value; }
        }

        private int? _RecBy = null;
        public int? RecBy
        {
            get { return this._RecBy; }
            set { this._RecBy = value; }
        }

        private string _RecDate = "";
        public string RecDate
        {
            get { return this._RecDate.Trim(); }
            set { this._RecDate = value; }
        }

        private string _RecYesNo = "";
        public string RecYesNo
        {
            get { return this._RecYesNo.Trim(); }
            set { this._RecYesNo = value; }
        }

        private int? _AppBy = null;
        public int? AppBy
        {
            get { return this._AppBy; }
            set { this._AppBy = value; }
        }

        private string _AppDate = "";
        public string AppDate
        {
            get { return this._AppDate.Trim(); }
            set { this._AppDate = value; }
        }

        private string _AppYesNo = "";
        public string AppYesNo
        {
            get { return this._AppYesNo.Trim(); }
            set { this._AppYesNo = value; }
        }

        private string _Action = "";
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private int? _Type;
        public int? Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }


        public List<ATTInvPurchaseOrderDetail> _lstPurchaseOrderDetail = new List<ATTInvPurchaseOrderDetail>();
        public List<ATTInvPurchaseOrderDetail> lstPurchaseOrderDetail
        {
            get { return this._lstPurchaseOrderDetail; }
            set { this._lstPurchaseOrderDetail = value;}
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

        public ATTInvPurchaseOrder()
        {
        }

     
    }
}
