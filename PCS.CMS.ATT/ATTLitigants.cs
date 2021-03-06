using System;
using System.Collections.Generic;
using System.Text;
using PCS.COMMON.ATT;

namespace PCS.CMS.ATT
{
    public class ATTLitigants
    {
        private double _CaseID;
        public double CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private double _LitigantID;
        public double LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private string _LitigantType;
        public string LitigantType
        {
            get { return _LitigantType; }
            set { _LitigantType = value; }
        }

        

        private int? _LitigantSubTypeID;
        public int? LitigantSubTypeID
        {
            get { return _LitigantSubTypeID; }
            set { _LitigantSubTypeID = value; }
        }

        private string _LitigantName;
        public string LitigantName
        {
            get { return _LitigantName; }
            set { this._LitigantName = value; }
        }

        private string _DiaplayName;
        public string DisplayName
        {
            get { return _DiaplayName; }
            set { _DiaplayName = value; }
        }

        private string _SNo;
        public string SNo
        {
            get { return _SNo; }
            set { _SNo = value; }
        }

        private string _IsPrisoned;
        public string IsPrisoned
        {
            get { return _IsPrisoned; }
            set { _IsPrisoned = value; }
        }

        private string _EntityType;
        public string EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }
	

        public string EntityTypeName
        {
            get { return EntityType == "P" ? "व्यक्ति" : "संस्था"; }
            
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

	

        private ATTPerson _PersonOBJ= new ATTPerson();
        public ATTPerson PersonOBJ
        {
            get { return _PersonOBJ; }
            set { _PersonOBJ = value; }
        }

        private List<ATTLitigantPrisonDetails> _LitigantPrisonDetailsLST=new List<ATTLitigantPrisonDetails>();
        public List<ATTLitigantPrisonDetails> LitigantPrisonDetailsLST
        {
            get { return _LitigantPrisonDetailsLST; }
            set { _LitigantPrisonDetailsLST = value; }
        }


        private List<ATTCaseLaywer> _CaseLawyerLST=new List<ATTCaseLaywer>();
        public List<ATTCaseLaywer> CaseLawyerLST
        {
            get { return _CaseLawyerLST; }
            set { _CaseLawyerLST = value; }
        }

	

	

	

	
	
	
    }
}
