using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.DLPDS.ATT
{
    public class ATTParticipantPost
    {
        private double _PID;
        public double PID
        {
            get { return this._PID; }
            set { this._PID = value; }
        }

        private int _PostID;
        public int PostID
        {
            get { return this._PostID; }
            set { this._PostID = value; }
        }

        private int _LevelID;
        public int LevelID
        {
            get { return this._LevelID; }
            set { this._LevelID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate; }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate; }
            set { this._ToDate = value; }
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

        private ATTParticipant _ObjParticipant;
        public ATTParticipant ObjParticipant
        {
            get { return this._ObjParticipant; }
            set { this._ObjParticipant = value; }
        }

        public ATTParticipantPost(double pId, int postId, int levelId, string fromDate)
        {
            this.PID = pId;
            this.PostID = postId;
            this.LevelID = levelId;
            this.FromDate = fromDate;
        }

        public ATTParticipantPost(double pId, int postId, int levelId, string fromDate, string toDate)
        {
            this.PID = pId;
            this.PostID = postId;
            this.LevelID = levelId;
            this.FromDate = fromDate;
            this.ToDate = toDate;
        }

    }
}
