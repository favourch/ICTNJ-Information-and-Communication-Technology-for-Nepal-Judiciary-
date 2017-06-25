using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.PMS.ATT
{
    public class ATTPostingType
    {
        private int _PostingTypeID;
        public int PostingTypeID
        {
            get { return _PostingTypeID; }
            set { _PostingTypeID = value; }
        }

        private string _PostingTypeName;
        public string PostingTypeName
        {
            get { return _PostingTypeName; }
            set { _PostingTypeName = value; }
        }

        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public ATTPostingType(int PostingTypeID, string PostingTypeName, string active)
        {
            this.PostingTypeID = PostingTypeID;
            this.PostingTypeName = PostingTypeName;
            this.Active = active;
        }
    }
}
