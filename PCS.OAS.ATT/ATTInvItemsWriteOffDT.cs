using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.OAS.ATT
{

  //ORG_ID                 NUMBER(3),
  //WRITEOFF_SEQ           NUMBER(10),
  //ITEMS_CATEGORY_ID      NUMBER(2),
  //ITEMS_SUB_CATEGORY_ID  NUMBER(3),
  //ITEMS_ID               NUMBER(4),
  //SEQ_NO                 NUMBER(5),
  //REMARKS                VARCHAR2(300 CHAR)

  public class ATTInvItemsWriteOffDT
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _OrgName;

        public string OrgName
        {
            get { return _OrgName; }
            set { _OrgName = value; }
        }
	
        private int _WriteOffSEQ;
        public int WriteOffSEQ
        {
            get { return this._WriteOffSEQ; }
            set { this._WriteOffSEQ = value; }
        }
        private string _WriteOffDate;

        public string WriteOffDate
        {
            get { return _WriteOffDate; }
            set { _WriteOffDate = value; }
        }
        private double _AppBy;

        public double AppBy
        {
            get { return _AppBy; }
            set { _AppBy = value; }
        }
        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _MiddleName;

        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _AppDate;

        public string AppDate
        {
            get { return _AppDate; }
            set { _AppDate = value; }
        }
        private string _AppYesNo;

        public string AppYesNo
        {
            get { return _AppYesNo; }
            set { _AppYesNo = value; }
        }
        private string _ItemsCategoryName;

        public string ItemsCategoryName
        {
            get { return _ItemsCategoryName; }
            set { _ItemsCategoryName = value; }
        }
        private string _ItemsSubCategoryName;

        public string ItemsSubCategoryName
        {
            get { return _ItemsSubCategoryName; }
            set { _ItemsSubCategoryName = value; }
        }
        private string _ItemsName;

        public string ItemsName
        {
            get { return _ItemsName; }
            set { _ItemsName = value; }
        }
        private string _JI_KHA_PA_NO;

        public string JI_KHA_PA_NO
        {
            get { return _JI_KHA_PA_NO; }
            set { _JI_KHA_PA_NO = value; }
        }
        private int _UnitPrice;

        public int UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        private string _ItemsStatus;

        public string ItemsStatus
        {
            get { return _ItemsStatus; }
            set { _ItemsStatus = value; }
        }
      private int _ItemsCategoryID;
      public int ItemsCategoryID
      {
          get { return this._ItemsCategoryID;}
          set { this._ItemsCategoryID = value; }
      } 
      private int _ItemsSubCategoryID;
      public int ItemsSubCategoryID
      {
          get { return this._ItemsSubCategoryID;}
          set { this._ItemsSubCategoryID = value; }
      }
      private int _ItemsID;
      public int ItemsID 
      {
          get { return this._ItemsID; }
          set { this._ItemsID = value; }
      }


      private int? _SeqNo;
      public int? SeqNo
        {
            get { return this._SeqNo; }
            set { this._SeqNo = value; }
        }
       private string _Remarks;
       public string Remarks
        {
            get { return this._Remarks; }
            set { this._Remarks = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
      public ATTInvItemsWriteOffDT(int orgID, int writeOffSEQ, int itemsCategoryID, int itemsSubCategoryID, int itemsID, int seqNo, string remarks, string action)
      {
          this.OrgID = orgID;
          this.WriteOffSEQ = writeOffSEQ;
          this.ItemsCategoryID = itemsCategoryID;
          this.ItemsSubCategoryID = itemsSubCategoryID;
          this.ItemsID = itemsID;
          this.SeqNo = seqNo;
          this.Remarks = remarks;
          this.Action = action;
      }
      public ATTInvItemsWriteOffDT()
      {
         
      }

        



    }
}
