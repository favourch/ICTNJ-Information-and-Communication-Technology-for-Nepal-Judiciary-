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
  public class BLLInvItemsSubCategory
    {
      public static List<ATTInvItemSubCategory> GetItemSubCategoryList(int? itemCategoryID,string active)
      {
          List<ATTInvItemSubCategory> lstItemSubcategoryList = new List<ATTInvItemSubCategory>();

          try
          {
              foreach (DataRow row in DLLInvItemSubCategory.GetItemSubCategoryTable(itemCategoryID,active).Rows)
              {
                  ATTInvItemSubCategory obj = new ATTInvItemSubCategory();

                  obj.ItemsCategoryID = int.Parse(row["items_category_id"].ToString());
                  obj.ItemsSubCategoryID = int.Parse(row["items_sub_category_id"].ToString());
                  obj.ItemsSubCategoryName = row["items_sub_category_name"].ToString();
                  obj.Active = row["active"].ToString();

                  lstItemSubcategoryList.Add(obj);
              }

              return lstItemSubcategoryList;
          }
          catch (Exception ex)
          {
              throw new Exception("Error occur while selecting ItemsSubCategory:"+ex.Message);
          }
      }

      public static List<ATTInvItemSubCategory> GetItemSubCategory(int? itemCategoryID, string active, bool ContainsDefault)
      {
          List<ATTInvItemSubCategory> lst = new List<ATTInvItemSubCategory>();
          try
          {
              foreach (DataRow row in DLLInvItemSubCategory.GetItemsSubCategory(itemCategoryID, active).Rows)
              {
                  ATTInvItemSubCategory objItemSubCategory = new ATTInvItemSubCategory(
                                   int.Parse(row["items_category_id"].ToString()),
                                   int.Parse(row["items_sub_category_id"].ToString()),
                                   row["items_sub_category_name"].ToString(),
                                   row["active"].ToString());
                  lst.Add(objItemSubCategory);
              }
              if (lst.Count > 0 && ContainsDefault == true)
              {
                  ATTInvItemSubCategory def = new ATTInvItemSubCategory();
                  def.ItemsSubCategoryID = -1;
                  def.ItemsSubCategoryName = "----छान्नुहोस----";
                  lst.Insert(0, def);
              }
              return lst;
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }
    }
}
