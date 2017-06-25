using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace PCS.OAS.ATT
{
    [Serializable]
  public class ATTInvItemsCategory
    {
        private int _ItemsCategoryID;
        public int ItemsCategoryID
        {
            get { return this._ItemsCategoryID; }
            set { this._ItemsCategoryID = value; }
        }
        private string _ItemsCategoryName;
        public string ItemsCategoryName
        {
            get { return this._ItemsCategoryName.Trim(); }
            set { this._ItemsCategoryName = value; }
        }
        private string _Active;
        public string Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }
        private string _EntryBy = "";
        public string EntryBy
        {
            get { return this._EntryBy.Trim(); }
            set { this._EntryBy = value; }
        }
        private string _Action;
        public string Action
        {
            get { return this._Action; }
            set { this._Action = value; }
        }
       
        public ATTInvItemsCategory()
        {
        }
      private List<ATTInvItemSubCategory> _LstItemSubCategory = new List<ATTInvItemSubCategory>();
      public List<ATTInvItemSubCategory> LstItemSubCategory
        {
            get { return this._LstItemSubCategory; }
            set { this._LstItemSubCategory = value; }
        }
      public ATTInvItemsCategory CreateDeepCopy()
      {
          MemoryStream m = new MemoryStream();
          BinaryFormatter b = new BinaryFormatter();
          b.Serialize(m, this);
          m.Position = 0;
          ATTInvItemsCategory obj = (ATTInvItemsCategory)b.Deserialize(m);
          m.Close();
          m.Dispose();
          return obj;
      }
     

        public ATTInvItemsCategory(int itemCategoryID, string itemsCategoryName,string active, string entryBy,string action)
        {
            this.ItemsCategoryID = itemCategoryID;
            this.ItemsCategoryName = itemsCategoryName;
            this.Active = active;
            this.EntryBy = entryBy;
            this.Action = action;
            
        }
      public ATTInvItemsCategory(int itemCategoryID, string itemsCategoryName)
      {
          this.ItemsCategoryID = itemCategoryID;
          this.ItemsCategoryName = itemsCategoryName;
         

      }

    }
}
