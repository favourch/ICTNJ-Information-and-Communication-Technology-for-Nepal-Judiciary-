using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTWard
    {
                private int _DistCode;
        public int DistCode
        {
            get { return this._DistCode; }
            set { this._DistCode = value; }
        }

        private int _VdcCode;
        public int VdcCode
        {
            get { return this._VdcCode; }
            set { this._VdcCode = value; }
        }

        private int _Ward;
        public int Ward
        {
            get { return this._Ward; }
            set { this._Ward = value; }
        }

        public ATTWard()
        {
        }

        public ATTWard(int distCode, int vdcCode, int ward)
        {
            this.DistCode = distCode;
            this.VdcCode = vdcCode;
            this.Ward = ward;
        }
    }
}
