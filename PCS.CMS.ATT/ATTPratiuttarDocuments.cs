using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTPratiuttarDocuments
    {
        private double _CaseID;
        public double CaseID
        {
            get { return this._CaseID; }
            set { this._CaseID = value; }
        }

        private int _PratiuttarID;
        public int PratiuttarID
        {
            get { return this._PratiuttarID; }
            set { this._PratiuttarID = value; }
        }

        private int _DocumentID;
        public int DocumentID
        {
            get { return this._DocumentID; }
            set { this._DocumentID = value; }
        }

        private string _DocumentFileName;
        public string DocumentFileName
        {
            get { return this._DocumentFileName; }
            set { this._DocumentFileName = value; }
        }

        private byte[] _DocumentContent;
        public byte[] DocumentContent
        {
            get { return this._DocumentContent; }
            set { this._DocumentContent = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return this._EntryBy; }
            set { this._EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }

        private double _LitigantID;
        public double LitigantID
        {
            get { return this._LitigantID; }
            set { this._LitigantID = value; }
        }

        private List<ATTPratiuttarDocLit> _LstPratiuttarDocLitigants = new List<ATTPratiuttarDocLit>();
        public List<ATTPratiuttarDocLit> LstPratiuttarDocLitigants
        {
            get { return this._LstPratiuttarDocLitigants; }
            set { this._LstPratiuttarDocLitigants = value; }
        }

        public ATTPratiuttarDocuments()
        {
        }

        public ATTPratiuttarDocuments(double caseID,int pratiuttarID, int documentID,string documentFileName, byte[] documentContent)
        {
            this.CaseID = caseID;
            this.PratiuttarID = pratiuttarID;
            this.DocumentID = documentID;
            this.DocumentFileName = documentFileName;
            this.DocumentContent = documentContent;
        }
    }
}
