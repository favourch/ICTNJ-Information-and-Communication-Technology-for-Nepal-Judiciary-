using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.CMS.ATT
{
    public class ATTCaseLaywer
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

            get { return LitigantType == "A" ? "वादि" : "प्रतिवादि"; }
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
	

        private double _LawyerID;
        public double LawyerID
        {
            get { return _LawyerID; }
            set { _LawyerID = value; }
        }

        private string _LaywerName;
        public string LawyerName
        {
            get { return _LaywerName; }
            set { _LaywerName = value; }
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

        private string _LicenceNo;
        public string LicenceNo
        {
            get { return _LicenceNo; }
            set { _LicenceNo = value; }
        }

        private string _EntryBy;
        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

	
        private ATTPerson _PersonOBJ=new ATTPerson();
        public ATTPerson PersonOBJ
        {
            get { return _PersonOBJ; }
            set { _PersonOBJ = value; }
        }





        public string AppOrRespLit
        {
            get { return AppOrResp + " " + LitigantID; }
        }
	
	
	
	
    }
}
