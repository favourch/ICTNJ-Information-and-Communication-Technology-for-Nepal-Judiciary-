using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvSrchDeliveryOrder
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

        private string _OrderNo = "";
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
    }
}
