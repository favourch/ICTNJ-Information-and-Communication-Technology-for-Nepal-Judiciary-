using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPost
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _DesID;
        public int DesID
        {
            get { return this._DesID; }
            set { this._DesID = value; }
        }

        private string _CreatedDate;
        public string CreatedDate
        {
            get { return this._CreatedDate; }
            set { this._CreatedDate = value; }
        }


        private int _PostID;
        public int PostID
        {
            get { return this._PostID; }
            set { this._PostID = value; }
        }

        private string _PostName;
        public string PostName
        {
            get { return this._PostName; }
            set { this._PostName = value; }
        }

        public string RDPostNameWithCreationDate
        {
            get { return this.PostName + " (" + this.CreatedDate + ")"; }
            //get { return this.PostName + " (" + "111" + ")"; }
        }

        public string RDPostIDWithCreationDate
        {
            get { return this.PostID + "/" + this.CreatedDate; }
        }

        private string _Occupied;
        public string Occupied
        {
            get { return this._Occupied; }
            set { this._Occupied = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }

        private string _DesName;
        public string DesName
        {
            get { return this._DesName; }
            set { this._DesName = value; }
        }

        public bool RDUnOccupiedPost
        {
            /* "NO"=Not occupied in the past nor has been occupied now. Returns true.
             * "PO"=Previously occupied but not been occupied now. Returns false.
             * "CO"= Currently occupied. Returns false.
            */

            get { return (this.Occupied == "NO" ? true : false); }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        public ATTPost()
        {
        }

        public ATTPost(int orgID,int desID,string createdDate, int postID, string postName, string occupied)
        {
            this.OrgID = orgID;
            this.DesID = desID;
            this.CreatedDate = createdDate;
            this.PostID = postID;
            this.PostName = postName;
            this.Occupied = occupied;
        }

       
    }
}
