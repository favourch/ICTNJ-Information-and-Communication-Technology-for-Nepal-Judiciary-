using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.DLPDS.ATT
{
   public class ATTPost
    {
        private int _PostID;

        public int PostID
        {
            get { return _PostID; }
            set { _PostID = value; }
        }

        private string  _PostName;

        public string  PostName
        {
            get { return _PostName; }
            set { _PostName = value; }
        }
        private List<ATTPostLevel> _LstPostLevel=new List<ATTPostLevel>();

        public List<ATTPostLevel> LstPostLevel
        {
            get { return _LstPostLevel; }
            set { _LstPostLevel= value; }
        }
	 

       public ATTPost(int postID, string postName)
       {
           this.PostID = postID;
           this.PostName = postName;
       }
	
	
    }
}
