using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTOrders
    {
        private int _OrdersID;
        public int OrdersID
        {
            get { return _OrdersID; }
            set { _OrdersID = value; }
        }

        private string _OrdersName;
        public string OrdersName
        {
            get { return _OrdersName; }
            set { _OrdersName = value; }
        }
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        public ATTOrders(int ordersID, string ordersName, string active)
        {
            this.OrdersID = ordersID;
            this.OrdersName = ordersName;
            this.Active = active;
        }
    }
}
