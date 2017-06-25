using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvDeliveryOrder
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


        private string _DeliveryPerson;
        public string DeliveryPerson
        {
            get { return this._DeliveryPerson; }
            set { this._DeliveryPerson = value; }
        }

        private string _DeliveryDate;
        public string DeliveryDate
        {
            get { return this._DeliveryDate; }
            set { this._DeliveryDate = value; }
        }

        private int? _ReceiverID;
        public int? ReceiverID
        {
            get { return this._ReceiverID; }
            set { this._ReceiverID = value; }
        }

        private string _ReceiverName;
        public string ReceiverName
        {
            get { return this._ReceiverName; }
            set { this._ReceiverName = value; }
        }



        private string _ReceivedDate;
        public string ReceivedDate
        {
            get { return this._ReceivedDate; }
            set { this._ReceivedDate = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
     
        private string _InvoiceNo;
        public string InvoiceNo
        {
            get { return this._InvoiceNo; }
            set { this._InvoiceNo = value; }
        }

        public List<ATTInvDeliveryOrderDetail> _lstDeliveryOrderDetail = new List<ATTInvDeliveryOrderDetail>();
        public List<ATTInvDeliveryOrderDetail> lstDeliveryOrderDetail
        {
            get { return this._lstDeliveryOrderDetail; }
            set { this._lstDeliveryOrderDetail = value; }
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

        public ATTInvDeliveryOrder()
        {
        }
    }
}
