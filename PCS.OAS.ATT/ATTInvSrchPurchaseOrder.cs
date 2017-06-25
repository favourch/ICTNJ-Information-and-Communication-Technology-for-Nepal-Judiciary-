using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvSrchPurchaseOrder
    {
      
        private int? _UnitID;
        public int? UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private int? _SectionID;
        public int? SectionID
        {
            get { return this._SectionID; }
            set { this._SectionID = value; }
        }


        private string _OrderNo ="";
        public string OrderNo
        {
            get { return this._OrderNo; }
            set { this._OrderNo = value; }
        }

        private string _OrderDate ="";
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
    }
}
