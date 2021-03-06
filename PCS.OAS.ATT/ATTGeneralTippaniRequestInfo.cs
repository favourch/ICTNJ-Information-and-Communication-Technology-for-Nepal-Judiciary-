using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public enum TippaniProcessRequestType
    {
        Request,
        History
    };

    public class ATTGeneralTippaniRequestInfo
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

        private string _TippaniSubject;
        public string TippaniSubject
        {
            get { return this._TippaniSubject.Trim(); }
            set { this._TippaniSubject = value; }
        }

        private int _SenderOrgID;
        public int SenderOrgID
        {
            get { return this._SenderOrgID; }
            set { this._SenderOrgID = value; }
        }

        private int _SenderUnitID;
        public int SenderUnitID
        {
            get { return this._SenderUnitID; }
            set { this._SenderUnitID = value; }
        }

        private string _SenderOrgName;
        public string SenderOrgName
        {
            get { return this._SenderOrgName; }
            set { this._SenderOrgName = value; }
        }

        private string _SenderUnitName;
        public string SenderUnitName
        {
            get { return this._SenderUnitName; }
            set { this._SenderUnitName = value; }
        }

        private double _ProcessByID;
        public double ProcessByID
        {
            get { return this._ProcessByID; }
            set { this._ProcessByID = value; }
        }

        private string _ProcessBy;
        public string ProcessBy
        {
            get { return this._ProcessBy.Trim(); }
            set { this._ProcessBy = value; }
        }

        private string _ProcessOn;
        public string ProcessOn
        {
            get { return this._ProcessOn.Trim(); }
            set { this._ProcessOn = value; }
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

        private string _ReceiverOrgName;
        public string ReceiverOrgName
        {
            get { return this._ReceiverOrgName; }
            set { this._ReceiverOrgName = value; }
        }

        private string _ReceiverUnitName;
        public string ReceiverUnitName
        {
            get { return this._ReceiverUnitName; }
            set { this._ReceiverUnitName = value; }
        }

        private double _ProcessToID;
        public double ProcessToID
        {
            get { return this._ProcessToID; }
            set { this._ProcessToID = value; }
        }

        private string _ProcessTo;
        public string ProcessTo
        {
            get { return this._ProcessTo.Trim(); }
            set { this._ProcessTo = value; }
        }

        private int _TippaniSubjectID;
        public int TippaniSubjectID
        {
            get { return this._TippaniSubjectID; }
            set { this._TippaniSubjectID = value; }
        }

        private string _TippaniSubjectName;
        public string TippaniSubjectName
        {
            get { return this._TippaniSubjectName.Trim(); }
            set { this._TippaniSubjectName = value; }
        }

        private int _TippaniStatusID;
        public int TippaniStatusID
        {
            get { return this._TippaniStatusID; }
            set { this._TippaniStatusID = value; }
        }

        private string _TippaniStatusName;
        public string TippaniStatusName
        {
            get { return this._TippaniStatusName.Trim(); }
            set { this._TippaniStatusName = value; }
        }

        private int _ProcessStatusID;
        public int ProcessStatusID
        {
            get { return this._ProcessStatusID; }
            set { this._ProcessStatusID = value; }
        }

        private string _ProcessStatusName;
        public string ProcessStatusName
        {
            get { return this._ProcessStatusName.Trim(); }
            set { this._ProcessStatusName = value; }
        }

        private string _Note;
        public string Note
        {
            get
            {
                string formatedNote;
                formatedNote = this._Note.Replace("<P>", "<br>").Replace("</P>", "");
                formatedNote = formatedNote.Replace("<p>", "<br>").Replace("</p>", "");
                if (formatedNote.StartsWith("<br>") == true)
                {
                    formatedNote = formatedNote.Remove(0, 4);
                }
                return formatedNote.Trim();
            }
            set { this._Note = value; }
        }

        public string NoteTitle
        {
            get 
            {
                if (this.Note == "")
                    return "टिप्पणीको लेख ! <strong>कुनै लेख छैन।</strong> (Click here to expand or collapse)";
                else
                    return "टिप्पणीको लेख ! (Click here to expand or collapse)";
            }
        }

        private string _Filter;
        public string Filter
        {
            get { return this._Filter; }
            set { this._Filter = value; }
        }

        private TippaniProcessRequestType _RequestType = TippaniProcessRequestType.Request;
        public TippaniProcessRequestType RequestType
        {
            get { return this._RequestType; }
            set { this._RequestType = value; }
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

        private List<ATTGeneralTippaniAttachment> _LstAttachment = new List<ATTGeneralTippaniAttachment>();
        public List<ATTGeneralTippaniAttachment> LstAttachment
        {
            get { return this._LstAttachment; }
            set { this._LstAttachment = value; }
        }

        public ATTGeneralTippaniRequestInfo()
        {

        }
    }
}
