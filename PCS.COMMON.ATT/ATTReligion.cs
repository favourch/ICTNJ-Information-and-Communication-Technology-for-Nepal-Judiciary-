using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTReligion
    {
        private int _ReligionId;
        public int ReligionId
        {
            get { return this._ReligionId; }
            set { this._ReligionId = value; }
        }

        private string _ReligionNepName;
        public string ReligionNepName
        {
            get { return this._ReligionNepName.Trim(); }
            set { this._ReligionNepName = value; }
        }

        private string _ReligionEngName;
        public string ReligionEngName
        {
            get { return this._ReligionEngName.Trim(); }
            set { this._ReligionEngName = value; }
        }

        public ATTReligion()
        {
        }

        public ATTReligion(int religionId, string religionNepName, string religionEngName)
        {
            this.ReligionId = religionId;
            this.ReligionNepName = religionNepName;
            this.ReligionEngName = religionEngName;
        }
    }
}
