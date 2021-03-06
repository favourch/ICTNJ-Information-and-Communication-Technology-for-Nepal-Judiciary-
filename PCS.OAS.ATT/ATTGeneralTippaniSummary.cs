using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTGeneralTippaniSummary : ATTGeneralTippaniDetail
    {
        #region common atribute for employee
        private string _EmpName;
        public string EmpName
        {
            get { return this._EmpName.Trim(); }
            set { this._EmpName = value; }
        }

        private string _OrgName;
        public string OrgName
        {
            get { return this._OrgName.Trim(); }
            set { this._OrgName = value; }
        }

        private string _DesName;
        public string DesName
        {
            get { return this._DesName.Trim(); }
            set { this._DesName = value; }
        }

        private string _Note;
        public string Note
        {
            get { return this._Note.Trim(); }
            set { this._Note = value; }
        }
        #endregion

        #region extra attribute for leave
        private string _LeaveType;
        public string LeaveType
        {
            get { return this._LeaveType.Trim(); }
            set { this._LeaveType = value; }
        }

        public string RDRecYesNo
        {
            get
            {
                if (this.RecYesNo == "Y")
                    return "सिफारिस गर्छु";
                else
                    return "सिफारिस गर्दिन";
            }
        }

        public string RDAppYesNo
        {
            get
            {
                if (this.AppYesNo == "Y")
                    return "प्रमाणित गर्छु";
                else
                    return "प्रमाणित गर्दिन";
            }
        }

        public string RDApplicationDate
        {
            get
            {
                string s = "";
                if (this.ApplicationDate != "")
                    s = "अ. " + s + this.ApplicationDate;

                if (this.RecDate != "")
                    s = s + "<br>" + "सि. " + this.RecDate;
                
                if (this.AppDate != "")
                    s = s + "<br>" + "प्र. " + this.AppDate;
                
                return s;
            }
        }

        public string RDFromDate
        {
            get
            {
                string s = "";
                if (this.ReqFromDate != "")
                    s = "अ. " + s + this.ReqFromDate;

                if (this.RecFromDate != "")
                    s = s + "<br>" + "सि. " + this.RecFromDate;

                if (this.AppFromDate != "")
                    s = s + "<br>" + "प्र. " + this.AppFromDate;

                return s;
            }
        }

        public string RDToDate
        {
            get
            {
                string s = "";
                if (this.ReqToDate != "")
                    s = "अ. " + s + this.ReqToDate;

                if (this.RecToDate != "")
                    s = s + "<br>" + "सि. " + this.RecToDate;

                if (this.AppToDate != "")
                    s = s + "<br>" + "प्र. " + this.AppToDate;

                return s;
            }
        }

        public string RDTotal
        {
            get
            {
                string s = "";
                if (this.ReqNoOfDays != 0)
                    s = "अ. " + s + this.ReqNoOfDays.ToString();

                if (this.RecNoOfDays != 0)
                    s = s + "<br>" + "सि. " + this.RecNoOfDays.ToString();

                if (this.AppNoOfDays != 0)
                    s = s + "<br>" + "प्र. " + this.AppNoOfDays.ToString(); ;

                return s;
            }
        }

        public string RDLeaveStatus
        {
            get
            {
                string s = "";
                if (this.RecYesNo != "")
                {
                    if (this.RecYesNo == "Y")
                        s = s + "<br>" + "सिफारिस गरेको छ";
                    else
                        s = s + "<br>" + "सिफारिस गरेको छैन्";
                }

                if (this.AppYesNo != "")
                {
                    if (this.AppYesNo == "Y")
                        s = s + "<br>" + "प्रमाणित गरेको छ";
                    else
                        s = s + "<br>" + "प्रमाणित गरेको छैन्";
                }

                return s;
            }
        }

        public string _OldFromDate;
        public string OldFromDate
        {
            get { return this._OldFromDate.Trim(); }
            set { this._OldFromDate = value; }
        }

        public string _OldToDate;
        public string OldToDate
        {
            get { return this._OldToDate.Trim(); }
            set { this._OldToDate = value; }
        }

        #endregion

        #region extra attribute for visit
        private string _VisitCountryName;
        public string VisitCountryName
        {
            get { return this._VisitCountryName.Trim(); }
            set { this._VisitCountryName = value; }
        }
        #endregion

        #region extra attribute for posting
        private string _PostOrgName;
        public string PostOrgName
        {
            get { return this._PostOrgName.Trim(); }
            set { this._PostOrgName = value; }
        }

        private string _PostDesName;
        public string PostDesName
        {
            get { return this._PostDesName.Trim(); }
            set { this._PostDesName = value; }
        }

        private string _PostName;
        public string PostName
        {
            get { return this._PostName.Trim(); }
            set { this._PostName = value; }
        }

        private string _PostingTypeName;
        public string PostingTypeName
        {
            get { return this._PostingTypeName.Trim(); }
            set { this._PostingTypeName = value; }
        }
        #endregion

        #region general attribute
        private int _ProcessStatus;
        public int ProcessStatus
        {
            get { return this._ProcessStatus; }
            set { this._ProcessStatus = value; }
        }
        #endregion

        #region extra attribute for training
        private string _TrnInstitutionName;
        public string TrnInstitutionName
        {
            get { return this._TrnInstitutionName.Trim(); }
            set { this._TrnInstitutionName = value; }
        }
        #endregion

        #region extra attribute for deputation
        private string _DepToOrgName;
        public string DepToOrgName
        {
            get { return this._DepToOrgName.Trim(); }
            set { this._DepToOrgName = value; }
        }
        #endregion

        #region extra attribute for committee
        private string _CommitteeOrgName;
        public string CommitteeOrgName
        {
            get { return this._CommitteeOrgName; }
            set { this._CommitteeOrgName = value; }
        }

        private string _CommitteeName;
        public string CommitteeName
        {
            get { return this._CommitteeName; }
            set { this._CommitteeName = value; }
        }
        #endregion
    }
}
