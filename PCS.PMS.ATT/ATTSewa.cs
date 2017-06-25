using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PCS.PMS.ATT
{
    [Serializable]
    public class ATTSewa
    {
        private int _SewaID;
        public int SewaID
        {
            get { return this._SewaID; }
            set { this._SewaID = value; }
        }

        private string _SewaName;
        public string SewaName
        {
            get { return this._SewaName.Trim(); }
            set { this._SewaName = value; }
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

        private List<ATTSamuha> _LstSamuha = new List<ATTSamuha>();
        public List<ATTSamuha> LstSamuha
        {
            get { return this._LstSamuha; }
            set { this._LstSamuha = value; }
        }

        public ATTSewa()
        {
        }

        public ATTSewa CreateDeepCopy()
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, this);
            m.Position = 0;
            ATTSewa obj = (ATTSewa)b.Deserialize(m);
            m.Close();
            m.Dispose();
            return obj;
        }

        public ATTSewa(int sewaID, string sewaName, string entryBy, DateTime entryOn, string action)
        {
            this.SewaID = sewaID;
            this.SewaName = sewaName;
            this.EntryBy = entryBy;
            this.EntryOn = entryOn;
            this.Action = action;
        }
    }
}
