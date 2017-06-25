using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.DLPDS.ATT
{
   public class ATTParticipant
    {
        private int _OrgID;

        public int OrgID
        {
            get { return _OrgID; }
            set { _OrgID = value; }
        }

        private int _ProgramID;
        public int ProgramID
        {
            get { return _ProgramID; }
            set { _ProgramID = value; }
        }

        private double _PID;
        public double PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
       
       private string _ParticipantName;
        public string ParticipantName
        {
            get { return _ParticipantName; }
            set { _ParticipantName = value; }
        }
	

        private string  _JoiningDate;
        public string  JoiningDate
        {
            get { return _JoiningDate; }
            set { _JoiningDate = value; }
        }

        private ATTParticipantPost _ObjParticipantPost;
        public ATTParticipantPost ObjParticipantPost
        {
            get { return _ObjParticipantPost; }
            set { _ObjParticipantPost = value; }
        }


        private List<ATTParticipantPost> _LstParticipantPost = new List<ATTParticipantPost>();
        public List<ATTParticipantPost> LstParticipantPost
        {
            get { return this._LstParticipantPost; }
            set { this._LstParticipantPost = value; }
        }

        private ATTPerson _ObjPerson;
       public ATTPerson ObjPerson
        {
            get { return _ObjPerson; }
            set { _ObjPerson = value; }
        }

        private string _Flag;

        public string  Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
	
		


       public ATTParticipant(int orgID, int programID, double personID, string participantName, string joiningDate,string flag)
       {
           this.OrgID = orgID;
           this.ProgramID = programID;
           this.PID = personID;
           this.ParticipantName = participantName;
           this.JoiningDate = joiningDate;
           this.Flag = flag;
       }

       public ATTParticipant(int personID, string participantName)
       {
           
           this.PID = personID;
           this.ParticipantName = participantName;
       }
    }

 
}
