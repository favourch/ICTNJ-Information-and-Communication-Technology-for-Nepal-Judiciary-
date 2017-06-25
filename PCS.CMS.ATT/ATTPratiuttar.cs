using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTPratiuttar
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private int _PratiuttarID;
        public int PratiuttarID
        {
            get { return _PratiuttarID; }
            set { _PratiuttarID = value; }
        }

        private string _PratiuttarDate;
        public string PratiuttarDate
        {
            get { return _PratiuttarDate; }
            set { _PratiuttarDate = value; }
        }

        private string _AccountForward;
        public string AccountForward
        {
            get { return _AccountForward; }
            set { _AccountForward = value; }
        }

        private double? _SubmittedBy;
        public double? SubmittedBy
        {
            get { return _SubmittedBy; }
            set { _SubmittedBy = value; }
        }

        private string _PratiuttarSummary;
        public string PratiuttarSummary
        {
            get { return _PratiuttarSummary; }
            set { _PratiuttarSummary = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private List<ATTPratiuttarLitigants> _LstPratiuttarLitigants = new List<ATTPratiuttarLitigants>();
        public List<ATTPratiuttarLitigants> LstPratiuttarLitigants
        {
            get { return this._LstPratiuttarLitigants; }
            set { this._LstPratiuttarLitigants = value; }
        }

        private List<ATTPratiuttarEvidence> _LstPratiuttarEvidence = new List<ATTPratiuttarEvidence>();
        public List<ATTPratiuttarEvidence> LstPratiuttarEvidence
        {
            get { return this._LstPratiuttarEvidence; }
            set { this._LstPratiuttarEvidence = value; }
        }

        private List<ATTPratiuttarDocuments> _LstPratiuttarDocuments = new List<ATTPratiuttarDocuments>();
        public List<ATTPratiuttarDocuments> LstPratiuttarDocuments
        {
            get { return this._LstPratiuttarDocuments; }
            set { this._LstPratiuttarDocuments = value; }
        }


        public ATTPratiuttar()
        {
        }

        public ATTPratiuttar(double caseID,int pratiuttarID,string pratiuttarDate,string accountForward,double? submittedBy,string pratiuttarSummary)
        {
            this.CaseID = caseID;
            this.PratiuttarID = PratiuttarID;
            this.PratiuttarDate = pratiuttarDate;
            this.AccountForward = accountForward;
            this.SubmittedBy = submittedBy;
            this.PratiuttarSummary = pratiuttarSummary;
        }
    }
}
