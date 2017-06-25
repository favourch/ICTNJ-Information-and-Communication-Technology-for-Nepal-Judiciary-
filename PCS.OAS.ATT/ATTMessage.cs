using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMessage
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        // NB: For Message Forward Case
        private int? _ParentMsgID = null;
        public int? ParentMsgID
        {
            get { return this._ParentMsgID; }
            set { this._ParentMsgID = value; }
        }
                
        private int? _MessageID;
        public int? MessageID
        {
            get { return this._MessageID; }
            set { this._MessageID = value; }
        }

        private int _MessageTypeID;
        public int MessageTypeID
        {
            get { return this._MessageTypeID; }
            set { this._MessageTypeID = value; }
        }

        private int _SenderID;
        public int SenderID
        {
            get { return this._SenderID; }
            set { this._SenderID = value; }
        }

        private string _Sender = "";
        public string Sender
        {
            get { return this._Sender.Trim(); }
            set { this._Sender = value; }
        }


        private string _Subject = "";
        public string Subject
        {
            get { return this._Subject.Trim(); }
            set { this._Subject = value; }
        }

        private string _Body = "";
        public string Body
        {
            get { return this._Body.Trim(); }
            set { this._Body = value; }
        }

        private int? _MsgSeq;
        public int? MsgSeq
        {
            get { return this._MsgSeq; }
            set { this._MsgSeq = value; }
        }

        private string _MsgGrpType;
        public string MsgGrpType
        {
            get { return this._MsgGrpType; }
            set { this._MsgGrpType = value; }
        }

        private string _Approve = "N";
        public string Approve
        {
            get { return this._Approve; }
            set { this._Approve = value; }
        }

      
        
        //-----------------------------------------------------
        // NB: For Letter
        //-----------------------------------------------------


        private string _LetterType = "";
        public string LetterType
        {
            get { return this._LetterType; }
            set { this._LetterType = value; }
        }

        private int? _FromOrgID = null;
        public int? FromOrgID
        {
            get { return this._FromOrgID; }
            set { this._FromOrgID = value; }
        }

        private int? _FromUnitID = null;
        public int? FromUnitID
        {
            get { return this._FromUnitID; }
            set { this._FromUnitID = value; }
        }

        private int? _FromPID = null;
        public int? FromPID
        {
            get { return this._FromPID; }
            set { this._FromPID = value; }
        }

        private int? _ToOrgID =null;
        public int? ToOrgID
        {
            get { return this._ToOrgID; }
            set { this._ToOrgID = value; }
        }

        private int? _ToUnitID = null;
        public int? ToUnitID
        {
            get { return this._ToUnitID; }
            set { this._ToUnitID = value; }
        }

        private int? _ToPID = null;
        public int? ToPID
        {
            get { return this._ToPID; }
            set { this._ToPID = value; }
        }

        //-------------------------------------------------

        private List<ATTMessageReceiver> _LstMessageReceiver = new List<ATTMessageReceiver>();
        public List<ATTMessageReceiver> LstMessageReceiver
        {
            get { return _LstMessageReceiver; }
            set { _LstMessageReceiver = value; }
        }

        private List<ATTMessageReceiver> _LstMessageCcReceiver = new List<ATTMessageReceiver>();
        public List<ATTMessageReceiver> LstMessageCcReceiver
        {
            get { return _LstMessageCcReceiver; }
            set { _LstMessageCcReceiver = value; }
        }


        private List<ATTMessageAttachment> _LstMsgAttachment = new List<ATTMessageAttachment>();
        public List<ATTMessageAttachment> LstMsgAttachment
        {
            get { return _LstMsgAttachment; }
            set { _LstMsgAttachment = value; }
        }

        private string _Read;
        public string Read
        {
            get { return this._Read; }
            set { this._Read = value; }
        }

        private int? _TippaniOrgID;
        public int? TippaniOrgID
        {
            get { return this._TippaniOrgID; }
            set { this._TippaniOrgID = value; }
        }

        private int? _TippaniID;
        public int? TippaniID
        {
            get { return this._TippaniID; }
            set { this._TippaniID = value; }
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

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn; }
            set { this._EntryOn = value; }
        }

        public ATTMessage()
        {
        }
        
        public ATTMessage(int orgID,int? messageID,int senderID,string sender,string subject,string body,string action,DateTime entryOn)
        {
            OrgID = orgID;
            MessageID = messageID;
            SenderID = senderID;
            Sender = sender;
            Subject = subject;
            Body = body;
            Action = action;
            EntryOn = entryOn;
        }

        
    }
}
