using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTRelatives
    {
        private double _PId;
        public double PId
        {
            get { return this._PId; }
            set { this._PId = value; }
        }

        private double _RelativeId;
        public double RelativeId
        {
            get { return this._RelativeId; }
            set { this._RelativeId = value; }
        }

        private int _RelationTypeId;
        public int RelationTypeId
        {
            get { return this._RelationTypeId; }
            set { this._RelationTypeId = value; }
        }

        private string _RelationTypeName;
        public string RelationTypeName
        {
            get { return _RelationTypeName; }
            set { _RelationTypeName = value; }
        }


        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _Occupation;
        public string Occupation
        {
            get { return this._Occupation; }
            set { this._Occupation = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private ATTPerson _ObjPerson;
        public ATTPerson ObjPerson
        {
            get { return this._ObjPerson; }
            set { this._ObjPerson = value; }
        }

        public ATTRelatives()
        {
        }

        public ATTRelatives(double pId, double relativeId, int relationTypeId, string active)
        {
            this.PId = pId;
            this.RelativeId = relativeId;
            this.Active = active;
            this.RelationTypeId = relationTypeId;
        }
    }
}
