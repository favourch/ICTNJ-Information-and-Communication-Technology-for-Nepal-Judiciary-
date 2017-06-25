using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public  class ATTWritCategory:ICloneable
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

        private string _WritSubjectCatName;
        public string WritSubjectCatName
        {
            get { return _WritSubjectCatName; }
            set { _WritSubjectCatName = value; }
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
            ATTWritCategory WritCategory = (ATTWritCategory)this.MemberwiseClone();
            List<ATTWritCategoryTitle> tmpWCTLst = new List<ATTWritCategoryTitle>();
            foreach (ATTWritCategoryTitle obj in this.WritCategoryTitleLST)
            {
                tmpWCTLst.Add((ATTWritCategoryTitle) obj.Clone());
            }
            WritCategory.WritCategoryTitleLST = tmpWCTLst;
            return WritCategory;
        }

        private List<ATTWritCategoryTitle> _WritCategoryTitleLST= new List<ATTWritCategoryTitle>();
        public List<ATTWritCategoryTitle> WritCategoryTitleLST
        {
            get { return _WritCategoryTitleLST; }
            set { _WritCategoryTitleLST = value; }
        }
	

	
    }
}
