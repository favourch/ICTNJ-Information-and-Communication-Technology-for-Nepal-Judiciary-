using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTMyaadType
    {
        private int? _MyaadTypeID;
        public int? MyaadTypeID
        {
            get { return _MyaadTypeID; }
            set { _MyaadTypeID = value; }
        }

        private string _MyaadTypeName;
        public string MyaadTypeName
        {
            get { return _MyaadTypeName; }
            set { _MyaadTypeName = value; }
        }

        private string _Litigant;
        public string Litigant
        {
            get { return _Litigant; }
            set { _Litigant = value; }
        }

        private string _Attorney;
        public string Attorney
        {
            get { return _Attorney; }
            set { _Attorney = value; }
        }

        private string _Witness;
        public string Witness
        {
            get { return _Witness; }
            set { _Witness = value; }
        }

       

        public string LitAttWit
        {
            get { return this.Litigant+","+this.Attorney+","+this.Witness; }
            
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

        public ATTMyaadType()
        { }
        public ATTMyaadType(int myaadTypeID,string myaadTypeName,string active)
        {
            this.MyaadTypeID = myaadTypeID;
            this.MyaadTypeName = myaadTypeName;
            this.Active = active;
        }
	
	
	
	
	
	
    }
}
