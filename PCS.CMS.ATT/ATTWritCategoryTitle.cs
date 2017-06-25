using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTWritCategoryTitle:ICloneable
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

        private string _WritSubjectCatTitleName;
        public string WritSubjectCatTitleName
        {
            get { return _WritSubjectCatTitleName; }
            set { _WritSubjectCatTitleName = value; }
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
            ATTWritCategoryTitle WritCatTitle = (ATTWritCategoryTitle)this.MemberwiseClone();
            List<ATTWritCategorySubTitle> tmpWCSTLst = new List<ATTWritCategorySubTitle>();
            foreach (ATTWritCategorySubTitle obj in this.WritCategorySubTitleLST)
            {
                tmpWCSTLst.Add((ATTWritCategorySubTitle)obj.Clone());
            }
            WritCatTitle.WritCategorySubTitleLST = tmpWCSTLst;
            return WritCatTitle;
        }

        private List<ATTWritCategorySubTitle> _WritCategorySubTitleLST = new List<ATTWritCategorySubTitle>();
        public List<ATTWritCategorySubTitle> WritCategorySubTitleLST
        {
            get { return _WritCategorySubTitleLST; }
            set { _WritCategorySubTitleLST = value; }
        }
    }
}
