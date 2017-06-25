using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTDistrict
    {
        private int _DistCode;
        public int DistCode
        {
            get { return _DistCode; }
            set { _DistCode = value; }
        }

        private string _NepDistName;
        public string NepDistName
        {
            get { return _NepDistName; }
            set { _NepDistName = value; }
        }

        private string _EngDistName;
        public string EngDistName
        {
            get { return _EngDistName; }
            set { _EngDistName = value; }
        }

        private string _DistUCode;
        public string DistUCode
        {
            get { return _DistUCode; }
            set { _DistUCode = value; }
        }

        private int _ZoneId;
        public int ZoneId
        {
            get { return this._ZoneId; }
            set { this._ZoneId = value; }
        }

        private List<ATTVDC> _LstVDCs = new List<ATTVDC>();
        public List<ATTVDC> LstVDCs
        {
            get { return this._LstVDCs; }
            set { this._LstVDCs = value; }
        }

        public ATTDistrict()
        {
        }

        public ATTDistrict(int distCode, string nepDistName, string engDistName,int zoneId)
        {
            this.DistCode= distCode;
            this.NepDistName = nepDistName;
            this.EngDistName = engDistName;
            this.ZoneId = zoneId;
        }

        public ATTDistrict(int distCode, string nepDistName, string engDistName,string distUCode, int zoneId)
        {
            this.DistCode = distCode;
            this.NepDistName = nepDistName;
            this.EngDistName = engDistName;
            this.DistUCode = distUCode;
            this.ZoneId = zoneId;
        }

    }
}
