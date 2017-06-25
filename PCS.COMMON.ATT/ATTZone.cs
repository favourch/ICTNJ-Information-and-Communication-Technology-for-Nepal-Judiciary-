using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTZone
    {
        private int _ZoneId;
        public int ZoneId
        {
            get { return this._ZoneId; }
            set { this._ZoneId = value; }
        }

        private string _ZoneName;
        public string ZoneName
        {
            get { return this._ZoneName; }
            set { this._ZoneName = value; }
        }

        public ATTZone()
        {
        }

        public ATTZone(int zoneId, string zoneName)
        {
            this.ZoneId = zoneId;
            this.ZoneName = zoneName;
        }
    }
}
