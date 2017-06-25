using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PCS.FRAMEWORK;
using PCS.COREDL;
using PCS.OAS.ATT;

namespace PCS.OAS.DLL
{
    public class DLLInvOrgItemsPrice
    {
        public static bool SaveOrgItemsPrice(List<ATTInvOrgItemsPrice> lstItemsPrice)
        {
            GetConnection getConn = new GetConnection();
            OracleConnection DBConn = getConn.GetDbConn(Module.OAS);
            OracleTransaction Tran = DBConn.BeginTransaction();
            try
            {

                foreach (ATTInvOrgItemsPrice obj in lstItemsPrice)
                {
                    List<OracleParameter> paramArray = new List<OracleParameter>();

                    paramArray.Add(Utilities.GetOraParam(":p_org_id", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_category_id", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_items_id", obj.ItemsID, OracleDbType.Int64, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_from_date", obj.FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_to_date", obj.ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_unit_price", obj.UnitPrice, OracleDbType.Double, ParameterDirection.Input));
                    paramArray.Add(Utilities.GetOraParam(":p_entry_by", obj.EntryBy, OracleDbType.Varchar2, ParameterDirection.Input));

                    if (obj.Action == "A") //New Add
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_add_org_items_price", paramArray.ToArray());
                    else if (obj.Action == "E") //Update
                        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "sp_inv_edit_org_items_price", paramArray.ToArray());
                    

                    paramArray.Clear();
                }
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
                getConn.CloseDbConn();
            }
        }
        public static DataTable GetOrgInvItemsPrice(int orgID,int ? itemCatID,int ? itemSubCatID)
        {
            try
            {
                string SelectSP = "sp_inv_get_org_items_price ";
               


                List<OracleParameter> paramArray = new List<OracleParameter>();
                paramArray.Add(Utilities.GetOraParam(":p_org_id", orgID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":p_items_category_id", itemCatID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":p_items_sub_category_id", itemSubCatID, OracleDbType.Int64, ParameterDirection.Input));
                paramArray.Add(Utilities.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));



                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, SelectSP, Module.OAS, paramArray.ToArray()).Tables[0];
                              
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOrgInvItemsPrice(ATTInvOrgItemsPrice obj)
        {
            string strSql = "SELECT * FROM VW_INV_ITEMS_ORG_PRICES WHERE 1=1";
            List<OracleParameter> paramArray = new List<OracleParameter>();
            try
            {
                if (obj.OrgID != null)
                {
                    strSql += " AND ORG_ID=:P_ORG_ID";
                    paramArray.Add(Utilities.GetOraParam(":P_ORG_ID", obj.OrgID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (obj.ItemsCategoryID != null)
                {
                    strSql += " AND ITEMS_CATEGORY_ID=:P_ITEMS_CAT_ID";
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_CAT_ID", obj.ItemsCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                }

                if (obj.ItemsSubCategoryID != null)
                {
                    strSql += " AND ITEMS_SUB_CATEGORY_ID=:P_ITEMS_SUB_CAT_ID";
                    paramArray.Add(Utilities.GetOraParam(":P_ITEMS_SUB_CAT_ID", obj.ItemsSubCategoryID, OracleDbType.Int64, ParameterDirection.Input));
                }
                if (obj.Quantity != null)
                {
                    strSql += " AND QUANTITY>:P_QUANTITY";
                    paramArray.Add(Utilities.GetOraParam(":P_QUANTITY", obj.Quantity, OracleDbType.Int64, ParameterDirection.Input));
                }
                return SqlHelper.ExecuteDataset(CommandType.Text, strSql, Module.OAS, paramArray.ToArray()).Tables[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
