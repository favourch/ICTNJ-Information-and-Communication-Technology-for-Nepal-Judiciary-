using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMessageReceiver
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int? _MessageID;
        public int? MessageID
        {
            get { return this._MessageID; }
            set { this._MessageID = value; }
        }

        private int? _ReceiverID;
        public int? ReceiverID
        {
            get { return this._ReceiverID; }
            set { this._ReceiverID = value; }
        }
        private string _Receiver = "";
        public string Receiver
        {
            get { return this._Receiver.Trim(); }
            set { this._Receiver = value; }
        }

        private string _OtherReceiver = "";
        public string OtherReceiver
        {
            get { return this._OtherReceiver.Trim(); }
            set { this._OtherReceiver = value; }
        }

        private int? _OtherOrgID;
        public int? OtherOrgID
        {
            get { return this._OtherOrgID; }
            set { this._OtherOrgID = value; }
        }

        private int? _OtherUnitID;
        public int? OtherUnitID
        {
            get { return this._OtherUnitID; }
            set { this._OtherUnitID = value; }
        }


        private int? _OtherReceiverID;
        public int? OtherReceiverID
        {
            get { return this._OtherReceiverID; }
            set { this._OtherReceiverID = value; }
        }

       

        private string _IsGrpReceiver;
        public string IsGrpReceiver
        {
            get { return this._IsGrpReceiver; }
            set { this._IsGrpReceiver = value; }
        }

        private int? _ReceiverOrgID;
        public int? ReceiverOrgID
        {
            get { return this._ReceiverOrgID; }
            set { this._ReceiverOrgID = value; }
        }

        private int? _GroupID;
        public int? GroupID
        {
            get { return this._GroupID; }
            set { this._GroupID = value; }
        }

        private string _GrpFromDate = "";
        public string GrpFromDate
        {
            get { return this._GrpFromDate; }
            set { this._GrpFromDate = value; }
        }

        private string _Read;
        public string Read
        {
            get { return this._Read; }
            set { this._Read = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _DisplayName = "";
        public string DisplayName
        {
            get { return this._DisplayName.Trim(); }
            set { this._DisplayName = value; }
        }

        private string _DetailName = "";
        public string DetailName
        {
            get { return this._DetailName.Trim(); }
            set { this._DetailName = value; }
        }

        private string _ReceiverType = "";
        public string ReceiverType
        {
            get { return this._ReceiverType.Trim(); }
            set { this._ReceiverType = value; }
        }

        private string _IsCc = "";
        public string IsCc
        {
            get { return this._IsCc.Trim(); }
            set { this._IsCc = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        public ATTMessageReceiver()
        {
        }

        public ATTMessageReceiver(int orgID, int? messageID, int? receiverID, string isGrpReceiver,
                                  int? groupID,int? receiverOrgID,string action, string entryBy)
        {
            OrgID = orgID;
            MessageID = messageID;
            ReceiverID = receiverID;
            IsGrpReceiver = isGrpReceiver;
            GroupID = groupID;
            ReceiverOrgID = receiverOrgID;
            Action = action;
            EntryBy = entryBy;

         }

        public ATTMessageReceiver(int orgID, int? messageID, int? receiverID, string isGrpReceiver,
                                 int? groupID, int? receiverOrgID,string grpFromDate,int? otherReceiverID, string action,
                                 string entryBy, string displayName,string detailName,string receiverType,string isCc)
        {
            OrgID = orgID;
            MessageID = messageID;
            ReceiverID = receiverID;
            IsGrpReceiver = isGrpReceiver;
            GroupID = groupID;
            ReceiverOrgID = receiverOrgID;
            GrpFromDate = grpFromDate;
            OtherReceiverID = otherReceiverID;
            Action = action;
            EntryBy = entryBy;
            DisplayName = displayName;
            DetailName = detailName;
            ReceiverType = receiverType;
            IsCc = isCc;

        }

        // NB: OtherReceiverOrgID, OtherReceiverUnitID

        public ATTMessageReceiver(int orgID, int? messageID, int? receiverID, string isGrpReceiver,
                               int? groupID, int? receiverOrgID, string grpFromDate,
                               int? otherReceiverOrgID,int? otherReceiverUnitID,int? otherReceiverID, string action,
                               string entryBy, string displayName, string detailName, string receiverType, string isCc)
        {
            OrgID = orgID;
            MessageID = messageID;
            ReceiverID = receiverID;
            IsGrpReceiver = isGrpReceiver;
            GroupID = groupID;
            ReceiverOrgID = receiverOrgID;
            GrpFromDate = grpFromDate;

            OtherOrgID = otherReceiverOrgID;
            OtherUnitID = otherReceiverUnitID;
            OtherReceiverID = otherReceiverID;

            Action = action;
            EntryBy = entryBy;
            DisplayName = displayName;
            DetailName = detailName;
            ReceiverType = receiverType;
            IsCc = isCc;

        }

        //---------------------------------------------

        public ATTMessageReceiver(int orgID, int? messageID, int? receiverID, string isGrpReceiver,
                                int? groupID, int? receiverOrgID, string grpFromDate, int? otherReceiverID, string action,
                                string entryBy, string displayName, string detailName, string receiverType)
        {
            OrgID = orgID;
            MessageID = messageID;
            ReceiverID = receiverID;
            IsGrpReceiver = isGrpReceiver;
            GroupID = groupID;
            ReceiverOrgID = receiverOrgID;
            GrpFromDate = grpFromDate;
            OtherReceiverID = otherReceiverID;
            Action = action;
            EntryBy = entryBy;
            DisplayName = displayName;
            DetailName = detailName;
            ReceiverType = receiverType;

        }

        public ATTMessageReceiver(int orgID, int? messageID, int? receiverID, string isGrpReceiver,
                                  int? groupID, int? receiverOrgID, string grpFromDate, int? otherReceiverID,
                                  string action, string entryBy)
        {
            OrgID = orgID;
            MessageID = messageID;
            ReceiverID = receiverID;
            IsGrpReceiver = isGrpReceiver;
            GroupID = groupID;
            ReceiverOrgID = receiverOrgID;
            GrpFromDate = grpFromDate;
            OtherReceiverID = otherReceiverID;
            Action = action;
            EntryBy = entryBy;
        }

    }
}


