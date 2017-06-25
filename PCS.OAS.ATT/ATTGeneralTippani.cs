using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public enum TippaniSubject
    {
        Leave = 1,
        Visit = 2, //COMPLETE
        Posting = 3, //COMPLETE
        General = 4, // NOT REQUIRED
        Training = 5, // COMPLETED
        Deputation = 6, //COMPLETED
        Punishment = 7, //COMPLETED
        Award = 8, //COMPLETED
        Committee = 9 //
    }

    public class ATTUnreadTippani
    {
        private double _EmpID;
        public double EmpID
        {
            get { return this._EmpID; }
            set { this._EmpID = value; }
        }

        private string _TippaniName;
        public string TippaniName
        {
            get { return this._TippaniName; }
            set { this._TippaniName = value; }
        }

        private int _SubjectID;
        public int SubjectID
        {
            get { return this._SubjectID; }
            set { this._SubjectID = value; }
        }

        private int _Number;
        public int Number
        {
            get { return this._Number; }
            set { this._Number = value; }
        }

        public string URL
        {
            get
            {
                string path = "";
                switch (this.SubjectID)
                {
                    case 1:
                        path = "~/modules/oas/tippani/LeaveTippaniRecommendViewer.aspx";
                        break;
                    case 2:
                        path = "~/modules/oas/tippani/visittippanirequestviewer.aspx";
                        break;
                    case 3:
                        path = "~/modules/oas/tippani/postingtippanirequestviewer.aspx";
                        break;
                    case 4:
                        path = "~/modules/oas/tippani/generaltippanirequestviewer.aspx";
                        break;
                    case 5:
                        path = "~/modules/oas/tippani/trainingtippanirequestviewer.aspx";
                        break;
                    case 6:
                        path = "~/modules/oas/tippani/deputationtippanirequestviewer.aspx";
                        break;
                    case 7:
                        path = "~/modules/oas/tippani/punishmenttippanirequestviewer.aspx";
                        break;
                    case 8:
                        path = "~/modules/oas/tippani/awardtippanirequestviewer.aspx";
                        break;
                    case 9:
                        path = "~/modules/oas/tippani/CommitteeTippaniViewer.aspx";
                        break;
                    default:
                        break;
                }
                return path;
            }
        }

        public ATTUnreadTippani()
        {
        }
    }

    public class ATTGeneralTippani
    {
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

        private int _TippaniSubjectID;
        public int TippaniSubjectID
        {
            get { return this._TippaniSubjectID; }
            set { this._TippaniSubjectID = value; }
        }

        private string _TippaniBy;
        public string TippaniBy
        {
            get { return this._TippaniBy; }
            set { this._TippaniBy = value; }
        }

        private string _TippaniOn;
        public string TippaniOn
        {
            get { return this._TippaniOn.Trim(); }
            set { this._TippaniOn = value; }
        }

        private string _TippaniText;
        public string TippaniText
        {
            get { return this._TippaniText.Trim(); }
            set { this._TippaniText = value; }
        }

        private double _FileNo;
        public double FileNo
        {
            get { return this._FileNo; }
            set { this._FileNo = value; }
        }

        private TippaniSubject _TippaniName;
        public TippaniSubject TippaniName
        {
            get { return this._TippaniName; }
            set { this._TippaniName = value; }
        }

        private int _FinalStatus;
        public int FinalStatus
        {
            get { return this._FinalStatus; }
            set { this._FinalStatus = value; }
        }

        private int _PriorityID;
        public int PriorityID
        {
            get { return this._PriorityID; }
            set { this._PriorityID = value; }
        }

        private double _CreatedBy;
        public double CreatedBy
        {
            get { return this._CreatedBy; }
            set { this._CreatedBy = value; }
        }

        private int? _MsgOrgID;
        public int? MsgOrgID
        {
            get { return this._MsgOrgID; }
            set { this._MsgOrgID = value; }
        }

        private int? _MsgID;
        public int? MsgID
        {
            get { return this._MsgID; }
            set { this._MsgID = value; }
        }

        private int? _DarOrgID;
        public int? DarOrgID
        {
            get { return this._DarOrgID; }
            set { this._DarOrgID = value; }
        }

        private string _DarRegDate;
        public string DarRegDate
        {
            get { return this._DarRegDate; }
            set { this._DarRegDate = value; }
        }

        private int? _DarRegNo;
        public int? DarRegNo
        {
            get { return this._DarRegNo; }
            set { this._DarRegNo = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private ATTGeneralTippaniDetail _TippaniDetail = new ATTGeneralTippaniDetail();
        public ATTGeneralTippaniDetail TippaniDetail
        {
            get { return this._TippaniDetail; }
            set { this._TippaniDetail = value; }
        }

        private List<ATTGeneralTippaniDetail> _LstTippaniDetail = new List<ATTGeneralTippaniDetail>();
        public List<ATTGeneralTippaniDetail> LstTippaniDetail
        {
            get { return this._LstTippaniDetail; }
            set { this._LstTippaniDetail = value; }
        }

        private List<ATTGeneralTippaniProcess> _LstTippaniProcess = new List<ATTGeneralTippaniProcess>();
        public List<ATTGeneralTippaniProcess> LstTippaniProcess
        {
            get { return this._LstTippaniProcess; }
            set { this._LstTippaniProcess = value; }
        }

        private List<ATTGeneralTippaniAttachment> _LstTippaniAttachment = new List<ATTGeneralTippaniAttachment>();
        public List<ATTGeneralTippaniAttachment> LstTippaniAttachment
        {
            get { return this._LstTippaniAttachment; }
            set { this._LstTippaniAttachment = value; }
        }

        private ATTCommitteeByTippani _Committee = null;
        public ATTCommitteeByTippani Committee
        {
            get { return this._Committee; }
            set { this._Committee = value; }
        }

        public ATTGeneralTippani()
        {
        }
    }
}
