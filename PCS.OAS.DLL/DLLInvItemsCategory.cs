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
  public  class DLLInvItemsCategory
    {
       
      public static bool AddUpdateItemCategory(ATTInvItemsCategory itemsCategory)
      {
          string sp = "";

          if (itemsCategory.Action == "A")
              sp = "sp_inv_add_items_category";
          else if (itemsCategory.Action == "E")
              sp = "sp_inv_edit_items_category";

          List<OracleParameter> paramArray = new List<OracleParameter>();
          paramArray.Add(Utilities.GetOraParam(":p_items_category_id", itemsCategory.ItemsCategoryID, OracleDbType.Int64, System.Data.ParameterDirection.InputOutput));
          paramArray.Add(Utilities.GetOraParam(":p_items_category_name", itemsCategory.ItemsCategoryName, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_active", itemsCategory.Active, OracleDbType.Varchar2, ParameterDirection.Input));
          paramArray.Add(Utilities.GetOraParam(":p_entry_by", itemsCategory.EntryBy, OracleDbType.Varchar2, System.Data.ParameterDirection.Input));


          GetConnection GetConn = new GetConnection();
          OracleTransaction Tran = GetConn.GetDbConn(Module.OAS).BeginTransaction();
          try
          {
              SqlHelper.ExecuteNonQuery(Tran, System.Data.CommandType.StoredProcedure, sp, paramArray.ToArray());
              itemsCategory.ItemsCategoryID = int.Parse(paramArray[0].Value.ToString());
              DLLInvItemSubCategory.AddUpdateDeleteItemSubCategory(itemsCategory.LstItemSubCategory,itemsCategory.ItemsCategoryID, Tran);
              Tran.Commit();
              return true;
          }
          catch (Exception ex)
          {
              Tran.Rollback();
              throw ex;
          }
          finally
          {
              GetConn.CloseDbConn();
          }
      }
      
 
      public static DataTable GetItemCategoryTable(int? itemCategoryID,string active)
      {
          string SelectSP;
          SelectSP = "sp_inv_get_items_category"; 

          OracleParameter[] paramArray = new OracleParameter[3];
          paramArray[0] = Utilities.GetOraParam(":p_items_category_id", itemCategoryID, OracleDbType.Int64, ParameterDirection.Input);
          paramArray[1] = Utilities.GetOraParam(":p_active", active, OracleDbType.Varchar2, ParameterDirection.Input);
          paramArray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);

          try
              {
                  return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.OAS, paramArray).Tables[0];
              }
              catch (Exception ex)
              {
                  throw ex;
              }
         
      }

      public static DataTable GetItemCategory(int? itemCategoryID, string itemCatActive)
      {
          string SelectSP;
          SelectSP = "sp_inv_get_items_category"; //p_items_category_id, p_active, p_rc

          OracleParameter[] paramArray = new OracleParameter[3];
          paramArray[0] = Utilities.GetOraParam(":p_items_category_id", itemCategoryID, OracleDbType.Int64, ParameterDirection.Input);
          paramArray[1] = Utilities.GetOraParam(":p_active", itemCatActive, OracleDbType.Varchar2, ParameterDirection.Input);
          paramArray[2] = Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output);

          GetConnection getConn = new GetConnection();
          try
          {
              OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
              SqlHelper.ExecuteNonQuery(DBConn, CommandType.StoredProcedure, SelectSP, paramArray);

              OracleDataReader reader = ((OracleRefCursor)paramArray[2].Value).GetDataReader();

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
