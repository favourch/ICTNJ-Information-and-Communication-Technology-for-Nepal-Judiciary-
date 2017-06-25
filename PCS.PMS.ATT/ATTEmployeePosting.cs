using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTEmployeePosting
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }
        
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName; }
            set { this._OrgName = value; }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return this._EmpName; }
            set { this._EmpName = value; }
        }

        private int _DesID;
        public int DesID
        {
            get { return this._DesID; }
            set { this._DesID = value; }
        }

        private string _DesName;
        public string DesName
        {
            get { return this._DesName; }
            set { this._DesName = value; }
        }

   
        private int _PostID;
        public int PostID
        {
            get { return this._PostID; }
            set { this._PostID = value; }
        }

        private string _CreatedDate;
        public string CreatedDate
        {
            get { return this._CreatedDate; }
            set { this._CreatedDate = value; }
        }

        private string _PostName;
        public string PostName
        {
            get { return this._PostName; }
            set { this._PostName = value; }
        }

        private int _PostingTypeID;
        public int PostingTypeID
        {
            get { return this._PostingTypeID; }
            set { this._PostingTypeID = value; }
        }

        private string _PostingTypeName;
        public string PostingTypeName
        {
            get { return this._PostingTypeName; }
            set { this._PostingTypeName = value; }
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

        private string _DecisionDate;
        public string DecisionDate
        {
            get { return this._DecisionDate; }
            set { this._DecisionDate = value; }
        }

        private string _LeaveDate;
        public string LeaveDate
        {
            get { return this._LeaveDate; }
            set { this._LeaveDate = value; }
        }

        private string _JoiningDate;
        public string JoiningDate
        {
            get { return this._JoiningDate; }
            set { this._JoiningDate = value; }
        }

        private int? _EmpSalary;

        public int? EmpSalary
        {
            get { return _EmpSalary; }
            set { _EmpSalary = value; }
        }

        private int? _EmpAllowance;

        public int? EmpAllowance
        {
            get { return _EmpAllowance; }
            set { _EmpAllowance = value; }
        }

        private string _EmpKitaabDartaNo;

        public string EmpKitaabDartaNo
        {
            get { return _EmpKitaabDartaNo; }
            set { _EmpKitaabDartaNo = value; }
        }

        private string _EmpPostingRemarks;

        public string EmpPostingRemarks
        {
            get { return _EmpPostingRemarks; }
            set { _EmpPostingRemarks = value; }
        }

        public string PostNameWithCreationDate
        {
            get { return this.DesName + " (" + this.CreatedDate + ")" + " (" + this.PostID + ")" + " (" + this.FromDate + ")"; }
            //get { return this.PostName + " (" + "111" + ")"; }
        }

        private string _PostingAttachmentContent;

        public string PostingAttachmentContent
        {
            get { return _PostingAttachmentContent; }
            set { _PostingAttachmentContent = value; }
        }

        private byte[] _PostingAttachmentDocs;

        public byte[] PostingAttachmentDocs
        {
            get { return _PostingAttachmentDocs; }
            set { _PostingAttachmentDocs = value; }
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

        public ATTEmployeePosting()
        {
        }

        public ATTEmployeePosting(double empID, int orgID, int desID, string createdDate, int postID, string fromDate,int postingTypeID, string entryBy)
        {
            this.EmpID = empID;
            this.OrgID = orgID;
            this.DesID = desID;
            this.CreatedDate = createdDate;
            this.PostID = postID;
            this.FromDate = fromDate;
            this.PostingTypeID = postingTypeID;
            this.EntryBy = entryBy;
            
        }
        public ATTEmployeePosting(double empID, int orgID, int desID, string createdDate, int postID, string fromDate, int postingTypeID,string orgName,string desName,string postingTypeName, string entryBy)
        {
            this.EmpID = empID;
            this.OrgID = orgID;
            this.DesID = desID;
            this.CreatedDate = createdDate;
            this.PostID = postID;
            this.FromDate = fromDate;
            this.PostingTypeID = postingTypeID;
            this.OrgName = orgName;
            this.DesName = desName;
            this.PostingTypeName = postingTypeName;
            this.EntryBy = entryBy;

        }
    }
}
