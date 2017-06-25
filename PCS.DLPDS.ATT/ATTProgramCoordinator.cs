using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
    public class ATTProgramCoordinator
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _ProgramID;
        public int ProgramID
        {
            get { return _ProgramID; }
            set { _ProgramID = value; }
        }

        private int _ProgramCoordinatorID;
        public int ProgramCoordinatorID
        {
            get { return _ProgramCoordinatorID; }
            set { _ProgramCoordinatorID = value; }
        }

        private double _PID;
        public double PID
        {
            get { return _PID; }
            set { _PID = value; }
        }

        private int _CoordinatorTypeID;
        public int CoordinatorTypeID
        {
            get { return _CoordinatorTypeID; }
            set { _CoordinatorTypeID = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private string  _CoordinatorName;
        public string  CoordinatorName
        {
            get { return _CoordinatorName; }
            set { _CoordinatorName = value; }
        }

        private string _CoordinatorType;
        public string CoordinatorType
        {
            get { return _CoordinatorType; }
            set { _CoordinatorType = value; }
        }
	        
	
	

        public ATTProgramCoordinator()
        { }


        public ATTProgramCoordinator(int orgID, int programID, int prgCoordinatorID,string coordinatorName, double pID, int prgCoordinatorTypeID,string coordinatorType, string action)
        {
            this.OrgID = orgID;
            this.ProgramID = programID;
            this.ProgramCoordinatorID = prgCoordinatorID;
            this.PID = pID;
            this.CoordinatorName = coordinatorName;
            this.CoordinatorTypeID = prgCoordinatorTypeID;
            this.CoordinatorType = coordinatorType;
            this.Action = action;
        }
	
	
        
    }
}
