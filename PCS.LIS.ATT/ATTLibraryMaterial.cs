using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.LIS.ATT
{
    public class ATTLibraryMaterial
    {
        private int _OrgID;
        public int OrgID
        {
            get { return this._OrgID; }
            set { this._OrgID = value; }
        }

        private int _LibraryID;
        public int LibraryID
        {
            get { return this._LibraryID; }
            set { this._LibraryID = value; }
        }

        private long _LMaterialID;
        public long LMaterialID
        {
            get { return this._LMaterialID; }
            set { this._LMaterialID = value; }
        }

        private int _LibraryMaterialType;
        public int LibraryMaterialType
        {
            get { return this._LibraryMaterialType; }
            set { this._LibraryMaterialType = value; }
        }

        private int _LibraryMaterialCategory;
        public int LibraryMaterialCategory
        {
            get { return this._LibraryMaterialCategory; }
            set { this._LibraryMaterialCategory = value; }
        }

        private string _CallNo = "";
        public string CallNo
        {
            get { return this._CallNo.Trim(); }
            set { this._CallNo = value; }
        }

        private string _CorporateBody = "";
        public string CorporateBody
        {
            get { return this._CorporateBody.Trim(); }
            set { this._CorporateBody = value; }
        }

        private string _Title = "";
        public string Title
        {
            get { return this._Title.Trim(); }
            set { this._Title = value; }
        }

        private string _SeriesStatement = "";
        public string SeriesStatement
        {
            get { return this._SeriesStatement.Trim(); }
            set { this._SeriesStatement = value; }
        }

        private string _Note = "";
        public string Note
        {
            get { return this._Note.Trim(); }
            set { this._Note = value; }
        }

        private string _BoardSubjectHeading = "";
        public string BoardSubjectHeading
        {
            get { return this._BoardSubjectHeading.Trim(); }
            set { this._BoardSubjectHeading = value; }
        }

        private string _GeoDescription = "";
        public string GeoDescription
        {
            get { return this._GeoDescription.Trim(); }
            set { this._GeoDescription = value; }
        }

        private int _LanguageID;
        public int LanguageID
        {
            get { return this._LanguageID; }
            set { this._LanguageID = value; }
        }

        private string _PhysicalDescription = "";
        public string PhysicalDescription
        {
            get { return this._PhysicalDescription.Trim(); }
            set { this._PhysicalDescription = value; }
        }

        private int _PublisherID;
        public int PublisherID
        {
            get { return this._PublisherID; }
            set { this._PublisherID = value; }
        }

        private byte[] _ContentFile = null;
        public byte[] ContentFile
        {
            get { return this._ContentFile; }
            set { this._ContentFile = value; }
        }

        private string _CFileType = "";
        public string CFileType
        {
            get { return this._CFileType.Trim(); }
            set { this._CFileType = value; }
        }

        private List<ATTLibraryMaterialAuthor> _LstLMAuthor = new List<ATTLibraryMaterialAuthor>();
        public List<ATTLibraryMaterialAuthor> LstLMAuthor
        {
            get { return this._LstLMAuthor; }
            set { this._LstLMAuthor = value; }
        }

        private List<ATTLibraryMaterialKeyword> _LstLMKeyword = new List<ATTLibraryMaterialKeyword>();
        public List<ATTLibraryMaterialKeyword> LstLMKeyword
        {
            get { return this._LstLMKeyword; }
            set { this._LstLMKeyword = value; }
        }

        private List<ATTLibraryMaterialCopy> _LstLMCopy = new List<ATTLibraryMaterialCopy>();
        public List<ATTLibraryMaterialCopy> LstLMCopy
        {
            get { return this._LstLMCopy; }
            set { this._LstLMCopy = value; }
        }

        public int CopyCount
        {
            get { return this.LstLMCopy.Count; }
        }

        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }

        private DateTime _EntryOn;
        public DateTime EntryOn
        {
            get { return this._EntryOn.Date; }
            set { this._EntryOn = value; }
        }

        private string _Action = "";
        public string Action
        {
            get { return this._Action.Trim(); }
            set { this._Action = value; }
        }
    }
}
