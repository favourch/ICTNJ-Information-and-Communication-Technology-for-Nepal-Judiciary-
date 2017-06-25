using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTVDC
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

        private string _VdcNepName;
        public string VdcNepName
        {
            get { return this._VdcNepName; }
            set { this._VdcNepName = value; }
        }

        private string _VdcEngName;
        public string VdcEngName
        {
            get { return this._VdcEngName; }
            set { this._VdcEngName = value; }
        }

        private string _VdcUCode;
        public string VdcUCode
        {
            get { return this._VdcUCode; }
            set { this._VdcUCode = value; }
        }


        private int _VdcType;
        public int VdcType
        {
            get { return this._VdcType; }
            set { this._VdcType = value; }
        }

        private List<ATTWard> _LstWards = new List<ATTWard>();
        public List<ATTWard> LstWards
        {
            get { return this._LstWards; }
            set { this._LstWards = value; }
        }


        public ATTVDC()
        {
        }

        public ATTVDC(int distCode,int vdcCode,string vdcNepName,string vdcEngName,int vdcType)
        {
            this.DistCode = distCode;
            this.VdcCode = vdcCode;
            this.VdcNepName = vdcNepName;
            this.VdcEngName = vdcEngName;
            this.VdcType = vdcType;
        }

        public ATTVDC(int distCode, int vdcCode, string vdcNepName, string vdcEngName,string vdcUCode, int vdcType)
        {
            this.DistCode = distCode;
            this.VdcCode = vdcCode;
            this.VdcNepName = vdcNepName;
            this.VdcEngName = vdcEngName;
            this.VdcUCode = vdcUCode;
            this.VdcType = vdcType;
        }

    }
}
