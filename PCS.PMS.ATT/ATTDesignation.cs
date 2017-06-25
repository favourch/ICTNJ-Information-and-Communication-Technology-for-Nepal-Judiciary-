using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTDesignation
    {

        private int _DesignationID;
        public int DesignationID
        {
            get { return _DesignationID; }
            set { _DesignationID = value; }
        }

        private string _DesignationName;
        public string DesignationName
        {
            get { return _DesignationName; }
            set { _DesignationName = value; }
        }

        private string _DesignationType;
        public string DesignationType
        {
            get { return _DesignationType; }
            set { _DesignationType = value; }
        }

        private int _ServicePeriod;

        public int ServicePeriod
        {
            get { return _ServicePeriod; }
            set { _ServicePeriod = value; }
        }

        private int _AgeLimit;

        public int AgeLimit
        {
            get { return _AgeLimit; }
            set { _AgeLimit = value; }
        }

        public ATTDesignation(int desgID, string desgName,string desType,int servicePeriod,int ageLimit)
        {
            this.DesignationID = desgID;
            this.DesignationName = desgName;
            this.DesignationType = desType;
            this.ServicePeriod = servicePeriod;
            this.AgeLimit = ageLimit;
        }
        public ATTDesignation(int desgID, string desgName, string desType)
        {
            this.DesignationID = desgID;
            this.DesignationName = desgName;
            this.DesignationType = desType;
        }
    }
}
