using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTOrganizationDesignation
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

        private int? _ParentOrg;
        public int? ParentOrg
        {
            get { return this._ParentOrg; }
            set { this._ParentOrg = value; }
        }

        private int? _ParentDes;
        public int? ParentDes
        {
            get {return this._ParentDes;}
            set {this._ParentDes=value;}
        }

        private int _TotalSeats;
        public int TotalSeats
        {
            get {return this._TotalSeats;}
            set {this._TotalSeats=value;}
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

        private string _DesType;
        public string DesType
        {
            get { return this._DesType; }
            set { this._DesType = value; }
        }

        private int _SewaID;
        public int SewaID
        {
            get { return this._SewaID; }
            set { this._SewaID = value; }
        }

        private int _SamuhaID;
        public int SamuhaID
        {
            get { return this._SamuhaID; }
            set { this._SamuhaID = value; }
        }

        private int _UpaSamuhaID;
        public int UpaSamuhaID
        {
            get { return this._UpaSamuhaID; }
            set { this._UpaSamuhaID = value; }
        }

        private int _DesgLevelID;
        public int DesgLevelID
        {
            get { return this._DesgLevelID; }
            set { this._DesgLevelID = value; }
        }

        private string _SewaName;
        public string SewaName
        {
            get { return this._SewaName; }
            set { this._SewaName = value; }
        }

        private string _SamuhaName;
        public string SamuhaName
        {
            get { return this._SamuhaName; }
            set { this._SamuhaName = value; }
        }

        private string _UpaSamuhaName;
        public string UpaSamuhaName
        {
            get { return this._UpaSamuhaName; }
            set { this._UpaSamuhaName = value; }
        }

        private string _DesgLevelName;
        public string DesgLevelName
        {
            get { return this._DesgLevelName; }
            set { this._DesgLevelName = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private List<ATTPost> _LstPosts = new List<ATTPost>();
        public List<ATTPost> LstPosts
        {
            get { return this._LstPosts; }
            set { this._LstPosts = value; }
        }

        public ATTOrganizationDesignation()
        {
        }

        public ATTOrganizationDesignation(int orgID,int desID,int totalSeats,int sewaID,int samuhaID,int upaSamuhaID,int desgLevelID)
        {
            this.OrgID=orgID;
            this.DesID=desID;
            this.TotalSeats=totalSeats;
            this.SewaID = sewaID;
            this.SamuhaID = samuhaID;
            this.UpaSamuhaID = upaSamuhaID;
            this.DesgLevelID = desgLevelID;
        }
        public ATTOrganizationDesignation(int orgID, int desID, int totalSeats, int sewaID, int samuhaID, int upaSamuhaID, int desgLevelID, string desName)
        {
            this.OrgID = orgID;
            this.DesID = desID;
            this.TotalSeats = totalSeats;
            this.SewaID = sewaID;
            this.SamuhaID = samuhaID;
            this.UpaSamuhaID = upaSamuhaID;
            this.DesgLevelID = desgLevelID;
            this.DesName = desName;
        }
    }
}
