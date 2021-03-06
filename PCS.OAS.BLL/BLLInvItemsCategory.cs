using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PCS.FRAMEWORK;
using PCS.OAS.ATT;
using PCS.OAS.DLL;
using PCS.SECURITY.ATT;

namespace PCS.OAS.BLL
{
  public  class BLLInvItemsCategory
    {
      
    public static bool AddUpdateItemCategory(ATTInvItemsCategory itemsCategory)
      {
          try
          {
              return DLLInvItemsCategory.AddUpdateItemCategory(itemsCategory);
          }
          catch (Exception ex)
          {
              throw new Exception("Error occur while adding and updating ItemCategory" +ex.Message);
          }
      }

            public static List<ATTInvItemsCategory> GetItemCategory(int? itemCategoryID,string itemCatActive, string itemSubCatActive, bool ContainsDefault)
      {
          List<ATTInvItemsCategory> lstItemCategoryList = new List<ATTInvItemsCategory>();
          //List<ATTInvItemsSubCategory> lstItemsSubCategory = BLLInvItemsSubCategory.GetItemSubCategory(itemCategoryID, itemSubCatActive, ContainsDefault);

          try
          {
              foreach (DataRow row in DLLInvItemsCategory.GetItemCategory(itemCategoryID, itemCatActive).Rows)
              {
                  ATTInvItemsCategory obj = new ATTInvItemsCategory(int.Parse(row["ITEMS_CATEGORY_ID"].ToString()), row["ITEMS_CATEGORY_NAME"].ToString());
                  obj.LstItemSubCategory = BLLInvItemsSubCategory.GetItemSubCategory(obj.ItemsCategoryID, itemSubCatActive, ContainsDefault); //lstItemsSubCategory.FindAll(delegate(ATTInvItemsSubCategory subCat) { return subCat.ItemsCategoryID == obj.ItemCategoryID; });
                  lstItemCategoryList.Add(obj);
              }
              if (lstItemCategoryList.Count > 0 && ContainsDefault == true)
              {
                  ATTInvItemsCategory def = new ATTInvItemsCategory();
                  def.ItemsCategoryID = -1;
                  def.ItemsCategoryName = "----छान्नुहोस----";
                  lstItemCategoryList.Insert(0, def);
              }
              return lstItemCategoryList;
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public static List<ATTInvItemsCategory> GetItemCategoryList(int? itemCategoryID,string active)
      {
          List<ATTInvItemsCategory> lstitemCategoryList = new List<ATTInvItemsCategory>();

          try
          {
              foreach (DataRow row in DLLInvItemsCategory.GetItemCategoryTable(itemCategoryID,active).Rows)
              {
                  ATTInvItemsCategory itemsCategory = new ATTInvItemsCategory();
                  itemsCategory.ItemsCategoryID = int.Parse(row["items_category_id"].ToString());
                  itemsCategory.ItemsCategoryName = row["items_category_name"].ToString();
                  itemsCategory.Active = row["active"].ToString();
                  itemsCategory.Action = "";
                  //itemsCategory.Active = "Y";
                  //itemsCategory.EntryBy = row["entry_by"].ToString();
                  itemsCategory.LstItemSubCategory = BLLInvItemsSubCategory.GetItemSubCategoryList(itemsCategory.ItemsCategoryID,itemsCategory.Active);
                  lstitemCategoryList.Add(itemsCategory);
              }
              return lstitemCategoryList;
          }
          catch (Exception ex)
          {
              throw new Exception("Error occur while selecting Item Category"+ex.Message);
          }
      }

      public static List<ATTInvItemsCategory> GetItemCategoryList(int? itemCategoryID, string itemCatActive, string itemSubCatActive, bool ContainsDefault)
      {
          List<ATTInvItemsCategory> lstItemCategoryList = new List<ATTInvItemsCategory>();
          //List<ATTInvItemsSubCategory> lstItemsSubCategory = BLLInvItemsSubCategory.GetItemSubCategory(itemCategoryID, itemSubCatActive, ContainsDefault);

          try
          {
              foreach (DataRow row in DLLInvItemsCategory.GetItemCategory(itemCategoryID, itemCatActive).Rows)
              {
                  ATTInvItemsCategory obj = new ATTInvItemsCategory(int.Parse(row["ITEMS_CATEGORY_ID"].ToString()), row["ITEMS_CATEGORY_NAME"].ToString());
                  obj.LstItemSubCategory = BLLInvItemsSubCategory.GetItemSubCategory(obj.ItemsCategoryID, itemSubCatActive, ContainsDefault); //lstItemsSubCategory.FindAll(delegate(ATTInvItemsSubCategory subCat) { return subCat.ItemsCategoryID == obj.ItemCategoryID; });
                  lstItemCategoryList.Add(obj);
              }
              if (lstItemCategoryList.Count > 0 && ContainsDefault == true)
              {
                  ATTInvItemsCategory def = new ATTInvItemsCategory();
                  def.ItemsCategoryID = -1;
                  def.ItemsCategoryName = "----छान्नुहोस----";
                  lstItemCategoryList.Insert(0, def);
              }
              return lstItemCategoryList;
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
       



    }
}


