using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
   public class ATTDegree
    {
        private int _DegreeID;

        public int DegreeID
        {
            get { return _DegreeID; }
            set { _DegreeID = value; }
        }

        private int _DegreeLevelID;

        public int DegreeLevelID
        {
            get { return _DegreeLevelID; }
            set { _DegreeLevelID = value; }
        }

        private string  _DegreeName;

        public string  DegreeName
        {
            get { return _DegreeName; }
            set { _DegreeName = value; }
        }

       private string _Active;
       public string Active
       {
           get { return this._Active; }
           set { this._Active = value; }
       }
       private string _Flag;

       public string Flag
       {
           get { return _Flag; }
           set { _Flag = value; }
       }
       private string _EntryBy;

       public string EntryBy
       {
           get { return _EntryBy; }
           set { _EntryBy = value; }
       }
	
       public ATTDegree(int degreeID, int degreeLevelID, string degreeName,string active,string flag)
       {
           this.DegreeID = degreeID;
           this.DegreeLevelID = degreeLevelID;
           this.DegreeName = degreeName;
           this.Active = active;
           this.Flag = flag;
       }
       public ATTDegree(int degreeID, int degreeLevelID, string degreeName, string active)
       {
           this.DegreeID = degreeID;
           this.DegreeLevelID = degreeLevelID;
           this.DegreeName = degreeName;
           this.Active = active;
       }
       
	
    }
}
