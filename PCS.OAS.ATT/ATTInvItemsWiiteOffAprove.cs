using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace PCS.OAS.ATT
{
 public class ATTInvItemsWiiteOffAprove
    {


     //org_id, writeoff_seq, writeoff_date, app_by,app_date, app_yes_no, entry_by, entry_date
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }
        private int _WriteOffSEQ;
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

        private int? _AppBy;
        public int? AppBy
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
    }
}
