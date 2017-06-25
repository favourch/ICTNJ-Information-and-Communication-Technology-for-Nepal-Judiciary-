using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTWritCategorySubTitle:ICloneable
    {
        private int _WritSubjectID;
        public int WritSubjectID
        {
            get { return _WritSubjectID; }
            set { _WritSubjectID = value; }
        }

        private int _WritSubjectCatID;
        public int WritSubjectCatID
        {
            get { return _WritSubjectCatID; }
            set { _WritSubjectCatID = value; }
        }

        private int _WritSubjectCatTitleID;
        public int WritSubjectCatTitleID
        {
            get { return _WritSubjectCatTitleID; }
            set { _WritSubjectCatTitleID = value; }
        }

        private int _WritSubjectCatSubTitleID;
        public int WritSubjectCatSubTitleID
        {
            get { return _WritSubjectCatSubTitleID; }
            set { _WritSubjectCatSubTitleID = value; }
        }

        private string _WritSubjectCatSubTitleName;
        public string WritSubjectCatSubTitleName
        {
            get { return _WritSubjectCatSubTitleName; }
            set { _WritSubjectCatSubTitleName = value; }
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

        private string _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
