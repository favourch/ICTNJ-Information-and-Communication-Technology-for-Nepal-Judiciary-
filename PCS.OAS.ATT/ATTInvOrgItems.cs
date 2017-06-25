using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvOrgItems
    {
        private int _OrgID;
        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }        

        private int _ItemsCategoryID;
        public int ItemsCategoryID
        {
            get { return _ItemsCategoryID; }
            set { _ItemsCategoryID = value; }
        }

        private int _ItemsSubCategoryID;
        public int ItemsSubCategoryID
        {
            get { return _ItemsSubCategoryID; }
            set { _ItemsSubCategoryID = value; }
        }

        private int _ItemsID;
        public int ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }

        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private string _PanNo;
        public string PanNo
        {
            get { return _PanNo; }
            set { _PanNo = value; }
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

     

        public ATTInvOrgItems()
        { }
        
    }
}
