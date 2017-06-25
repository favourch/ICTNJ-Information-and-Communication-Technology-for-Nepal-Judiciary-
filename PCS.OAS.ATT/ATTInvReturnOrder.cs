using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvReturnOrder
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

        private string _OrderNo;
        public string OrderNo
        {
            get { return this._OrderNo; }
            set { this._OrderNo = value; }
        }

        private int? _DeliverySeq = null;
        public int? DeliverySeq
        {
            get { return this._DeliverySeq; }
            set { this._DeliverySeq = value; }
        }

        private int? _ReturnSeq = null;
        public int? ReturnSeq
        {
            get { return this._ReturnSeq; }
            set { this._ReturnSeq = value; }
        }

        private string _ReturnDate;
        public string ReturnDate
        {
            get { return this._ReturnDate; }
            set { this._ReturnDate = value; }
        }

        private string _ReturnRemarks;
        public string ReturnRemarks
        {
            get { return this._ReturnRemarks; }
            set { this._ReturnRemarks = value; }
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

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private List<ATTInvReturnOrderDetail> _LstReturnOrderDetail = new List<ATTInvReturnOrderDetail>();
        public List<ATTInvReturnOrderDetail> LstReturnOrderDetail
        {
            get { return _LstReturnOrderDetail; }
            set { _LstReturnOrderDetail = value; }
        }

        public ATTInvReturnOrder()
        {
        }

     
    }

}
