using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
    public class ATTRelationType
    {
        private int _RelationTypeID;
        public int RelationTypeID
        {
            get { return this._RelationTypeID; }
            set { this._RelationTypeID = value; }
        }

        private string _RelationTypeName;
        public string RelationTypeName
        {
            get { return this._RelationTypeName; }
            set { this._RelationTypeName = value; }
        }

        private int? _RelationTypeCardinality;
        public int? RelationTypeCardinality
        {
            get { return this._RelationTypeCardinality; }
            set { this._RelationTypeCardinality = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        public ATTRelationType()
        {
        }

        public ATTRelationType(int relationTypeID, string relationTypeName)
        {
            this.RelationTypeID = relationTypeID;
            this.RelationTypeName = relationTypeName;
        }
    }
}
