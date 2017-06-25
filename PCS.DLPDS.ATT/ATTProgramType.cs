using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTProgramType
    {
        private int _ProgramTypeID;
        public int ProgramTypeID
        {
            get { return this._ProgramTypeID; }
            set { this._ProgramTypeID = value; }
        }

        private string _ProgramTypeName;
        public string ProgramTypeName
        {
            get { return this._ProgramTypeName; }
            set { this._ProgramTypeName = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTProgramType(int programTypeID, string programTypeName ,string action)
        {
            this.ProgramTypeID = programTypeID;
            this.ProgramTypeName = programTypeName;
            this.Action = action;
        }
    }
}
