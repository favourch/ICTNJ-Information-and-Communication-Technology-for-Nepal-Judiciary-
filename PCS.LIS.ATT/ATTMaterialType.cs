using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTMaterialType
    {

        private int _MaterialID;
        public int MaterialID
        {
            get { return this._MaterialID; }
            set { this._MaterialID = value; }
        }


        private string _MaterialTypeName;
        public string MaterialTypeName
        {
            get { return this._MaterialTypeName.Trim(); }
            set { this._MaterialTypeName = value; }
        }

        private string _MaterialEntryBy;
        public string MaterialEntryBy
        {
            get { return this._MaterialEntryBy.Trim(); }
            set { this._MaterialEntryBy = value; }
        }

        private string _MaterialDescription;
        public string MaterialDescription
        {
            get { return this._MaterialDescription.Trim(); }
            set { this._MaterialDescription = value; }
        }

        public ATTMaterialType(int materialID,string materialTypeName,string materialEntryBy,string materialDescription)
        {
            this.MaterialID = materialID;
            this.MaterialTypeName = materialTypeName;
            this.MaterialEntryBy = materialEntryBy;
            this.MaterialDescription = materialDescription;
          
        }

        
    }
}
