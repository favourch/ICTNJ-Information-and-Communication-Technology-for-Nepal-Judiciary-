using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTLitigantandAttorney
    {
        private double? _CaseID;
        public double? CaseID
        {
            get { return _CaseID; }
            set { _CaseID = value; }
        }

        private double? _LitigantID;
        public double? LitigantID
        {
            get { return _LitigantID; }
            set { _LitigantID = value; }
        }

        private double? _AttorneyID;
        public double? AttorneyID
        {
            get { return _AttorneyID; }
            set { _AttorneyID = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _RDGender;
        public string RDGender
        {
            get
            {
                if (Gender == "M")
                    return "पूरु्ष";
                else if (Gender == "F")
                    return "महिला";
                else
                    return "ञन्य";
            }
        }
	
        private string _DOB;
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
       public ATTLitigantandAttorney()
        {
        }
	
    }
}
