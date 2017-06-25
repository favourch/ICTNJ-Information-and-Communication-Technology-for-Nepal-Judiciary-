using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.COMMON.ATT
{
   public class ATTDegreeLevel
    {
        private int _DegreeLevelID;

        public int DegreeLevelID
        {
            get { return _DegreeLevelID; }
            set { _DegreeLevelID = value; }
        }
        private string  _DegreeLevelName;

        public string  DegreeLevelName
        {
            get { return _DegreeLevelName; }
            set { _DegreeLevelName = value; }
        }

        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
	

        private List<ATTDegree> _LstDegree=new List<ATTDegree>();
        public List<ATTDegree> LstDegree
        {
            get { return _LstDegree; }
            set { _LstDegree= value; }
        }
	

       public ATTDegreeLevel(int degreeLevelID, string degreeLevelName,string active,string entryBy)
       {
           this.DegreeLevelID = degreeLevelID;
           this.DegreeLevelName = degreeLevelName;
           this.Active = active;
           this.EntryBy = entryBy;
       }

       public ATTDegreeLevel(int degreeLevelID, string degreeLevelName, string active)
       {
           this.DegreeLevelID = degreeLevelID;
           this.DegreeLevelName = degreeLevelName;
           this.Active = active;           
       }
    }
}
