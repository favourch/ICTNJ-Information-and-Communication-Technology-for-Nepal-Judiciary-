using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    [Serializable]
    public class ATTSamuha
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

        private string _SamuhaName;
        public string SamuhaName
        {
            get { return this._SamuhaName.Trim(); }
            set { this._SamuhaName = value; }
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

        private List<ATTUpaSamuha> _LstUpaSamuha = new List<ATTUpaSamuha>();
        public List<ATTUpaSamuha> LstUpaSamuha
        {
            get { return this._LstUpaSamuha; }
            set { this._LstUpaSamuha = value; }
        }

        public ATTSamuha()
        {
        }

        public ATTSamuha(int sewaID, int samuhaID, string samuhaName, string entryBy, DateTime entryOn,string action)
        {
            this.SewaID = sewaID;
            this.SamuhaID = samuhaID;
            this.SamuhaName = samuhaName;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
            this.Action = action;
        }
    }
}
