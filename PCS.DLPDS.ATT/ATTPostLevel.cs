using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
   public class ATTPostLevel
    {
        private int _PostID;

        public int PostID
        {
            get { return _PostID; }
            set { _PostID = value; }
        }

        private int _PostLevelID;

        public int PostLevelID
        {
            get { return _PostLevelID; }
            set { _PostLevelID = value; }
        }

        private string _PostLevelName;

        public string PostLevelName
        {
            get { return _PostLevelName; }
            set { _PostLevelName = value; }
        }
        private string  _Flag;

        public string  Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
	

       public ATTPostLevel(int postID, int postLevelID, string PostLevelName,string flag)
       {
           this.PostID = postID;
           this.PostLevelID = postLevelID;
           this.PostLevelName = PostLevelName;
           this.Flag = flag;
       }
	
    }
}
