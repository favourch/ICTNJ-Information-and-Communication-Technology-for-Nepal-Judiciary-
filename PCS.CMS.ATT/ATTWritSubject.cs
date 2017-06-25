using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.CMS.ATT
{
    public class ATTWritSubject:ICloneable
    {
        private int _WritSubjectID;
        public int WritSubjectID
        {
            get { return _WritSubjectID; }
            set { _WritSubjectID = value; }
        }

        private string _WritSubjectName;
        public string WritSubjectName
        {
            get { return _WritSubjectName; }
            set { _WritSubjectName = value; }
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

        private string   _Action;
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        private List<ATTWritCategory> _WritCategoryLST=new List<ATTWritCategory>();
        public List<ATTWritCategory> WritCategoryLST
        {
            get { return _WritCategoryLST; }
            set { _WritCategoryLST= value; }
        }

        public object Clone()
        {
            ATTWritSubject WritSubject = (ATTWritSubject)this.MemberwiseClone();
            List<ATTWritCategory> tmpWCLst = new List<ATTWritCategory>();
            foreach (ATTWritCategory obj in this.WritCategoryLST)
            {
                tmpWCLst.Add((ATTWritCategory)obj.Clone());
            }
            WritSubject.WritCategoryLST = tmpWCLst;
            return WritSubject;
        }
	
	
    }
}
