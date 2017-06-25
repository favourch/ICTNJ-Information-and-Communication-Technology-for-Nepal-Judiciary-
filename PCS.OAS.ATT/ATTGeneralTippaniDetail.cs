using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public enum LeaveMode
    {
        Request = 1,
        Recommend = 2,
        Approve = 3
    }

    public class ATTGeneralTippaniDetail
    {
        #region General attributes
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _TippaniID;
        public int TippaniID
        {
            get { return this._TippaniID; }
            set { this._TippaniID = value; }
        }

        private int _TippaniSNO;
        public int TippaniSNO
        {
            get { return this._TippaniSNO; }
            set { this._TippaniSNO = value; }
        }

        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
        #endregion End of General attributes

        #region Leave attributes

        private string _ApplicationDate;
        public string ApplicationDate
        {
            get { return this._ApplicationDate.Trim(); }
            set { this._ApplicationDate = value; }
        }

        private int _LeaveTypeID;
        public int LeaveTypeID
        {
            get { return this._LeaveTypeID; }
            set { this._LeaveTypeID = value; }
        }

        private string _ReqFromDate;
        public string ReqFromDate
        {
            get { return this._ReqFromDate.Trim(); }
            set { this._ReqFromDate = value; }
        }

        private string _ReqToDate;
        public string ReqToDate
        {
            get { return this._ReqToDate.Trim(); }
            set { this._ReqToDate = value; }
        }

        private int _ReqNoOfDays;
        public int ReqNoOfDays
        {
            get { return this._ReqNoOfDays; }
            set { this._ReqNoOfDays = value; }
        }

        private string _ReqReason;
        public string ReqReason
        {
            get { return this._ReqReason.Trim(); }
            set { this._ReqReason = value; }
        }

       /*************************************************************************************/

        private double _RecBy;
        public double RecBy
        {
            get { return this._RecBy; }
            set { this._RecBy = value; }
        }

        private string _RecDate;
        public string RecDate
        {
            get { return this._RecDate.Trim(); }
            set { this._RecDate = value; }
        }

        private string _RecFromDate;
        public string RecFromDate
        {
            get { return this._RecFromDate.Trim(); }
            set { this._RecFromDate = value; }
        }

        private string _RecToDate;
        public string RecToDate
        {
            get { return this._RecToDate.Trim(); }
            set { this._RecToDate = value; }
        }

        private int _RecNoOfDays;
        public int RecNoOfDays
        {
            get { return this._RecNoOfDays; }
            set { this._RecNoOfDays = value; }
        }

        private string _RecYesNo;
        public string RecYesNo
        {
            get { return this._RecYesNo.Trim(); }
            set { this._RecYesNo = value; }
        }

        private string _RecReason;
        public string RecReason
        {
            get { return this._RecReason.Trim(); }
            set { this._RecReason = value; }
        }

        /*************************************************************************************/

        private double _AppBy;
        public double AppBy
        {
            get { return this._AppBy; }
            set { this._AppBy = value; }
        }

        private string _AppDate;
        public string AppDate
        {
            get { return this._AppDate.Trim(); }
            set { this._AppDate = value; }
        }

        private string _AppFromDate;
        public string AppFromDate
        {
            get { return this._AppFromDate.Trim(); }
            set { this._AppFromDate = value; }
        }

        private string _AppToDate;
        public string AppToDate
        {
            get { return this._AppToDate.Trim(); }
            set { this._AppToDate = value; }
        }

        private int _AppNoOfDays;
        public int AppNoOfDays
        {
            get { return this._AppNoOfDays; }
            set { this._AppNoOfDays = value; }
        }

        private string _AppYesNo;
        public string AppYesNo
        {
            get { return this._AppYesNo.Trim(); }
            set { this._AppYesNo = value; }
        }

        private string _AppReason;
        public string AppReason
        {
            get { return this._AppReason.Trim(); }
            set { this._AppReason = value; }
        }

        private string _LeaveFY;
        public string LeaveFY
        {
            get { return this._LeaveFY.Trim(); }
            set { this._LeaveFY = value; }
        
        }

        private string _LeavePeriodUnit;
        public string LeavePeriodUnit
        {
            get { return this._LeavePeriodUnit.Trim(); }
            set { this._LeavePeriodUnit = value; }

        }

        /*************************************************************************************/

        private LeaveMode _LeaveLevel;
        public LeaveMode LeaveLevel
        {
            get { return this._LeaveLevel; }
            set { this._LeaveLevel = value; }
        }

        private string _LeaveEntryBy;
        public string LeaveEntryBy
        {
            get { return this._LeaveEntryBy.Trim(); }
            set { this._LeaveEntryBy = value; }
        }

        private DateTime _LeaveEntryOn;
        public DateTime LeaveEntryOn
        {
            get { return this._LeaveEntryOn; }
            set { this._LeaveEntryOn = value; }
        }

        #endregion

        #region Visit attributes
        private string _VisitLocation;
        public string VisitLocation
        {
            get { return this._VisitLocation.Trim(); }
            set { this._VisitLocation = value; }
        }

        private int _VisitCountryID;
        public int VisitCountryID
        {
            get { return this._VisitCountryID; }
            set { this._VisitCountryID = value; }
        }

        private string _VisitFromDate;
        public string VisitFromDate
        {
            get { return this._VisitFromDate.Trim(); }
            set { this._VisitFromDate = value; }
        }

        private string _VisitToDate;
        public string VisitToDate
        {
            get { return this._VisitToDate.Trim(); }
            set { this._VisitToDate = value; }
        }

        private string _VisitVehicle;
        public string VisitVehicle
        {
            get { return this._VisitVehicle.Trim(); }
            set { this._VisitVehicle = value; }
        }

        private string _VisitPurpose;
        public string VisitPurpose
        {
            get { return this._VisitPurpose.Trim(); }
            set { this._VisitPurpose = value; }
        }

        private string _VisitRemark;
        public string VisitRemark
        {
            get { return this._VisitRemark.Trim(); }
            set { this._VisitRemark = value; }
        }

        private string _VisitEntryBy;
        public string VisitEntryBy
        {
            get { return this._VisitEntryBy.Trim(); }
            set { this._VisitEntryBy = value; }
        }

        private DateTime _VisitEntryOn;
        public DateTime VisitEntryOn
        {
            get { return this._VisitEntryOn; }
            set { this._VisitEntryOn = value; }
        }
        #endregion

        #region Posting attributes
        private int _PostOrgID;
        public int PostOrgID
        {
            get { return this._PostOrgID; }
            set { this._PostOrgID = value; }
        }

        private int _DesID;
        public int DesID
        {
            get { return this._DesID; }
            set { this._DesID = value; }
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
            get { return this._CreatedDate.Trim(); }
            set { this._CreatedDate = value; }
        }
        
        private int _PostingTypeID;
        public int PostingTypeID
        {
            get { return this._PostingTypeID; }
            set { this._PostingTypeID = value; }
        }

        private string _FromDate;
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }

        private string _ToDate;
        public string ToDate
        {
            get { return this._ToDate.Trim(); }
            set { this._ToDate = value; }
        }

        private string _DecisionDate;
        public string DecisionDate
        {
            get { return this._DecisionDate.Trim(); }
            set { this._DecisionDate = value; }
        }

        private string _LeaveDate;
        public string LeaveDate
        {
            get { return this._LeaveDate.Trim(); }
            set { this._LeaveDate = value; }
        }

        private string _JoiningDate;
        public string JoiningDate
        {
            get { return this._JoiningDate.Trim(); }
            set { this._JoiningDate = value; }
        }

        private string _PostingRemark;
        public string PostingRemark
        {
            get { return this._PostingRemark.Trim(); }
            set { this._PostingRemark = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        #endregion

        #region Training attributes
        private string _TrnSubject;
        public string TrnSubject
        {
            get { return this._TrnSubject.Trim(); }
            set { this._TrnSubject = value; }
        }

        private int _TrnInstitutionID;
        public int TrnInstitutionID
        {
            get { return this._TrnInstitutionID; }
            set { this._TrnInstitutionID = value; }
        }

        private string _TrnFromDate;
        public string TrnFromDate
        {
            get { return this._TrnFromDate.Trim(); }
            set { this._TrnFromDate = value; }
        }

        private string _TrnToDate;
        public string TrnToDate
        {
            get { return this._TrnToDate.Trim(); }
            set { this._TrnToDate = value; }
        }

        private string _TrnRemark;
        public string TrnRemark
        {
            get { return this._TrnRemark.Trim(); }
            set { this._TrnRemark = value; }
        }

        private string _TrnEntryBy;
        public string TrnEntryBy
        {
            get { return this._TrnEntryBy.Trim(); }
            set { this._TrnEntryBy = value; }
        }
        #endregion

        #region Deputation attributes
        private int _DepOrgID;
        public int DepOrgID
        {
            get { return this._DepOrgID; }
            set { this._DepOrgID = value; }
        }

        private int _DepDesID;
        public int DepDesID
        {
            get { return this._DepDesID; }
            set { this._DepDesID = value; }
        }

        private string _DepCreatedDate;
        public string DepCreatedDate
        {
            get { return this._DepCreatedDate.Trim(); }
            set { this._DepCreatedDate = value; }
        }

        private int _DepPostID;
        public int DepPostID
        {
            get { return this._DepPostID; }
            set { this._DepPostID = value; }
        }

        private string _DepFromDate;
        public string DepFromDate
        {
            get { return this._DepFromDate.Trim(); }
            set { this._DepFromDate = value; }
        }

        private string _DepDecisionDate;
        public string DepDecisionDate
        {
            get { return this._DepDecisionDate.Trim(); }
            set { this._DepDecisionDate = value; }
        }

        private int _DepToOrgID;
        public int DepToOrgID
        {
            get { return this._DepToOrgID; }
            set { this._DepToOrgID = value; }
        }

        private string _DepLeaveDate;
        public string DepLeaveDate
        {
            get { return this._DepLeaveDate.Trim(); }
            set { this._DepLeaveDate = value; }
        }

        private string _DepResponsibility;
        public string DepResponsibility
        {
            get { return this._DepResponsibility.Trim(); }
            set { this._DepResponsibility = value; }
        }

        private string _DepEntryBy;
        public string DepEntryBy
        {
            get { return this._DepEntryBy.Trim(); }
            set { this._DepEntryBy = value; }
        }
        #endregion

        #region Punishment attributes
        private string _Punishment;
        public string Punishment
        {
            get { return this._Punishment.Trim(); }
            set { this._Punishment = value; }
        }

        private string _PunishmentDate;
        public string PunishmentDate
        {
            get { return this._PunishmentDate.Trim(); }
            set { this._PunishmentDate = value; }
        }

        private string _PunishmentRemark;
        public string PunishmentRemark
        {
            get { return this._PunishmentRemark.Trim(); }
            set { this._PunishmentRemark = value; }
        }

        private string _PunEntryBy;
        public string PunEntryBy
        {
            get { return this._PunEntryBy.Trim(); }
            set { this._PunEntryBy = value; }
        }

        private string _PunEntryDate;
        public string PunEntryDate
        {
            get { return this._PunEntryDate.Trim(); }
            set { this._PunEntryDate = value; }
        }
        #endregion

        #region Award attributes
        private string _Award;
        public string Award
        {
            get { return this._Award.Trim(); }
            set { this._Award = value; }
        }

        private string _AwardDate;
        public string AwardDate
        {
            get { return this._AwardDate.Trim(); }
            set { this._AwardDate = value; }
        }

        private string _AwardRemark;
        public string AwardRemark
        {
            get { return this._AwardRemark.Trim(); }
            set { this._AwardRemark = value; }
        }

        private string _AwdEntryBy;
        public string AwdEntryBy
        {
            get { return this._AwdEntryBy.Trim(); }
            set { this._AwdEntryBy = value; }
        }

        private string _AwdEntryDate;
        public string AwdEntryDate
        {
            get { return this._AwdEntryDate.Trim(); }
            set { this._AwdEntryDate = value; }
        }
        #endregion

        #region Committee attribute
        private int _CommitteeOrgID;
        public int CommitteeOrgID
        {
            get { return this._CommitteeOrgID; }
            set { this._CommitteeOrgID = value; }
        }

        private int _CommitteeID;
        public int CommitteeID
        {
            get { return this._CommitteeID; }
            set { this._CommitteeID = value; }
        }
        #endregion

        public ATTGeneralTippaniDetail()
        {

        }
    }
}
