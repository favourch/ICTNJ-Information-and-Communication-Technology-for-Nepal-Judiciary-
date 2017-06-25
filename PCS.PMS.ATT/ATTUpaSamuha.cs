using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    [Serializable]
    public class ATTUpaSamuha
    {
        private int _SewaID;
        public int SewaID
        {
            get { return this._SewaID; }
            set { this._SewaID = value; }
        }

        private int _SamuhaID;
        public int SamuhaID
        {
            get { return this._SamuhaID; }
            set { this._SamuhaID = value; }
        }

        private int _UpaSamuhaID;
        public int UpaSamuhaID
        {
            get { return this._UpaSamuhaID; }
            set { this._UpaSamuhaID = value; }
        }

        private string _UpaSamuhaName;
        public string UpaSamuhaName
        {
            get { return this._UpaSamuhaName.Trim(); }
            set { this._UpaSamuhaName = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn; }
            set { this._EntryOn = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTUpaSamuha()
        {
        }

        public ATTUpaSamuha(int sewaID, int samuhaID,int upaSamuhaID, string upaSamuhaName, string entryBy, DateTime entryOn,string action)
        {
            this.SewaID = sewaID;
            this.SamuhaID = samuhaID;
            this.UpaSamuhaID = upaSamuhaID;
            this.UpaSamuhaName = upaSamuhaName;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
            this.Action = action;
        }
    }
}
