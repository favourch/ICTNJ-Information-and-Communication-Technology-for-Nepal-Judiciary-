using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvSrchReturnOrder
    {
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
    }
}
