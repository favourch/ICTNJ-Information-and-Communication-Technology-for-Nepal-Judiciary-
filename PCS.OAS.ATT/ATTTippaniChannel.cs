using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    [Serializable()]
    public class ATTTippaniChannel
    {
        private int _ChannelSeqID;
        public int ChannelSeqID
        {
            get { return this._ChannelSeqID; }
            set { this._ChannelSeqID = value; }
        }

        private int _OTOrgID;
        public int OTOrgID
        {
            get { return this._OTOrgID; }
            set { this._OTOrgID = value; }
        }

        private string _OTFromDate;
        public string OTFromDate
        {
            get { return this._OTFromDate; }
            set { this._OTFromDate = value; }
        }

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

        private int _UnitOrgID;
        public int UnitOrgID
        {
            get { return this._UnitOrgID; }
            set { this._UnitOrgID = value; }
        }

        private int _UnitID;
        public int UnitID
        {
            get { return this._UnitID; }
            set { this._UnitID = value; }
        }

        private string _UnitName;
        public string UnitName
        {
            get { return this._UnitName.Trim(); }
            set { this._UnitName = value; }
        }

        private string _UnitFromDate;
        public string UnitFromDate
        {
            get { return this._UnitFromDate.Trim(); }
            set { this._UnitFromDate = value; }
        }

        private string _CreatedDate;
        public string CreatedDate
        {
            get { return this._CreatedDate.Trim(); }
            set { this._CreatedDate = value; }
        }

        private int _PostID;
        public int PostID
        {
            get { return this._PostID; }
            set { this._PostID = value; }
        }

        private string _PostFromDate;
        public string PostFromDate
        {
            get { return this._PostFromDate.Trim(); }
            set { this._PostFromDate = value; }
        }

        private int _TippaniSubjectID;
        public int TippaniSubjectID
        {
            get { return this._TippaniSubjectID; }
            set { this._TippaniSubjectID = value; }
        }

        private double _ChannelPersonID;
        public double ChannelPersonID
        {
            get { return this._ChannelPersonID; }
            set { this._ChannelPersonID = value; }
        }

        private string _ChannelPersonName = "";
        public string ChannelPersonName
        {
            get { return this._ChannelPersonName.Trim(); }
            set { this._ChannelPersonName = value; }
        }

        private string _FromDate = "";
        public string FromDate
        {
            get { return this._FromDate.Trim(); }
            set { this._FromDate = value; }
        }

        private string _ToDate = "";
        public string ToDate
        {
            get { return this._ToDate.Trim(); }
            set { this._ToDate = value; }
        }

        private int _ChannelPersonOrder;
        public int ChannelPersonOrder
        {
            get { return this._ChannelPersonOrder; }
            set { this._ChannelPersonOrder = value; }
        }

        private string _ChannelPersonType = "";
        public string ChannelPersonType
        {
            get { return this._ChannelPersonType.Trim(); }
            set { this._ChannelPersonType = value; }
        }

        public string RDPersonType
        {
            get
            {
                if (this.ChannelPersonType == "APP")
                    return "प्रमाणित कर्त्ता";
                else if (this.ChannelPersonType == "REC")
                    return "सिफारिस कर्त्ता";
                else if (this.ChannelPersonType == "INI")
                    return "उठाउने व्यक्ति";
                else
                    return "";
            }
        }

        private bool _IsFinalApprover;
        public bool IsFinalApprover
        {
            get { return this._IsFinalApprover; }
            set { this._IsFinalApprover = value; }
        }

        public string RDIsFinalApprover
        {
            get
            {
                if (this.IsFinalApprover == true)
                    return "हो";
                else
                    return "होइन";
            }
        }

        private string _OrgName = "";
        public string OrgName
        {
            get { return this._OrgName.Trim(); }
            set { this._OrgName = value; }
        }

        private string _DegName = "";
        public string DegName
        {
            get { return this._DegName.Trim(); }
            set { this._DegName = value; }
        }

        private string _CommitteeName = "";
        public string CommitteeName
        {
            get { return this._CommitteeName.Trim(); }
            set { this._CommitteeName = value; }
        }

        private string _PostName = "";
        public string PostName
        {
            get { return this._PostName.Trim(); }
            set { this._PostName = value; }
        }

        private string _OldValue = "";
        public string OldValue
        {
            set { this._OldValue = value; }
            get { return this._OldValue; }
        }

        public string NewValue
        {
            get 
            {
                return this.FromDate + "|" + this.ChannelPersonOrder + "|" + this.ChannelPersonType + "|" + this.IsFinalApprover.ToString();
            }
        }

        public bool Enable
        {
            get
            {
                if (this.Action == "D")
                    return false;
                else
                    return true;
            }
        }

        public bool EnableDate
        {
            get
            {
                if (this.Action == "A")
                    return false;
                else
                    return true;
            }
        }

        public System.Drawing.Color DateColor
        {
            get
            {
                if (this.Action == "A")
                    return System.Drawing.Color.White;
                else
                    return System.Drawing.Color.FromName("#E7E2E2");
            }
        }

        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTTippaniChannel()
        {
        }
    }
}
