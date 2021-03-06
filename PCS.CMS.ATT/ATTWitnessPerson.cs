using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.CMS.ATT
{
    public class ATTWitnessPerson
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }


        private string _LitigantType;
        public string LitigantType
        {
            get { return _LitigantType; }
            set { _LitigantType = value; }
        }
	

        public string AppOrResp
        {
            
            get { return LitigantType=="A"?"वादि":"प्रतिवादि";  }
        }

        


        private double _LitigantID;
        public double LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private string _LitigantName;
        public string LitigantName
        {
            get { return _LitigantName; }
            set { _LitigantName = value; }
        }
	
        private double _PersonID;
        public double PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

        private string _WitnessName;
        public string WitnessName
        {
            get { return _WitnessName; }
            set { _WitnessName = value; }
        }
	

        private string _FromDate;
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private string _ToDate;

        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
	

        private int _WitnessID;
        public int WitnessID
        {
            get { return _WitnessID; }
            set { _WitnessID = value; }
        }
        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
        private string _EntryDate;
        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private ATTPerson _PersonOBJ = new ATTPerson();
        public ATTPerson PersonOBJ
        {
            get { return _PersonOBJ; }
            set { _PersonOBJ = value; }
        }
	
	
        public ATTWitnessPerson()
        {

        }

        public ATTWitnessPerson(int caseID, int litigantID, int personID, string fromDate, int witnessID, string entryBy)
        {
            this.CaseID = caseID;
            this.LitigantID = litigantID;
            this.PersonID = personID;
            this.FromDate = fromDate;
            this.WitnessID = witnessID;
            this.EntryDate = entryBy;
        }
	
    }
}
