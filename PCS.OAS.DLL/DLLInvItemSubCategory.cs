using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

using PCS.OAS.ATT;
using PCS.COREDL;
using PCS.FRAMEWORK;



namespace PCS.OAS.DLL
{
  public  class DLLInvItemSubCategory
    {
      public static DataTable GetItemSubCategoryTable(int? itemsCategoryID,string active)
      {
   
          string selectsp = "sp_inv_get_items_sub_category";
          OracleParameter[] paramarray = new OracleParameter[3];
          paramarray[0] = Utilities.GetOraParam(":p_items_category_id",itemsCategoryID,OracleDbType.Int64, ParameterDirection.Input);
          paramarray[1] = Utilities.GetOraParam(":p_active",active, OracleDbType.Varchar2, ParameterDirection.Input);
          paramarray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.InputOutput);
          try
          {
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, selectsp, Module.OAS,paramarray).Tables[0];
          }
          catch (Exception ex)
          {
              throw new Exception("Error ocur While getting itemsubcategory" +ex.Message);
             
          }
      }
      public static bool AddUpdateDeleteItemSubCategory(List<ATTInvItemSubCategory> lstItemSubCategory, int itemCategoryID, OracleTransaction oraTran)
      {
          string sp = "";
          List<ATTInvItemSubCategory> lst = lstItemSubCategory.FindAll(
                                                        delegate(ATTInvItemSubCategory obj)
                                                        {
                                                            return obj.Action != null;
                                                        }
                                                        );
          List<OracleParameter> paramArray = new List<OracleParameter>();
          
          try
          {
              foreach(ATTInvItemSubCategory itemSubCategory in lst)
              {
                  if (itemSubCategory.Action == "D")
                  {
                      sp = "SP_INV_DEL_ITEMS_SUB_CATEGORY";
                      paramArray.Add(Utilities.GetOraParam(":p_items_category_id",itemCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                      paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id",itemSubCategory.ItemsSubCategoryID,OracleDbType.Varchar2,ParameterDirection.InputOutput));
                      SqlHelper.ExecuteNonQuery(oraTran, CommandType.StoredProcedure, sp, paramArray.ToArray());
                      itemSubCategory.ItemsCategoryID = itemCategoryID;
                      paramArray.Clear();

                  }

                  else
                  {
                      if (itemSubCategory.Action == "A")
                      {
                          sp = "sp_inv_add_items_sub_category";
                      }
                      
                      else if(itemSubCategory.Action =="E") 
                      {
                          sp = "sp_inv_EDIT_items_sub_category";
                      }
                      paramArray.Add(Utilities.GetOraParam(":p_items_category_id", itemCategoryID,OracleDbType.Int64, ParameterDirection.Input));
                      paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id",itemSubCategory.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.InputOutput));
                      paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_name",itemSubCategory.ItemsSubCategoryName, OracleDbType.Varchar2, ParameterDirection.Input));
                      paramArray.Add(Utilities.GetOraParam(":p_active",itemSubCategory.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                      paramArray.Add(Utilities.GetOraParam(":p_entry_by",itemSubCategory.EntryBy,OracleDbType.Varchar2, ParameterDirection.Input));
                      SqlHelper.ExecuteNonQuery(oraTran, CommandType.StoredProcedure, sp, paramArray.ToArray());
                      itemSubCategory.ItemsCategoryID = itemCategoryID;
                      paramArray.Clear();
                  }
              }
              return true;

          }
          catch(Exception ex)
          {
              throw new Exception("Error occur at operation" +ex.Message);
          }
 
      }
      public static DataTable GetItemsSubCategory(int? itemCategoryID, string active)
      {
          List<OracleParameter> param = new List<OracleParameter>();
          param.Add(Utilities.GetOraParam(":p_items_category_id", itemCategoryID, OracleDbType.Int64, ParameterDirection.Input));
          param.Add(Utilities.GetOraParam(":p_active", active, OracleDbType.Varchar2, ParameterDirection.Input));
          param.Add(Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));
          GetConnection getConn = new GetConnection();
          try
          {
              OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
              SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, "sp_inv_get_items_sub_category", param.ToArray());
              OracleDataReader reader = ((OracleRefCursor)param[2].Value).GetDataReader();
              DataTable tbl = new DataTable();
              tbl.Load(reader, LoadOption.OverwriteChanges);

              return tbl;
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally
          {
              getConn.CloseDbConn();
          }
      } 
  }
}
