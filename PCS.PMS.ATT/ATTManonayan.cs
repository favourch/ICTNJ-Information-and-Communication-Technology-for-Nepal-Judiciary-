using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
     public class ATTManonayan
    {
        private double _EmpID;
        public double EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }
        private string _ManonayanDate;
        public string ManonayanDate
        {
            get { return _ManonayanDate; }
            set { _ManonayanDate = value; }
        }
        private string _ManonayanPurpose;
        public string ManonayanPurpose
        {
            get { return _ManonayanPurpose; }
            set { _ManonayanPurpose = value; }
        }
        private string _ManonayanDescription;
        public string ManonayanDescription
        {
            get { return _ManonayanDescription; }
            set { _ManonayanDescription = value; }
        }
        private string _ManonayanFromDate;
        public string ManonayanFromDate
        {
            get { return _ManonayanFromDate; }
            set { _ManonayanFromDate = value; }
        }
        private string _ManonayanToDate;
        public string ManonayanToDate
        {
            get { return _ManonayanToDate; }
            set { _ManonayanToDate = value; }
        }
        private double _ManonayanApprovedBY;
        public double ManonayanApprovedBY
        {
            get { return _ManonayanApprovedBY; }
            set { _ManonayanApprovedBY = value; }
        }
        private string _ManonayanApprovedDate;
        public string ManonayanApprovedDate
        {
            get { return _ManonayanApprovedDate; }
            set { _ManonayanApprovedDate = value; }
        }
        private string _ManonayanApprovedYesNo;
        public string ManonayanApprovedYesNo
        {
            get { return _ManonayanApprovedYesNo; }
            set { _ManonayanApprovedYesNo = value; }
        }
        private string _ManonayanEntryBY;
        public string ManonayanEntryBY
        {
            get { return _ManonayanEntryBY; }
            set { _ManonayanEntryBY = value; }
        }

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

         public ATTManonayan()
         {
         }
    }
}
