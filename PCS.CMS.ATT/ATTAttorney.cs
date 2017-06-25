using System;
using System.Collections.Generic;
using System.Text;

using PCS.COMMON.ATT;

namespace PCS.CMS.ATT
{
    public class ATTAttorney
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

        private double _PersonID;
        public double PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }

        private double? _AttorneyID;
        public double? AttorneyID
        {
            get { return _AttorneyID; }
            set { _AttorneyID = value; }
        }


        private int _AttorneyTypeID;
        public int AttorneyTypeID
        {
            get { return _AttorneyTypeID; }
            set { _AttorneyTypeID = value; }
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

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
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

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private ATTPerson _Person;

        public ATTPerson Person
        {
            get { return _Person; }
            set { _Person = value; }
        }





        private string _CaseNo;
        public string CaseNo
        {
            get { return _CaseNo; }
            set { _CaseNo = value; }
        }

        private string _RegistrationNo;
        public string RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }

        private string _LitigantName;
        public string LitigantName
        {
            get { return _LitigantName; }
            set { _LitigantName = value; }
        }

        private string _AttorneyName;
        public string AttorneyName
        {
            get { return _AttorneyName; }
            set { _AttorneyName = value; }
        }

        private string _AttorneyType;
        public string AttorneyType
        {
            get { return _AttorneyType; }
            set { _AttorneyType = value; }
        }


        private string _LitigantGender;
        public string LitigantGender
        {
            get { return _LitigantGender; }
            set { _LitigantGender = value; }
        }

        private string _LitigantDOB;
        public string LitigantDOB
        {
            get { return _LitigantDOB; }
            set { _LitigantDOB = value; }
        }

        private string _AttorneyGender;
        public string AttorneyGender
        {
            get { return _AttorneyGender; }
            set { _AttorneyGender = value; }
        }

        private string _AttorneyDOB;
        public string AttorneyDOB
        {
            get { return _AttorneyDOB; }
            set { _AttorneyDOB = value; }
        }
	
	
        
	
        
        public ATTAttorney()
        { }


    }
}
