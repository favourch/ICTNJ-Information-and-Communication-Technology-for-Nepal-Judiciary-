using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    public class ATTMeetingResources
    {
        private int _ResourceID;

        public int ResourceID
        {
            get { return _ResourceID; }
            set { _ResourceID = value; }
        }

        private string _ResourceName;

        public string ResourceName
        {
            get { return _ResourceName; }
            set { _ResourceName = value; }
        }


        private string _ResourceDescription;

        public string ResourceDescription
        {
            get { return _ResourceDescription; }
            set { _ResourceDescription = value; }
        }

        private string _Action;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
	

        public ATTMeetingResources()
        {
        }
	
    }
}
