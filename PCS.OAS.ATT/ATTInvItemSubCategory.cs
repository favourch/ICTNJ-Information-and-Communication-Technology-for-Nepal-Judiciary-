using System;
using System.Collections.Generic;
using System.Text;

namespace PCS.OAS.ATT
{
    [Serializable]
 public class ATTInvItemSubCategory
    {
  
        private int _ItemsCategoryID;
        public int ItemsCategoryID
        {
            get { return this._ItemsCategoryID; }
            set { this._ItemsCategoryID = value; }
        }
        public int _ItemsSubCategoryID;
        public int ItemsSubCategoryID
        {
            get{return this._ItemsSubCategoryID;}
            set { this._ItemsSubCategoryID = value; }
        }
        private string _ItemsSubCategoryName;
        public string ItemsSubCategoryName
        {
            get { return this._ItemsSubCategoryName.Trim(); }
            set { this._ItemsSubCategoryName = value; }
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
    
   public ATTInvItemSubCategory()
   {
   }
     public ATTInvItemSubCategory(int itemsCategoryID, int itemsSubCategoryID, string itemsSubCategoryName, string active, string entryBy,string action)
     {
         this.ItemsCategoryID = itemsCategoryID;
         this.ItemsSubCategoryID = itemsSubCategoryID;
         this.ItemsSubCategoryName = itemsSubCategoryName;
         this.Active = active;
         this.EntryBy = entryBy;
         this.Action = action;
 
     }
     public ATTInvItemSubCategory(int itemsCategoryID, int itemsSubCategoryID, string itemsSubCategoryName, string active)
     {
         this.ItemsCategoryID = itemsCategoryID;
         this.ItemsSubCategoryID = itemsSubCategoryID;
         this.ItemsSubCategoryName = itemsSubCategoryName;
         this.Active = active;
        

     }
        

    }
}
