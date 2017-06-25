using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTDesignationLevel
    {
        private int _LevelID;
        public int LevelID
        {
            get
            {
                return this._LevelID;
            }
            set
            {
                this._LevelID=value;
            }
        }
        private string _LevelName;
        public string LevelName
        {
            get
            {
                return this._LevelName;
            }
            set
            {
                this._LevelName = value;
            }
        }
        private string _EntryBy="";
        public string EntryBy
        {
            get
            {
                return this._EntryBy;
            }
            set
            {
                this._EntryBy = value;
            }
        }
        public DateTime _EntryOn;
        public DateTime EntryOn
        {
            get
            {
                return this._EntryOn;
            }
            set
            {
                this._EntryOn = value;
            }
        }

        public ATTDesignationLevel()
        {
        }

        public ATTDesignationLevel(int levelID, string levelName, string entryBy)
        {
            this.LevelID = levelID;
            this.LevelName = levelName;
            this.EntryBy = entryBy;
        }

        public ATTDesignationLevel(int levelID, string levelName)
        {
            this.LevelID = levelID;
            this.LevelName = levelName;
        }
    }
}
