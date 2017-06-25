using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    [Serializable()]
    public class ATTOrganizationTippaniSubject
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
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

        private string _Action;
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }

        private List<ATTTippaniChannel> _LstTippaniChannel = new List<ATTTippaniChannel>();
        public List<ATTTippaniChannel> LstTippaniChannel
        {
            get { return this._LstTippaniChannel; }
            set { this._LstTippaniChannel = value; }
        }

        public ATTOrganizationTippaniSubject(
       
            int OrgID,
            int TippaniSubjectID,
            string TippaniSubjectName,
            string fromDate,
            string toDate,
            string action
        )
            {
                this.OrgID = OrgID;
                this.TippaniSubjectID = TippaniSubjectID;
                this.TippaniSubjectName = TippaniSubjectName;
                this.FromDate = fromDate;
                this.ToDate = toDate;
                this.Action = action;

            }

        public ATTOrganizationTippaniSubject()
        { }
        
               
    
    }
}
