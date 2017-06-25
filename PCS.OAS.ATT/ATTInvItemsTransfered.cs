using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTInvItemsTransfered
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }
        private string _OrgName;

        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }
	

        private int _EmpID;

        public int EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }
	
        private int _ItemsCategoryID;

        public int ItemsCategoryID
        {
            get { return _ItemsCategoryID; }
            set { _ItemsCategoryID = value; }
        }
        private string _ItemsCategoryName;

        public string ItemsCategoryName
        {
            get { return _ItemsCategoryName; }
            set { _ItemsCategoryName = value; }
        }
	
        private int _ItemsSubCategoryID;

        public int ItemsSubCategoryID
        {
            get { return _ItemsSubCategoryID; }
            set { _ItemsSubCategoryID = value; }
        }
        private string _ItemsSubCategoryName;

        public string ItemsSubCategoryName
        {
            get { return _ItemsSubCategoryName; }
            set { _ItemsSubCategoryName = value; }
        }
	
        private int _ItemsID;

        public int ItemsID
        {
            get { return _ItemsID; }
            set { _ItemsID = value; }
        }
        private string _ItemsName;

        public string ItemsName
        {
            get { return _ItemsName; }
            set { _ItemsName = value; }
        }
        private int _ItemsTypeID;

        public int ItemsTypeID
        {
            get { return _ItemsTypeID; }
            set { _ItemsTypeID = value; }
        }
        private string _ItemsTypeName;

        public string ItemsTypeName
        {
            get { return _ItemsTypeName; }
            set { _ItemsTypeName = value; }
        }
	
        private int _SeqNo;

        public int SeqNo
        {
            get { return _SeqNo; }
            set { _SeqNo = value; }
        }
        private int _Quantity;

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
	
        private int _TransORG;

        public int TransORG
        {
            get { return _TransORG; }
            set { _TransORG = value; }
        }
        private string _TransfOrgName;

        public string TransfOrgName
        {
            get { return _TransfOrgName; }
            set { _TransfOrgName = value; }
        }
	
        private int _TransSEQ;

        public int TransSEQ
        {
            get { return _TransSEQ; }
            set { _TransSEQ = value; }
        }

        private string _TransDate;

        public string TransDate
        {
            get { return _TransDate; }
            set { _TransDate = value; }
        }
        private int _TransVia;

        public int TransVia
        {
            get { return _TransVia; }
            set { _TransVia = value; }
        }
        private string _DecisionDate;

        public string DecisionDate
        {
            get { return _DecisionDate; }
            set { _DecisionDate = value; }
        }
	
        private int? _TransRecvBy;

        public int? TransRecvBy
        {
            get { return _TransRecvBy; }
            set { _TransRecvBy = value; }
        }
        private string _TransRecvPerson;

        public string TransRecvPerson
        {
            get { return _TransRecvPerson; }
            set { _TransRecvPerson = value; }
        }
	
        private int _TransOrgUnit;

        public int TransOrgUnit
        {
            get { return _TransOrgUnit; }
            set { _TransOrgUnit = value; }
        }
        private int _OrgUnitID;

        public int OrgUnitID
        {
            get { return _OrgUnitID; }
            set { _OrgUnitID = value; }
        }
	
        private int _TransTo;

        public int TransTo
        {
            get { return _TransTo; }
            set { _TransTo = value; }
        }
        private string _TransRecvDate;

        public string TransRecvDate
        {
            get { return _TransRecvDate; }
            set { _TransRecvDate = value; }
        }

        private int? _ReturnBy;

        public int? ReturnBy
        {
            get { return _ReturnBy; }
            set { _ReturnBy = value; }
        }
        private string _ReturnDate;

        public string ReturnDate
        {
            get { return _ReturnDate; }
            set { _ReturnDate = value; }
        }
        private int? _ReturnVia;

        public int? ReturnVia
        {
            get { return _ReturnVia; }
            set { _ReturnVia = value; }
        }
        private int? _ReturnRecvBy;

        public int? ReturnRecvBy
        {
            get { return _ReturnRecvBy; }
            set { _ReturnRecvBy = value; }
        }
        private string _ReturnRecvDate;

        public string ReturnRecvDate
        {
            get { return _ReturnRecvDate; }
            set { _ReturnRecvDate = value; }
        }
        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
        private DateTime _EntryDate;

        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private int _ItemsUnitID;

        public int ItemsUnitID
        {
            get { return _ItemsUnitID; }
            set { _ItemsUnitID = value; }
        }
        private string _ItemsUnitName;

        public string ItemsUnitName
        {
            get { return _ItemsUnitName; }
            set { _ItemsUnitName = value; }
        }
	
        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        public ATTInvItemsTransfered()
        {
        }
	
	
    }
}
