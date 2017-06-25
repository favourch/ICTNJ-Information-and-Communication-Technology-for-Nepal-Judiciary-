using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTGeneralTippaniProcess
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

        private int _TippaniProcessID;
        public int TippaniProcessID
        {
            get { return this._TippaniProcessID; }
            set { this._TippaniProcessID = value; }
        }

        private int? _SenderOrgID;
        public int? SenderOrgID
        {
            get { return this._SenderOrgID; }
            set { this._SenderOrgID = value; }
        }

        private int? _SenderUnitID;
        public int? SenderUnitID
        {
            get { return this._SenderUnitID; }
            set { this._SenderUnitID = value; }
        }

        private double? _SendBy;
        public double? SendBy
        {
            get { return this._SendBy; }
            set { this._SendBy = value; }
        }

        private string _SendOn;
        public string SendOn
        {
            get { return this._SendOn.Trim(); }
            set { this._SendOn = value; }
        }

        private int _ReceiverOrgID;
        public int ReceiverOrgID
        {
            get { return this._ReceiverOrgID; }
            set { this._ReceiverOrgID = value; }
        }

        private int _ReceiverUnitID;
        public int ReceiverUnitID
        {
            get { return this._ReceiverUnitID; }
            set { this._ReceiverUnitID = value; }
        }

        private int _SendTo;
        public int SendTo
        {
            get { return this._SendTo; }
            set { this._SendTo = value; }
        }

        private string _Note;
        public string Note
        {
            get
            {
                //string s = this._Note.Replace("<p>", "<br />");
                //s = s.Replace("</p>", "");
                //s = s.Remove(0, 6);
                return this._Note;
            }
            set { this._Note = value; }
        }

        /*********************************************/

        private double _ProcessBy;
        public double ProcessBy
        {
            get { return this._ProcessBy; }
            set { this._ProcessBy = value; }
        }

        private string _ProcessOn;
        public string ProcessOn
        {
            get { return this._ProcessOn.Trim(); }
            set { this._ProcessOn = value; }
        }

        private int _ProcessTo;
        public int ProcessTo
        {
            get { return this._ProcessTo; }
            set { this._ProcessTo = value; }
        }

        /*********************************************/

        private int? _Status;
        public int? Status
        {
            get { return this._Status; }
            set { this._Status = value; }
        }

        private string _SendType;
        public string SendType
        {
            get { return this._SendType.Trim(); }
            set { this._SendType = value; }
        }

        private string _IsChannelPerson;
        public string IsChannelPerson
        {
            get { return this._IsChannelPerson.Trim(); }
            set { this._IsChannelPerson = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private string _EntryOn;
        public string EntryOn
        {
            get { return this._EntryOn.Trim(); }
            set { this._EntryOn = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        public ATTGeneralTippaniProcess()
        {
        }
    }
}
