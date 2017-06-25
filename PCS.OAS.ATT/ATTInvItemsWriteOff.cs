using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.OAS.ATT
{
  public  class ATTInvItemsWriteOff
    {

        //ORG_ID         NUMBER(3),
        //WRITEOFF_SEQ   NUMBER(10),
        //WRITEOFF_DATE  VARCHAR2(10 BYTE),
        //APP_BY         NUMBER(10),
        //APP_DATE       VARCHAR2(10 BYTE),
        //APP_YES_NO     VARCHAR2(1 BYTE),
        //ENTRY_BY       VARCHAR2(15 BYTE)              NOT NULL,
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }
        private int _WriteOffSEQ ;
        public int WriteOffSEQ
        {
            get { return this._WriteOffSEQ; }
            set { this._WriteOffSEQ = value; }
        }

        private string _WriteoffDate;
        public string WriteoffDate
        {
            get { return this._WriteoffDate; }
            set { this._WriteoffDate = value; }
        }

        private double ? _AppBy;
        public double? AppBy
        {
            get { return this._AppBy; }
            set { this._AppBy = value; }
        }
        private string _AppDate;
        public string AppDate
        {
            get { return this._AppDate; }
            set { this._AppDate = value; }
        }

        private string _AppYesNo;
        public string AppYesNo
        {
            get { return this._AppYesNo; }
            set { this._AppYesNo = value; }
        }
        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }
        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
      private List<ATTInvItemsWriteOffDT> _LstItemsWriteOffDT = new List<ATTInvItemsWriteOffDT>();
      public List<ATTInvItemsWriteOffDT> LstItemsWriteOffDT 
        {
            get { return this._LstItemsWriteOffDT; }
            set { this._LstItemsWriteOffDT = value; }
        }


      public ATTInvItemsWriteOff()
      {
          

      }
      public ATTInvItemsWriteOff(int orgID, int writeOffSEQ, string writeoffDate, int appBy, string appDate, string appYesNo, string entryBy, string action)
        {
            this.OrgID = orgID;
            this.WriteOffSEQ = writeOffSEQ;
            this.WriteoffDate = writeoffDate;
            this.AppBy = appBy;
            this.AppDate = appDate;
            this.AppYesNo = appYesNo;
            this.EntryBy = entryBy;
            this.Action = action;
            
        }

       
    }
}
